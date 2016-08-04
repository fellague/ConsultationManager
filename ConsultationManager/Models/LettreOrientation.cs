using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class LettreOrientation : INotifyPropertyChanged
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
