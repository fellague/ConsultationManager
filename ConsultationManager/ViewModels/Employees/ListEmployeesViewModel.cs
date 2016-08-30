using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using ConsultationManager.ServiceReferenceUtilisateur;
using System.ServiceModel.Security;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using System.Windows;
using System.ComponentModel;

namespace ConsultationManagerClient.ViewModels.Employees
{
    internal class ListEmployeesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Utilisateur> listAllEmployee;
        private ObservableCollection<Utilisateur> listMedecin;
        private ObservableCollection<Utilisateur> listInfirmier;
        private ObservableCollection<Utilisateur> listChefService;
        private ObservableCollection<Utilisateur> listAssistant;

        private Utilisateur newUtilisateur;

        public ListEmployeesViewModel()
        {
            //listAllEmployee = CreateEmployees();
            //listMedecin = CreateListMedecin();
            //listInfirmier = CreateListInfirmier();
            //listChefService = CreateListChefService();
            //listAssistant = CreateListAssistant();
            listAllEmployee = CreateEmployees();
            listMedecin = CreateListMedecin();
            listInfirmier = CreateListInfirmier();
            listChefService = CreateListChefService();
            listAssistant = CreateListAssistant();

            newUtilisateur = new Utilisateur();
            newUtilisateur.DateNaiss = new DateTime(1980, 01, 01);

            AddUtilisateurCommand = new RelayCommand(param => AjouterUtilisateur());
        }

        #region ListEmployeesViewModel Variables

        public ObservableCollection<Utilisateur> ListAllEmployee
        {
            get
            {
                return listAllEmployee;
            }
        }
        public ObservableCollection<Utilisateur> ListMedecin
        {
            get
            {
                return listMedecin;
            }
        }
        public ObservableCollection<Utilisateur> ListInfirmier
        {
            get
            {
                return listInfirmier;
            }
        }
        public ObservableCollection<Utilisateur> ListChefService
        {
            get
            {
                return listChefService;
            }
        }
        public ObservableCollection<Utilisateur> ListAssistant
        {
            get
            {
                return listAssistant;
            }
        }

        public Utilisateur NewUtilisateur
        {
            get
            {
                return newUtilisateur;
            }
            set
            {
                newUtilisateur = value;
                OnPropertyChanged("NewUtilisateur");
            }
        }

        #endregion

        #region ListEmployeesViewModel Commands

        public ICommand AddUtilisateurCommand
        {
            get;
            private set;
        }

        #endregion

        #region ListEmployeesViewModel Methods

        private ObservableCollection<Utilisateur> CreateEmployees()
        {
            ObservableCollection<Utilisateur> list = new ObservableCollection<Utilisateur>();
            list.Add(new Utilisateur{ Nom = "Bennouna", Prenom = "El khebith" });

            

            //list.Add(new Employee("Mimouni", "Soumia", "admin", new DateTime(1975, 7, 13), "chlef hay essalem n 3", "06 98 75 65 90", DateTime.Today, "admin"));
            //list.Add(new Employee("Jack", "Rodman", "infirmier", new DateTime(1965, 3, 23), "blida hay el amal n 98", "07 99 87 54 76", new DateTime(2009, 5, 10), "Mimouni Soumia"));
            //list.Add(new Employee("Sandra", "Sherry", "chef_service", new DateTime(1967, 1, 10), "alger harrach bouraoui A 33", "05 87 09 54 34", new DateTime(2008, 12, 22), "Mimouni Soumia"));
            //list.Add(new Employee("Sabrina", "Vilk", "medecin", new DateTime(1987, 7, 8), "tyaret hay essaada nu 381", "07 98 65 34 98", DateTime.Today, "Mimouni Soumia"));
            //list.Add(new Employee("Mike", "Pearson", "medecin", new DateTime(1952, 8, 30), "oran la korniche nup 929", "07 87 87 98 09", new DateTime(2008, 10, 18), "Mimouni Soumia"));
            //list.Add(new Employee("Bill", "Watson", "infirmier", new DateTime(1978, 4, 20), "Khenchla bouhmema nu 098", "06 65 34 23 87", new DateTime(2016, 1, 18), "Mimouni Soumia"));
            //list.Add(new Employee("Christiano", "Ronaldo", "medecin", new DateTime(1987, 3, 10), "Purtugal hay el amal 054", "05 34 53 23 24", new DateTime(2014, 7, 10), "Mimouni Soumia"));
            //list.Add(new Employee("Maria", "Klara", "infirmier", new DateTime(1962, 1, 10), "alger harrach bouraoui A 33", "05 87 09 54 34", new DateTime(2012, 2, 20), "Mimouni Soumia"));
            //list.Add(new Employee("Amaouri", "Benjamen", "chef_service", new DateTime(1978, 3, 23), "blida hay el amal n 98", "07 99 87 54 76", new DateTime(2003, 7, 1), "Mimouni Soumia"));
            //list.Add(new Employee("Bouraoui", "ElMerioul", "medecin", new DateTime(1955, 6, 12), "Herrach hay essalem n 3", "06 97 75 65 89", DateTime.Today, "Mimouni Soumia"));
            //list.Add(new Employee("Henni", "El Alia", "assistant", new DateTime(1982, 8, 3), "Betna la korniche nup 929", "07 89 76 76 54", new DateTime(2005, 10, 18), "Mimouni Soumia"));
            //list.Add(new Employee("Keyta", "Ben yamina", "infirmier", new DateTime(1954, 1, 1), "Chlef hey essalem A 33", "05 65 87 98 65", new DateTime(2012, 12, 22), "Mimouni Soumia"));
            //list.Add(new Employee("Gabriel", "Pepe", "assistant", new DateTime(1943, 11, 16), "Anaba hay el amal 054", "05 87 33 21 24", new DateTime(2011, 7, 10), "Mimouni Soumia"));
            //list.Add(new Employee("Khoukhi", "Doukkich", "medecin", new DateTime(1990, 4, 20), "Chlef hay essalem nu 098", "07 76 98 09 54", new DateTime(2009, 4, 8), "Mimouni Soumia"));
            return list;
        }

        private ObservableCollection<Utilisateur> CreateListMedecin()
        {
            ObservableCollection<Utilisateur> allList = CreateEmployees();
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in allList)
            {
                if (element.Role == "medecin")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Utilisateur> CreateListInfirmier()
        {
            ObservableCollection<Utilisateur> allList = CreateEmployees();
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in allList)
            {
                if (element.Role == "infirmier")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Utilisateur> CreateListChefService()
        {
            ObservableCollection<Utilisateur> allList = CreateEmployees();
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in allList)
            {
                if (element.Role == "chef_service")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Utilisateur> CreateListAssistant()
        {
            ObservableCollection<Utilisateur> allList = CreateEmployees();
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in allList)
            {
                if (element.Role == "assistant")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        private void AjouterUtilisateur()
        {
            
            var newUser = new Utilisateur();
            UtilisateurServiceClient usc = new UtilisateurServiceClient();

            usc.ClientCredentials.UserName.UserName = "mimouni";
            usc.ClientCredentials.UserName.Password = "e8x_";
            usc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            MessageBox.Show("Utilisateur Saved Request... " + newUtilisateur.Nom);
            newUtilisateur.UserName = newUtilisateur.Nom;
            newUtilisateur.Password = CreateRandomPassword(4);
            newUtilisateur.CreeDans = DateTime.Now;
            newUser = usc.AddUtilisateur(newUtilisateur);
        }

        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
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
