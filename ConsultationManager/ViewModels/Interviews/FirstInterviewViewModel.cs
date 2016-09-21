using System;
using System.Linq;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.Views.Interviews;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManagerClient.ViewModels.RDVs;
using ConsultationManager.Views.Interviews;
using System.Windows;
using ConsultationManager.ServiceReferenceDossierMed;
using ConsultationManagerClient.ViewModels.Authentication;
using System.ServiceModel.Security;

namespace ConsultationManagerClient.ViewModels.Interviews
{
    internal class FirstInterviewViewModel
    {
        private DossierMedServiceClient dsc = new DossierMedServiceClient();

        private ListRvdViewModel listRdvVM;
        private RdvPatientMedecin rdvConsult;
        private DossierMed dossier;
        private NewAntecedPersWindow dialogNewAntecedPers;
        private NewAntecedFamilWindow dialogNewAntecedFamil;
        private AntecedentPersonel newAntecedPers;
        private AntecedentFamilial newAntecedFamil;
        //private ObservableCollection<AntecedentPersonel> listAntecedentPersonel;
        //private ObservableCollection<AntecedentFamilial> listAntecedentFamilial;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;

        public FirstInterviewViewModel(RdvPatientMedecin rdv, ListRvdViewModel rdvsVM)
        {
            dsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            dsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            dsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            rdvConsult = rdv;
            dossier = new DossierMed();

            listRdvVM = rdvsVM;

            CancelCommand = new RelayCommand(o => ((Window)o).Close());

            NewAntecedPersDialogCommand = new RelayCommand(param=>ShowDialogNewAntecedPers());
            NewAntecedFamilDialogCommand = new RelayCommand(param => ShowDialogNewAntecedFamil());
            //listAntecedentPersonel = new ObservableCollection<AntecedentPersonel>();
            //listAntecedentFamilial = new ObservableCollection<AntecedentFamilial>();
            RemoveAntecedPersCommand = new RelayCommand(param => DeleteAntecedPers(param));
            RemoveAntecedFamilCommand = new RelayCommand(param => DeleteAntecedFamil(param));

            ShowExamenWindowCommand = new RelayCommand(param => AfficherExamenWindow());
            ShowConsultConclusWindowCommand = new RelayCommand(param => AfficherConclusionWindow());
        }




        #region FirstConsultationViewModel Variables

        public RdvPatientMedecin RdvConsult
        {
            get
            {
                return rdvConsult;
            }
        }
        public DossierMed Dossier
        {
            get
            {
                return dossier;
            }
        }
        public NewAntecedPersWindow DialogNewAntecedPers
        {
            get
            {
                return dialogNewAntecedPers;
            }
        }
        public NewAntecedFamilWindow DialogNewAntecedFamil
        {
            get
            {
                return dialogNewAntecedFamil;
            }
        }
        public AntecedentPersonel NewAntecedPers
        {
            get
            {
                return newAntecedPers;
            }
        }
        public AntecedentFamilial NewAntecedFamil
        {
            get
            {
                return newAntecedFamil;
            }
        }
        //public ObservableCollection<AntecedentPersonel> ListAntecedentPersonel
        //{
        //    get
        //    {
        //        return listAntecedentPersonel;
        //    }
        //}
        //public ObservableCollection<AntecedentFamilial> ListAntecedentFamilal
        //{
        //    get
        //    {
        //        return listAntecedentFamilial;
        //    }
        //}
        public ObservableCollection<int> ListMois
        {
            get
            {
                return listMois;
            }
        }
        public ObservableCollection<int> ListJours
        {
            get
            {
                return listJours;
            }
        }

        #endregion

        #region FirstConsultationViewModel Commands

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        public ICommand NewAntecedPersDialogCommand
        {
            get;
            private set;
        }
        public ICommand NewAntecedFamilDialogCommand
        {
            get;
            private set;
        }

        public ICommand AddAntecedPersCommand
        {
            get;
            private set;
        }
        public ICommand AddAntecedFamilCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedPersCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedFamilCommand
        {
            get;
            private set;
        }

        public ICommand ShowExamenWindowCommand
        {
            get;
            private set;
        }

        public ICommand ShowConsultConclusWindowCommand
        {
            get;
            private set;
        }

        #endregion

        #region FirstConsultationViewModel Methods

        public void ShowDialogNewAntecedPers()
        {
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
            dialogNewAntecedPers = new NewAntecedPersWindow();
            dialogNewAntecedPers.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
            AddAntecedPersCommand = new RelayCommand(param => AjouterAntecedPers(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedPers = new AntecedentPersonel("", 0, 0, "");
            dialogNewAntecedPers.ShowDialog();
        }
        public void ShowDialogNewAntecedFamil()
        {
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
            dialogNewAntecedFamil = new NewAntecedFamilWindow();
            dialogNewAntecedFamil.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
            AddAntecedFamilCommand = new RelayCommand(param => AjouterAntecedFamil(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedFamil = new AntecedentFamilial("", "");
            dialogNewAntecedFamil.ShowDialog();
        }

        public void AjouterAntecedPers(object ant)
        {
            var newAnteced = ant as AntecedentPersonel;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  "+newAnteced.Organe);
            dialogNewAntecedPers.Close();
            dossier.AntecedPers.Add(newAnteced);
            //dialogNewAntecedent.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
        }
        public void AjouterAntecedFamil(object ant)
        {
            var newAnteced = ant as AntecedentFamilial;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newAnteced.Membre);
            dialogNewAntecedFamil.Close();
            dossier.AntecedFamil.Add(newAnteced);
            //dialogNewAntecedent.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
        }
        public void DeleteAntecedPers(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as AntecedentPersonel;
            dossier.AntecedPers.Remove(ant);
        }
        public void DeleteAntecedFamil(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as AntecedentFamilial;
            dossier.AntecedFamil.Remove(ant);
        }

        private void AfficherExamenWindow()
        {
            listRdvVM.DialogFirstInterviewView.Close();
            listRdvVM.DialogFirstRdvExamenView = new FirstInterviewExamenWindow();
            listRdvVM.DialogFirstRdvExamenView.DataContext = this;
            listRdvVM.DialogFirstRdvExamenView.ShowDialog();
        }
        
        private void AfficherConclusionWindow()
        {
            //listRdvVM.DialogFirstRdvExamenView.Close();

            dossier.Identifiant = "HDJ/"+"0001"+"/"+DateTime.Now.Year;
            dossier.IdPatient = rdvConsult.Patient.Id;
            dossier.IdMedecin = rdvConsult.Medecin.Id;
            dossier.ServiceId = rdvConsult.Medecin.ServiceId;
            dossier.PathologieId = rdvConsult.Medecin.PathologieId;
            dossier.CreeDans = DateTime.Now;
            dossier.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

            
            //dsc.AddDossierMed(dossier);
            MessageBox.Show("Un Nouveau Dossier Médical est Creé avec l'Identifiant" + dsc.GetDossierMedNum(rdvConsult));


            //listRdvVM.DialogInterwiewConclusionView = new InterviewConclusionWindow();
            //listRdvVM.DialogInterwiewConclusionView.DataContext = new InterviewConclusionViewModel(rdvConsult, null,listRdvVM);
            //listRdvVM.DialogInterwiewConclusionView.ShowDialog();
        }

        #endregion
    }
}
