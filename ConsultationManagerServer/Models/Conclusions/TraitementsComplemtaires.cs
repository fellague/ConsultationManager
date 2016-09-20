﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class TraitementsComplemtaires : INotifyPropertyChanged
    {
        private ObservableCollection<Traitement> listTraitements;

        //private string idConclusion;
        //private DateTime creeDans;
        //private string creePar;

        public TraitementsComplemtaires()
        {
            this.listTraitements = new ObservableCollection<Traitement>();
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
        public ObservableCollection<Traitement> ListTraitements
        {
            get
            {
                return listTraitements;
            }
            set
            {
                listTraitements = value;
                OnPropertyChanged("ListTraitements");
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
