using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.DossierMedicale
{
    [DataContract]
    public class Bilan : INotifyPropertyChanged
    {
        private string tsh;
        private string ft3;
        private string ft4;
        private string tg;
        private string actg;
        private string actpo;
        private string tct;
        private string t41;
        private string t31;
        private string t4;
        
        public Bilan()
        {
            tsh = "";
            ft3 = "";
            ft4 = "";
            tg = "";
            actg = "";
            actpo = "";
            tct = "";
            t41 = "";
            t31 = "";
            t4 = "";
        }

        [DataMember]
        public string TSH
        {
            get
            {
                return tsh;
            }
            set
            {
                tsh = value;
                OnPropertyChanged("TSH");
            }
        }
        [DataMember]
        public string FT3
        {
            get
            {
                return ft3;
            }
            set
            {
                ft3 = value;
                OnPropertyChanged("FT3");
            }
        }
        [DataMember]
        public string FT4
        {
            get
            {
                return ft4;
            }
            set
            {
                ft4 = value;
                OnPropertyChanged("FT4");
            }
        }
        [DataMember]
        public string TG
        {
            get
            {
                return tg;
            }
            set
            {
                tg = value;
                OnPropertyChanged("TG");
            }
        }
        [DataMember]
        public string ACTG
        {
            get
            {
                return actg;
            }
            set
            {
                actg = value;
                OnPropertyChanged("ACTG");
            }
        }
        [DataMember]
        public string ACTPO
        {
            get
            {
                return actpo;
            }
            set
            {
                actpo = value;
                OnPropertyChanged("ACTPO");
            }
        }
        [DataMember]
        public string TCT
        {
            get
            {
                return tct;
            }
            set
            {
                tct = value;
                OnPropertyChanged("TCT");
            }
        }
        [DataMember]
        public string T41
        {
            get
            {
                return t41;
            }
            set
            {
                t41 = value;
                OnPropertyChanged("T41");
            }
        }
        [DataMember]
        public string T31
        {
            get
            {
                return t31;
            }
            set
            {
                t31 = value;
                OnPropertyChanged("T31");
            }
        }
        [DataMember]
        public string T4
        {
            get
            {
                return t4;
            }
            set
            {
                t4 = value;
                OnPropertyChanged("T4");
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