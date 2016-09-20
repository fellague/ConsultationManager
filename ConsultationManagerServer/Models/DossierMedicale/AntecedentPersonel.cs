using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class AntecedentPersonel : INotifyPropertyChanged
    {
        private string organe;
        private int avMois;
        private int avJours;
        private string description;

        public AntecedentPersonel(string org, int mois, int jours, string descr)
        {
            organe = org;
            avMois = mois;
            avJours = jours;
            description = descr;
        }

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
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
