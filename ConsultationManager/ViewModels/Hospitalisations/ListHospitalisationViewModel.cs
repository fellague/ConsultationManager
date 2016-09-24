using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models.Hospitalisations;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using System.Windows;
using ConsultationManager.Views.Hospitalisations;
using ConsultationManager.ServiceReferenceSalle;
using System.ServiceModel.Security;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManager.ServiceReferenceHospit;
using ConsultationManager.ViewModels.Hospitalisations;

namespace ConsultationManagerClient.ViewModels.Hospitalisations
{
    internal class ListHospitalisationViewModel : INotifyPropertyChanged
    {
        private SalleServiceClient ssc = new SalleServiceClient();
        private HospitServiceClient hsc = new HospitServiceClient();
        

        private string nomUtilisateur;
        private ObservableCollection<HospitalisationDetail> listAllHospitalisation;
        private ObservableCollection<HospitalisationDetail> listActiveHospitalisation;
        
        private ObservableCollection<Salle> listSalle;

        private ObservableCollection<DemandeHospitDetail> listDemandeHospit;


        private NewSalleWindow dialogNewSalle;
        private Salle newSalle;
        private int selectedNbLit;
        private ObservableCollection<int> listNbLit;
        
        private NewHospitWindow dialogNewHospit;
        private Hospitalisation newHospit;
        private DemandeHospitDetail selectedDemande;

        private UpdateSalleWindow dialogUpdateSalle;
        private Salle updatedSalle;

