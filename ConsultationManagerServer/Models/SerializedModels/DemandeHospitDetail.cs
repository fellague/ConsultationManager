using ConsultationManagerServer.Models.Hospitalisations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class DemandeHospitDetail : INotifyPropertyChanged
    {
        public DemandeHospitDetail()
        {
            DemandeHospit = new DemandeHospit();
            Patient = new Patient();
            Medecin = new Utilisateur();
            IntervConclus = new Conclusion();
        }

        [DataMember]
        public DemandeHospit DemandeHospit
        {
            get;
            set;
        }

        [DataMember]
        public Patient Patient
        {
            get;
            set;
        }

        [DataMember]
        public Utilisateur Medecin
        {
            get;
            set;
        }

        [DataMember]
        public Conclusion IntervConclus
        {
            get;
            set;
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