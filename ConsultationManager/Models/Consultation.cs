using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsultationManagerClient.Models
{
    class Consultation : INotifyPropertyChanged
    {
        private ObservableCollection<AntecedentPersonel> commentsPatient;
        private ObservableCollection<RemarqueMedecin> remarquesMedecin;
        //private FileStream tests;
        private int poids;
        private int ta;
        private int tension;
        private int temperature;
        private string glycemique;
        private string hymoglobine;

        public Consultation(ObservableCollection<AntecedentPersonel> commentsPatient, ObservableCollection<RemarqueMedecin> remarquesMedecin, int poids, int ta, int tension, int temperature, string glycemique, string hymoglobine)
        {
            this.commentsPatient = commentsPatient;
            this.remarquesMedecin = remarquesMedecin;
            this.poids = poids;
            this.ta = ta;
            this.tension = tension;
            this.temperature = temperature;
            this.glycemique = glycemique;
            this.hymoglobine = hymoglobine;

        }

        public ObservableCollection<AntecedentPersonel> CommentsPatient
        {
            get
            {
                return commentsPatient;
            }
        }
        public ObservableCollection<RemarqueMedecin> RemarquesMedecin
        {
            get
            {
                return remarquesMedecin;
            }
        }
        public int Poids
        {
            get
            {
                return poids;
            }
        }
        public int TA
        {
            get
            {
                return ta;
            }
        }
        public int Tension
        {
            get
            {
                return tension;
            }
        }
        public int Temperature
        {
            get
            {
                return temperature;
            }
        }
        public string Glycemique
        {
            get
            {
                return glycemique;
            }
        }
        public string Hymoglobine
        {
            get
            {
                return hymoglobine;
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
