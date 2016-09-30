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
using System.Linq;

namespace ConsultationManagerClient.ViewModels.RDVs
{
    internal class ListRvdViewModel : INotifyPropertyChanged
    {
        private RdvServiceClient rsc = new RdvServiceClient();

        private ObservableCollection<RdvDetail> listAllRvd;
        private ObservableCollection<RdvDetail> listServiceRvd;
        private ObservableCollection<RdvDetail> listPasseRvd;
        private ObservableCollection<RdvDetail> listRateRvd;
        private ObservableCollection<RdvDetail> listMyTodayRvd;
        private ObservableCollection<RdvDetail> listFirstRvd;
        private ObservableCollection<RdvDetail> listHospitRvd;
        private ObservableCollection<RdvDetail> listFuturRdv;
        
        private InterviewWindow dialogConsultation;
        private FirstInterviewWindow dialogFirstInterview;
        private FirstInterviewExamenWindow dialogFirstRdvExamenView;
        private InterviewConclusionWindow dialogConsltConclusion;
        private NextRdvWindow nextRdvWindow;
        
        private DossierMedServiceClient psc = new DossierMedServiceClient();
        private DossierMedicalWindow dialoDossierMedical;
        private DossierMedDetail selectedDossier;

        private ObservableCollection<GridRdvData> listRdvGrid;

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

