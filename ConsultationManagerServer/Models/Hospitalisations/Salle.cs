using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.Hospitalisations
{
    [DataContract]
    public class Salle : INotifyPropertyChanged
    {
        private string nom;
        private string type;
        private int nbLit;

        private string idService;

        private DateTime creeDans;
        private string creePar;

        public Salle()
        {
            nom = "";
            type = "";
            nbLit = 1;

            idService = "";

            creeDans = new DateTime();
            creePar = "";
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
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
                OnPropertyChanged("Nom");
            }
        }

        [DataMember]
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        
        [DataMember]
        public int NbLit
        {
            get
            {
                return nbLit;
            }
            set
            {
                nbLit = value;
                OnPropertyChanged("NbLit");
            }
        }

        [DataMember]
        public string IdService
        {
            get
            {
                return idService;
            }
            set
            {
                idService = value;
                OnPropertyChanged("IdService");
            }
        }

        [DataMember]
        public DateTime CreeDans
        {
            get
            {
                return creeDans;
            }
            set
            {
                creeDans = value;
                OnPropertyChanged("CreeDans");
            }
        }

        [DataMember]
        public string CreePar
        {
            get
            {
                return creePar;
            }
            set
            {
                creePar = value;
                OnPropertyChanged("CreePar");
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