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

namespace ConsultationManagerClient.ViewModels.Hospitalisations
{
    internal class ListHospitalisationViewModel : INotifyPropertyChanged
    {
        private SalleServiceClient ssc = new SalleServiceClient();

        private string nomUtilisateur;
        private ObservableCollection<Hospitalisation> listAllHospitalisation;
        private ObservableCollection<Hospitalisation> listActiveHospitalisation;
        
        private ObservableCollection<Salle> listSalle;


        private NewSalleWindow dialogNewSalle;
        private Salle newSalle;
        private int selectedNbLit;
        private ObservableCollection<int> listNbLit;

        private UpdateSalleWindow dialogUpdateSalle;
        private Salle updatedSalle;

        public ListHospitalisationViewModel()
        {
            ssc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            ssc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            ssc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listAllHospitalisation = CreateHospitalisations();
            listActiveHospitalisation = CreateListActiveHospitalisation();
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            listSalle = new ObservableCollection<Salle>(ssc.GetSalles(AuthenticationViewModel.AuthenticatedUser.ServiceId));

            CancelCommand = new RelayCommand(o => ((Window)o).Close());

            NewSalleDialogCommand = new RelayCommand(param => ShowDialogNewSalle());
            UpdateSalleDialogCommand = new RelayCommand(param => this.ShowDialogUpdateSalle(param));
            RemoveSalleCommand = new RelayCommand(param => DeleteSalle(param));

        }


        #region PatientsViewModel Variables

        public ObservableCollection<Hospitalisation> ListAllHospitalisation
        {
            get
            {
                return listAllHospitalisation;
            }
        }
        public ObservableCollection<Hospitalisation> ListActiveHospitalisation
        {
            get
            {
                return listActiveHospitalisation;
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

        #endregion

        #region PatientsViewModel Commands

        public ICommand NewSalleDialogCommand
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
        public ICommand CancelCommand
        {
            get;
            private set;
        }


        #endregion

        #region PatientsViewModel Methods

        private ObservableCollection<Hospitalisation> CreateHospitalisations()
        {
            ObservableCollection<Hospitalisation> list = new ObservableCollection<Hospitalisation>();
            //list.Add(new Hospitalisation("", "Kaddour Aissa", "Kamel", "5", "14", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-3), DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-11), "Adda hanifi Omar"));
            //list.Add(new Hospitalisation("1", "Hadj Henni", "Abdelkader" , "3", "7", DateTime.Today.AddDays(-5), DateTime.Today.AddDays(2), DateTime.Today, DateTime.Today.AddDays(-32), "Mokrane Fatiha"));
            //list.Add(new Hospitalisation("2", "Koidri", "Fatma", "1", "3", DateTime.Today, DateTime.Today.AddDays(7),new DateTime(1, 1, 1), DateTime.Today.AddDays(-1), "Halim Imed"));
            //list.Add(new Hospitalisation("", "Chergou", "Abdelhak" , "5", "10", DateTime.Today.AddDays(-20), DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-30), "Fellague chebra Abdelhalim"));
            //list.Add(new Hospitalisation("3", "Bouzidi", "Brahim", "3", "5", DateTime.Today.AddDays(-1), DateTime.Today.AddDays(10), DateTime.Today, DateTime.Today.AddDays(-19), "bennouna el khebith"));
            //list.Add(new Hospitalisation("", "Aissawi", "Oussama", "5", "6", DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-4), "fellague halim"));
            //list.Add(new Hospitalisation("", "Nouri", "Hakim", "3", "2", DateTime.Today.AddMonths(-3), DateTime.Today.AddMonths(-3).AddDays(10), DateTime.Today.AddMonths(-3).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-1), "Sakraoui Imed"));
            //list.Add(new Hospitalisation("", "Berroudji", "Bakhta", "5", "8", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "Melloul Abdellah"));
            //list.Add(new Hospitalisation("", "Amaouri", "Saiid", "5", "3", DateTime.Today.AddMonths(1).AddDays(3), DateTime.Today.AddMonths(1).AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "Adda hanifi Omar"));
            //list.Add(new Hospitalisation("", "Bouraoui", "Ammar", "1", "4", DateTime.Today.AddMonths(-4), DateTime.Today.AddMonths(-4).AddDays(7), DateTime.Today.AddMonths(-4).AddDays(10), DateTime.Today.AddMonths(-4).AddDays(-4), "Halim Imed"));
            //list.Add(new Hospitalisation("4", "Henni", "El Alia", "3", "4", DateTime.Today.AddDays(-4), DateTime.Today.AddDays(5), new DateTime(1, 1, 1), DateTime.Today.AddDays(-6), "Melloul Abdellah"));
            //list.Add(new Hospitalisation("", "Ben yamina", "Abdelkader", "5", "11", DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-4), "Sakraoui Imed"));
            //list.Add(new Hospitalisation("5", "Bougara", "Brahim", "1", "2", DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1), new DateTime(1, 1, 1), DateTime.Today.AddDays(-10), "Melloul Abdellah"));
            //list.Add(new Hospitalisation("", "Khoukhi", "Doukkich", "5", "9", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "Sakraoui Imed"));
            return list;
        }

        private ObservableCollection<Hospitalisation> CreateListActiveHospitalisation()
        {
            ObservableCollection<Hospitalisation> allList = CreateHospitalisations();
            ObservableCollection<Hospitalisation> allMyList = new ObservableCollection<Hospitalisation>();
            foreach (Hospitalisation element in allList)
            {
                if (element.DateFinPrevu.Date.CompareTo(DateTime.Now) > 0 && element.DateDebut.Date.CompareTo(DateTime.Now.Date) <= 0)
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
            UpdateSalleCommand = new RelayCommand(param => ModifierPathologie());
            dialogUpdateSalle.ShowDialog();
        }
        public void ModifierPathologie()
        {
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
            ssc.AddSalle(NewSalle);
            listSalle.Add(NewSalle);
            dialogNewSalle.Close();
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
