using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.Models
{
    class Patient: INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private DateTime dateNaiss;
        private string raison;
        private string adresse;
        private string telephone;
        private bool mariee;
        private DateTime creeDans;
        private string creePar;

        public Patient(string nom, string prenom, DateTime dateNaiss, string raison, string adresse, string telephone, bool mariee, DateTime creeDans, string creePar)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
            Raison = raison;
            Adresse = adresse;
            Telephone = telephone;
            Mariee = mariee;
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
