using System;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.Views.RDVs;
using ConsultationManagerClient.Views.Interviews;
using ConsultationManagerClient.ViewModels.Interviews;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManager.ServiceReferenceRdv;
using System.ServiceModel.Security;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManager.Views.Interviews;
using ConsultationManager.Views.RDVs;
using System.Windows;
using ConsultationManager.Views.DossierMedicals;
using ConsultationManager.ServiceReferenceDossierMed;
using ConsultationManager.ViewModels.RDVs;
using ConsultationManager.ViewModels.DossierMedicals;

namespace ConsultationManagerClient.ViewModels.RDVs
{
    internal class ListRvdViewModel : INotifyPropertyChanged
    {
        private RdvServiceClient rsc = new RdvServiceClient();

        private ObservableCollection<RdvPatientMedecin> listAllRvd;
        private ObservableCollection<RdvPatientMedecin> listServiceRvd;
        private ObservableCollection<RdvPatientMedecin> listPasseRvd;
        private ObservableCollection<RdvPatientMedecin> listRateRvd;
        private ObservableCollection<RdvPatientMedecin> listMyTodayRvd;
        private ObservableCollection<RdvPatientMedecin> listFirstRvd;
        private ObservableCollection<RdvPatientMedecin> listHospitRvd;
        private ObservableCollection<RdvPatientMedecin> listFuturRdv;

        private UpdateRdvWindow dialogUpdate;
        private InterviewWindow dialogConsultation;
        private FirstInterviewWindow dialogFirstInterview;
        private FirstInterviewExamenWindow dialogFirstRdvExamenView;
        private InterviewConclusionWindow dialogConsltConclusion;
        private NextRdvWindow nextRdvWindow;
        
        private DossierMedServiceClient psc = new DossierMedServiceClient();
        private DossierMedicalWindow dialoDossierMedical;
        private DossierMedDetail selectedDossier;

        private string nomUtilisateur;

