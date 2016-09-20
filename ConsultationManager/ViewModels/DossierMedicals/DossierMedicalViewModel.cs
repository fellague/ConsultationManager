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
    class DossierMedicalViewModel : INotifyPropertyChanged
    {
        private DossierMedServiceClient psc = new DossierMedServiceClient();
        private string nomUtilisateur;
        private ObservableCollection<DossierMedDetail> listAllDossier;
        private ObservableCollection<DossierMedDetail> listAllMyDossier;
        private ObservableCollection<DossierMedDetail> listConsultDossier;
        
        private DossierMedicalWindow dialoDossierMedical;
        private DossierMedDetail selectedDossier;

        public DossierMedicalViewModel()
        {
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;
            listAllDossier = GetDossierMeds();
            listAllMyDossier = CreateListAllMyPatientDossier();

            listConsultDossier = CreateListConsultPatDoss();

            OpenDialogMedFolderCommand = new RelayCommand(param => ShowDialogDossierMedical(param));
        }



        #region PatientsViewModel Variables

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

        private void ShowDialogDossierMedical(object param)
        {
            selectedDossier = param as DossierMedDetail;
            dialoDossierMedical = new DossierMedicalWindow();
            dialoDossierMedical.DataContext = this;
            //newPathologie = new Consultation();
            //AddPathologieCommand = new RelayCommand(param => AjouterPathologie());
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
}
