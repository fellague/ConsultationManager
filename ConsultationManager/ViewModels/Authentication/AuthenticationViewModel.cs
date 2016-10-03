using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using System.Windows.Controls;
using ConsultationManager.ServiceReferenceAuthentication;
using System.ServiceModel.Security;
using System.Windows;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.Views;

namespace ConsultationManagerClient.ViewModels.Authentication
{
    internal class AuthenticationViewModel : INotifyPropertyChanged
    {
        private string userName;
        private static Utilisateur authenticatedUser;


        public AuthenticationViewModel()
        {
            LoginCommad = new RelayCommand(param => Login(param));
        }

        

        #region AuthenticationViewModel Variables

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public static Utilisateur AuthenticatedUser
        {
            get
            {
                return authenticatedUser;
            }
        }

        #endregion

        #region AuthenticationViewModel Commands

        public ICommand LoginCommad
        {
            get;
            private set;
        }

        #endregion

        #region AuthenticationViewModel Methods

        private void Login(object param)
        {
            //var loginUser = new Utilisateur();
            PasswordBox pwBox = param as PasswordBox;
            AuthenticationServiceClient asc = new AuthenticationServiceClient();

            //asc.ClientCredentials.UserName.UserName = "mimouni";
            //asc.ClientCredentials.UserName.Password = "e8x_";
            if (String.IsNullOrEmpty(userName)|| String.IsNullOrEmpty(pwBox.Password))
            {
                MessageBox.Show("Vou devez fournir le Nom d'utilisateur et le Mot de passe");
            }
            else
            {
                asc.ClientCredentials.UserName.UserName = UserName;
                asc.ClientCredentials.UserName.Password = pwBox.Password;
                asc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                    X509CertificateValidationMode.None;

                authenticatedUser = asc.Authenticate(UserName, pwBox.Password);
                try
                {
                    if (authenticatedUser.Id != null)
                    {
                        Application.Current.MainWindow.Hide();
                        var form2 = new Home();
                        form2.Closed += (s, args) => Application.Current.MainWindow.Close();
                        form2.Show();
                        //foreach (Window win in App.Current.Windows)
                        //{
                        //    if (win.Tag.ToString() != "home")
                        //    {
                        //        win.Close();
                        //    }
                        //}
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Nom utilisateur ou Mot de Passe Erroné ");
                }
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
