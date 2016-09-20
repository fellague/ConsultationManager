using ConsultationManagerServer.Models.DossierMedicale;
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
        private string numero;

        private ObservableCollection<AntecedentPersonel> commentsPatient;
        private ObservableCollection<RemarqueMedecin> remarquesMedecin;
        private string poids;
        private string ta;
        private string temperature;
        private string taille;
        //private FileStream tests;
        private Bilan bilan;

        private string idPatient;
        private string idMedecin;
        private string idConclusion;
        private string idRdv;

        private DateTime creeDans;
        private string creePar;


        public Interview()
        {
            this.commentsPatient = new ObservableCollection<AntecedentPersonel>();
            this.remarquesMedecin = new ObservableCollection<RemarqueMedecin>();
            this.poids = "";
            this.ta = "";
            this.numero = "";
            this.temperature = "";
            this.taille = "";

            bilan = new Bilan();

            idPatient = "";
            idMedecin = "";
            idConclusion = "";
            idRdv = "";

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
        public string Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
                OnPropertyChanged("Numero");
            }
        }

        [DataMember]
        public ObservableCollection<AntecedentPersonel> CommentsPatient
        {
            get
            {
                return commentsPatient;
            }
            set
            {
                commentsPatient = value;
                OnPropertyChanged("CommentsPatient");
            }
        }

        [DataMember]
        public ObservableCollection<RemarqueMedecin> RemarquesMedecin
        {
            get
            {
                return remarquesMedecin;
            }
            set
            {
                remarquesMedecin = value;
                OnPropertyChanged("RemarquesMedecin");
            }
        }

        [DataMember]
        public string Poids
        {
            get
            {
                return poids;
            }
            set
            {
                poids = value;
                OnPropertyChanged("Poids");
            }
        }

        [DataMember]
        public string TA
        {
            get
            {
                return ta;
            }
            set
            {
                ta = value;
                OnPropertyChanged("TA");
            }
        }
        
        [DataMember]
        public string Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        [DataMember]
        public string Taille
        {
            get
            {
                return taille;
            }
            set
            {
                taille = value;
                OnPropertyChanged("Taille");
            }
        }
        
        [DataMember]
        public Bilan Bilan
        {
            get
            {
                return bilan;
            }
            set
            {
                bilan = value;
                OnPropertyChanged("Bilan");
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
