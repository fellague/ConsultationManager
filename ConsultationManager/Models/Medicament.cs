﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.Models
{
    class Medicament : INotifyPropertyChanged
    {
        private string nom;
        private int periodeMois;
        private int periodeJours;
        private int nbFoisJours;
        private string temps;
        private string remarque;

        public Medicament(string nom, int periodeMois, int periodeJours, int nbFoisJours, string temps, string remarque)
        {
            this.nom = nom;
            this.periodeMois = periodeMois;
            this.periodeJours = periodeJours;
            this.nbFoisJours = nbFoisJours;
            this.temps = temps;
            this.remarque = remarque;
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
        public int PeriodeMois
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
        public int PeriodeJours
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
        public int NbFoisJours
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
