using System.Collections.ObjectModel;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using RestSharp;
using System.Net;
using System.Windows;
using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Bson;
using DevExpress.Mvvm;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.Views.Pathologies;
using System.Windows.Threading;
using RestSharp.Authenticators;
using System.ServiceModel.Security;
using ConsultationManagerClient.Properties;
using ConsultationManager.ServiceReferencePathologie;

namespace ConsultationManagerClient.ViewModels.Pathologies
{
    internal class PathologiesViewModel : INotifyPropertyChanged
    {


        private RestClient client = new RestClient("http://localhost:64183/");
        private Service service;
        private Service cloneService;
        private ObservableCollection<Pathologie> listPathologies;

        private string newTelephone;

        private UpdatePathologieWindow dialogUpdatePathol;
        private Pathologie updatedPathologie;

        private NewPathologieWindow dialogNewPathol;
        private Pathologie newPathologie;

        public PathologiesViewModel()
        {
            service = new Service();
            listPathologies = new ObservableCollection<Pathologie>();

            newTelephone = "";

            //client.ClientCertificates = new X509CertificateValidationMode();
            client.Authenticator = new HttpBasicAuthenticator("yow", "123");
            GetServicePathologies();

            AddTelephoneCommand = new RelayCommand(param => AjouterTelephone());
            RemoveTelephoneCommand = new RelayCommand(param => DeleteTelephone(param));

            UpdatePathologieDialogCommand = new RelayCommand(param => this.ShowDialogUpdatePathologie(param));
            RemovePathologieCommand = new RelayCommand(param => DeletePathologie(param));
            NewPathologieDialogCommand = new RelayCommand(param => ShowDialogNewPathologie());

            UpdateServiceCommand = new RelayCommand(param => UpdateService());
        }

        #region ConsultationViewModel Variables
        
        public Service Service
        {
            get
            {
                return service;
            }
            set
            {
                service = value;
                OnPropertyChanged("Service");
            }
        }

