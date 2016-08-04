using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class Hospitalisation : INotifyPropertyChanged
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
