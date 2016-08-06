using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Consultation : INotifyPropertyChanged
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

        [DataMember]
        public ObservableCollection<AntecedentPersonel> CommentsPatient
        {
            get
            {
                return commentsPatient;
            }
        }

        [DataMember]
        public ObservableCollection<RemarqueMedecin> RemarquesMedecin
        {
            get
            {
                return remarquesMedecin;
            }
        }

        [DataMember]
        public int Poids
        {
            get
            {
                return poids;
            }
        }

        [DataMember]
        public int TA
        {
            get
            {
                return ta;
            }
        }

        [DataMember]
        public int Tension
        {
            get
            {
                return tension;
            }
        }

        [DataMember]
        public int Temperature
        {
            get
            {
                return temperature;
            }
        }

        [DataMember]
        public string Glycemique
        {
            get
            {
                return glycemique;
            }
        }

        [DataMember]
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
