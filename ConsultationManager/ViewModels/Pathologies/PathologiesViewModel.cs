using System.Collections.ObjectModel;
using ConsultationManagerServer.Models;
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

namespace ConsultationManagerClient.ViewModels.Pathologies
{
    internal class PathologiesViewModel : INotifyPropertyChanged
    {


        private RestClient client = new RestClient("http://localhost:64183/");
        private ObservableCollection<Pathologie> listPathologies;
        private Service service;

        public PathologiesViewModel()
        {
            listPathologies = new ObservableCollection<Pathologie>();
            service = new Service();
            //service.Nom = "Endochrinoe";
            //service.DateOuverture = DateTime.Now;
            //service.Domaine = "dkjsc sdlksc sdlksc sdlksd lksd dlk sdlksd sdlksd sdlksd sdclksd lksd sdlksd sdlkn cdlksd dlkze sdlkn sdsdnd sdlk";
            //service.Adresse = "Chlef hay essalem n 3";
            //service.Telephones.Add("021 87 54 43");
            //service.Telephones.Add("021 27 53 43");

            GetPathologies();
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

        private void GetPathologies()
        {
            var request = new RestRequest("Pathologies", Method.GET) { RequestFormat = RestSharp.DataFormat.Json };
            try
            {
                client.ExecuteAsync<Service>(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        MessageBox.Show("There is a content for the response... "+response.Content);
                        //MessageBox.Show("There is a content for the response... " + response.Data.Nom);

                        Service = JsonConvert.DeserializeObject<Service>(response.Content);
                        //MessageBox.Show("There is a content for the response... " + service.Nom + "  "+service.Pathologies[0].Nom);
                        //if (listPathologies.Count == 0)
                        //    MessageBox.Show("There is 0 Pathologies...");
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

            //ObservableCollection<Pathologie> list = new ObservableCollection<Pathologie>();
            //list.Add(new Pathologie("Thyroide", "c'est une patholgie qui tklcs lj djlsjd sdflkjds lskdjns clkcd cdkljcd sdlk"));
            //list.Add(new Pathologie("Cancer", "lkqskxc okqsxl qslkqskl xkl,xs xlkx xlk poqpx qsozaf sdzeed"));
            //list.Add(new Pathologie("Diabetre", "zsdef sdlk sdcl,k cdmlksd epoied ioue oiusd diou"));
            //list.Add(new Pathologie("Cardiologue", "oeuzi ezioefz eoiuef epfoize fpoiezpo zefoizef ezofioe zefoiuez zefiouez"));
            //list.Add(new Pathologie("Poumon", "efzke eoizef zefoief zeoif zelfe zeflkeff zeklef elkjef zeflkj"));
            //return list;
        }
        

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
