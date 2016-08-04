using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManagerClient.Models;
using System.Collections.ObjectModel;

namespace ConsultationManagerClient.ViewModels.Hospitalisations
{
    internal class ListHospitalisationViewModel
    {
        private ObservableCollection<Hospitalisation> listAllHospitalisation;
        private ObservableCollection<Hospitalisation> listActiveHospitalisation;

        public ListHospitalisationViewModel()
        {
            listAllHospitalisation = CreateHospitalisations();
            listActiveHospitalisation = CreateListActiveHospitalisation();
        }

        public ObservableCollection<Hospitalisation> ListAllHospitalisation
        {
            get
            {
                return listAllHospitalisation;
            }
        }
        public ObservableCollection<Hospitalisation> ListActiveHospitalisation
        {
            get
            {
                return listActiveHospitalisation;
            }
        }

        private ObservableCollection<Hospitalisation> CreateHospitalisations()
        {
            ObservableCollection<Hospitalisation> list = new ObservableCollection<Hospitalisation>();
            list.Add(new Hospitalisation("Nick", "White", "5", "14", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-3), DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-11), "tebibell saliha"));
            list.Add(new Hospitalisation("Jack", "Rodman" , "3", "7", DateTime.Today.AddDays(-30), DateTime.Today.AddDays(-24), DateTime.Today.AddDays(-22), DateTime.Today.AddDays(-32), "mokrane fatiha"));
            list.Add(new Hospitalisation("Sandra", "Sherry", "1", "3", DateTime.Today, DateTime.Today.AddDays(7),new DateTime(1, 1, 1), DateTime.Today.AddDays(-1), "bellal kader"));
            list.Add(new Hospitalisation("Sabrina", "Vilk" , "5", "10", DateTime.Today.AddDays(-20), DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-30), "fellague halim"));
            list.Add(new Hospitalisation("Mike", "Pearson", "3", "5", DateTime.Today.AddDays(-17), DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-19), "bennouna el khebith"));
            list.Add(new Hospitalisation("Bill", "Watson", "5", "6", DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-4), "fellague halim"));
            list.Add(new Hospitalisation("Christiano", "Ronaldo", "3", "2", DateTime.Today.AddMonths(-3), DateTime.Today.AddMonths(-3).AddDays(10), DateTime.Today.AddMonths(-3).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-1), "bennouna el khebith"));
            list.Add(new Hospitalisation("Maria", "Klara", "5", "8", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "bellal kader"));
            list.Add(new Hospitalisation("Amaouri", "Benjamen", "5", "3", DateTime.Today.AddMonths(1).AddDays(3), DateTime.Today.AddMonths(1).AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "fellague halim"));
            list.Add(new Hospitalisation("Bouraoui", "ElMerioul", "1", "4", DateTime.Today.AddMonths(-4), DateTime.Today.AddMonths(-4).AddDays(7), DateTime.Today.AddMonths(-4).AddDays(10), DateTime.Today.AddMonths(-4).AddDays(-4), "tebibell saliha"));
            list.Add(new Hospitalisation("Henni", "El Alia", "3", "4", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "fellague halim"));
            list.Add(new Hospitalisation("Keyta", "Ben yamina", "5", "11", DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-4), "bellal kader"));
            list.Add(new Hospitalisation("Gabriel", "Pepe", "1", "2", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "bennouna el khebith"));
            list.Add(new Hospitalisation("Khoukhi", "Doukkich", "5", "9", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "fellague halim"));
            return list;
        }

        private ObservableCollection<Hospitalisation> CreateListActiveHospitalisation()
        {
            ObservableCollection<Hospitalisation> allList = CreateHospitalisations();
            ObservableCollection<Hospitalisation> allMyList = new ObservableCollection<Hospitalisation>();
            foreach (Hospitalisation element in allList)
            {
                if (element.DateFinReel.CompareTo(new DateTime(1, 1, 1)) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
    }
}
