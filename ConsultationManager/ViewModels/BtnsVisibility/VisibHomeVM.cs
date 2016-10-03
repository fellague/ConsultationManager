using ConsultationManagerClient.ViewModels.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConsultationManager.ViewModels.BtnsVisibility
{
    class VisibHomeVM : INotifyPropertyChanged
    {
        private bool hidePatients;
        private bool hideHospitalisation;
        private bool hideMyPatients;
        private bool hideEducation;
        private bool hideUtilisateur;
        private bool hidePlanning;
        private bool hideDossier;
        private bool hideRdv;
        private bool hideTransfert;


        private string nomUtilisateur;

        public VisibHomeVM()
        {
            hidePatients = true;
            hideHospitalisation = true;
            hideMyPatients = true;
            hideEducation = true;
            hideUtilisateur = true;
            hidePlanning = true;
            hideDossier = true;
            hideRdv = true;
            hideTransfert = true;

            if (AuthenticationViewModel.AuthenticatedUser.Role == "Chef Service")
            {
                hidePatients = false;
                hideHospitalisation = false;
                hideUtilisateur = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Médecin")
            {
                hidePatients = false;
                hideHospitalisation = false;
                hideUtilisateur = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Chef Hospitalisation")
            {
                hidePatients = false;
                hideMyPatients = false;
                hideDossier = false;
                hideRdv = false;
                hideTransfert = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Infirmier")
            {
                hidePatients = false;
                hideMyPatients = false;
                hideUtilisateur = false;
                hidePlanning = false;
                hideDossier = false;
                hideRdv = false;
                hideTransfert = false;
            }
            if (AuthenticationViewModel.AuthenticatedUser.Role == "Assistant")
            {
                hideHospitalisation = false;
                hideMyPatients = false;
                hideEducation = false;
                hideUtilisateur = false;
                hideDossier = false;
            }
        }

        
        #region HomeViewModel Variables
        
        public bool HidePatients
        {
            get
            {
                return hidePatients;
            }
            set
            {
                hidePatients = value;
                OnPropertyChanged("HidePatients");
            }
        }
        public bool HideHospitalisation
        {
            get
            {
                return hideHospitalisation;
            }
            set
            {
                hideHospitalisation = value;
                OnPropertyChanged("HideHospitalisation");
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
        public bool HideEducation
        {
            get
            {
                return hideEducation;
            }
            set
            {
                hideEducation = value;
                OnPropertyChanged("HideEducation");
            }
        }
        public bool HideUtilisateur
        {
            get
            {
                return hideUtilisateur;
            }
            set
            {
                hideUtilisateur = value;
                OnPropertyChanged("HideUtilisateur");
            }
        }
        public bool HidePlanning
        {
            get
            {
                return hidePlanning;
            }
            set
            {
                hidePlanning = value;
                OnPropertyChanged("HidePlanning");
            }
        }
        public bool HideDossier
        {
            get
            {
                return hideDossier;
            }
            set
            {
                hideDossier = value;
                OnPropertyChanged("HideDossier");
            }
        }
        public bool HideRdv
        {
            get
            {
                return hideRdv;
            }
            set
            {
                hideRdv = value;
                OnPropertyChanged("HideRdv");
            }
        }
        public bool HideTransfert
        {
            get
            {
                return hideTransfert;
            }
            set
            {
                hideTransfert = value;
                OnPropertyChanged("HideTransfert");
            }
        }

        public List<EducationContent> EducationContents { get { return ConsultationManager.ViewModels.BtnsVisibility.EducationContents.DataSource; } }
        public List<EmployeeContent> EmployeeContents { get { return ConsultationManager.ViewModels.BtnsVisibility.EmployeeContents.DataSource; } }

        #endregion

        #region HomeViewModel Commands


        #endregion

        #region HomeViewModel Methods



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

    public class EducationContent
    {
        public string HeaderCont { get; set; }
        public string TextCont { get; set; }
        public string Photo { get; set; }
        public ImageSource PhotoSource
        {
            get
            {
                return string.IsNullOrEmpty(Photo) ? null : new BitmapImage(new Uri(Photo, UriKind.Relative));
            }
        }
    }
    public static class EducationContents
    {
        public static readonly List<EducationContent> DataSource =
            new List<EducationContent> {
                new EducationContent { HeaderCont = "Education thérapeutique", TextCont = "Visualiser tous les rapport d'éducation thérapeutique", Photo = "/ConsultationManager;component/Imgs/Home/education.png" },
                new EducationContent { HeaderCont = "Education thérapeutique", TextCont = "Editer un rapport d'éducation thérapeutique", Photo = "/ConsultationManager;component/Imgs/Home/education-rapport.png" }
            };
    }
    
    public class EmployeeContent
    {
        public string HeaderCont { get; set; }
        public string TextCont { get; set; }
        public string Photo { get; set; }
        public ImageSource PhotoSource
        {
            get
            {
                return string.IsNullOrEmpty(Photo) ? null : new BitmapImage(new Uri(Photo, UriKind.Relative));
            }
        }
    }
    public static class EmployeeContents
    {
        public static readonly List<EmployeeContent> DataSource =
            new List<EmployeeContent> {
                new EmployeeContent { HeaderCont = "Utilisateurs", TextCont = "Afficher et modifier la liste des utilisateurs", Photo = "/ConsultationManager;component/Imgs/Home/staff.jpg" },
                new EmployeeContent { HeaderCont = "Accès", TextCont = "Controller les droits d'accès des utilisateurs", Photo = "/ConsultationManager;component/Imgs/Home/roles.png" }
            };
    }
}
