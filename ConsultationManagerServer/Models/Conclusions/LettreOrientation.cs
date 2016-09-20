using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class LettreOrientation : INotifyPropertyChanged
    {
        private string destination;
        private string motif;
        private string description;

        public LettreOrientation(string destination, string motif, string description)
        {
            this.destination = destination;
            this.motif = motif;
            this.description = description;
        }

        [DataMember]
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
                OnPropertyChanged("Destination");
            }
        }

        [DataMember]
        public string Motif
        {
            get
            {
                return motif;
            }
            set
            {
                motif = value;
                OnPropertyChanged("Motif");
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
