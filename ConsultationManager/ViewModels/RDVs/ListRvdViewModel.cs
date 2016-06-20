using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;
using ConsultationManager.Views.RDVs;
using System.Windows.Input;
using ConsultationManager.Commands;
using System.Collections.ObjectModel;

namespace ConsultationManager.ViewModels.RDVs
{
    internal class ListRvdViewModel
    {
        private ObservableCollection<RDV> listAllRvd;
        private ObservableCollection<RDV> listAllMyRvd;
        private ObservableCollection<RDV> listAllMyTodayRvd;

        public ListRvdViewModel()
        {
            listAllRvd = CreateRDVs();
            listAllMyRvd = CreateListAllMyRdv();
            listAllMyTodayRvd = CreateListAllMyTodayRdv();

            RunDialogCommand = new RunDialogUpdateRdvCommand(this);
        }

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

        public ICommand RunDialogCommand
        {
            get;
            private set;
        }

        public void ShowDialogUpdateRvd()
        {
            //Debug.Assert(false, String.Format("{0} was updated.", Customer.Name));
            //NewRdvPage view = new NewRdvPage();
            //view.DataContext = childViewModel;

            //childViewModel.Info = Customer.Name + " was updated in the database";
            //view.ShowDialog();
        }


        private ObservableCollection<RDV> CreateRDVs()
        {
            ObservableCollection<RDV> list = new ObservableCollection<RDV>();
            list.Add(new RDV("Nick", "White", "mokrane", "fatiha", new DateTime(2016, 10, 13, 8, 30, 0), DateTime.Today, "tebibell saliha"));
            list.Add(new RDV("Jack", "Rodman", "bellal", "kader", new DateTime(2017, 3, 23, 9, 45, 0), new DateTime(2016, 5, 10), "mokrane fatiha"));
            list.Add(new RDV("Sandra", "Sherry", "fellague", "halim", new DateTime(2016, 11, 10, 11, 0, 0), new DateTime(2008, 12, 22), "bellal kader"));
            list.Add(new RDV("Sabrina", "Vilk", "mokrane", "fatiha", new DateTime(2016, 10, 13, 12, 0, 0), DateTime.Today, "fellague halim"));
            list.Add(new RDV("Mike", "Pearson", "bellal", "kader", new DateTime(2016, 12, 30, 9, 0, 0), new DateTime(2008, 10, 18), "bennouna el khebith"));
            list.Add(new RDV("Bill", "Watson", "fellague", "halim", new DateTime(2017, 4, 20, 10, 15, 0), new DateTime(2016, 1, 18), "fellague halim"));
            list.Add(new RDV("Christiano", "Ronaldo", "bellal", "kader", new DateTime(2017, 3, 10, 14, 0, 0), new DateTime(2014, 7, 10), "bennouna el khebith"));
            list.Add(new RDV("Maria", "Klara", "mokrane", "fatiha", new DateTime(2016, 10, 13, 15, 0, 0), new DateTime(2012, 2, 20), "bellal kader"));
            list.Add(new RDV("Amaouri", "Benjamen", "mokrane", "fatiha", new DateTime(2017, 1, 1, 8, 45, 0), new DateTime(2003, 7, 1), "fellague halim"));
            list.Add(new RDV("Bouraoui", "ElMerioul", "fellague", "halim", new DateTime(2017, 6, 12, 11, 0, 0), DateTime.Today, "tebibell saliha"));
            list.Add(new RDV("Henni", "El Alia", "mokrane", "fatiha", new DateTime(2016, 10, 13, 13, 0, 0), new DateTime(2005, 10, 18), "fellague halim"));
            list.Add(new RDV("Keyta", "Ben yamina", "mokrane", "fatiha", new DateTime(2017, 1, 1, 8, 45, 0), new DateTime(2012, 12, 22), "bellal kader"));
            list.Add(new RDV("Gabriel", "Pepe", "fellague", "halim", new DateTime(2016, 11, 16, 10, 0, 0), new DateTime(2011, 7, 10), "bennouna el khebith"));
            list.Add(new RDV("Khoukhi", "Doukkich", "mokrane", "fatiha", new DateTime(2017, 1, 1, 9, 45, 0), new DateTime(2009, 4, 8), "fellague halim"));
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
                if (element.NomMedecin == "mokrane" && element.PrenomMedecin == "fatiha" && element.DateRdv.CompareTo(today)==0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
    }
}
