using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using ConsultationManager.ServiceReferenceUtilisateur;
using System.ServiceModel.Security;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManager.ServiceReferenceConsultation;

namespace ConsultationManagerClient.ViewModels.Users
{
    internal class UsersViewModel : INotifyPropertyChanged
    {
        private string nomUtilisateur;
        private ObservableCollection<Utilisateur> listAllUsers;
        private ObservableCollection<Utilisateur> listMedecin;
        private ObservableCollection<Utilisateur> listInfirmier;
        private ObservableCollection<Utilisateur> listChefService;
        private ObservableCollection<Utilisateur> listAssistant;

        private UtilisateurServiceClient usc = new UtilisateurServiceClient();


        private Utilisateur newUtilisateur;
        private ObservableCollection<Utilisateur> listMedecinSuperieur;
        private ServicePathologies servicePathologies;

        public UsersViewModel()
        {
            usc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            usc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            usc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;
            listAllUsers = GetUsers();
            listMedecin = CreateListMedecin();
            listInfirmier = CreateListInfirmier();
            listChefService = CreateListChefService();
            listAssistant = CreateListAssistant();
            //listMedecinSuperieur = CreateListMedSup();

            servicePathologies = GetServicePathols();

            newUtilisateur = new Utilisateur();
            newUtilisateur.DateNaiss = new DateTime(1980, 01, 01);

            AddUtilisateurCommand = new RelayCommand(param => AjouterUtilisateur(param));
        }

        #region ListUsersViewModel Variables

        public ObservableCollection<Utilisateur> ListAllUsers
        {
            get
            {
                return listAllUsers;
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
        public ObservableCollection<Utilisateur> ListMedecinSuperieur
        {
            get
            {
                return listMedecinSuperieur;
            }
        }

        public ServicePathologies ServicePathol
        {
            get
            {
                return servicePathologies;
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
        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        #endregion

        #region ListUsersViewModel Commands

        public ICommand AddUtilisateurCommand
        {
            get;
            private set;
        }

        #endregion

        #region ListUsersViewModel Methods

        private ObservableCollection<Utilisateur> GetUsers()
        {
            ObservableCollection<Utilisateur> list = new ObservableCollection<Utilisateur>();
            list = new ObservableCollection<Utilisateur>(usc.GetUtilisateurs());
            return list;
        }
        private ServicePathologies GetServicePathols()
        {
            ServicePathologies serv = new ServicePathologies();

            ConsultationServiceClient psc = new ConsultationServiceClient();
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            serv = psc.GetServiceDetails();
            return serv;
        }

        private ObservableCollection<Utilisateur> CreateListMedecin()
        {
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in listAllUsers)
            {
                if (element.Role == "Médecin")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Utilisateur> CreateListInfirmier()
        {
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in listAllUsers)
            {
                if (element.Role == "Infirmier")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Utilisateur> CreateListChefService()
        {
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in listAllUsers)
            {
                if (element.Role == "Chef Service")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Utilisateur> CreateListAssistant()
        {
            ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur element in listAllUsers)
            {
                if (element.Role == "Assistant")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        //private ObservableCollection<Utilisateur> CreateListMedSup()
        //{
        //    ObservableCollection<Utilisateur> allMyList = new ObservableCollection<Utilisateur>();
        //    foreach (Utilisateur element in listAllUsers)
        //    {
        //        if (element.Role != "Assistant" && element.Role!= "Infirmier")
        //        {
        //            allMyList.Add(element);
        //        }
        //    }
        //    return allMyList;
        //}

        private void AjouterUtilisateur(object param)
        {
            var newUser = new Utilisateur();
            
            newUtilisateur.UserName = newUtilisateur.Nom;
            newUtilisateur.Password = CreateRandomPassword(4);
            newUtilisateur.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            newUtilisateur.ServiceId = servicePathologies.Service.Id;
            newUtilisateur.CreeDans = DateTime.Now;
            //MessageBox.Show("Day " + DateTime.Now.DayOfWeek.ToString());
            //if(NewUtilisateur.Role== "Assistant")
            //{
            //    foreach(Utilisateur empl in listAllUsers)
            //    {
            //        if(empl.Id == newUtilisateur.MedecinSup)
            //            newUtilisateur.PathologieId = empl.PathologieId;
            //    }
            //}
            newUser = usc.AddUtilisateur(newUtilisateur);
            MessageBox.Show("Nouveau Utilisateur est ajouté avec le Nom d'utilisateur : " + newUtilisateur.UserName+"   et le Mot de Passe : " + newUtilisateur.Password);

            listAllUsers.Add(newUser);
            NewUtilisateur = new Utilisateur();
            ActualiserLists();
        }

        private void ActualiserLists()
        {
            listMedecin = CreateListMedecin();
            listInfirmier = CreateListInfirmier();
            listChefService = CreateListChefService();
            listAssistant = CreateListAssistant();
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
