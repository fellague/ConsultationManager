using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using ConsultationManagerClient.ViewModels.Authentication;
using System.Windows;
using System.ComponentModel;
using ConsultationManager.ServiceReferencePatient;
using System.ServiceModel.Security;
using System.Windows.Input;
using ConsultationManagerClient.Commands;

namespace ConsultationManagerClient.ViewModels.Patients
{
    internal class PatientsViewModel : INotifyPropertyChanged
    {
        private PatientServiceClient psc = new PatientServiceClient();
        private string nomUtilisateur;
        private ObservableCollection<Patient> listAllPatient;
        private ObservableCollection<Patient> listAllMyPatient;

        private Patient newPatient;
        private string newTelephone;

        public PatientsViewModel()
        {
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;
            listAllPatient = GetPatients();
            listAllMyPatient = CreateListAllMyPatient();

            newPatient = new Patient();
            newTelephone = "";
            newPatient.DateNaiss = new DateTime(1980, 01, 01);

            AddTelephoneCommand = new RelayCommand(param => AjouterTelephone());
            RemoveTelephoneCommand = new RelayCommand(param => DeleteTelephone(param));

            AddPatientCommand = new RelayCommand(param => AjouterUtilisateur(param));
        }
        

        #region PatientsViewModel Variables

        public ObservableCollection<Patient> ListAllPatient
        {
            get
            {
                return listAllPatient;
            }
        }
        public ObservableCollection<Patient> ListAllMyPatient
        {
            get
            {
                return listAllMyPatient;
            }
        }

        public Patient NewPatient
        {
            get
            {
                return newPatient;
            }
            set
            {
                newPatient = value;
                OnPropertyChanged("NewPatient");
            }
        }
        
