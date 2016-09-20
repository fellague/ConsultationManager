using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models.Hospitalisations
{
    [DataContract]
    public class Hospitalisation : INotifyPropertyChanged
    {
        private string idPatient;
        private string idMedecin;
        private string idConclusion;

        private string idSalle;
        private string lit;
        private DateTime dateDebut;
        private DateTime dateFinPrevu;
        private DateTime dateFinReel;

        private ObservableCollection<string> ficheTA;
        private ObservableCollection<string> fichePoids;
        private ObservableCollection<string> ficheTemperature;
        private ObservableCollection<string> ficheGlycemique;

        private DateTime creeDans;
        private string creePar;

        public Hospitalisation()
        {
            idPatient = "";
            idMedecin = "";
            idConclusion = "";

            idSalle = "";
            lit = "";
            dateDebut = new DateTime();
            dateFinPrevu = new DateTime();
            dateFinReel = new DateTime();

            ficheTA = new ObservableCollection<string>();
            fichePoids = new ObservableCollection<string>();
            ficheTemperature = new ObservableCollection<string>();
            ficheGlycemique = new ObservableCollection<string>();

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
        public string IdSalle
        {
            get
            {
                return idSalle;
            }
            set
            {
                idSalle = value;
                OnPropertyChanged("IdSalle");
            }
        }

        [DataMember]
        public string Lit
        {
            get
            {
                return lit;
            }
            set
            {
                lit = value;
                OnPropertyChanged("Lit");
            }
        }

        [DataMember]
        public DateTime DateDebut
        {
            get
            {
                return dateDebut;
            }
            set
            {
                dateDebut = value;
                OnPropertyChanged("DateDebut");
            }
        }

        [DataMember]
        public DateTime DateFinPrevu
        {
            get
            {
                return dateFinPrevu;
            }
            set
            {
                dateFinPrevu = value;
                OnPropertyChanged("DateFinPrevu");
            }
        }

        [DataMember]
        public DateTime DateFinReel
        {
            get
            {
                return dateFinReel;
            }
            set
            {
                dateFinReel = value;
                OnPropertyChanged("DateFinReel");
            }
        }

        [DataMember]
        public ObservableCollection<string> FicheTA
        {
            get
            {
                return ficheTA;
            }
            set
            {
                ficheTA = value;
                OnPropertyChanged("FicheTA");
            }
        }
        [DataMember]
        public ObservableCollection<string> FichePoids
        {
            get
            {
                return fichePoids;
            }
            set
            {
                fichePoids = value;
                OnPropertyChanged("FichePoids");
            }
        }
        [DataMember]
        public ObservableCollection<string> FicheTemperature
        {
            get
            {
                return ficheTemperature;
            }
            set
            {
                ficheTemperature = value;
                OnPropertyChanged("FicheTemperature");
            }
        }
        [DataMember]
        public ObservableCollection<string> FicheGlycemique
        {
            get
            {
                return ficheGlycemique;
            }
            set
            {
                ficheGlycemique = value;
                OnPropertyChanged("FicheGlycemique");
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
