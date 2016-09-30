using ConsultationManager.ServiceReferenceConclusion;
using ConsultationManager.ServiceReferenceHospit;
using ConsultationManager.ServiceReferenceInterview;
using ConsultationManager.Views.DossierMedicals;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.Hospitalisations;
using ConsultationManagerServer.Models.SerializedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConsultationManager.ViewModels.DossierMedicals
{
    class DossierMedViewModel : INotifyPropertyChanged
    {
        private DossierMedDetail dossier;

        private Conclusion selectedConcl;
        private DetailInterviewWindow interviewDetailWindow;
        private InterviewDetail interviewDetail;
        private DetailFirstInterviewWindow firstInterviewDetailWindow;
        private DetailFirstIntervExamWindow firstIntervExamDetailWindow;
        private DetailFirstConclWindow detailFirstConclWindow;

        private HospitalisationDetail selectHosp;
        private DetailHospitWindow detailHospitWindow;
        private List<Point> pointsPoids;
        private List<Point> pointsTA;
        private List<Point> pointsTemperature;
        private List<Point> pointsGlycemique;

        private InterviewServiceClient isc = new InterviewServiceClient();
        private ConclusionServiceClient csc = new ConclusionServiceClient();
        private HospitServiceClient hsc = new HospitServiceClient();

        public DossierMedViewModel(DossierMedDetail doss)
        {
            isc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            isc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            isc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            csc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            csc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            csc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            hsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            hsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            hsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            dossier = doss;


            DetailIntervDialogCommand = new RelayCommand(param => ShowDialogInterviewDetail(param));
            ShowExamenDetailWindowCommand = new RelayCommand(param => ShowDialogFirstExamenDetail(param));
            ShowFirstConclDetailWindowCommand = new RelayCommand(param => ShowDialogFirstConclusionDetail(param));
            UpdateCompteRendu = new RelayCommand(param => ModifierCompteRendu());

            DetailHospitDialogCommand = new RelayCommand(param => ShowDialogHospitDetail(param));
            //UpdateCompteRenduHospit = new RelayCommand(param => ModifierCompteRenduHosp());
            DetailIntervHospDialogCommand = new RelayCommand(param => ShowDialogIntervHospDetail(param));
        }

        #region DossierMedViewModel Variables

        public DossierMedDetail Dossier
        {
            get
            {
                return dossier;
            }
            set
            {
                dossier = value;
                OnPropertyChanged("Dossier");
            }
        }
        public Conclusion SelectConcl
        {
            get
            {
                return selectedConcl;
            }
            set
            {
                selectedConcl = value;
                OnPropertyChanged("SelectConcl");
            }
        }
        public HospitalisationDetail SelectHosp
        {
            get
            {
                return selectHosp;
            }
            set
            {
                selectHosp = value;
                OnPropertyChanged("SelectHosp");
            }
        }
        public InterviewDetail InterviewDetail
        {
            get
            {
                return interviewDetail;
            }
            set
            {
                interviewDetail = value;
                OnPropertyChanged("InterviewDetail");
            }
        }
        public List<Point> PointsPoids
        {
            get
            {
                return pointsPoids;
            }
            set
            {
                pointsPoids = value;
                OnPropertyChanged("PointsPoids");
            }
        }
        public List<Point> PointsTA
        {
            get
            {
                return pointsTA;
            }
            set
            {
                pointsTA = value;
                OnPropertyChanged("PointsTA");
            }
        }
        public List<Point> PointsTemperature
        {
            get
            {
                return pointsTemperature;
            }
            set
            {
                pointsTemperature = value;
                OnPropertyChanged("PointsTemperature");
            }
        }
        public List<Point> PointsGlycemique
        {
            get
            {
                return pointsGlycemique;
            }
            set
            {
                pointsGlycemique = value;
                OnPropertyChanged("PointsGlycemique");
            }
        }

        #endregion

        #region DossierMedViewModel Commands

        public ICommand DetailIntervDialogCommand
        {
            get;
            private set;
        }
        public ICommand DetailIntervHospDialogCommand
        {
            get;
            private set;
        }

        public ICommand DetailHospitDialogCommand
        {
            get;
            private set;
        }

        public ICommand ShowExamenDetailWindowCommand
        {
            get;
            private set;
        }
        public ICommand ShowFirstConclDetailWindowCommand
        {
            get;
            private set;
        }
        public ICommand UpdateCompteRendu
        {
            get;
            private set;
        }
        //public ICommand UpdateCompteRenduHospit
        //{
        //    get;
        //    private set;
        //}

        #endregion

        #region DossierMedViewModel Methods

        private void ShowDialogInterviewDetail(object param)
        {
            SelectConcl = param as Conclusion;
            if(Dossier.ConclusionsInterview.IndexOf(SelectConcl) == 0)
            {
                firstInterviewDetailWindow = new DetailFirstInterviewWindow();
                firstInterviewDetailWindow.DataContext = this;
                firstInterviewDetailWindow.ShowDialog();
            }
            else
            {
                interviewDetail = isc.GetInterview(SelectConcl.IdRdv);
                interviewDetailWindow = new DetailInterviewWindow();
                interviewDetailWindow.DataContext = this;
                interviewDetailWindow.ShowDialog();
            }
        }

        private void ShowDialogHospitDetail(object param)
        {
            SelectConcl = param as Conclusion;
            selectHosp = hsc.GetHospit(SelectConcl.Id);

            pointsPoids = new List<Point>();
            pointsTA = new List<Point>();
            pointsTemperature = new List<Point>();
            pointsGlycemique = new List<Point>();
            foreach (Mesure item in SelectHosp.FichePoids)
            {
                pointsPoids.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheTA)
            {
                pointsTA.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheTemperature)
            {
                pointsTemperature.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheGlycemique)
            {
                pointsGlycemique.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }

            detailHospitWindow = new DetailHospitWindow();
            detailHospitWindow.DataContext = this;
            detailHospitWindow.ShowDialog();
        }

        private void ShowDialogIntervHospDetail(object param)
        {
            interviewDetail = isc.GetInterview(SelectConcl.IdRdv);
            interviewDetailWindow = new DetailInterviewWindow();
            interviewDetailWindow.DataContext = this;
            interviewDetailWindow.ShowDialog();
        }

        private void ShowDialogFirstExamenDetail(object param)
        {
            firstInterviewDetailWindow.Close();
            firstIntervExamDetailWindow = new DetailFirstIntervExamWindow();
            firstIntervExamDetailWindow.DataContext = this;
            firstIntervExamDetailWindow.ShowDialog();
        }

        private void ShowDialogFirstConclusionDetail(object param)
        {
            firstIntervExamDetailWindow.Close();
            detailFirstConclWindow = new DetailFirstConclWindow();
            detailFirstConclWindow.DataContext = this;
            detailFirstConclWindow.ShowDialog();
        }

        private void ModifierCompteRendu()
        {
            SelectConcl = csc.UpdateConclusion(SelectConcl);
            MessageBox.Show("Le Compte Rendu a été Modifié ");
        }

        //private void ModifierCompteRenduHosp()
        //{
        //    SelectHosp.Conclusion = csc.UpdateConclusion(SelectHosp.Conclusion);
        //    MessageBox.Show("Le Compte Rendu de l'Hospitalisation a été Modifié ");
        //}

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

    public class Point
    {
        public Point()
        {
            X = "";
            Y = 0;
        }
        public string X { get; set; }
        public float Y { get; set; }
    }
}
