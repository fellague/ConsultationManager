using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.Models
{
    class Antecedent : INotifyPropertyChanged
    {
        private string organe;
        private int avMois;
        private int avJours;
        private string description;

        public Antecedent(string org, int mois, int jours, string descr)
        {
            organe = org;
            avMois = mois;
            avJours = jours;
            description = descr;
        }

        public string Organe
        {
            get
            {
                return organe;
            }
            set
            {
                organe = value;
                OnPropertyChanged("Organe");
            }
        }
        public int AvMois
        {
            get
            {
                return avMois;
            }
            set
            {
                avMois = value;
                OnPropertyChanged("AvMois");
            }
        }
        public int AvJours
        {
            get
            {
                return avJours;
            }
            set
            {
                avJours = value;
                OnPropertyChanged("AvJours");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Desrcription");
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
