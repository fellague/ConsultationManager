﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class RDV : INotifyPropertyChanged
    {
        private string nomPatient;
        private string prenomPatient;
        private string nomMedecin;
        private string prenomMedecin;
        private DateTime dateRdv;
        private int rang;
        private DateTime creeDans;
        private string creePar;

        public RDV(string nomPatient, string prenomPatient, string nomMedecin, string prenomMedecin, DateTime dateRdv, int rang, DateTime creeDans, string creePar)
        {
            NomPatient = nomPatient;
            PrenomPatient = prenomPatient;
            NomMedecin = nomMedecin;
            PrenomMedecin = prenomMedecin;
            DateRdv = dateRdv;
            Rang = rang;
            CreeDans = creeDans;
            CreePar = creePar;
        }

        public string NomPatient
        {
            get
            {
                return nomPatient;
            }
            set
            {
                nomPatient = value;
                OnPropertyChanged("NomPatient");
            }
        }
        public string PrenomPatient
        {
            get
            {
                return prenomPatient;
            }
            set
            {
                prenomPatient = value;
                OnPropertyChanged("PrenomPatient");
            }
        }
        public string NomMedecin
        {
            get
            {
                return nomMedecin;
            }
            set
            {
                nomMedecin = value;
                OnPropertyChanged("NomMedecin");
            }
        }
        public string PrenomMedecin
        {
            get
            {
                return prenomMedecin;
            }
            set
            {
                prenomMedecin = value;
                OnPropertyChanged("PrenomMedecin");
            }
        }
        public DateTime DateRdv
        {
            get
            {
                return dateRdv;
            }
            set
            {
                dateRdv = value;
                OnPropertyChanged("DateRdv");
            }
        }
        public int Rang
        {
            get
            {
                return rang;
            }
            set
            {
                rang = value;
                OnPropertyChanged("Rang");
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
