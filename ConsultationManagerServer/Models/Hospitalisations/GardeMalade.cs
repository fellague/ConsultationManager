using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.Hospitalisations
{
    [DataContract]
    public class GardeMalade : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private DateTime dateNaiss;
        private string numeroCarte;
        private ObservableCollection<string> telephones;

        //private string idHospitalisation;

        //private DateTime creeDans;
        //private string creePar;

        public GardeMalade()
        {
            nom = "";
            prenom = "";
            dateNaiss = new DateTime();
            numeroCarte = "";
            telephones = new ObservableCollection<string>();

            //idHospitalisation = "";
            //creeDans = new DateTime();
            //creePar = "";
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
        public string NumeroCarte
        {
            get
            {
                return numeroCarte;
            }
            set
            {
                numeroCarte = value;
                OnPropertyChanged("NumeroCarte");
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

        //[DataMember]
        //public string IdHospitalisation
        //{
        //    get
        //    {
        //        return idHospitalisation;
        //    }
        //    set
        //    {
        //        idHospitalisation = value;
        //        OnPropertyChanged("IdHospitalisation");
        //    }
        //}

        //[DataMember]
        //public DateTime CreeDans
        //{
        //    get
        //    {
        //        return creeDans;
        //    }
        //    set
        //    {
        //        creeDans = value;
        //        OnPropertyChanged("CreeDans");
        //    }
        //}

        //[DataMember]
        //public string CreePar
        //{
        //    get
        //    {
        //        return creePar;
        //    }
        //    set
        //    {
        //        creePar = value;
        //        OnPropertyChanged("CreePar");
        //    }
        //}

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