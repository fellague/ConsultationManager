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
    public class Intervention : INotifyPropertyChanged
    {
        private string idHospitalisation;

        private string motif;
        private string description;
        
        private DateTime creeDans;
        private string creePar;

        public Intervention()
        {
            idHospitalisation = "";

            motif = "";
            description = "";
            
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
        public string IdHospitalisation
        {
            get
            {
                return idHospitalisation;
            }
            set
            {
                idHospitalisation = value;
                OnPropertyChanged("IdHospitalisation");
            }
        }

        [DataMember]
        public string Motif
        {
            get
            {
                return motif;
            }
            set
            {
                motif = value;
                OnPropertyChanged("Motif");
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
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