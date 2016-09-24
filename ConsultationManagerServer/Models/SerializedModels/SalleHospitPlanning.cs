using ConsultationManagerServer.Models.Hospitalisations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class SalleHospitPlanning : INotifyPropertyChanged
    {
        private Salle salle;
        private List<Hospitalisation> hospits;

        public SalleHospitPlanning()
        {
            salle = new Salle();
            hospits = new List<Hospitalisation>();
        }

        [DataMember]
        public Salle Salle
        {
            get
            {
                return salle;
            }
            set
            {
                salle = value;
                OnPropertyChanged("Salle");
            }
        }

        [DataMember]
        public List<Hospitalisation> Hospits
        {
            get
            {
                return hospits;
            }
            set
            {
                hospits = value;
                OnPropertyChanged("Hospits");
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