        public ListRvdViewModel()
        {
            rsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            rsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            rsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listAllRvd = new ObservableCollection<RdvPatientMedecin>(rsc.GetAllRdv(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            listServiceRvd = CreateListServiceRdv();
            listPasseRvd = CreateListPasseRdv();
            listRateRvd = CreateListRateRdv();
            listMyTodayRvd = CreateListMyTodayRdv();
            listFirstRvd = CreateListFirstRdv();
            listHospitRvd = CreateListHospitRdv();
            listFuturRdv = CreateListFuturRdv();

            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            //RunDialogCommand = new RunDialogUpdateRdvCommand(this);
            ReschedRdvDialogCommand = new RelayCommand(param => this.ShowDialogUpdateRvd(param));
            ConsultationDialogCommand = new RelayCommand(param => this.ShowDialogConsult(param));
            FirstRdvDialogCommand = new RelayCommand(param => this.ShowDialogFirstConsult(param));

            RemoveSelectedRdvCommand = new RelayCommand(param => this.Delete(param));

            OpenDialogMedFolderCommand = new RelayCommand(param => ShowDialogDossierMedical(param));
            //AddNextRdvCommand = new RelayCommand(param => this.AddNextRvd());
            CancelCommand = new RelayCommand(o => ((Window)o).Close());
        }
        #region ListRvdViewModel Variables

        public ObservableCollection<RdvPatientMedecin> ListAllRvd
        {
            get
            {
                return listAllRvd;
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListServiceRvd
        {
            get
            {
                return listServiceRvd;
            }
            set
            {
                listServiceRvd = value;
                OnPropertyChanged("ListServiceRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListPasseRvd
        {
            get
            {
                return listPasseRvd;
            }
            set
            {
                listPasseRvd = value;
                OnPropertyChanged("ListAllPasseRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListRateRvd
        {
            get
            {
                return listRateRvd;
            }
            set
            {
                listRateRvd = value;
                OnPropertyChanged("ListRateRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListMyTodayRvd
        {
            get
            {
                return listMyTodayRvd;
            }
            set
            {
                listMyTodayRvd = value;
                OnPropertyChanged("ListMyTodayRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListFirstRvd
        {
            get
            {
                return listFirstRvd;
            }
            set
            {
                listFirstRvd = value;
                OnPropertyChanged("ListFirstRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListHospitRvd
        {
            get
            {
                return listHospitRvd;
            }
            set
            {
                listHospitRvd = value;
                OnPropertyChanged("ListHospitRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListFuturRdv
        {
            get
            {
                return listFuturRdv;
            }
            set
            {
                listFuturRdv = value;
                OnPropertyChanged("ListFuturRdv");
            }
        }

        public UpdateRdvWindow DialogUpdateView
        {
            get
            {
                return dialogUpdate;
            }
        }
        public InterviewWindow DialogInterviewView
        {
            get
            {
                return dialogConsultation;
            }
        }
        public FirstInterviewWindow DialogFirstInterviewView
        {
            get
            {
                return dialogFirstInterview;
            }
        }
        public FirstInterviewExamenWindow DialogFirstRdvExamenView
        {
            get
            {
                return dialogFirstRdvExamenView;
            }
            set
            {
                dialogFirstRdvExamenView = value;
            }
        }
        public InterviewConclusionWindow DialogInterwiewConclusionView
        {
            get
            {
                return dialogConsltConclusion;
            }
            set
            {
                dialogConsltConclusion = value;
            }
        }
        public NextRdvWindow NextRdvWindow
        {
            get
            {
                return nextRdvWindow;
            }
            set
            {
                nextRdvWindow = value;
            }
        }
        
        public DossierMedDetail SelectedDossier
        {
            get
            {
                return selectedDossier;
            }
            set
            {
                selectedDossier = value;
                OnPropertyChanged("SelectedDossier");
            }
        }

        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        #endregion

        #region ListRvdViewModel Commands

        public ICommand ReschedRdvDialogCommand
        {
            get;
            private set;
        }

        public ICommand ConsultationDialogCommand
        {
            get;
            private set;
        }

        public ICommand FirstRdvDialogCommand
        {
            get;
            private set;
        }

        public ICommand RemoveSelectedRdvCommand
        {
            get;
            private set;
        }

        //public ICommand AddNextRdvCommand
        //{
        //    get;
        //    private set;
        //}

        public ICommand CancelCommand
        {
            get;
            private set;
        }
        public ICommand OpenDialogMedFolderCommand
        {
            get;
            private set;
        }

        #endregion

        #region ListRvdViewModel Methodes

        public void ShowDialogUpdateRvd(object selectedRdv)
        {
            var rdv = selectedRdv as RdvPatientMedecin;
            nextRdvWindow = new NextRdvWindow();
            nextRdvWindow.DataContext = new NextRdvViewModel(selectedRdv as RdvPatientMedecin, this);
            nextRdvWindow.ShowDialog();
        }

        public void ShowDialogConsult(object selectedRdv)
        {
            var rdv = selectedRdv as RdvPatientMedecin;
            //Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.DateRdv);
            dialogConsultation = new InterviewWindow();
            dialogConsultation.DataContext = new InterviewViewModel(rdv, this);
            dialogConsultation.ShowDialog();
        }

        public void ShowDialogFirstConsult(object selectedRdv)
        {
            var rdv = selectedRdv as RdvPatientMedecin;
            Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.Rdv.DateRdv);
            dialogFirstInterview = new FirstInterviewWindow();
            dialogFirstInterview.DataContext = new FirstInterviewViewModel(rdv, this);
            dialogFirstInterview.ShowDialog();
        }

        public void CloseDialogUpdateRvd(RdvPatientMedecin updRdv)
        {
            Console.WriteLine("ListRvdViewModel : Dialog closed with updated RDV  " + updRdv.Rdv.DateRdv);
            dialogUpdate.Close();
        }

        private void ShowDialogDossierMedical(object param)
        {
            RdvPatientMedecin selRdv = param as RdvPatientMedecin;
            SelectedDossier = psc.GetDossierMed(selRdv.Patient.Id);
            dialoDossierMedical = new DossierMedicalWindow();
            //dialoDossierMedical.DataContext = this;

            dialoDossierMedical.DataContext = new DossierMedViewModel(SelectedDossier);
            //newPathologie = new Consultation();
            //AddPathologieCommand = new RelayCommand(param => AjouterPathologie());
            dialoDossierMedical.ShowDialog();
        }

        public void Delete(object selectedRdv)
        {
            Console.WriteLine("ListRvdViewModel : Remove RDV  " );
            var rdv = selectedRdv as RdvPatientMedecin;
            this.listPasseRvd.Remove(rdv);
        }

        private ObservableCollection<RdvPatientMedecin> CreateListServiceRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (!element.Rdv.DejaFait)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvPatientMedecin> CreateListPasseRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id 
                    && element.Rdv.DejaFait)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvPatientMedecin> CreateListRateRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id 
                    && !element.Rdv.DejaFait 
                    && element.Rdv.DateRdv.Date.CompareTo(DateTime.Now.Date) < 0
                    && element.Rdv.DateRdv.Date.CompareTo(new DateTime(1, 1, 1)) != 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvPatientMedecin> CreateListMyTodayRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if(AuthenticationViewModel.AuthenticatedUser.Role == "Assistant")
                {
                    if (element.Rdv.PathologieId == AuthenticationViewModel.AuthenticatedUser.PathologieId
                        && !element.Rdv.NouvPat
                        && !element.Rdv.DejaFait
                        && element.Rdv.DateRdv.Date.CompareTo(DateTime.Now.Date) == 0)
                    {
                        allMyList.Add(element);
                    }
                }
                else
                    if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id 
                        && !element.Rdv.NouvPat 
                        && !element.Rdv.DejaFait
                        && element.Rdv.DateRdv.Date.CompareTo(DateTime.Now.Date) == 0)
                    {
                        allMyList.Add(element);
                    }
            }
            return allMyList;
        }
        private ObservableCollection<RdvPatientMedecin> CreateListFirstRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id
                    && element.Rdv.NouvPat
                    && !element.Rdv.DejaFait
                    && element.Rdv.DateRdv.Date.CompareTo(DateTime.Now.Date) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvPatientMedecin> CreateListHospitRdv()
        {
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id
                    && !element.Rdv.DejaFait
                    && element.Rdv.DateRdv.Date.CompareTo(new DateTime(1, 1, 1)) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvPatientMedecin> CreateListFuturRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id
                    && !element.Rdv.DejaFait
                    && element.Rdv.DateRdv.Date.CompareTo(DateTime.Now.Date) > 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        public void ActualiserLists()
        {
            ListServiceRvd = CreateListServiceRdv();
            ListPasseRvd = CreateListPasseRdv();
            ListRateRvd = CreateListRateRdv();
            ListMyTodayRvd = CreateListMyTodayRdv();
            ListFirstRvd = CreateListFirstRdv();
            ListHospitRvd = CreateListHospitRdv();
            ListFuturRdv = CreateListFuturRdv();
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
