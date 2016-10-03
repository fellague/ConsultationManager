using ConsultationManagerClient.ViewModels.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.ViewModels.BtnsVisibility
{
    class VisibHospitVM : INotifyPropertyChanged
    {
        private bool hidePasseHosp;
        private bool hideActiveHosp;
        private bool hideFuturHosp;
        private bool hideAttenteHosp;
        private bool hideRateHosp;
        private bool hideDemandHosp;
        private bool hideSalleHosp;

        private string nomUtilisateur;

        public VisibHospitVM()
        {
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            hidePasseHosp = true;
            hideActiveHosp = true;
            hideFuturHosp = true;
            hideAttenteHosp = true;
            hideRateHosp = true;
            hideDemandHosp = true;
            hideSalleHosp = true;

            //if (AuthenticationViewModel.AuthenticatedUser.Role == "Chef Hospitalisation")
            //{
            //    hidePasseHosp = false;
            //    hideRateHosp = false;
            //}
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Infirmier")
            {
                hidePasseHosp = false;
                //hideActiveHosp = false;
                hideFuturHosp = false;
                hideAttenteHosp = false;
                hideRateHosp = false;
                hideDemandHosp = false;
                hideSalleHosp = false;
            }
            //if (AuthenticationViewModel.AuthenticatedUser.Role == "Administrateur")
            //{
            //    hidePasseHosp = false;
            //    hideActiveHosp = false;
            //    hideFuturHosp = false;
            //    hideAttenteHosp = false;
            //    hideRateHosp = false;
            //    hideDemandHosp = false;
            //    hideSalleHosp = false;
            //}
        }


        #region VisibPatientVM Variables

        public bool HidePasseHosp
        {
            get
            {
                return hidePasseHosp;
            }
            set
            {
                hidePasseHosp = value;
                OnPropertyChanged("HidePasseHosp");
            }
        }
        public bool HideActiveHosp
        {
            get
            {
                return hideActiveHosp;
            }
            set
            {
                hideActiveHosp = value;
                OnPropertyChanged("HideActiveHosp");
            }
        }
        public bool HideFuturHosp
        {
            get
            {
                return hideFuturHosp;
            }
            set
            {
                hideFuturHosp = value;
                OnPropertyChanged("HideFuturHosp");
            }
        }
        public bool HideAttenteHosp
        {
            get
            {
                return hideAttenteHosp;
            }
            set
            {
                hideAttenteHosp = value;
                OnPropertyChanged("HideAttenteHosp");
            }
        }
        public bool HideRateHosp
        {
            get
            {
                return hideRateHosp;
            }
            set
            {
                hideRateHosp = value;
                OnPropertyChanged("HideRateHosp");
            }
        }
        public bool HideDemandHosp
        {
            get
            {
                return hideDemandHosp;
            }
            set
            {
                hideDemandHosp = value;
                OnPropertyChanged("HideDemandHosp");
            }
        }
        public bool HideSalleHosp
        {
            get
            {
                return hideSalleHosp;
            }
            set
            {
                hideSalleHosp = value;
                OnPropertyChanged("HideSalleHosp");
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
