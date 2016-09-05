using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Consultation : INotifyPropertyChanged
    {
        private string idService;
        private string idPlanning;
        private string nom; 
        private string description;

        public Consultation()
        {
            this.nom = "";
            description = "";
            idService = "";
            idPlanning = "";
        }

        [BsonId]
        public ObjectId _id { get; set; }

        [DataMember]
        public string Id
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        [DataMember]
        public string IdService
        {
            get
            {
                return idService;
            }
            set
            {
                idService = value;
                OnPropertyChanged("IdService");
            }
        }

        [DataMember]
        public string IdPlanning
        {
            get
            {
                return idPlanning;
            }
            set
            {
                idPlanning = value;
                OnPropertyChanged("IdPlanning");
            }
        }

        [DataMember]
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
                OnPropertyChanged("Nom");
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
