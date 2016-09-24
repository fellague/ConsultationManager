using System;
using System.Linq;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.ViewModels.RDVs;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ConsultationManagerClient.Views.Interviews;
using ConsultationManagerClient.Commands;
using System.ComponentModel;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManager.Views.RDVs;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManager.ServiceReferenceConclusion;
using System.ServiceModel.Security;
using ConsultationManager.ViewModels.RDVs;
using ConsultationManager.Views.Hospitalisations;
using ConsultationManagerServer.Models.Hospitalisations;
using System.Windows;

namespace ConsultationManagerClient.ViewModels.Interviews
{
    internal class InterviewConclusionViewModel : INotifyPropertyChanged
    {
        private ConclusionServiceClient csc = new ConclusionServiceClient();

        private RdvPatientMedecin rdvConsult;
        private ListRvdViewModel rdvsViewModel;
        private Interview interview;

        private Conclusion intervConclus;

        private NewMedicamentWindow dialogNewMedicament;
        private Medicament newMedicament;

        private NewTraitemComplWindow dialogNewTraitement;
        private Traitement newTraitement;

        private NewDemandeHospitWindow dialogNewDemandeHospit;
        private DemandeHospit newDemandeHospit;
        private ObservableCollection<int> listNbJours;

        private LettreOrientation lettreOrientation;

        private string newConseil;

        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;
        private ObservableCollection<int> listNbFois;
        

