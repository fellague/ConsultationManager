using System;
using System.Linq;
using System.Collections.ObjectModel;
using ConsultationManagerClient.Views.Interviews;
using System.Windows.Input;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.ViewModels.RDVs;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManager.ServiceReferenceInterview;
using System.ServiceModel.Security;

namespace ConsultationManagerClient.ViewModels.Interviews
{
    internal class InterviewViewModel
    {
        private InterviewServiceClient dsc = new InterviewServiceClient();

        private RdvPatientMedecin rdvConsult;
        private ListRvdViewModel rdvsViewModel;

        private Interview interview;
        private NewAntecedPersWindow dialogNewAntecedPers;
        private NewRemarqMedWindow dialogNewRemarqMed;
        private AntecedentPersonel newAntecedPers;
        private RemarqueMedecin newRemarqMed;
        
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;

        public InterviewViewModel(RdvPatientMedecin rdv, ListRvdViewModel rdvVM)
        {
            dsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            dsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            dsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            this.rdvConsult = rdv;
            rdvsViewModel = rdvVM;
            NewAntecedPersDialogCommand = new RelayCommand(param => ShowDialogNewAntecedPers());
            NewRemarqMedDialogCommand = new RelayCommand(param => ShowDialogNewRemarqMed());
            interview = new Interview();
            RemoveAntecedPersCommand = new RelayCommand(param => DeleteAntecedPers(param));
            RemoveRemarqMedCommand = new RelayCommand(param => DeleteRemarqMed(param));
            
            SuivantCommand = new RelayCommand(param => ShowDialogConsultConclusion());
        }

        #region ConsultationViewModel Variables

        public RdvPatientMedecin RdvConsult
        {
            get
            {
                return rdvConsult;
            }
        }
        public Interview Interview
        {
            get
            {
                return interview;
            }
        }
        public NewAntecedPersWindow DialogNewAntecedPers
        {
            get
            {
                return dialogNewAntecedPers;
            }
        }
        public NewRemarqMedWindow DialogNewRemarqMed
        {
            get
            {
                return dialogNewRemarqMed;
            }
        }
        public AntecedentPersonel NewAntecedPers
        {
            get
            {
                return newAntecedPers;
            }
        }
        public RemarqueMedecin NewRemarqMed
        {
            get
            {
                return newRemarqMed;
            }
        }
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

        #region ConsultationViewModel Commands

        public ICommand NewAntecedPersDialogCommand
        {
            get;
            private set;
        }
        public ICommand NewRemarqMedDialogCommand
        {
            get;
            private set;
        }

        public ICommand AddAntecedPersCommand
        {
            get;
            private set;
        }
        public ICommand AddRemarqMedCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedPersCommand
        {
            get;
            private set;
        }
        public ICommand RemoveRemarqMedCommand
        {
            get;
            private set;
        }
        public ICommand SuivantCommand
        {
            get;
            private set;
        }

        #endregion

        #region ConsultationViewModel Methods

        public void ShowDialogNewAntecedPers()
        {
            Console.WriteLine("ConsultationViewModel : Dialog Antecedent Personnel opened with RDV  ");
            dialogNewAntecedPers = new NewAntecedPersWindow();
            dialogNewAntecedPers.DataContext = this;
            AddAntecedPersCommand = new RelayCommand(param => AjouterAntecedPers(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedPers = new AntecedentPersonel("", 0, 0, "");
            dialogNewAntecedPers.ShowDialog();
        }
        public void ShowDialogNewRemarqMed()
        {
            Console.WriteLine("ConsultationViewModel : Dialog Remarque Medecin opened with RDV  ");
            dialogNewRemarqMed = new NewRemarqMedWindow();
            dialogNewRemarqMed.DataContext = this;
            AddRemarqMedCommand = new RelayCommand(param => AjouterRemarqMed(param));
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newRemarqMed = new RemarqueMedecin("", "");
            dialogNewRemarqMed.ShowDialog();
        }

        public void AjouterAntecedPers(object ant)
        {
            var newAnteced = ant as AntecedentPersonel;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newAnteced.Organe);
            dialogNewAntecedPers.Close();
            interview.CommentsPatient.Add(newAnteced);
        }
        public void AjouterRemarqMed(object ant)
        {
            var newAnteced = ant as RemarqueMedecin;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newAnteced.Organe);
            dialogNewRemarqMed.Close();
            interview.RemarquesMedecin.Add(newRemarqMed);
        }
        public void DeleteAntecedPers(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as AntecedentPersonel;
            interview.CommentsPatient.Remove(ant);
        }
        public void DeleteRemarqMed(object selectedRem)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var rem = selectedRem as RemarqueMedecin;
            interview.RemarquesMedecin.Remove(rem);
        }

        public void ShowDialogConsultConclusion()
        {
            //rdvsViewModel.ShowDialogConsultConclusion(rdvConsult, interview);
            Interview.IdPatient = rdvConsult.Patient.Id;
            Interview.IdMedecin = rdvConsult.Medecin.Id;
            Interview.IdRdv = rdvConsult.Rdv.Id;
            Interview.CreeDans = DateTime.Now;
            Interview.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

            interview = dsc.AddInterview(Interview);

            rdvsViewModel.DialogInterwiewConclusionView = new InterviewConclusionWindow();
            rdvsViewModel.DialogInterwiewConclusionView.DataContext = new InterviewConclusionViewModel(rdvConsult, interview, rdvsViewModel);
            rdvsViewModel.DialogInterwiewConclusionView.ShowDialog();
        }

        #endregion
    }
}
