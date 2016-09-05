using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Utilisateur: INotifyPropertyChanged
    {
        private string userName;
        private string password;

        private string nom;
        private string prenom;
        private string role;
        private DateTime dateNaiss;
        private string sexe;
        private string specialite;
        private string adresse;
        private string telephone;
        private DateTime creeDans;
        private string creePar;
        
        private string serviceId;
        private string pathologieId;

        public Utilisateur()
        {
            Nom = "";
            Prenom = "";
            Role = "";
            DateNaiss = new DateTime();
            Sexe = "";
            Specialite = "";
            Adresse = "";
            Telephone = "";
            CreeDans = new DateTime();
            CreePar = "";
            
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
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        [DataMember]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
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
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                OnPropertyChanged("Role");
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
        public string Sexe
        {
            get
            {
                return sexe;
            }
            set
            {
                sexe = value;
                OnPropertyChanged("Sexe");
            }
        }

        [DataMember]
        public string Specialite
        {
            get
            {
                return specialite;
            }
            set
            {
                specialite = value;
                OnPropertyChanged("Specialite");
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
        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
                OnPropertyChanged("Telephone");
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
