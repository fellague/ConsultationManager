using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class RemarqueMedecin : INotifyPropertyChanged
    {
        private string organe;
        private string description;
        public RemarqueMedecin(string org, string descr)
        {
            organe = org;
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
