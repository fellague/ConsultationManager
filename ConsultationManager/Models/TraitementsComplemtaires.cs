using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.Models
{
    class TraitementsComplemtaires : INotifyPropertyChanged
    {
        private ObservableCollection<Traitement> listTraitements;

        public TraitementsComplemtaires(ObservableCollection<Traitement> listTraitements)
        {
            this.listTraitements = listTraitements;
        }

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
