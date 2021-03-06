﻿using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Medicament : INotifyPropertyChanged
    {
        private string nom;
        private string periodeMois;
        private string periodeJours;
        private string nbFoisJours;
        private string temps;
        private string remarque;

        public Medicament()
        {
            this.nom = "";
            this.periodeMois = "";
            this.periodeJours = "";
            this.nbFoisJours = "";
            this.temps = "";
            this.remarque = "";
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
        public string PeriodeMois
        {
            get
            {
                return periodeMois;
            }
            set
            {
                periodeMois = value;
                OnPropertyChanged("PeriodeMois");
            }
        }

        [DataMember]
        public string PeriodeJours
        {
            get
            {
                return periodeJours;
            }
            set
            {
                periodeJours = value;
                OnPropertyChanged("PeriodeJours");
            }
        }

        [DataMember]
        public string NbFoisJours
        {
            get
            {
                return nbFoisJours;
            }
            set
            {
                nbFoisJours = value;
                OnPropertyChanged("NbFoisJours");
            }
        }

        [DataMember]
        public string Temps
        {
            get
            {
                return temps;
            }
            set
            {
                temps = value;
                OnPropertyChanged("Temps");
            }
        }

        [DataMember]
        public string Remarque
        {
            get
            {
                return remarque;
            }
            set
            {
                remarque = value;
                OnPropertyChanged("Remarque");
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
