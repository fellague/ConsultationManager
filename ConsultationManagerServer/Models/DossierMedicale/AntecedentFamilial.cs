using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class AntecedentFamilial : INotifyPropertyChanged
    {
        private string membre; //père, mère,frère
        private string description;

        public AntecedentFamilial(string memb, string descr)
        {
            membre = memb;
            description = descr;
        }

        [DataMember]
        public string Membre
        {
            get
            {
                return membre;
            }
            set
            {
                membre = value;
                OnPropertyChanged("Membre");
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
