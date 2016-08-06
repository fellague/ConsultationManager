using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Hospitalisation : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private string salle;
        private string lit;
        private DateTime dateDebut;
        private DateTime dateFinPrevu;
        private DateTime dateFinReel;
        private DateTime creeDans;
        private string creePar;

        public Hospitalisation(string nom, string prenom, string salle, string lit, DateTime dateDebut, DateTime dateFinPrevu, DateTime dateFinReel, DateTime creeDans, string creePar)
        {
            Nom = nom;
            Prenom = prenom;
            Salle = salle;
            Lit = lit;
            DateDebut = dateDebut;
            DateFinPrevu = dateFinPrevu;
            DateFinReel = dateFinReel;
            CreeDans = creeDans;
            CreePar = creePar;
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
        public string Salle
        {
            get
            {
                return salle;
            }
            set
            {
                salle = value;
                OnPropertyChanged("Salle");
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
