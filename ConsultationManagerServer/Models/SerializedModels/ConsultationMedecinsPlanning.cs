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
    public class ConsultationMedecinsPlanning : INotifyPropertyChanged
    {
        private Consultation consult;
        private ObservableCollection<Utilisateur> medecinsDimanche;
        private ObservableCollection<Utilisateur> medecinsLundi;
        private ObservableCollection<Utilisateur> medecinsMardi;
        private ObservableCollection<Utilisateur> medecinsMercredi;
        private ObservableCollection<Utilisateur> medecinsJeudi;

        public ConsultationMedecinsPlanning()
        {
            consult = new Consultation();
            medecinsDimanche = new ObservableCollection<Utilisateur>();
            medecinsLundi = new ObservableCollection<Utilisateur>();
            medecinsMardi = new ObservableCollection<Utilisateur>();
            medecinsMercredi = new ObservableCollection<Utilisateur>();
            medecinsJeudi = new ObservableCollection<Utilisateur>();
        }

        [DataMember]
        public Consultation Consult
        {
            get
            {
                return consult;
            }
            set
            {
                consult = value;
                OnPropertyChanged("Consult");
            }
        }

        [DataMember]
        public ObservableCollection<Utilisateur> MedecinsDimanche
        {
            get
            {
                return medecinsDimanche;
            }
            set
            {
                medecinsDimanche = value;
                OnPropertyChanged("MedecinsDimanche");
            }
        }
        [DataMember]
        public ObservableCollection<Utilisateur> MedecinsLundi
        {
            get
            {
                return medecinsLundi;
            }
            set
            {
                medecinsLundi = value;
                OnPropertyChanged("MedecinsLundi");
            }
        }
        [DataMember]
        public ObservableCollection<Utilisateur> MedecinsMardi
        {
            get
            {
                return medecinsMardi;
            }
            set
            {
                medecinsMardi = value;
                OnPropertyChanged("MedecinsMardi");
            }
        }
        [DataMember]
        public ObservableCollection<Utilisateur> MedecinsMercredi
        {
            get
            {
                return medecinsMercredi;
            }
            set
            {
                medecinsMercredi = value;
                OnPropertyChanged("MedecinsMercredi");
            }
        }
        [DataMember]
        public ObservableCollection<Utilisateur> MedecinsJeudi
        {
            get
            {
                return medecinsJeudi;
            }
            set
            {
                medecinsJeudi = value;
                OnPropertyChanged("MedecinsJeudi");
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