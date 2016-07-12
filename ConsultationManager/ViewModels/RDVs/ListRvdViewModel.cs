﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;
using ConsultationManager.Views.RDVs;
using ConsultationManager.Views.Consultation;
using ConsultationManager.ViewModels.Consultations;
using System.Windows.Input;
using ConsultationManager.Commands.RDVs;
using ConsultationManager.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ConsultationManager.ViewModels.RDVs
{
    internal class ListRvdViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<RDV> listAllRvd;
        private ObservableCollection<RDV> listAllMyRvd;
        private ObservableCollection<RDV> listAllMyTodayRvd;
        private ObservableCollection<RDV> listAllFirstRvd;
        //private RDV selectedRDV = null;
        private UpdateRdvWindow dialogUpdateView;
        private ConsultationWindow dialogConsultationView;
        private FirstConsultationWindow dialogFirstRdvView;

        public ListRvdViewModel()
        {
            listAllRvd = CreateRDVs();
            listAllMyRvd = CreateListAllMyRdv();
            listAllMyTodayRvd = CreateListAllMyTodayRdv();
            listAllFirstRvd = CreateListAllFirstRdv();

            //RunDialogCommand = new RunDialogUpdateRdvCommand(this);
            UpdateRdvDialogCommand = new RelayCommand(param => this.ShowDialogUpdateRvd(param));
            ConsultationDialogCommand = new RelayCommand(param => this.ShowDialogConsult(param));
            FirstRdvDialogCommand = new RelayCommand(param => this.ShowDialogFirstConsult(param));

            RemoveSelectedRdvCommand = new RelayCommand(param => this.Delete(param));
        }
        #region ListRvdViewModel Variables

        public ObservableCollection<RDV> ListAllRvd
        {
            get
            {
                return listAllRvd;
            }
        }
        public ObservableCollection<RDV> ListAllMyRvd
        {
            get
            {
                return listAllMyRvd;
            }
        }
        public ObservableCollection<RDV> ListAllMyTodayRvd
        {
            get
            {
                return listAllMyTodayRvd;
            }
        }
        public ObservableCollection<RDV> ListAllFirstRvd
        {
            get
            {
                return listAllFirstRvd;
            }
        }
        public UpdateRdvWindow DialogUpdateView
        {
            get
            {
                return dialogUpdateView;
            }
        }
        public ConsultationWindow DialogConsultationView
        {
            get
            {
                return dialogConsultationView;
            }
        }
        public FirstConsultationWindow DialogFirstRdvView
        {
            get
            {
                return dialogFirstRdvView;
            }
        }
        //public RDV SelectedRDV
        //{
        //    get
        //    {
        //        return selectedRDV;
        //    }
        //    set
        //    {
        //        selectedRDV = value;
        //        //Console.WriteLine("ListRvdViewModel : SelectedRDV changed " + selectedRDV.NomPatient);
        //        OnPropertyChanged("SelectedRDV");
        //    }
        //}

        #endregion


        #region ListRvdViewModel Commands

        public ICommand UpdateRdvDialogCommand
        {
            get;
            private set;
        }

        public ICommand ConsultationDialogCommand
        {
            get;
            private set;
        }

        public ICommand FirstRdvDialogCommand
        {
            get;
            private set;
        }

        public ICommand RemoveSelectedRdvCommand
        {
            get;
            private set;
        }

        #endregion

        public void ShowDialogUpdateRvd(object selectedRdv)
        {
            var rdv = selectedRdv as RDV;
            Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.DateRdv);
            dialogUpdateView = new UpdateRdvWindow();
            dialogUpdateView.DataContext = new UpdateRdvViewModel(rdv, this);
            dialogUpdateView.ShowDialog();
        }

        public void ShowDialogConsult(object selectedRdv)
        {
            var rdv = selectedRdv as RDV;
            Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.DateRdv);
            dialogConsultationView = new ConsultationWindow();
            dialogConsultationView.DataContext = new ConsultationViewModel(rdv);
            dialogConsultationView.ShowDialog();
        }

        public void ShowDialogFirstConsult(object selectedRdv)
        {
            var rdv = selectedRdv as RDV;
            Console.WriteLine("ListRvdViewModel : Dialog opened with RDV  " + rdv.DateRdv);
            dialogFirstRdvView = new FirstConsultationWindow();
            dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
            dialogFirstRdvView.ShowDialog();
        }


        public void CloseDialogUpdateRvd(RDV updRdv)
        {
            Console.WriteLine("ListRvdViewModel : Dialog closed with updated RDV  " + updRdv.DateRdv);
            dialogUpdateView.Close();
        }

        public void Delete(object selectedRdv)
        {
            Console.WriteLine("ListRvdViewModel : Remove RDV  " );
            var rdv = selectedRdv as RDV;
            this.listAllMyRvd.Remove(rdv);
        }


        private ObservableCollection<RDV> CreateRDVs()
        {
            ObservableCollection<RDV> list = new ObservableCollection<RDV>();
            list.Add(new RDV("Nick", "White", "mokrane", "fatiha", new DateTime(2016, 10, 13), 1, DateTime.Today, "tebibell saliha"));
            list.Add(new RDV("Jack", "Rodman", "bellal", "kader", new DateTime(2017, 3, 23), 1, new DateTime(2016, 5, 10), "mokrane fatiha"));
            list.Add(new RDV("Sandra", "Sherry", "fellague", "halim", new DateTime(2016, 11, 10), 1, new DateTime(2008, 12, 22), "bellal kader"));
            list.Add(new RDV("Sabrina", "Vilk", "mokrane", "fatiha", new DateTime(2016, 10, 13), 2, DateTime.Today, "fellague halim"));
            list.Add(new RDV("Mike", "Pearson", "bellal", "kader", new DateTime(2016, 12, 30), 3, new DateTime(2008, 10, 18), "bennouna el khebith"));
            list.Add(new RDV("Bill", "Watson", "fellague", "halim", new DateTime(2017, 4, 20), 1, new DateTime(2016, 1, 18), "fellague halim"));
            list.Add(new RDV("Christiano", "Ronaldo", "bellal", "kader", new DateTime(2017, 3, 10), 1, new DateTime(2014, 7, 10), "bennouna el khebith"));
            list.Add(new RDV("Maria", "Klara", "mokrane", "fatiha", new DateTime(2016, 10, 13), 4, new DateTime(2012, 2, 20), "bellal kader"));
            list.Add(new RDV("Amaouri", "Benjamen", "mokrane", "fatiha", new DateTime(2017, 1, 1), 5, new DateTime(2003, 7, 1), "fellague halim"));
            list.Add(new RDV("Bouraoui", "ElMerioul", "fellague", "halim", new DateTime(2017, 6, 12), 6, DateTime.Today, "tebibell saliha"));
            list.Add(new RDV("Henni", "El Alia", "mokrane", "fatiha", new DateTime(2016, 10, 13), 8, new DateTime(2005, 10, 18), "fellague halim"));
            list.Add(new RDV("Keyta", "Ben yamina", "mokrane", "fatiha", new DateTime(2017, 1, 1), 5, new DateTime(2012, 12, 22), "bellal kader"));
            list.Add(new RDV("Gabriel", "Pepe", "fellague", "halim", new DateTime(2016, 11, 16), 1, new DateTime(2011, 7, 10), "bennouna el khebith"));
            list.Add(new RDV("Khoukhi", "Doukkich", "mokrane", "fatiha", new DateTime(2017, 1, 1), 10, new DateTime(2009, 4, 8), "fellague halim"));
            return list;
        }

        private ObservableCollection<RDV> CreateListAllMyRdv()
        {
            ObservableCollection<RDV> allList = CreateRDVs();
            ObservableCollection<RDV> allMyList = new ObservableCollection<RDV>();
            foreach (RDV element in allList)
            {
                if (element.NomMedecin == "mokrane" && element.PrenomMedecin == "fatiha")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        private ObservableCollection<RDV> CreateListAllMyTodayRdv()
        {
            ObservableCollection<RDV> allList = CreateRDVs();
            ObservableCollection<RDV> allMyList = new ObservableCollection<RDV>();
            DateTime today = new DateTime(2016, 10, 13);
            foreach (RDV element in allList)
            {
                if (element.NomMedecin == "mokrane" && element.PrenomMedecin == "fatiha" && element.DateRdv.Date==today.Date)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        private ObservableCollection<RDV> CreateListAllFirstRdv()
        {
            ObservableCollection<RDV> allList = CreateRDVs();
            ObservableCollection<RDV> allMyList = new ObservableCollection<RDV>();
            DateTime today = new DateTime(2016, 10, 13);
            foreach (RDV element in allList)
            {
                if (element.NomMedecin == "mokrane" && element.PrenomMedecin == "fatiha" && element.DateRdv.Date == today.Date)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
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
