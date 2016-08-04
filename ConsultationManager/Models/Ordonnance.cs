using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class Ordonnance : INotifyPropertyChanged
    {
        private ObservableCollection<Medicament> listMedicaments;

        public Ordonnance(ObservableCollection<Medicament> listMedicaments)
        {
            this.listMedicaments = listMedicaments;
        }

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
