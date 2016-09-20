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
    public class Conclusion : INotifyPropertyChanged
    {
        private string idPatient;
        private string idConsultation;
        private string idRdv;
        private Ordonnance ordonnance;
        private TraitementsComplemtaires traitementsCompl;
        private ObservableCollection<string> conseils;
        private CompteRendu compteRendu;

        private string idSource;

        private DateTime creeDans;
        private string creePar;

        public Conclusion()
        {
            idPatient = "";
            idConsultation = "";
            idRdv = "";
            ordonnance = new Ordonnance();
            traitementsCompl = new TraitementsComplemtaires();
            conseils = new ObservableCollection<string>();
            compteRendu = new CompteRendu();

            idSource = "";

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
        public string IdConsultation
        {
            get
            {
                return idConsultation;
            }
            set
            {
                idConsultation = value;
                OnPropertyChanged("IdConsultation");
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
        public Ordonnance Ordonnance
        {
            get
            {
                return ordonnance;
            }
            set
            {
                ordonnance = value;
                OnPropertyChanged("Ordonnance");
            }
        }

        [DataMember]
        public TraitementsComplemtaires TraitementsCompl
        {
            get
            {
                return traitementsCompl;
            }
            set
            {
                traitementsCompl = value;
                OnPropertyChanged("TraitementsCompl");
            }
        }
        
        [DataMember]
        public ObservableCollection<string> Conseils
        {
            get
            {
                return conseils;
            }
            set
            {
                conseils = value;
                OnPropertyChanged("Conseils");
            }
        }

        [DataMember]
        public CompteRendu CompteRendu
        {
            get
            {
                return compteRendu;
            }
            set
            {
                compteRendu = value;
                OnPropertyChanged("CompteRendu");
            }
        }

        [DataMember]
        public string IdSource
        {
            get
            {
                return idSource;
            }
            set
            {
                idSource = value;
                OnPropertyChanged("IdSource");
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