        public ObservableCollection<Pathologie> ListPathologies
        {
            get
            {
                return listPathologies;
            }
            set
            {
                listPathologies = value;
                OnPropertyChanged("ListPathologies");
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

        public UpdatePathologieWindow DialogUpdatePathol
        {
            get
            {
                return dialogUpdatePathol;
            }
        }
        public Pathologie UpdatedPathologie
        {
            get
            {
                return updatedPathologie;
            }
            set
            {
                updatedPathologie = value;
                OnPropertyChanged("UpdatedPathologie");
            }
        }

        public NewPathologieWindow DialogNewPathol
        {
            get
            {
                return dialogNewPathol;
            }
        }
        public Pathologie NewPathologie
        {
            get
            {
                return newPathologie;
            }
            set
            {
                newPathologie = value;
                OnPropertyChanged("NewPathologie");
            }
        }

        #endregion

        #region PathologiesViewModel Commands

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

        public ICommand UpdatePathologieDialogCommand
        {
            get;
            private set;
        }
        public ICommand UpdatePathologieCommand
        {
            get;
            private set;
        }
        public ICommand RemovePathologieCommand
        {
            get;
            private set;
        }
        public ICommand NewPathologieDialogCommand
        {
            get;
            private set;
        }
        public ICommand AddPathologieCommand
        {
            get;
            private set;
        }

        public ICommand UpdateServiceCommand
        {
            get;
            private set;
        }

        #endregion

        #region PathologiesViewModel Methodes

        private void GetServicePathologies()
        {
            //ServicePathologies servPatholog = new ServicePathologies();
            //var request = new RestRequest("ServicePathologies", Method.GET) { RequestFormat = RestSharp.DataFormat.Json };
            //try
            //{
            //    client.ExecuteAsync<ServicePathologies>(request, response =>
            //    {
            //        if (response.StatusCode == HttpStatusCode.OK)
            //        {
            //            //MessageBox.Show("There is a content for the response... "+response.Content);
            //            servPatholog = JsonConvert.DeserializeObject<ServicePathologies>(response.Content);
            //            Service = servPatholog.Service;
            //            cloneService = Service;
            //            ListPathologies = servPatholog.ListPthologie;
            //            if (ListPathologies.Count == 0)
            //                MessageBox.Show("There is 0 Pathologies...");
            //        }
            //        else
            //        {
            //            if (response.StatusCode == HttpStatusCode.NotFound)
            //                MessageBox.Show("404 : The ressource dose not exist...");

            //            else
            //                MessageBox.Show("Une Exeption est apparut..." + response.s);
            //        }

            //        //switch (response.StatusCode)
            //        //{
            //        //    case HttpStatusCode.OK:
            //        //        ListPathologies = JsonConvert.DeserializeObject<ObservableCollection<Pathologie>>(response.Content);
            //        //        break;
            //        //    case HttpStatusCode.NoContent:
            //        //        MessageBox.Show("There is 0 Pathologies...");
            //        //        break;
            //        //    default:
            //        //        MessageBox.Show("404 : The ressource dose not exist...");
            //        //        break;
            //        //}
            //    });
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("An Exeption has accured" + error);
            //}

            ServicePathologies servPatholog = new ServicePathologies();

            PathologieServiceClient psc = new PathologieServiceClient();
            psc.ClientCredentials.UserName.UserName = "yoww";
            psc.ClientCredentials.UserName.Password = "123";
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            servPatholog = psc.GetServiceDetails();
            Service = servPatholog.Service;
            cloneService = Service;
            ListPathologies = servPatholog.ListPthologie;
            if (ListPathologies.Count == 0)
                MessageBox.Show("There is 0 Pathologies...");
             
        }

        public void AjouterTelephone()
        {
            //var newCsl = csl as string;
            if (newTelephone != "")
            {
                service.Telephones.Add(newTelephone);
                NewTelephone = "";
            }

        }
        public void DeleteTelephone(object selectedTelephone)
        {
            Console.WriteLine("PathologiesViewModel : Remove Telephone  ");
            var telephone = selectedTelephone as string;
            service.Telephones.Remove(telephone);
        }

        public void ShowDialogUpdatePathologie(object selectedPathologie)
        {
            var patholog = selectedPathologie as Pathologie;
            Console.WriteLine("PathologiesViewModel : Dialog opened with Pathologie  " + patholog.Nom);
            dialogUpdatePathol = new UpdatePathologieWindow();
            dialogUpdatePathol.DataContext = this;
            updatedPathologie = patholog;
            UpdatePathologieCommand = new RelayCommand(param => ModifierPathologie(param));
            dialogUpdatePathol.ShowDialog();
        }
        public void ModifierPathologie(object pathol)
        {
            var updatePatholog = pathol as Pathologie;
            Console.WriteLine("PathologiesViewModel : Dialog Closed with Pathologie  " + updatePatholog.Nom);
            dialogUpdatePathol.Close();

            var request = new RestRequest("ServicePathologies/Pathologies/{id}", Method.PUT) { RequestFormat = RestSharp.DataFormat.Json };
            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var json = JsonConvert.SerializeObject(updatePatholog, microsoftDateFormatSettings);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.AddParameter("id", updatedPathologie.Id, ParameterType.UrlSegment);
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //MessageBox.Show("Client response : Pathologie have been saved... " + response.Content);
                        Pathologie patholSave = JsonConvert.DeserializeObject<Pathologie>(response.Content);
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => ListPathologies.Add(patholSave)));
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            MessageBox.Show("404 : The ressource dose not exist...");
                        else
                            MessageBox.Show("Une Exeption est apparut...");
                    }
                });
            }
            catch (Exception error)
            {
                MessageBox.Show("An Exeption has accured" + error.Message);
            }
        }
        public void DeletePathologie(object selectedPathologie)
        {
            Console.WriteLine("PathologiesViewModel : Remove Pathologie  ");
            var pathol = selectedPathologie as Pathologie;
            //listPathologies.Remove(pathol);

            var request = new RestRequest("ServicePathologies/Pathologies/{id}", Method.DELETE) { RequestFormat = RestSharp.DataFormat.Json };
            request.AddParameter("id", pathol.Id, ParameterType.UrlSegment);
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Console.WriteLine("ContentElement  " + response.Content);
                        MessageBox.Show("Pathologie is deleted... ");
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => listPathologies.Remove(pathol)));
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            MessageBox.Show("404 : The ressource dose not exist...");

                        else
                            MessageBox.Show("Une Exeption est apparut...");
                    }

                    //switch (response.StatusCode)
                    //{
                    //    case HttpStatusCode.OK:
                    //        ListPathologies = JsonConvert.DeserializeObject<ObservableCollection<Pathologie>>(response.Content);
                    //        break;
                    //    case HttpStatusCode.NoContent:
                    //        MessageBox.Show("There is 0 Pathologies...");
                    //        break;
                    //    default:
                    //        MessageBox.Show("404 : The ressource dose not exist...");
                    //        break;
                    //}
                });
            }
            catch (Exception error)
            {
                MessageBox.Show("An Exeption has accured" + error);
            }
        }
        public void ShowDialogNewPathologie()
        {
            dialogNewPathol = new NewPathologieWindow();
            dialogNewPathol.DataContext = this;
            newPathologie = new Pathologie();
            AddPathologieCommand = new RelayCommand(param => AjouterPathologie());
            dialogNewPathol.ShowDialog();
        }
        public void AjouterPathologie()
        {
            dialogNewPathol.Close();

            newPathologie.IdService = service.Id;
            
            //ListPathologies.Add(newPathologie);

            var request = new RestRequest("ServicePathologies/Pathologies", Method.POST) { RequestFormat = RestSharp.DataFormat.Json };
            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var json = JsonConvert.SerializeObject(newPathologie, microsoftDateFormatSettings);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //MessageBox.Show("Client response : Pathologie have been saved... " + response.Content);
                        Pathologie patholSave = JsonConvert.DeserializeObject<Pathologie>(response.Content);
                        //MessageBox.Show("Client response : Pathologie have been saved... " + patholSave.Nom + " " + patholSave.Description);
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => ListPathologies.Add(patholSave)));
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            MessageBox.Show("404 : The ressource dose not exist...");
                        else
                            MessageBox.Show("Une Exeption est apparut...");
                    }
                });
            }
            catch (Exception error)
            {
                MessageBox.Show("An Exeption has accured" + error.Message);
            }
        }

        private void UpdateService()
        {
            
            var request = new RestRequest("ServicePathologies/{id}", Method.PUT) { RequestFormat = RestSharp.DataFormat.Json };
            request.AddParameter("id", service.Id, ParameterType.UrlSegment);
            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            var json = JsonConvert.SerializeObject(service, microsoftDateFormatSettings);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //MessageBox.Show("Client response : Pathologie have been saved... " + response.Content);
                        Service serviceSave = JsonConvert.DeserializeObject<Service>(response.Content);
                        MessageBox.Show("Client response : Service have been saved... " + serviceSave.Nom);
                        //Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => ));
                    }
                    else
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => Service = cloneService));
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            MessageBox.Show("404 : The ressource dose not exist...");
                        else
                            MessageBox.Show("Une Exeption est apparut...");
                    }
                });
            }
            catch (Exception error)
            {
                MessageBox.Show("An Exeption has accured" + error.Message);
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