        public string NewTelephone
        {
            get
            {
                return newTelephone;
            }
            set
            {
                newTelephone = value;
                OnPropertyChanged("NewTelephone");
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

        public ICommand AddTelephoneCommand
        {
            get;
            private set;
        }
        public ICommand RemoveTelephoneCommand
        {
            get;
            private set;
        }

        public ICommand AddPatientCommand
        {
            get;
            private set;
        }

        #endregion

        #region PatientsViewModel Methods

        private ObservableCollection<Patient> GetPatients()
        {
            ObservableCollection<Patient> list = new ObservableCollection<Patient>();
            list = new ObservableCollection<Patient>(psc.GetAllPatients(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            //list.Add(new Patient("Nick", "White", new DateTime(1975, 7, 13), "un kis zza doic sdz zdlkd sdndk sdcioz sdijd", "chlef hay essalem n 3", "06 98 75 65 90", true, DateTime.Today, "tebibell saliha"));
            //list.Add(new Patient("Jack", "Rodman", new DateTime(1965, 3, 23), "un malle dans la tete qsjsd cjqs ketipaliss", "blida hay el amal n 98", "07 99 87 54 76", false, new DateTime(2009, 5, 10), "mokrane fatiha"));
            //list.Add(new Patient("Sandra", "Sherry", new DateTime(1967, 1, 10), "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc", "alger harrach bouraoui A 33", "05 87 09 54 34", false, new DateTime(2008, 12, 22), "bellal kader"));
            //list.Add(new Patient("Sabrina", "Vilk", new DateTime(1987, 7, 8), "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj", "tyaret hay essaada nu 381", "07 98 65 34 98", true, DateTime.Today, "fellague halim"));
            //list.Add(new Patient("Mike", "Pearson", new DateTime(1952, 8, 30), "mpqxn ckjqs xc ydc jwx wdckjqsd xwjwxc kjxw kjcqs cjksd ,jwx", "oran la korniche nup 929", "07 87 87 98 09", true, new DateTime(2008, 10, 18), "bennouna el khebith"));
            //list.Add(new Patient("Bill", "Watson", new DateTime(1978, 4, 20), "fcef rvfrf rfv tgv wqw zsxsx zxszsd cedcvf rf tb tynh,uj ujkol pmsd", "Khenchla bouhmema nu 098", "06 65 34 23 87", true, new DateTime(2016, 1, 18), "fellague halim"));
            //list.Add(new Patient( "Christiano", "Ronaldo", new DateTime(1987, 3, 10), "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj", "Purtugal hay el amal 054", "05 34 53 23 24", true, new DateTime(2014, 7, 10), "bennouna el khebith"));
            //list.Add(new Patient("Maria","Klara", new DateTime(1962, 1, 10), "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc", "alger harrach bouraoui A 33", "05 87 09 54 34", false, new DateTime(2012, 2, 20), "bellal kader"));
            //list.Add(new Patient("Amaouri", "Benjamen", new DateTime(1978, 3, 23), "un malle dans la tete qsjsd cjqs ketipaliss", "blida hay el amal n 98", "07 99 87 54 76", false, new DateTime(2003, 7, 1), "fellague halim"));
            //list.Add(new Patient("Bouraoui", "ElMerioul", new DateTime(1955, 6, 12), "un kis zza doic sdz zdlkd sdndk sdcioz sdijd", "Herrach hay essalem n 3", "06 97 75 65 89", true, DateTime.Today, "tebibell saliha"));
            //list.Add(new Patient("Henni", "El Alia", new DateTime(1982, 8, 3), "mpqxn ckqs sckqs ckjqs xc ydc jwx wdckjqsd xwjwxc kjxw kjcqs cjksd ,jwx", "Betna la korniche nup 929", "07 89 76 76 54", true, new DateTime(2005, 10, 18), "fellague halim"));
            //list.Add(new Patient("Keyta", "Ben yamina", new DateTime(1954, 1, 1), "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc", "Chlef hey essalem A 33", "05 65 87 98 65", false, new DateTime(2012, 12, 22), "bellal kader"));
            //list.Add(new Patient("Gabriel", "Pepe", new DateTime(1943, 11, 16), "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj", "Anaba hay el amal 054", "05 87 33 21 24", true, new DateTime(2011, 7, 10), "bennouna el khebith"));
            //list.Add(new Patient( "Khoukhi", "Doukkich", new DateTime(1990, 4, 20), "fcef rvfrf rfv tgv wqw zsxsx zxszsd cedcvf rf tb tynh,uj ujkol pmsd", "Chlef hay essalem nu 098", "07 76 98 09 54", false, new DateTime(2009, 4, 8), "fellague halim"));
            return list;
        }

        private ObservableCollection<Patient> CreateListAllMyPatient()
        {
            ObservableCollection<Patient> allMyList = new ObservableCollection<Patient>();
            foreach (Patient element in listAllPatient)
            {
                if (element.MedecinResp == AuthenticationViewModel.AuthenticatedUser.Id)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        public void AjouterTelephone()
        {
            //var newCsl = csl as string;
            if (newTelephone != "")
            {
                newPatient.Telephones.Add(newTelephone);
                NewTelephone = "";
            }
        }
        public void DeleteTelephone(object selectedTelephone)
        {
            Console.WriteLine("PathologiesViewModel : Remove Telephone  ");
            var telephone = selectedTelephone as string;
            newPatient.Telephones.Remove(telephone);
        }

        private void AjouterUtilisateur(object param)
        {
            var newPat = new Patient();

            newPatient.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            //newPatient.ServiceId = servicePathologies.Service.Id;
            newPatient.ServiceId = AuthenticationViewModel.AuthenticatedUser.ServiceId;
            newPatient.CreeDans = DateTime.Now;
            if(AuthenticationViewModel.AuthenticatedUser.Role== "Chef Service"|| AuthenticationViewModel.AuthenticatedUser.Role == "Médecin")
            {
                newPatient.MedecinResp = AuthenticationViewModel.AuthenticatedUser.Id;
            }
            //if (AuthenticationViewModel.AuthenticatedUser.Role == "Assistant")
            //{
            //    newPatient.MedecinResp = AuthenticationViewModel.AuthenticatedUser.MedecinSup;
            //}
            newPatient.PathologieId = AuthenticationViewModel.AuthenticatedUser.PathologieId;

            newPat = psc.AddPatient(newPatient);
            MessageBox.Show("Patient Saved Request... " + newPat.Id);

            listAllPatient.Add(newPat);
            NewPatient = new Patient();
            ActualiserLists();
        }

        private void ActualiserLists()
        {
            listAllMyPatient = CreateListAllMyPatient();
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