            listAllRvd = new ObservableCollection<RdvDetail>(rsc.GetAllRdv(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            listServiceRvd = CreateListServiceRdv();
            listPasseRvd = CreateListPasseRdv();
            listRateRvd = CreateListRateRdv();
            listMyTodayRvd = CreateListMyTodayRdv();
            listFirstRvd = CreateListFirstRdv();
            listHospitRvd = CreateListHospitRdv();
            listFuturRdv = CreateListFuturRdv();

            listRdvGrid = CreateListServiceGrid();

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

        public ObservableCollection<RdvDetail> ListAllRvd
        {
            get
            {
                return listAllRvd;
            }
        }
        public ObservableCollection<RdvDetail> ListServiceRvd
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
        public ObservableCollection<RdvDetail> ListPasseRvd
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
        public ObservableCollection<RdvDetail> ListRateRvd
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
        public ObservableCollection<RdvDetail> ListMyTodayRvd
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
        public ObservableCollection<RdvDetail> ListFirstRvd
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
        public ObservableCollection<RdvDetail> ListHospitRvd
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
        public ObservableCollection<RdvDetail> ListFuturRdv
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

        public ObservableCollection<GridRdvData> ListRdvGrid
        {
            get
            {
                return listRdvGrid;
            }
            set
            {
                listRdvGrid = value;
                OnPropertyChanged("ListRdvGrid");
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
            var rdv = selectedRdv as RdvDetail;
            nextRdvWindow = new NextRdvWindow();
            nextRdvWindow.DataContext = new NextRdvViewModel(selectedRdv as RdvDetail, this);
            nextRdvWindow.ShowDialog();
        }

        public void ShowDialogConsult(object selectedRdv)
        {
            var rdv = selectedRdv as RdvDetail;
            //Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.DateRdv);
            dialogConsultation = new InterviewWindow();
            dialogConsultation.DataContext = new InterviewViewModel(rdv, this);
            dialogConsultation.ShowDialog();
        }

        public void ShowDialogFirstConsult(object selectedRdv)
        {
            var rdv = selectedRdv as RdvDetail;
            Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.Rdv.DateRdv);
            dialogFirstInterview = new FirstInterviewWindow();
            dialogFirstInterview.DataContext = new FirstInterviewViewModel(rdv, this);
            dialogFirstInterview.ShowDialog();
        }

        private void ShowDialogDossierMedical(object param)
        {
            RdvDetail selRdv = param as RdvDetail;
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
            var rdv = selectedRdv as RdvDetail;
            this.listPasseRvd.Remove(rdv);
        }

        private ObservableCollection<RdvDetail> CreateListServiceRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
            {
                if (!element.Rdv.DejaFait)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvDetail> CreateListPasseRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id 
                    && element.Rdv.DejaFait)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<RdvDetail> CreateListRateRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
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
        private ObservableCollection<RdvDetail> CreateListMyTodayRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
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
        private ObservableCollection<RdvDetail> CreateListFirstRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
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
        private ObservableCollection<RdvDetail> CreateListHospitRdv()
        {
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
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
        private ObservableCollection<RdvDetail> CreateListFuturRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvDetail> allMyList = new ObservableCollection<RdvDetail>();
            foreach (RdvDetail element in listAllRvd)
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

        private ObservableCollection<GridRdvData> CreateListServiceGrid()
        {
            ObservableCollection<GridRdvData> list = new ObservableCollection<GridRdvData>();
            GridRdvData data;

            if (AuthenticationViewModel.AuthenticatedUser.Role == "Chef Service" || AuthenticationViewModel.AuthenticatedUser.Role == "Assistant")
            {
                foreach (RdvDetail element in listServiceRvd)
                {
                    if(element.Rdv.PathologieId == AuthenticationViewModel.AuthenticatedUser.PathologieId)
                    {
                        data = new GridRdvData();
                        data.Date = element.Rdv.DateRdv.Year + "-" + element.Rdv.DateRdv.Month + "-" + element.Rdv.DateRdv.Day;
                        data.Position = element.Rdv.Rang;
                        data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                        data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                        data.Medecin = element.Medecin.Nom + "  " + element.Medecin.Prenom;
                        data.Consultation = element.Consultation.Nom;
                        data.Adresse = element.Patient.Adresse;
                        data.Telephone = element.Patient.Telephones.First();
                        data.CreerDans = element.Patient.CreeDans.ToString();
                        list.Add(data);

                    }
                }
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Médecin")
            {
                foreach (RdvDetail element in listMyTodayRvd)
                {
                    data = new GridRdvData();
                    data.Date = element.Rdv.DateRdv.Year + "-" + element.Rdv.DateRdv.Month + "-" + element.Rdv.DateRdv.Day;
                    data.Position = element.Rdv.Rang;
                    data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                    data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                    data.Medecin = element.Medecin.Nom + "  " + element.Medecin.Prenom;
                    data.Consultation = element.Consultation.Nom;
                    data.Adresse = element.Patient.Adresse;
                    data.Telephone = element.Patient.Telephones.First();
                    data.CreerDans = element.Patient.CreeDans.ToString();
                    list.Add(data);
                }
                foreach (RdvDetail element in listFuturRdv)
                {
                    data = new GridRdvData();
                    data.Date = element.Rdv.DateRdv.Year + "-" + element.Rdv.DateRdv.Month + "-" + element.Rdv.DateRdv.Day;
                    data.Position = element.Rdv.Rang;
                    data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                    data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                    data.Medecin = element.Medecin.Nom + "  " + element.Medecin.Prenom;
                    data.Consultation = element.Consultation.Nom;
                    data.Adresse = element.Patient.Adresse;
                    data.Telephone = element.Patient.Telephones.First();
                    data.CreerDans = element.Patient.CreeDans.ToString();
                    list.Add(data);
                }
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Administrateur")
            {
                foreach (RdvDetail element in listServiceRvd)
                {
                    data = new GridRdvData();
                    data.Date = element.Rdv.DateRdv.Year + "-" + element.Rdv.DateRdv.Month + "-" + element.Rdv.DateRdv.Day;
                    data.Position = element.Rdv.Rang;
                    data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                    data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                    data.Medecin = element.Medecin.Nom + "  " + element.Medecin.Prenom;
                    data.Consultation = element.Consultation.Nom;
                    data.Adresse = element.Patient.Adresse;
                    data.Telephone = element.Patient.Telephones.First();
                    data.CreerDans = element.Patient.CreeDans.ToString();
                    list.Add(data);
                }
            }
            return list;
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

    public class GridRdvData
    {
        public string Date { get; set; }
        public int Position { get; set; }
        public string Patient { get; set; }
        public string DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string CreerDans { get; set; }
        public string Medecin { get; set; }
        public string Consultation { get; set; }
    }
}