        public ListHospitalisationViewModel()
        {
            ssc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            ssc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            ssc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            hsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            hsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            hsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listAllHospitalisation = new ObservableCollection<HospitalisationDetail>();
            listAllHospitalisation = new ObservableCollection<HospitalisationDetail>(hsc.GetHospits(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            listActiveHospitalisation = new ObservableCollection<HospitalisationDetail>();
            ActualiserLists();
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            listSalle = new ObservableCollection<Salle>(ssc.GetSalles(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            listDemandeHospit = new ObservableCollection<DemandeHospitDetail>(hsc.GetDemandesHospit(AuthenticationViewModel.AuthenticatedUser.ServiceId));

            CancelCommand = new RelayCommand(o => ((Window)o).Close());

            NewHospitDialogCommand = new RelayCommand(param => ShowDialogNewHospit(param));

            NewSalleDialogCommand = new RelayCommand(param => ShowDialogNewSalle());
            UpdateSalleDialogCommand = new RelayCommand(param => this.ShowDialogUpdateSalle(param));
            RemoveSalleCommand = new RelayCommand(param => DeleteSalle(param));

        }


        #region PatientsViewModel Variables

        public ObservableCollection<HospitalisationDetail> ListAllHospitalisation
        {
            get
            {
                return listAllHospitalisation;
            }
            set
            {
                listAllHospitalisation = value;
                OnPropertyChanged("ListAllHospitalisation");
            }
        }
        public ObservableCollection<HospitalisationDetail> ListActiveHospitalisation
        {
            get
            {
                return listActiveHospitalisation;
            }
            set
            {
                listActiveHospitalisation = value;
                OnPropertyChanged("ListActiveHospitalisation");
            }
        }
        public ObservableCollection<Salle> ListSalle
        {
            get
            {
                return listSalle;
            }
            set
            {
                listSalle = value;
                OnPropertyChanged("ListSalle");
            }
        }
        public ObservableCollection<DemandeHospitDetail> ListDemandeHospit
        {
            get
            {
                return listDemandeHospit;
            }
            set
            {
                listDemandeHospit = value;
                OnPropertyChanged("ListDemandeHospit");
            }
        }
        public Salle NewSalle
        {
            get
            {
                return newSalle;
            }
            set
            {
                newSalle = value;
                OnPropertyChanged("NewSalle");
            }
        }
        public Salle UpdatedSalle
        {
            get
            {
                return updatedSalle;
            }
            set
            {
                updatedSalle = value;
                OnPropertyChanged("UpdatedSalle");
            }
        }
        public ObservableCollection<int> ListNbLit
        {
            get
            {
                return listNbLit;
            }
            set
            {
                listNbLit = value;
                OnPropertyChanged("ListNbLit");
            }
        }
        public int SelectedNbLit
        {
            get
            {
                return selectedNbLit;
            }
            set
            {
                selectedNbLit = value;
                OnPropertyChanged("SelectedNbLit");
            }
        }
        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        public Hospitalisation NewHospit
        {
            get
            {
                return newHospit;
            }
            set
            {
                newHospit = value;
                OnPropertyChanged("NewHospit");
            }
        }
        public DemandeHospitDetail SelectedDemande
        {
            get
            {
                return selectedDemande;
            }
            set
            {
                selectedDemande = value;
                OnPropertyChanged("SelectedDemande");
            }
        }

        public NewHospitWindow DialogNewHospit
        {
            get
            {
                return dialogNewHospit;
            }
        }
        #endregion

        #region PatientsViewModel Commands

        public ICommand NewSalleDialogCommand
        {
            get;
            private set;
        }
        public ICommand NewHospitDialogCommand
        {
            get;
            private set;
        }

        public ICommand UpdateSalleDialogCommand
        {
            get;
            private set;
        }

        public ICommand UpdateSalleCommand
        {
            get;
            private set;
        }
        public ICommand RemoveSalleCommand
        {
            get;
            private set;
        }

        public ICommand AddSalleCommand
        {
            get;
            private set;
        }
        public ICommand AddHospitCommand
        {
            get;
            private set;
        }
        public ICommand CancelCommand
        {
            get;
            private set;
        }


        #endregion

        #region PatientsViewModel Methods
        
        private ObservableCollection<HospitalisationDetail> CreateListActiveHospitalisation()
        {
            ObservableCollection<HospitalisationDetail> allMyList = new ObservableCollection<HospitalisationDetail>();
            foreach (HospitalisationDetail element in listAllHospitalisation)
            {
                if (element.Hospitalisation.DateFinPrevu.Date.CompareTo(DateTime.Now) > 0 && element.Hospitalisation.DateDebutReel.Date.CompareTo(DateTime.Now.Date) <= 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        public void ShowDialogUpdateSalle(object selectedSalle)
        {
            updatedSalle = selectedSalle as Salle;
            dialogUpdateSalle = new UpdateSalleWindow();
            listNbLit = new ObservableCollection<int>(Enumerable.Range(1, 20));
            dialogUpdateSalle.DataContext = this;
            UpdateSalleCommand = new RelayCommand(param => ModifierSalle());
            dialogUpdateSalle.ShowDialog();
        }
        public void ModifierSalle()
        {
            UpdatedSalle.LitsLibres = new ObservableCollection<int>(Enumerable.Range(1, UpdatedSalle.NbLit));
            ssc.UpdateSalle(UpdatedSalle);
            dialogUpdateSalle.Close();
        }
        public void DeleteSalle(object selectedSalle)
        {
            var deletedSalle = selectedSalle as Salle;

            ssc.DeleteSalle(deletedSalle.Id);
            listSalle.Remove(deletedSalle);
        }

        private void ShowDialogNewSalle()
        {
            dialogNewSalle = new NewSalleWindow();
            dialogNewSalle.DataContext = this;
            newSalle = new Salle();
            ListNbLit = new ObservableCollection<int>(Enumerable.Range(1, 20));
            AddSalleCommand = new RelayCommand(param => AjouterSalle());
            dialogNewSalle.ShowDialog();
        }

        private void AjouterSalle()
        {
            NewSalle.IdService = AuthenticationViewModel.AuthenticatedUser.ServiceId;
            NewSalle.NbLit = SelectedNbLit;
            NewSalle.CreeDans = DateTime.Now;
            NewSalle.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            NewSalle.LitsLibres = new ObservableCollection<int>(Enumerable.Range(1, NewSalle.NbLit));
            ssc.AddSalle(NewSalle);
            listSalle.Add(NewSalle);
            dialogNewSalle.Close();
        }

        private void ShowDialogNewHospit(object selecDemand)
        {
            SelectedDemande = selecDemand as DemandeHospitDetail;
            dialogNewHospit = new NewHospitWindow();
            dialogNewHospit.DataContext = new NewHospitViewModel(SelectedDemande, this);
            dialogNewHospit.ShowDialog();
        }
        //private void AjouterHospit()
        //{
        //    NewSalle.IdService = AuthenticationViewModel.AuthenticatedUser.ServiceId;
        //    NewSalle.NbLit = SelectedNbLit;
        //    NewSalle.CreeDans = DateTime.Now;
        //    NewSalle.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
        //    ssc.AddSalle(NewSalle);
        //    listSalle.Add(NewSalle);
        //    dialogNewSalle.Close();
        //}

        public void ActualiserLists()
        {
            listActiveHospitalisation = CreateListActiveHospitalisation();
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
