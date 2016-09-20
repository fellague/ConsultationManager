using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class CompteRendu : INotifyPropertyChanged
    {
        private string description;

        //private string idConclusion;
        //private DateTime creeDans;
        //private string creePar;

        public CompteRendu()
        {
            description = "";
            //idConclusion = "";
            //creeDans = new DateTime();
            //creePar = "";
        }

        //[BsonId]
        //public ObjectId _id { get; set; }

        //[DataMember]
        //public string Id
        //{
        //    get { return _id.ToString(); }
        //    set { _id = ObjectId.Parse(value); }
        //}

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

        //[DataMember]
        //public string IdConclusion
        //{
        //    get
        //    {
        //        return idConclusion;
        //    }
        //    set
        //    {
        //        idConclusion = value;
        //        OnPropertyChanged("IdCompteRendu");
        //    }
        //}

        //[DataMember]
        //public DateTime CreeDans
        //{
        //    get
        //    {
        //        return creeDans;
        //    }
        //    set
        //    {
        //        creeDans = value;
        //        OnPropertyChanged("CreeDans");
        //    }
        //}

        //[DataMember]
        //public string CreePar
        //{
        //    get
        //    {
        //        return creePar;
        //    }
        //    set
        //    {
        //        creePar = value;
        //        OnPropertyChanged("CreePar");
        //    }
        //}

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
