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
    public class DemandeHospit : INotifyPropertyChanged
    {
        private string idPatient;
        private string idMedecin;
        private string idIntervConclus;
        private string idHospit;

        private string idRdv;
        private string serviceId;

        private string motif;
        private string traitement;
        private string nbJours;
        private string urgence;

        private DateTime creeDans;
        private string creePar;

        public DemandeHospit()
        {
            idPatient = "";
            idMedecin = "";
            idIntervConclus = "";
            idHospit = "";

            idRdv = "";
            serviceId = "";

            motif = "";
            traitement = "";
            nbJours = "";
            urgence = "";
            
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
        public string IdPatient
        {
            get
            {
                return idPatient;
            }
            set
            {
                idPatient = value;
                OnPropertyChanged("IdPatient");
            }
        }

        [DataMember]
        public string IdMedecin
        {
            get
            {
                return idMedecin;
            }
            set
            {
                idMedecin = value;
                OnPropertyChanged("IdMedecin");
            }
        }

        [DataMember]
        public string IdRdv
        {
            get
            {
                return idRdv;
            }
            set
            {
                idRdv = value;
                OnPropertyChanged("IdRdv");
            }
        }

        [DataMember]
        public string IdIntervConclus
        {
            get
            {
                return idIntervConclus;
            }
            set
            {
                idIntervConclus = value;
                OnPropertyChanged("IdInterview");
            }
        }

        [DataMember]
        public string IdHospit
        {
            get
            {
                return idHospit;
            }
            set
            {
                idHospit = value;
                OnPropertyChanged("IdHospit");
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
        public string Traitement
        {
            get
            {
                return traitement;
            }
            set
            {
                traitement = value;
                OnPropertyChanged("Traitement");
            }
        }

        [DataMember]
        public string NbJours
        {
            get
            {
                return nbJours;
            }
            set
            {
                nbJours = value;
                OnPropertyChanged("NbJours");
            }
        }

        [DataMember]
        public string Urgence
        {
            get
            {
                return urgence;
            }
            set
            {
                urgence = value;
                OnPropertyChanged("Urgence");
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