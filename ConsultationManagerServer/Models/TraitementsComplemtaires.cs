using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class TraitementsComplemtaires : INotifyPropertyChanged
    {
        private ObservableCollection<Traitement> listTraitements;

        public TraitementsComplemtaires(ObservableCollection<Traitement> listTraitements)
        {
            this.listTraitements = listTraitements;
        }

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
