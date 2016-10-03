using ConsultationManager.ServiceReferencePlanning;
using ConsultationManager.ServiceReferenceUtilisateur;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConsultationManager.ViewModels.Plannings
{
    class PlanningsViewModel : INotifyPropertyChanged
    {
        private PlanningServiceClient psc = new PlanningServiceClient();

        private ObservableCollection<ConsultationMedecinsPlanning> listPlannings;
        private ConsultationMedecinsPlanning selectedConsultation;

        private List<Utilisateur> listAllUsers;
        private ObservableCollection<Utilisateur> listMedecinsDimanche;
        private ObservableCollection<Utilisateur> listMedecinsLundi;
        private ObservableCollection<Utilisateur> listMedecinsMardi;
        private ObservableCollection<Utilisateur> listMedecinsMercredi;
        private ObservableCollection<Utilisateur> listMedecinsJeudi;

        private Utilisateur addedMedecinDimanche;
        private Utilisateur addedMedecinLundi;
        private Utilisateur addedMedecinMardi;
        private Utilisateur addedMedecinMercredi;
        private Utilisateur addedMedecinJeudi;

        private string nomUtilisateur;

        private bool hideUpdatePlann;

        public PlanningsViewModel()
        {
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listPlannings = GetPlannings();

            listAllUsers = GetUsers();
            listMedecinsDimanche = new ObservableCollection<Utilisateur>();
            listMedecinsLundi = new ObservableCollection<Utilisateur>();
            listMedecinsMardi = new ObservableCollection<Utilisateur>();
            listMedecinsMercredi = new ObservableCollection<Utilisateur>();
            listMedecinsJeudi = new ObservableCollection<Utilisateur>();

            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            selectedConsultation = new ConsultationMedecinsPlanning();

            addedMedecinDimanche = new Utilisateur();
            addedMedecinLundi = new Utilisateur();
            addedMedecinMardi = new Utilisateur();
            addedMedecinMercredi = new Utilisateur();
            addedMedecinJeudi = new Utilisateur();

            AddMedecinDimancheCommand = new RelayCommand(param => AjouterMedecinDimanche());
            RemoveMedecinDimancheCommand = new RelayCommand(param => DeleteMedecinDimanche(param));
            AddMedecinLundiCommand = new RelayCommand(param => AjouterMedecinLundi());
            RemoveMedecinLundiCommand = new RelayCommand(param => DeleteMedecinLundi(param));
            AddMedecinMardiCommand = new RelayCommand(param => AjouterMedecinMardi());
            RemoveMedecinMardiCommand = new RelayCommand(param => DeleteMedecinMardi(param));
            AddMedecinMercrediCommand = new RelayCommand(param => AjouterMedecinMercredi());
            RemoveMedecinMercrediCommand = new RelayCommand(param => DeleteMedecinMercredi(param));
            AddMedecinJeudiCommand = new RelayCommand(param => AjouterMedecinJeudi());
            RemoveMedecinJeudiCommand = new RelayCommand(param => DeleteMedecinJeudi(param));

            UpdatePlanningCommand = new RelayCommand(param => ModifierPlanning());


            hideUpdatePlann = true;
            if (AuthenticationViewModel.AuthenticatedUser.Role != "Administrateur")
                hideUpdatePlann = false;
        }

        #region PlanningsViewModel Variables

        public ObservableCollection<ConsultationMedecinsPlanning> ListPlannings
        {
            get
            {
                return listPlannings;
            }
            set
            {
                listPlannings = value;
                OnPropertyChanged("ListPlannings");
            }
        }

        public ConsultationMedecinsPlanning SelectedConsultation
        {
            get
            {
                return selectedConsultation;
            }
            set
            {
                selectedConsultation = value;
                GetMedecin();
                OnPropertyChanged("SelectedConsultation");
            }
        }


        public ObservableCollection<Utilisateur> ListMedecinsDimanche
        {
            get
            {
                return listMedecinsDimanche;
            }
            set
            {
                listMedecinsDimanche = value;
                OnPropertyChanged("ListMedecinsDimanche");
            }
        }
        public ObservableCollection<Utilisateur> ListMedecinsLundi
        {
            get
            {
                return listMedecinsLundi;
            }
            set
            {
                listMedecinsLundi = value;
                OnPropertyChanged("ListMedecinsLundi");
            }
        }
        public ObservableCollection<Utilisateur> ListMedecinsMardi
        {
            get
            {
                return listMedecinsMardi;
            }
            set
            {
                listMedecinsMardi = value;
                OnPropertyChanged("ListMedecinsMardi");
            }
        }
        public ObservableCollection<Utilisateur> ListMedecinsMercredi
        {
            get
            {
                return listMedecinsMercredi;
            }
            set
            {
                listMedecinsMercredi = value;
                OnPropertyChanged("ListMedecinsMercredi");
            }
        }
        public ObservableCollection<Utilisateur> ListMedecinsJeudi
        {
            get
            {
                return listMedecinsJeudi;
            }
            set
            {
                listMedecinsJeudi = value;
                OnPropertyChanged("ListMedecinsJeudi");
            }
        }

        public Utilisateur AddedMedecinDimanche
        {
            get
            {
                return addedMedecinDimanche;
            }
            set
            {
                addedMedecinDimanche = value;
                OnPropertyChanged("AddedMedecinDimanche");
            }
        }
        public Utilisateur AddedMedecinLundi
        {
            get
            {
                return addedMedecinLundi;
            }
            set
            {
                addedMedecinLundi = value;
                OnPropertyChanged("AddedMedecinLundi");
            }
        }
        public Utilisateur AddedMedecinMardi
        {
            get
            {
                return addedMedecinMardi;
            }
            set
            {
                addedMedecinMardi = value;
                OnPropertyChanged("AddedMedecinMardi");
            }
        }
        public Utilisateur AddedMedecinMercredi
        {
            get
            {
                return addedMedecinMercredi;
            }
            set
            {
                addedMedecinMercredi= value;
                OnPropertyChanged("AddedMedecinMercredi");
            }
        }
        public Utilisateur AddedMedecinJeudi
        {
            get
            {
                return addedMedecinJeudi;
            }
            set
            {
                addedMedecinJeudi = value;
                OnPropertyChanged("AddedMedecinJeudi");
            }
        }
        
        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        public bool HideUpdatePlann
        {
            get
            {
                return hideUpdatePlann;
            }
        }
        #endregion

        #region PlanningsViewModel Commands

        public ICommand AddMedecinDimancheCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedecinDimancheCommand
        {
            get;
            private set;
        }

        public ICommand AddMedecinLundiCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedecinLundiCommand
        {
            get;
            private set;
        }

        public ICommand AddMedecinMardiCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedecinMardiCommand
        {
            get;
            private set;
        }

        public ICommand AddMedecinMercrediCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedecinMercrediCommand
        {
            get;
            private set;
        }

        public ICommand AddMedecinJeudiCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedecinJeudiCommand
        {
            get;
            private set;
        }

        public ICommand UpdatePlanningCommand
        {
            get;
            private set;
        }

        #endregion

        #region PlanningsViewModel Methods

        private ObservableCollection<ConsultationMedecinsPlanning> GetPlannings()
        {
            ObservableCollection<ConsultationMedecinsPlanning> list = new ObservableCollection<ConsultationMedecinsPlanning>();
            list = new ObservableCollection<ConsultationMedecinsPlanning>(psc.GetAllPlannings(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            return list;
        }

        private List<Utilisateur> GetUsers()
        {
            List<Utilisateur> list = new List<Utilisateur>();
            UtilisateurServiceClient usc = new UtilisateurServiceClient();
            usc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            usc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            usc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            list = new List<Utilisateur>(usc.GetUtilisateurs());
            return list;
        }

        public void ModifierPlanning()
        {
            if (SelectedConsultation.Consult.Nom != "")
            {
                Planning planning = new Planning();
                planning.Id = selectedConsultation.Consult.IdPlanning;
                foreach (Utilisateur dimUser in selectedConsultation.MedecinsDimanche)
                    planning.MedecinsDimanche.Add(dimUser.Id);
                foreach (Utilisateur lunUser in selectedConsultation.MedecinsLundi)
                    planning.MedecinsLundi.Add(lunUser.Id);
                foreach (Utilisateur marUser in selectedConsultation.MedecinsMardi)
                    planning.MedecinsMardi.Add(marUser.Id);
                foreach (Utilisateur merUser in selectedConsultation.MedecinsMercredi)
                    planning.MedecinsMercredi.Add(merUser.Id);
                foreach (Utilisateur jeuUser in selectedConsultation.MedecinsJeudi)
                    planning.MedecinsJeudi.Add(jeuUser.Id);
                psc.UpdatePlanning(planning);
                MessageBox.Show("Le Planning de la Consultation a été Modifier");
            }
        }

        public void AjouterMedecinDimanche()
        {
            if (addedMedecinDimanche.Nom != "")
            {
                selectedConsultation.MedecinsDimanche.Add(addedMedecinDimanche);
                ListMedecinsDimanche.Remove(addedMedecinDimanche);
            }
        }
        public void DeleteMedecinDimanche(object selMed)
        {
            
            var user = selMed as Utilisateur;
            selectedConsultation.MedecinsDimanche.Remove(user);
            ListMedecinsDimanche.Add(user);
        }

        public void AjouterMedecinLundi()
        {
            if (AddedMedecinLundi.Nom != "")
            {
                selectedConsultation.MedecinsLundi.Add(addedMedecinLundi);
                ListMedecinsLundi.Remove(addedMedecinLundi);
            }
        }
        public void DeleteMedecinLundi(object selMed)
        {

            var user = selMed as Utilisateur;
            selectedConsultation.MedecinsLundi.Remove(user);
            ListMedecinsLundi.Add(user);
        }

        public void AjouterMedecinMardi()
        {
            if (addedMedecinMardi.Nom != "")
            {
                selectedConsultation.MedecinsMardi.Add(addedMedecinMardi);
                ListMedecinsMardi.Remove(addedMedecinMardi);
            }
        }
        public void DeleteMedecinMardi(object selMed)
        {

            var user = selMed as Utilisateur;
            selectedConsultation.MedecinsMardi.Remove(user);
            ListMedecinsMardi.Add(user);
        }

        public void AjouterMedecinMercredi()
        {
            if (addedMedecinMercredi.Nom != "")
            {
                selectedConsultation.MedecinsMercredi.Add(addedMedecinMercredi);
                ListMedecinsMercredi.Remove(addedMedecinMercredi);
            }
        }
        public void DeleteMedecinMercredi(object selMed)
        {

            var user = selMed as Utilisateur;
            selectedConsultation.MedecinsMercredi.Remove(user);
            ListMedecinsMercredi.Add(user);
        }

        public void AjouterMedecinJeudi()
        {
            if (addedMedecinJeudi.Nom != "")
            {
                selectedConsultation.MedecinsJeudi.Add(addedMedecinJeudi);
                ListMedecinsJeudi.Remove(addedMedecinJeudi);
            }
        }
        public void DeleteMedecinJeudi(object selMed)
        {

            var user = selMed as Utilisateur;
            selectedConsultation.MedecinsJeudi.Remove(user);
            ListMedecinsJeudi.Add(user);
        }

        private void GetMedecin()
        {
            ListMedecinsDimanche = new ObservableCollection<Utilisateur>();
            ListMedecinsLundi = new ObservableCollection<Utilisateur>();
            ListMedecinsMardi = new ObservableCollection<Utilisateur>();
            ListMedecinsMercredi = new ObservableCollection<Utilisateur>();
            ListMedecinsJeudi = new ObservableCollection<Utilisateur>();
            foreach (var item in listAllUsers)
            {
                ListMedecinsDimanche.Add(item);
                ListMedecinsLundi.Add(item);
                ListMedecinsMardi.Add(item);
                ListMedecinsMercredi.Add(item);
                ListMedecinsJeudi.Add(item);
            }

            var toRemove = listAllUsers.Where(user => selectedConsultation.MedecinsDimanche.Any(u => u.Id == user.Id) || user.Role == "Infirmier" || user.Role == "Assistant").ToList();
            //foreach (var plan in listPlannings)
            //    foreach (var item in plan.MedecinsDimanche)
            //        if(!toRemove.Any(u => u.Id == item.Id))
            //            toRemove.Add(item);
            ////////////////////////////////////////tryed to remove patient who are not available in Dimanche in other Consultation

            foreach (var item in toRemove)
                ListMedecinsDimanche.Remove(item);

            toRemove = listAllUsers.Where(user => selectedConsultation.MedecinsLundi.Any(u => u.Id == user.Id) || user.Role == "Infirmier" || user.Role == "Assistant").ToList();
            foreach (var item in toRemove)
                listMedecinsLundi.Remove(item);

            toRemove = listAllUsers.Where(user => selectedConsultation.MedecinsMardi.Any(u => u.Id == user.Id) || user.Role == "Infirmier" || user.Role == "Assistant").ToList();
            foreach (var item in toRemove)
                listMedecinsMardi.Remove(item);

            toRemove = listAllUsers.Where(user => selectedConsultation.MedecinsMercredi.Any(u => u.Id == user.Id) || user.Role == "Infirmier" || user.Role == "Assistant").ToList();
            foreach (var item in toRemove)
                listMedecinsMercredi.Remove(item);

            toRemove = listAllUsers.Where(user => selectedConsultation.MedecinsJeudi.Any(u => u.Id == user.Id) || user.Role == "Infirmier" || user.Role == "Assistant").ToList();
            foreach (var item in toRemove)
                listMedecinsJeudi.Remove(item);
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