        public InterviewConclusionViewModel(RdvPatientMedecin rdv, Interview interv, ListRvdViewModel rdvVM)
        {
            csc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            csc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            csc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            this.rdvConsult = rdv;
            if(interv != null)
                interview = interv;
            else
            {
                interview = new Interview();
                interview.Numero = 1;
            }
            rdvsViewModel = rdvVM;

            intervConclus = new Conclusion();
            intervConclus.Numero = interview.Numero;

            CancelCommand = new RelayCommand(o => ((Window)o).Close());

            NewMedicamentDialogCommand = new RelayCommand(param => ShowDialogNewMedicament());
            RemoveMedicamentCommand = new RelayCommand(param => DeleteMedicament(param));

            NewTraitementDialogCommand = new RelayCommand(param => ShowDialogNewTraitement());
            RemoveTraitementCommand = new RelayCommand(param => DeleteTraitement(param));

            lettreOrientation = new LettreOrientation("", "", "");

            newConseil = "";
            AddConseilCommand = new RelayCommand(param => AjouterConseil());
            RemoveConseilCommand = new RelayCommand(param => DeleteConseil(param));

            ShowDialogNextRdvCommand = new RelayCommand(param => ShowDialogNextRdv(param));
            ShowDialogDemandeHospCommand = new RelayCommand(param => ShowDialogDemandeHospit(param));
            AddDemandeHospCommand = new RelayCommand(param => AjouterDemandeHospit());
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

        public Conclusion IntervConclus
        {
            get
            {
                return intervConclus;
            }
        }

        public Medicament NewMedicament
        {
            get
            {
                return newMedicament;
            }
        }

        public Traitement NewTraitement
        {
            get
            {
                return newTraitement;
            }
        }

        public LettreOrientation LettreOrientation
        {
            get
            {
                return lettreOrientation;
            }
        }

        public string NewConseil
        {
            get
            {
                return newConseil;
            }
            set
            {
                newConseil = value;
                OnPropertyChanged("NewConseil");
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
        public ObservableCollection<int> ListNbFois
        {
            get
            {
                return listNbFois;
            }
        }
        public ObservableCollection<int> ListNbJours
        {
            get
            {
                return listNbJours;
            }
        }

        public DemandeHospit NewDemandeHospit
        {
            get
            {
                return newDemandeHospit;
            }
            set
            {
                newDemandeHospit = value;
                OnPropertyChanged("NewDemandeHospit");
            }
        }

        #endregion

        #region ConsultationViewModel Commands

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        public ICommand NewMedicamentDialogCommand
        {
            get;
            private set;
        }
        public ICommand AddMedicamentCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedicamentCommand
        {
            get;
            private set;
        }

        public ICommand NewTraitementDialogCommand
        {
            get;
            private set;
        }
        public ICommand AddTraitementCommand
        {
            get;
            private set;
        }
        public ICommand RemoveTraitementCommand
        {
            get;
            private set;
        }

        public ICommand AddConseilCommand
        {
            get;
            private set;
        }
        public ICommand RemoveConseilCommand
        {
            get;
            private set;
        }

        public ICommand PrecedentCommand
        {
            get;
            private set;
        }

        public ICommand ShowDialogNextRdvCommand
        {
            get;
            private set;
        }
        
        public ICommand ShowDialogDemandeHospCommand
        {
            get;
            private set;
        }

        public ICommand AddDemandeHospCommand
        {
            get;
            private set;
        }

        #endregion

        #region ConsultationViewModel Methods

        public void ShowDialogNewMedicament()
        {
            dialogNewMedicament = new NewMedicamentWindow();
            dialogNewMedicament.DataContext = this;
            AddMedicamentCommand = new RelayCommand(param => AjouterMedicament(param));
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            listNbFois = new ObservableCollection<int>(Enumerable.Range(1, 3));
            newMedicament = new Medicament();
            dialogNewMedicament.ShowDialog();
        }
        public void AjouterMedicament(object med)
        {
            var newMed = med as Medicament;
            dialogNewMedicament.Close();
            IntervConclus.Ordonnance.ListMedicaments.Add(newMed);
        }
        public void DeleteMedicament(object selectedMed)
        {
            var med = selectedMed as Medicament;
            IntervConclus.Ordonnance.ListMedicaments.Remove(med);
        }

        public void ShowDialogNewTraitement()
        {
            dialogNewTraitement = new NewTraitemComplWindow();
            dialogNewTraitement.DataContext = this;
            AddTraitementCommand = new RelayCommand(param => AjouterTraitement(param));
            newTraitement = new Traitement("", "");
            dialogNewTraitement.ShowDialog();
        }
        public void AjouterTraitement(object trait)
        {
            var newTrait = trait as Traitement;
            dialogNewTraitement.Close();
            IntervConclus.TraitementsCompl.ListTraitements.Add(newTrait);
        }
        public void DeleteTraitement(object selectedTrait)
        {
            var trait = selectedTrait as Traitement;
            IntervConclus.TraitementsCompl.ListTraitements.Remove(trait);
        }

        public void AjouterConseil()
        {
            if (newConseil != "")
            {
                IntervConclus.Conseils.Add(newConseil);
                NewConseil = "";
            }
                
        }
        public void DeleteConseil(object selectedConseil)
        {
            var consl = selectedConseil as string;
            IntervConclus.Conseils.Remove(consl);
        }

        private void ShowDialogNextRdv(object param)
        {
            rdvsViewModel.NextRdvWindow = new NextRdvWindow();

            rdvsViewModel.NextRdvWindow.DataContext = new NextRdvViewModel(rdvConsult, rdvsViewModel);

            if (rdvConsult.Rdv.NouvPat)
            {
                intervConclus.IdSource = "first";
            }
            else
            {
                IntervConclus.IdSource = interview.Id;
            }

            intervConclus.IdPatient = rdvConsult.Patient.Id;
            intervConclus.IdConsultation = rdvConsult.Rdv.PathologieId;
            intervConclus.IdRdv = rdvConsult.Rdv.Id;
            intervConclus.CreeDans = DateTime.Now;
            intervConclus.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            csc.AddConclusion(intervConclus);
            
            rdvsViewModel.NextRdvWindow.ShowDialog();
        }
        
        private void ShowDialogDemandeHospit(object param)
        {
            dialogNewDemandeHospit = new NewDemandeHospitWindow();
            newDemandeHospit = new DemandeHospit();
            dialogNewDemandeHospit.DataContext = this;
            
            listNbJours = new ObservableCollection<int>(Enumerable.Range(1, 30));

            dialogNewDemandeHospit.ShowDialog();
        }

        private void AjouterDemandeHospit()
        {

            if (rdvConsult.Rdv.NouvPat)
            {
                intervConclus.IdSource = "first";
            }
            else
            {
                IntervConclus.IdSource = interview.Id;
            }

            intervConclus.IdPatient = rdvConsult.Patient.Id;
            intervConclus.IdConsultation = rdvConsult.Rdv.PathologieId;
            intervConclus.IdRdv = rdvConsult.Rdv.Id;
            intervConclus.CreeDans = DateTime.Now;
            intervConclus.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

            NewDemandeHospit.IdIntervConclus = csc.AddConclusion(intervConclus).Id;

            NewDemandeHospit.IdPatient = rdvConsult.Patient.Id;
            NewDemandeHospit.IdMedecin = rdvConsult.Medecin.Id;

            NewDemandeHospit.ServiceId = rdvConsult.Rdv.ServiceId;
            NewDemandeHospit.IdRdv = rdvConsult.Rdv.Id;
            NewDemandeHospit.CreeDans = DateTime.Now;
            NewDemandeHospit.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            csc.AddDemandeHospit(NewDemandeHospit);

            dialogNewDemandeHospit.Close();
            rdvsViewModel.DialogInterwiewConclusionView.Close();

            rdvsViewModel.ListAllRvd.Remove(rdvConsult);
            rdvsViewModel.ActualiserLists();
        }
        #endregion

        #region InotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
