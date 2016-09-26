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
        private string idDemande;
        private string serviceId;

        private string idSalle;
        private int lit;
        private DateTime dateDebutPrevu;
        private DateTime dateDebutReel;
        private DateTime dateFinPrevu;
        private DateTime dateFinReel;

        private GardeMalade garde;

        private ObservableCollection<string> idSalleChanges;
        private ObservableCollection<string> idInterventions;
        //private ObservableCollection<string> idGardesMalade;

        private ObservableCollection<string> idMesuresFicheTA;
        private ObservableCollection<string> idMesuresFichePoids;
        private ObservableCollection<string> idMesuresFicheTemperature;
        private ObservableCollection<string> idMesuresFicheGlycemique;

        private DateTime creeDans;
        private string creePar;

        public Hospitalisation()
        {
            idPatient = "";
            idMedecin = "";
            idConclusion = "";
            idDemande = "";
            serviceId = "";

            idSalle = "";
            lit = 1;
            dateDebutPrevu = new DateTime();
            dateDebutReel = new DateTime();
            dateFinPrevu = new DateTime();
            dateFinReel = new DateTime();

            garde = new GardeMalade();

            idSalleChanges = new ObservableCollection<string>();
            idInterventions = new ObservableCollection<string>();
            //idGardesMalade = new ObservableCollection<string>();

            idMesuresFicheTA = new ObservableCollection<string>();
            idMesuresFichePoids = new ObservableCollection<string>();
            idMesuresFicheTemperature = new ObservableCollection<string>();
            idMesuresFicheGlycemique = new ObservableCollection<string>();

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
        public string IdDemande
        {
            get
            {
                return idDemande;
            }
            set
            {
                idDemande = value;
                OnPropertyChanged("IdDemande");
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
        public int Lit
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
        public DateTime DateDebutPrevu
        {
            get
            {
                return dateDebutPrevu;
            }
            set
            {
                dateDebutPrevu = value;
                OnPropertyChanged("DateDebutPrevu");
            }
        }

        //[DataMember]
        //public DateTime DateDebutPrevu
        //{
        //    get
        //    {
        //        return dateDebutPrevu;
        //    }
        //    set
        //    {
        //        dateDebutPrevu = value;
        //        OnPropertyChanged("DateDebutPrevu");
        //    }
        //}

        [DataMember]
        public DateTime DateDebutReel
        {
            get
            {
                return dateDebutReel;
            }
            set
            {
                dateDebutReel = value;
                OnPropertyChanged("DateDebutReel");
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
        public GardeMalade Garde
        {
            get
            {
                return garde;
            }
            set
            {
                garde = value;
                OnPropertyChanged("Garde");
            }
        }

        [DataMember]
        public ObservableCollection<string> IdSallesChange
        {
            get
            {
                return idSalleChanges;
            }
            set
            {
                idSalleChanges = value;
                OnPropertyChanged("SalleChanges");
            }
        }
        [DataMember]
        public ObservableCollection<string> IdInterventions
        {
            get
            {
                return idInterventions;
            }
            set
            {
                idInterventions = value;
                OnPropertyChanged("IdInterventions");
            }
        }
        //[DataMember]
        //public ObservableCollection<string> IdGardesMalade
        //{
        //    get
        //    {
        //        return idGardesMalade;
        //    }
        //    set
        //    {
        //        idGardesMalade = value;
        //        OnPropertyChanged("IdGardesMalade");
        //    }
        //}

        [DataMember]
        public ObservableCollection<string> IdMesuresFicheTA
        {
            get
            {
                return idMesuresFicheTA;
            }
            set
            {
                idMesuresFicheTA = value;
                OnPropertyChanged("FicheTA");
            }
        }
        [DataMember]
        public ObservableCollection<string> IdMesuresFichePoids
        {
            get
            {
                return idMesuresFichePoids;
            }
            set
            {
                idMesuresFichePoids = value;
                OnPropertyChanged("FichePoids");
            }
        }
        [DataMember]
        public ObservableCollection<string> IdMesuresFicheTemperature
        {
            get
            {
                return idMesuresFicheTemperature;
            }
            set
            {
                idMesuresFicheTemperature = value;
                OnPropertyChanged("FicheTemperature");
            }
        }
        [DataMember]
        public ObservableCollection<string> IdMesuresFicheGlycemique
        {
            get
            {
                return idMesuresFicheGlycemique;
            }
            set
            {
                idMesuresFicheGlycemique = value;
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
