using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Planning : INotifyPropertyChanged
    {
        private string consultationId;
        private ObservableCollection<string> medecinsDimanche;
        private ObservableCollection<string> medecinsLundi;
        private ObservableCollection<string> medecinsMardi;
        private ObservableCollection<string> medecinsMercredi;
        private ObservableCollection<string> medecinsJeudi;

        public Planning()
        {
            consultationId = "";
            medecinsDimanche = new ObservableCollection<string>();
            medecinsLundi = new ObservableCollection<string>();
            medecinsMardi = new ObservableCollection<string>();
            medecinsMercredi = new ObservableCollection<string>();
            medecinsJeudi = new ObservableCollection<string>();
        }

        [BsonId]
        public ObjectId _id { get; set; }

        [DataMember]
        public string Id
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        [DataMember]
        public string ConsultationId
        {
            get
            {
                return consultationId;
            }
            set
            {
                consultationId = value;
                OnPropertyChanged("ConsultationId");
            }
        }

        [DataMember]
        public ObservableCollection<string> MedecinsDimanche
        {
            get
            {
                return medecinsDimanche;
            }
            set
            {
                medecinsDimanche = value;
                OnPropertyChanged("MedecinsDimanche");
            }
        }
        [DataMember]
        public ObservableCollection<string> MedecinsLundi
        {
            get
            {
                return medecinsLundi;
            }
            set
            {
                medecinsLundi = value;
                OnPropertyChanged("MedecinsLundi");
            }
        }
        [DataMember]
        public ObservableCollection<string> MedecinsMardi
        {
            get
            {
                return medecinsMardi;
            }
            set
            {
                medecinsMardi = value;
                OnPropertyChanged("MedecinsMardi");
            }
        }
        [DataMember]
        public ObservableCollection<string> MedecinsMercredi
        {
            get
            {
                return medecinsMercredi;
            }
            set
            {
                medecinsMercredi = value;
                OnPropertyChanged("MedecinsMercredi");
            }
        }
        [DataMember]
        public ObservableCollection<string> MedecinsJeudi
        {
            get
            {
                return medecinsJeudi;
            }
            set
            {
                medecinsJeudi = value;
                OnPropertyChanged("MedecinsJeudi");
            }
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