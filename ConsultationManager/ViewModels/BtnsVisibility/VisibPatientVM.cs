using ConsultationManagerClient.ViewModels.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.ViewModels.BtnsVisibility
{
    class VisibPatientVM : INotifyPropertyChanged
    {
        private bool hideAllPatient;
        private bool hideConsultPatient;
        private bool hideMyPatients;
        private bool hideNewPatients;
        private bool hideNewPatient;

        private string nomUtilisateur;

        public VisibPatientVM()
        {
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            hideAllPatient = true;
            hideConsultPatient = true;
            hideMyPatients = true;
            hideNewPatients = true;
            hideNewPatient = true;

            if (AuthenticationViewModel.AuthenticatedUser.Role == "Chef Service")
            {
                hideAllPatient = false;
                hideNewPatient = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Médecin")
            {
                hideAllPatient = false;
                hideConsultPatient = false;
                hideNewPatients = false;
                hideNewPatient = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Administrateur")
            {
                hideConsultPatient = false;
                hideNewPatients = false;
                hideNewPatient = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Assistant")
            {
                hideAllPatient = false;
                hideMyPatients = false;
                hideNewPatients = false;
            }
        }


        #region VisibPatientVM Variables

        public bool HideAllPatient
        {
            get
            {
                return hideAllPatient;
            }
            set
            {
                hideAllPatient = value;
                OnPropertyChanged("HideAllPatient");
            }
        }
        public bool HideConsultPatient
        {
            get
            {
                return hideConsultPatient;
            }
            set
            {
                hideConsultPatient = value;
                OnPropertyChanged("HideConsultPatient");
            }
        }
        public bool HideMyPatients
        {
            get
            {
                return hideMyPatients;
            }
            set
            {
                hideMyPatients = value;
                OnPropertyChanged("HideMyPatients");
            }
        }
        public bool HideNewPatients
        {
            get
            {
                return hideNewPatients;
            }
            set
            {
                hideNewPatients = value;
                OnPropertyChanged("HideNewPatients");
            }
        }
        public bool HideNewPatient
        {
            get
            {
                return hideNewPatient;
            }
            set
            {
                hideNewPatient = value;
                OnPropertyChanged("HideNewPatient");
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
