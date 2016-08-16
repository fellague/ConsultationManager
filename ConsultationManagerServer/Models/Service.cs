using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsultationManagerServer.Models
{
    //[Serializable]
    [DataContract]
    public class Service : INotifyPropertyChanged
    {
        private string nom;
        private DateTime dateOuverture;
        private string domaine;
        private string adresse;
        private ObservableCollection<string> telephones;

        private DateTime creerDans;
        private string creePar;

        public Service()
        {
            nom = "";
            dateOuverture = new DateTime();
            domaine = "";
            adresse = "";
            telephones = new ObservableCollection<string>();
            creerDans = DateTime.Now;
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
        public DateTime DateOuverture
        {
            get
            {
                return dateOuverture;
            }
            set
            {
                dateOuverture = value;
                OnPropertyChanged("DateOuverture");
            }
        }

        [DataMember]
        public string Domaine
        {
            get
            {
                return domaine;
            }
            set
            {
                domaine = value;
                OnPropertyChanged("Domaine");
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
        public ObservableCollection<string> Telephones
        {
            get
            {
                return telephones;
            }
            set
            {
                telephones = value;
                OnPropertyChanged("Telephones");
            }
        }

        //[DataMember]
        //public ObservableCollection<string> PathologiesId
        //{
        //    get
        //    {
        //        return pathologiesId;
        //    }
        //    set
        //    {
        //        pathologiesId = value;
        //        OnPropertyChanged("PathologiesId");
        //    }
        //}

        [DataMember]
        public DateTime CreerDans
        {
            get
            {
                return creerDans;
            }
            set
            {
                creerDans = value;
                OnPropertyChanged("CreerDans");
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