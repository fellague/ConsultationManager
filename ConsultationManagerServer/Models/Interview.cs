using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Interview : INotifyPropertyChanged
    {
        private ObservableCollection<AntecedentPersonel> commentsPatient;
        private ObservableCollection<RemarqueMedecin> remarquesMedecin;
        //private FileStream tests;
        private string poids;
        private string ta;
        private string tension;
        private string temperature;
        private string taille;

        private string idPatient;
        private string idMedecin;
        private string idConclusion;

        private DateTime creeDans;
        private string creePar;


        public Interview()
        {
            this.commentsPatient = new ObservableCollection<AntecedentPersonel>();
            this.remarquesMedecin = new ObservableCollection<RemarqueMedecin>();
            this.poids = "";
            this.ta = "";
            this.tension = "";
            this.temperature = "";
            this.taille = "";

            idPatient = "";
            idMedecin = "";
            idConclusion = "";

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
        public ObservableCollection<AntecedentPersonel> CommentsPatient
        {
            get
            {
                return commentsPatient;
            }
        }

        [DataMember]
        public ObservableCollection<RemarqueMedecin> RemarquesMedecin
        {
            get
            {
                return remarquesMedecin;
            }
        }

        [DataMember]
        public string Poids
        {
            get
            {
                return poids;
            }
        }

        [DataMember]
        public string TA
        {
            get
            {
                return ta;
            }
        }

        [DataMember]
        public string Tension
        {
            get
            {
                return tension;
            }
        }

        [DataMember]
        public string Temperature
        {
            get
            {
                return temperature;
            }
        }

        [DataMember]
        public string Taille
        {
            get
            {
                return taille;
            }
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
        public string IdConclusion
        {
            get
            {
                return idConclusion;
            }
            set
            {
                idConclusion = value;
                OnPropertyChanged("IdConclusion");
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
