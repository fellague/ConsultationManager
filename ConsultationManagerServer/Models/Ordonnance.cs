using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class Ordonnance : INotifyPropertyChanged
    {
        private ObservableCollection<Medicament> listMedicaments;

        public Ordonnance(ObservableCollection<Medicament> listMedicaments)
        {
            this.listMedicaments = listMedicaments;
        }

        [DataMember]
        public ObservableCollection<Medicament> ListMedicaments
        {
            get
            {
                return listMedicaments;
            }
            set
            {
                listMedicaments = value;
                OnPropertyChanged("ListMedicaments");
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
