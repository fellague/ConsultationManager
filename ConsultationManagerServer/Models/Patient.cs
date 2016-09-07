using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Patient: INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private DateTime dateNaiss;
        private string raison;
        private string origineGeo;
        private string adresse;
        private string nationnalite;
        private string profession;
        private ObservableCollection<string> telephones;
        private bool mariee;

        private DateTime creeDans;
        private string creePar;

        private bool nouveau;
        private string degreUrgence;
        private string medecinResp;
        private string serviceId;
        private string pathologieId;

        public Patient()
        {
            nom = "";
            prenom = "";
            dateNaiss = new DateTime();
            raison = "";
            origineGeo = "";
            adresse = "";
            nationnalite = "";
            telephones = new ObservableCollection<string>();
            mariee = false;

            nouveau = true;
            degreUrgence = "";
            creeDans = new DateTime();
            creePar = "";

            medecinResp = "";
            serviceId = "";
            pathologieId = "";
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
        public string Prenom
        {
            get
            {
                return prenom;
            }
            set
            {
                prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        [DataMember]
        public DateTime DateNaiss
        {
            get
            {
                return dateNaiss;
            }
            set
            {
                dateNaiss = value;
                OnPropertyChanged("DateNaiss");
            }
        }

        [DataMember]
        public string Raison
        {
            get
            {
                return raison;
            }
            set
            {
                raison = value;
                OnPropertyChanged("Raison");
            }
        }

        [DataMember]
        public string OrigineGeo
        {
            get
            {
                return origineGeo;
            }
            set
            {
                origineGeo = value;
                OnPropertyChanged("OrigineGeo");
            }
        }

        [DataMember]
        public string Adresse
        {
            get
            {
                return adresse;
            }
            set
            {
                adresse = value;
                OnPropertyChanged("Adresse");
            }
        }

        [DataMember]
        public string Nationnalite
        {
            get
            {
                return nationnalite;
            }
            set
            {
                nationnalite = value;
                OnPropertyChanged("Nationnalite");
            }
        }

        [DataMember]
        public string Profession
        {
            get
            {
                return profession;
            }
            set
            {
                profession = value;
                OnPropertyChanged("Profession");
            }
        }

        [DataMember]
        public ObservableCollection<string> Telephones
        {
            get
            {
                return telephones;
            }
            set
            {
                telephones = value;
                OnPropertyChanged("Telephone");
            }
        }

        [DataMember]
        public bool Mariee
        {
            get
            {
                return mariee;
            }
            set
            {
                mariee = value;
                OnPropertyChanged("Mariee");
            }
        }

        [DataMember]
        public bool Nouveau
        {
            get
            {
                return nouveau;
            }
            set
            {
                nouveau = value;
                OnPropertyChanged("Nouveau");
            }
        }

        [DataMember]
        public string DegreUrgence
        {
            get
            {
                return degreUrgence;
            }
            set
            {
                degreUrgence = value;
                OnPropertyChanged("DegreUrgence");
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
        public string MedecinResp
        {
            get
            {
                return medecinResp;
            }
            set
            {
                medecinResp = value;
                OnPropertyChanged("MedecinSup");
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
