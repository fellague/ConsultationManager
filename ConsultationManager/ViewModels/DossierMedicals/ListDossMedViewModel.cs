using ConsultationManager.ServiceReferenceDossierMed;
using ConsultationManager.Views.DossierMedicals;
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
using System.Windows.Input;

namespace ConsultationManager.ViewModels.DossierMedicals
{
    class ListDossMedViewModel : INotifyPropertyChanged
    {
        private DossierMedServiceClient psc = new DossierMedServiceClient();
        private string nomUtilisateur;
        private ObservableCollection<DossierMedDetail> listAllDossier;
        private ObservableCollection<DossierMedDetail> listAllMyDossier;
        private ObservableCollection<DossierMedDetail> listConsultDossier;

        //private ObservableCollection<GridMyDossierData> listMyDossierGrid;
        //private ObservableCollection<GridConsultDossierData> listConsultDossierGrid;
        private ObservableCollection<GridServiceDossierData> listAllDossierGrid;


        private DossierMedicalWindow dialoDossierMedical;
        private DossierMedDetail selectedDossier;

        public ListDossMedViewModel()
        {
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;
            listAllDossier = GetDossierMeds();
            listAllMyDossier = CreateListAllMyPatientDossier();

            listConsultDossier = CreateListConsultPatDoss();

            //listMyDossierGrid = CreateListMyGrid();
            //listConsultDossierGrid = CreateListConsultGrid();
            listAllDossierGrid = CreateListDossierGrid();

            OpenDialogMedFolderCommand = new RelayCommand(param => ShowDialogDossierMedical(param));
        }
        
        #region ListDossMedViewModel Variables

        public ObservableCollection<DossierMedDetail> ListAllDossier
        {
            get
            {
                return listAllDossier;
            }
        }
        public ObservableCollection<DossierMedDetail> ListAllMyDossier
        {
            get
            {
                return listAllMyDossier;
            }
        }
        public ObservableCollection<DossierMedDetail> ListConsultDossier
        {
            get
            {
                return listConsultDossier;
            }
        }


        //public ObservableCollection<GridMyDossierData> ListMyDossierGrid
        //{
        //    get
        //    {
        //        return listMyDossierGrid;
        //    }
        //}
        //public ObservableCollection<GridConsultDossierData> ListConsultDossierGrid
        //{
        //    get
        //    {
        //        return listConsultDossierGrid;
        //    }
        //}
        public ObservableCollection<GridServiceDossierData> ListAllDossierGrid
        {
            get
            {
                return listAllDossierGrid;
            }
        }

        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
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

        #endregion

        #region PatientsViewModel Commands

        public ICommand OpenDialogMedFolderCommand
        {
            get;
            private set;
        }

        #endregion

        #region PatientsViewModel Methods

        private ObservableCollection<DossierMedDetail> GetDossierMeds()
        {
            ObservableCollection<DossierMedDetail> list = new ObservableCollection<DossierMedDetail>();
            list = new ObservableCollection<DossierMedDetail>(psc.GetAllDossierMeds(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            return list;
        }

        private ObservableCollection<DossierMedDetail> CreateListAllMyPatientDossier()
        {
            ObservableCollection<DossierMedDetail> allMyList = new ObservableCollection<DossierMedDetail>();
            foreach (DossierMedDetail element in listAllDossier)
            {
                if (element.Patient.MedecinResp == AuthenticationViewModel.AuthenticatedUser.Id)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        private ObservableCollection<DossierMedDetail> CreateListConsultPatDoss()
        {
            ObservableCollection<DossierMedDetail> list = new ObservableCollection<DossierMedDetail>();
            foreach (DossierMedDetail element in listAllDossier)
            {
                if (element.Patient.PathologieId == AuthenticationViewModel.AuthenticatedUser.PathologieId)
                {
                    list.Add(element);
                }
            }
            return list;
        }
        
        private ObservableCollection<GridServiceDossierData> CreateListDossierGrid()
        {
            ObservableCollection<GridServiceDossierData> list = new ObservableCollection<GridServiceDossierData>();
            GridServiceDossierData data;

            if (AuthenticationViewModel.AuthenticatedUser.Role == "Chef Service" || AuthenticationViewModel.AuthenticatedUser.Role == "Assistant")
            {
                foreach (DossierMedDetail element in listConsultDossier)
                {
                    data = new GridServiceDossierData();
                    data.Identifiant = element.DossierMedical.Identifiant;
                    data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                    data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                    data.Medecin = element.Medecin.Nom + "  " + element.Medecin.Prenom;
                    data.Consultation = element.Consultation.Nom;
                    data.Adresse = element.Patient.Adresse;
                    data.Telephone = element.Patient.Telephones.First();
                    data.CreerDans = element.DossierMedical.CreeDans.ToString();
                    list.Add(data);
                }
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Médecin")
            {
                foreach (DossierMedDetail element in listAllMyDossier)
                {
                    data = new GridServiceDossierData();
                    data.Identifiant = element.DossierMedical.Identifiant;
                    data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                    data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                    data.Adresse = element.Patient.Adresse;
                    data.Telephone = element.Patient.Telephones.First();
                    data.CreerDans = element.DossierMedical.CreeDans.ToString();
                    list.Add(data);
                }
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Administrateur" || AuthenticationViewModel.AuthenticatedUser.Role == "Chef Hospitalisation")
            {
                foreach (DossierMedDetail element in listAllDossier)
                {
                    data = new GridServiceDossierData();
                    data.Identifiant = element.DossierMedical.Identifiant;
                    data.Patient = element.Patient.Nom + "  " + element.Patient.Prenom;
                    data.DateNaissance = element.Patient.DateNaiss.Year + "-" + element.Patient.DateNaiss.Month + "-" + element.Patient.DateNaiss.Day;
                    data.Adresse = element.Patient.Adresse;
                    data.Telephone = element.Patient.Telephones.First();
                    data.CreerDans = element.DossierMedical.CreeDans.ToString();
                    list.Add(data);
                }
            }
            
            return list;
        }

        private void ShowDialogDossierMedical(object param)
        {
            selectedDossier = param as DossierMedDetail;
            dialoDossierMedical = new DossierMedicalWindow();
            //dialoDossierMedical.DataContext = this;
            dialoDossierMedical.DataContext = new DossierMedViewModel(selectedDossier);
            dialoDossierMedical.ShowDialog();
        }

        private void ActualiserLists()
        {
            listAllMyDossier = CreateListAllMyPatientDossier();
            listConsultDossier = CreateListConsultPatDoss();
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

    //public class GridMyDossierData
    //{
    //    public string Identifiant { get; set; }
    //    public string Patient { get; set; }
    //    public string DateNaissance { get; set; }
    //    public string Adresse { get; set; }
    //    public string Telephone { get; set; }
    //    public string CreerDans { get; set; }
    //}
    //public class GridConsultDossierData
    //{
    //    public string Identifiant { get; set; }
    //    public string Patient { get; set; }
    //    public string Medecin { get; set; }
    //    public string Adresse { get; set; }
    //    public string Telephone { get; set; }
    //    public string CreerDans { get; set; }
    //}
    public class GridServiceDossierData
    {
        public string Identifiant { get; set; }
        public string Patient { get; set; }
        public string DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string CreerDans { get; set; }
        public string Medecin { get; set; }
        public string Consultation { get; set; }
    }
}
