using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class RDV : INotifyPropertyChanged
    {
        private string patientId;
        private string medecinRespId;
        private DateTime dateRdv;
        private int rang;
        private bool dejaFait;
        private DateTime creeDans;
        private string creePar;

        private string serviceId;
        private string pathologieId;
        private bool nouvPat;

        public RDV()
        {
            patientId = "";
            medecinRespId = "";
            dateRdv = new DateTime();
            rang = 1;
            dejaFait = false;
            creeDans = new DateTime();
            creePar = "";

            serviceId = "";
            pathologieId = "";
            nouvPat = true;
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
        public string PatientId
        {
            get
            {
                return patientId;
            }
            set
            {
                patientId = value;
                OnPropertyChanged("PatientId");
            }
        }

        [DataMember]
        public string MedecinRespId
        {
            get
            {
                return medecinRespId;
            }
            set
            {
                medecinRespId = value;
                OnPropertyChanged("MedecinRespId");
            }
        }

        [DataMember]
        public DateTime DateRdv
        {
            get
            {
                return dateRdv;
            }
            set
            {
                dateRdv = value;
                OnPropertyChanged("DateRdv");
            }
        }

        [DataMember]
        public int Rang
        {
            get
            {
                return rang;
            }
            set
            {
                rang = value;
                OnPropertyChanged("Rang");
            }
        }

        [DataMember]
        public bool DejaFait
        {
            get
            {
                return dejaFait;
            }
            set
            {
                dejaFait = value;
                OnPropertyChanged("DejaFait");
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

        [DataMember]
        public string ServiceId
        {
            get
            {
                return serviceId;
            }
            set
            {
                serviceId = value;
                OnPropertyChanged("ServiceId");
            }
        }
        [DataMember]
        public string PathologieId
        {
            get
            {
                return pathologieId;
            }
            set
            {
                pathologieId = value;
                OnPropertyChanged("PathologieId");
            }
        }

        [DataMember]
        public bool NouvPat
        {
            get
            {
                return nouvPat;
            }
            set
            {
                nouvPat = value;
                OnPropertyChanged("NouvPat");
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
