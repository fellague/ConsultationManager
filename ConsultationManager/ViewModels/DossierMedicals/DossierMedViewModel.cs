using ConsultationManager.ServiceReferenceConclusion;
using ConsultationManager.ServiceReferenceInterview;
using ConsultationManager.Views.DossierMedicals;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models;
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

        private Conclusion selectedIntevConcl;
        private DetailInterviewWindow interviewDetailWindow;
        private InterviewDetail interviewDetail;
        private DetailFirstInterviewWindow firstInterviewDetailWindow;
        private DetailFirstIntervExamWindow firstIntervExamDetailWindow;
        private DetailFirstConclWindow detailFirstConclWindow;

        private InterviewServiceClient isc = new InterviewServiceClient();
        private ConclusionServiceClient csc = new ConclusionServiceClient();

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

            dossier = doss;

            DetailIntervDialogCommand = new RelayCommand(param => ShowDialogInterviewDetail(param));
            ShowExamenDetailWindowCommand = new RelayCommand(param => ShowDialogFirstExamenDetail(param));
            ShowFirstConclDetailWindowCommand = new RelayCommand(param => ShowDialogFirstConclusionDetail(param));
            UpdateCompteRendu = new RelayCommand(param => ModifierCompteRendu());
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
        public Conclusion SelectedIntevConcl
        {
            get
            {
                return selectedIntevConcl;
            }
            set
            {
                selectedIntevConcl = value;
                OnPropertyChanged("SelectedIntevConcl");
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

        #endregion

        #region DossierMedViewModel Commands

        public ICommand DetailIntervDialogCommand
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

        #endregion

        #region DossierMedViewModel Methods

        private void ShowDialogInterviewDetail(object param)
        {
            selectedIntevConcl = param as Conclusion;
            if(Dossier.ConclusionsInterview.IndexOf(selectedIntevConcl) == 0)
            {
                firstInterviewDetailWindow = new DetailFirstInterviewWindow();
                firstInterviewDetailWindow.DataContext = this;
                firstInterviewDetailWindow.ShowDialog();
            }
            else
            {
                interviewDetail = isc.GetInterview(selectedIntevConcl.IdRdv);
                interviewDetailWindow = new DetailInterviewWindow();
                interviewDetailWindow.DataContext = this;
                interviewDetailWindow.ShowDialog();
            }
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
            SelectedIntevConcl = csc.UpdateConclusion(SelectedIntevConcl);
            MessageBox.Show("Le Compte Rendu a été Modifié ");
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
