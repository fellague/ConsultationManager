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
    public class ServicePathologies : INotifyPropertyChanged
    {
        private Service service;
        private ObservableCollection<Pathologie> listPthologie;

        public ServicePathologies()
        {
            service = new Service();
            listPthologie = new ObservableCollection<Pathologie>();
        }

        [DataMember]
        public Service Service
        {
            get
            {
                return service;
            }
            set
            {
                service = value;
                OnPropertyChanged("Service");
            }
        }

        [DataMember]
        public ObservableCollection<Pathologie> ListPthologie
        {
            get
            {
                return listPthologie;
            }
            set
            {
                listPthologie = value;
                OnPropertyChanged("ListPthologie");
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