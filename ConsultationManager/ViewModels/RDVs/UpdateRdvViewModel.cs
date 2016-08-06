using System;
using System.Linq;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.Commands.RDVs;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ConsultationManagerClient.Commands;

namespace ConsultationManagerClient.ViewModels.RDVs
{
    internal class UpdateRdvViewModel : INotifyPropertyChanged
    {
        private RDV updatedRdv;
        private int diffMois;
        private int diffJours;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;


        public UpdateRdvViewModel(RDV rdv, ListRvdViewModel vmLi)
        {
            updatedRdv = rdv;

            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            
            UpdateRdvCommand = new UpdateRdvCommand(this, vmLi);
            CancelCommand = new RelayCommand(o => ((Window)o).Close());
        }

        public RDV UpdatedRdv
        {
            get
            {
                //Console.WriteLine("UpdateRdvViewModel : difference date ( " + updatedRdv.DateRdv + " --- " + DateTime.Now + " )  is " + diffMois + " months and " + diffJours + " days");
                return updatedRdv;
            }
        }

        public int DiffMois
        {
            get
            {
                int Mois = 0;
                while (updatedRdv.DateRdv.CompareTo(DateTime.Now.Date.AddMonths(++Mois)) >= 0) { }
                diffMois = --Mois;
                Console.WriteLine("DiffMois get changed" + diffMois);
                return diffMois;
            }
            set
            {
                diffMois = value;
                Console.WriteLine("DiffMois set changed "+diffMois);
                updatedRdv.DateRdv = DateTime.Now.Date.AddMonths(diffMois).AddDays(diffJours);
                OnPropertyChanged("DiffMois");
            }
        }

        public int DiffJours
        {
            get
            {
                int Jours = 0;
                while (updatedRdv.DateRdv.CompareTo(DateTime.Now.AddMonths(diffMois).AddDays(++Jours)) >= 0) { }
                diffJours = --Jours;
                return diffJours;
            }
            set
            {
                diffJours = value;
                updatedRdv.DateRdv = DateTime.Now.AddMonths(diffMois).AddDays(diffJours);
                OnPropertyChanged("DiffJours");
            }
        }

        public ObservableCollection<int> ListMois
        {
            get
            {
                return listMois;
            }
        }
        public ObservableCollection<int> ListJours
        {
            get
            {
                return listJours;
            }
        }

        public ICommand UpdateRdvCommand
        {
            get;
            private set;
        }
        public ICommand CancelCommand
        {
            get;
            private set;
        }

        public bool UpdateRvd()
        {
            //Console.WriteLine("UpdateRdvViewModel : difference date ( " + updatedRdv.DateRdv + " --- " + DateTime.Now+ " )  is " + diffMois + " months and " + diffJours+" days");
            return true;
        }

        //void GetMonths(DateTime startDate, DateTime endDate)
        //{
        //    int Mois = 0;
        //    // Traverse until start date parameter is beyond the end date parameter
        //    while (endDate.CompareTo(startDate.AddMonths(++Mois)) >= 0) { }
        //    DiffMois = --Mois;
        //}
        //void GetDays(DateTime startDate, DateTime endDate)
        //{
        //    int Jours = 0;
        //    // Traverse until start date parameter is beyond the end date parameter
        //    while (endDate.CompareTo(startDate.AddDays(++Jours)) >= 0) { }
        //    DiffJours = --Jours;
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
