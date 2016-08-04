using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class Employee: INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private string role;
        private DateTime dateNaiss;
        private string adresse;
        private string telephone;
        private DateTime creeDans;
        private string creePar;

        public Employee(string nom, string prenom, string role, DateTime dateNaiss, string adresse, string telephone, DateTime creeDans, string creePar)
        {
            Nom = nom;
            Prenom = prenom;
            Role = role;
            DateNaiss = dateNaiss;
            Adresse = adresse;
            Telephone = telephone;
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
