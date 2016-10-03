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
using ConsultationManager.Views.Patients;
using ConsultationManager.Views.DossierMedicals;
using ConsultationManager.ViewModels.DossierMedicals;

namespace ConsultationManagerClient.ViewModels.Patients
{
    internal class PatientsViewModel : INotifyPropertyChanged
    {
        private PatientServiceClient psc = new PatientServiceClient();
        private ObservableCollection<Patient> listAllPatient;
        private ObservableCollection<Patient> listConsultPatient;
        private ObservableCollection<Patient> listAllMyPatient;

        private ObservableCollection<Patient> listNewPatients;

        private Patient newPatient;
        private string newTelephone;

        private NewPatientRdvWindow dialogNewPatRdv;

        private DossierMedicalWindow dialoDossierMedical;

        public PatientsViewModel()
        {
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listAllPatient = GetPatients();
            listConsultPatient = CreateListConsultPatient();
            listAllMyPatient = CreateListAllMyPatient();

            listNewPatients = CreateListNewPatients();

            newPatient = new Patient();
            newTelephone = "";
            newPatient.DateNaiss = new DateTime(1980, 01, 01);

            AddTelephoneCommand = new RelayCommand(param => AjouterTelephone());
            RemoveTelephoneCommand = new RelayCommand(param => DeleteTelephone(param));

            AddPatientCommand = new RelayCommand(param => AjouterPatient(param));

            OpenDialogRdvCommand = new RelayCommand(param => ShowDialogRdvNewPatient(param));

            //OpenDialogMedFolderCommand = new RelayCommand(param => ShowDialogDossierMedical(param));
        }

        #region PatientsViewModel Variables

        public ObservableCollection<Patient> ListAllPatient
        {
            get
            {
                return listAllPatient;
            }
            set
            {
                listAllPatient = value;
                OnPropertyChanged("ListAllPatient");
            }
        }
        public ObservableCollection<Patient> ListConsultPatient
        {
            get
            {
                return listConsultPatient;
            }
            set
            {
                listConsultPatient = value;
                OnPropertyChanged("ListConsultPatient");
            }
        }
        public ObservableCollection<Patient> ListAllMyPatient
        {
            get
            {
                return listAllMyPatient;
            }
            set
            {
                listAllMyPatient = value;
                OnPropertyChanged("ListAllMyPatient");
            }
        }
        public ObservableCollection<Patient> ListNewPatients
        {
            get
            {
                return listNewPatients;
            }
            set
            {
                listNewPatients = value;
                OnPropertyChanged("ListNewPatients");
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
        
        public NewPatientRdvWindow DialogNewPatRdv
        {
            get
            {
                return dialogNewPatRdv;
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

        public ICommand OpenDialogRdvCommand
        {
            get;
            private set;
        }

        //public ICommand OpenDialogMedFolderCommand
        //{
        //    get;
        //    private set;
        //}

        #endregion

        #region PatientsViewModel Methods

        private ObservableCollection<Patient> GetPatients()
        {
            ObservableCollection<Patient> list = new ObservableCollection<Patient>();
            list = new ObservableCollection<Patient>(psc.GetAllPatients(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            return list;
        }

        private ObservableCollection<Patient> CreateListConsultPatient()
        {
            ObservableCollection<Patient> allMyList = new ObservableCollection<Patient>();
            foreach (Patient element in listAllPatient)
            {
                if (element.PathologieId == AuthenticationViewModel.AuthenticatedUser.PathologieId)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
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

        private ObservableCollection<Patient> CreateListNewPatients()
        {
            ObservableCollection<Patient> list = new ObservableCollection<Patient>();
            foreach (Patient element in listAllPatient)
            {
                if (element.Nouveau && element.PathologieId == AuthenticationViewModel.AuthenticatedUser.PathologieId)
                {
                    list.Add(element);
                }
            }
            return list;
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

        private void AjouterPatient(object param)
        {
            var newPat = new Patient();

            newPatient.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            newPatient.ServiceId = AuthenticationViewModel.AuthenticatedUser.ServiceId;
            newPatient.CreeDans = DateTime.Now;
            newPatient.PathologieId = AuthenticationViewModel.AuthenticatedUser.PathologieId;

            newPat = psc.AddPatient(newPatient);
            MessageBox.Show("Patient " + newPat.Nom+" "+newPat.Prenom+" a été sauvegardé");

            listAllPatient.Add(newPat);
            NewPatient = new Patient();
            ActualiserLists();
        }
        
        private void ShowDialogRdvNewPatient(object param)
        {
            Patient selPat = param as Patient;
            dialogNewPatRdv = new NewPatientRdvWindow();
            dialogNewPatRdv.DataContext = new RdvNewPatientViewModel(selPat, this);
            dialogNewPatRdv.ShowDialog();

            ListAllPatient = GetPatients();
            ActualiserLists();
        }

        //private void ShowDialogDossierMedical(object param)
        //{
        //    Patient selPat = param as Patient;
        //    dialoDossierMedical = new DossierMedicalWindow();
        //    dialoDossierMedical.DataContext = new DossierMedicalViewModel();
        //    //newPathologie = new Consultation();
        //    //AddPathologieCommand = new RelayCommand(param => AjouterPathologie());
        //    dialoDossierMedical.ShowDialog();
        //}

        private void ActualiserLists()
        {
            ListConsultPatient = CreateListConsultPatient();
            ListAllMyPatient = CreateListAllMyPatient();
            ListNewPatients = CreateListNewPatients();
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
