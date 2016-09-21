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

namespace ConsultationManagerClient.ViewModels.RDVs
{
    internal class ListRvdViewModel : INotifyPropertyChanged
    {
        private RdvServiceClient rsc = new RdvServiceClient();

        private ObservableCollection<RdvPatientMedecin> listAllRvd;
        private ObservableCollection<RdvPatientMedecin> listAllMyRvd;
        private ObservableCollection<RdvPatientMedecin> listAllMyTodayRvd;
        private ObservableCollection<RdvPatientMedecin> listAllFirstRvd;
        //private RDV selectedRDV = null;
        private UpdateRdvWindow dialogUpdate;
        private InterviewWindow dialogConsultation;
        private FirstInterviewWindow dialogFirstInterview;
        private FirstInterviewExamenWindow dialogFirstRdvExamenView;
        private InterviewConclusionWindow dialogConsltConclusion;
        private NextRdvWindow nextRdvWindow;

        private string nomUtilisateur;

        public ListRvdViewModel()
        {
            rsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            rsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            rsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listAllRvd = GetRDVs();
            listAllMyRvd = CreateListAllMyRdv();
            listAllMyTodayRvd = CreateListAllMyTodayRdv();
            listAllFirstRvd = CreateListAllFirstRdv();
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            //RunDialogCommand = new RunDialogUpdateRdvCommand(this);
            UpdateRdvDialogCommand = new RelayCommand(param => this.ShowDialogUpdateRvd(param));
            ConsultationDialogCommand = new RelayCommand(param => this.ShowDialogConsult(param));
            FirstRdvDialogCommand = new RelayCommand(param => this.ShowDialogFirstConsult(param));

            RemoveSelectedRdvCommand = new RelayCommand(param => this.Delete(param));

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
        public ObservableCollection<RdvPatientMedecin> ListAllMyRvd
        {
            get
            {
                return listAllMyRvd;
            }
            set
            {
                listAllMyRvd = value;
                OnPropertyChanged("ListAllMyRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListAllMyTodayRvd
        {
            get
            {
                return listAllMyTodayRvd;
            }
            set
            {
                listAllMyTodayRvd = value;
                OnPropertyChanged("ListAllMyTodayRvd");
            }
        }
        public ObservableCollection<RdvPatientMedecin> ListAllFirstRvd
        {
            get
            {
                return listAllFirstRvd;
            }
            set
            {
                listAllFirstRvd = value;
                OnPropertyChanged("ListAllFirstRvd");
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

        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        #endregion

        #region ListRvdViewModel Commands

        public ICommand UpdateRdvDialogCommand
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

        #endregion

        #region ListRvdViewModel Methodes

        public void ShowDialogUpdateRvd(object selectedRdv)
        {
            var rdv = selectedRdv as RdvPatientMedecin;
            //Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.Rdv.DateRdv);
            dialogUpdate = new UpdateRdvWindow();
            dialogUpdate.DataContext = new UpdateRdvViewModel(rdv, this);
            dialogUpdate.ShowDialog();
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

        //public void AddNextRvd()
        //{
        //    nextRdvWindow.Close();
        //}

        public void Delete(object selectedRdv)
        {
            Console.WriteLine("ListRvdViewModel : Remove RDV  " );
            var rdv = selectedRdv as RdvPatientMedecin;
            this.listAllMyRvd.Remove(rdv);
        }

        private ObservableCollection<RdvPatientMedecin> GetRDVs()
        {
            ObservableCollection<RdvPatientMedecin> list = new ObservableCollection<RdvPatientMedecin>();
            list = new ObservableCollection<RdvPatientMedecin>(rsc.GetAllRdv(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            //list.Add(new RDV("Nick", "White", "mokrane", "fatiha", new DateTime(2016, 10, 13), 1, DateTime.Today, "tebibell saliha"));
            //list.Add(new RDV("Jack", "Rodman", "bellal", "kader", new DateTime(2017, 3, 23), 1, new DateTime(2016, 5, 10), "mokrane fatiha"));
            //list.Add(new RDV("Sandra", "Sherry", "fellague", "halim", new DateTime(2016, 11, 10), 1, new DateTime(2008, 12, 22), "bellal kader"));
            //list.Add(new RDV("Sabrina", "Vilk", "mokrane", "fatiha", new DateTime(2016, 10, 13), 2, DateTime.Today, "fellague halim"));
            //list.Add(new RDV("Mike", "Pearson", "bellal", "kader", new DateTime(2016, 12, 30), 3, new DateTime(2008, 10, 18), "bennouna el khebith"));
            //list.Add(new RDV("Bill", "Watson", "fellague", "halim", new DateTime(2017, 4, 20), 1, new DateTime(2016, 1, 18), "fellague halim"));
            //list.Add(new RDV("Christiano", "Ronaldo", "bellal", "kader", new DateTime(2017, 3, 10), 1, new DateTime(2014, 7, 10), "bennouna el khebith"));
            //list.Add(new RDV("Maria", "Klara", "mokrane", "fatiha", new DateTime(2016, 10, 13), 4, new DateTime(2012, 2, 20), "bellal kader"));
            //list.Add(new RDV("Amaouri", "Benjamen", "mokrane", "fatiha", new DateTime(2017, 1, 1), 5, new DateTime(2003, 7, 1), "fellague halim"));
            //list.Add(new RDV("Bouraoui", "ElMerioul", "fellague", "halim", new DateTime(2017, 6, 12), 6, DateTime.Today, "tebibell saliha"));
            //list.Add(new RDV("Henni", "El Alia", "mokrane", "fatiha", new DateTime(2016, 10, 13), 8, new DateTime(2005, 10, 18), "fellague halim"));
            //list.Add(new RDV("Keyta", "Ben yamina", "mokrane", "fatiha", new DateTime(2017, 1, 1), 5, new DateTime(2012, 12, 22), "bellal kader"));
            //list.Add(new RDV("Gabriel", "Pepe", "fellague", "halim", new DateTime(2016, 11, 16), 1, new DateTime(2011, 7, 10), "bennouna el khebith"));
            //list.Add(new RDV("Khoukhi", "Doukkich", "mokrane", "fatiha", new DateTime(2017, 1, 1), 10, new DateTime(2009, 4, 8), "fellague halim"));
            return list;
        }

        private ObservableCollection<RdvPatientMedecin> CreateListAllMyRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id && !element.Rdv.DejaFait)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        private ObservableCollection<RdvPatientMedecin> CreateListAllMyTodayRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id && element.Rdv.DateRdv.Date == DateTime.Now.Date && !element.Rdv.NouvPat)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        private ObservableCollection<RdvPatientMedecin> CreateListAllFirstRdv()
        {
            //ObservableCollection<RdvPatientMedecin> allList = CreateRDVs();
            ObservableCollection<RdvPatientMedecin> allMyList = new ObservableCollection<RdvPatientMedecin>();
            foreach (RdvPatientMedecin element in listAllRvd)
            {
                if (element.Rdv.MedecinRespId == AuthenticationViewModel.AuthenticatedUser.Id && element.Rdv.DateRdv.Date == DateTime.Now.Date && element.Rdv.NouvPat)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        public void ActualiserLists()
        {
            ListAllMyRvd = CreateListAllMyRdv();
            ListAllMyTodayRvd = CreateListAllMyTodayRdv();
            ListAllFirstRvd = CreateListAllFirstRdv();
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
