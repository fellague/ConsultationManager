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

namespace ConsultationManager.ViewModels.Patients
{
    internal class ListPatientViewModel
    {
        private ObservableCollection<Patient> listAllPatient;
        private ObservableCollection<Patient> listAllMyPatient;

        public ListPatientViewModel()
        {
            listAllPatient = CreatePatients();
            listAllMyPatient = CreateListAllMyPatient();
            
        }

        public ObservableCollection<Patient> ListAllPatient
        {
            get
            {
                return listAllPatient;
            }
        }
        public ObservableCollection<Patient> ListAllMyPatient
        {
            get
            {
                return listAllMyPatient;
            }
        }

        private ObservableCollection<Patient> CreatePatients()
        {
            ObservableCollection<Patient> list = new ObservableCollection<Patient>();
            list.Add(new Patient("Nick", "White", new DateTime(1975, 7, 13), "un kis zza doic sdz zdlkd sdndk sdcioz sdijd", "chlef hay essalem n 3", "06 98 75 65 90", true, DateTime.Today, "tebibell saliha"));
            list.Add(new Patient("Jack", "Rodman", new DateTime(1965, 3, 23), "un malle dans la tete qsjsd cjqs ketipaliss", "blida hay el amal n 98", "07 99 87 54 76", false, new DateTime(2009, 5, 10), "mokrane fatiha"));
            list.Add(new Patient("Sandra", "Sherry", new DateTime(1967, 1, 10), "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc", "alger harrach bouraoui A 33", "05 87 09 54 34", false, new DateTime(2008, 12, 22), "bellal kader"));
            list.Add(new Patient("Sabrina", "Vilk", new DateTime(1987, 7, 8), "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj", "tyaret hay essaada nu 381", "07 98 65 34 98", true, DateTime.Today, "fellague halim"));
            list.Add(new Patient("Mike", "Pearson", new DateTime(1952, 8, 30), "mpqxn ckjqs xc ydc jwx wdckjqsd xwjwxc kjxw kjcqs cjksd ,jwx", "oran la korniche nup 929", "07 87 87 98 09", true, new DateTime(2008, 10, 18), "bennouna el khebith"));
            list.Add(new Patient("Bill", "Watson", new DateTime(1978, 4, 20), "fcef rvfrf rfv tgv wqw zsxsx zxszsd cedcvf rf tb tynh,uj ujkol pmsd", "Khenchla bouhmema nu 098", "06 65 34 23 87", true, new DateTime(2016, 1, 18), "fellague halim"));
            list.Add(new Patient( "Christiano", "Ronaldo", new DateTime(1987, 3, 10), "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj", "Purtugal hay el amal 054", "05 34 53 23 24", true, new DateTime(2014, 7, 10), "bennouna el khebith"));
            list.Add(new Patient("Maria","Klara", new DateTime(1962, 1, 10), "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc", "alger harrach bouraoui A 33", "05 87 09 54 34", false, new DateTime(2012, 2, 20), "bellal kader"));
            list.Add(new Patient("Amaouri", "Benjamen", new DateTime(1978, 3, 23), "un malle dans la tete qsjsd cjqs ketipaliss", "blida hay el amal n 98", "07 99 87 54 76", false, new DateTime(2003, 7, 1), "fellague halim"));
            list.Add(new Patient("Bouraoui", "ElMerioul", new DateTime(1955, 6, 12), "un kis zza doic sdz zdlkd sdndk sdcioz sdijd", "Herrach hay essalem n 3", "06 97 75 65 89", true, DateTime.Today, "tebibell saliha"));
            list.Add(new Patient("Henni", "El Alia", new DateTime(1982, 8, 3), "mpqxn ckqs sckqs ckjqs xc ydc jwx wdckjqsd xwjwxc kjxw kjcqs cjksd ,jwx", "Betna la korniche nup 929", "07 89 76 76 54", true, new DateTime(2005, 10, 18), "fellague halim"));
            list.Add(new Patient("Keyta", "Ben yamina", new DateTime(1954, 1, 1), "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc", "Chlef hey essalem A 33", "05 65 87 98 65", false, new DateTime(2012, 12, 22), "bellal kader"));
            list.Add(new Patient("Gabriel", "Pepe", new DateTime(1943, 11, 16), "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj", "Anaba hay el amal 054", "05 87 33 21 24", true, new DateTime(2011, 7, 10), "bennouna el khebith"));
            list.Add(new Patient( "Khoukhi", "Doukkich", new DateTime(1990, 4, 20), "fcef rvfrf rfv tgv wqw zsxsx zxszsd cedcvf rf tb tynh,uj ujkol pmsd", "Chlef hay essalem nu 098", "07 76 98 09 54", false, new DateTime(2009, 4, 8), "fellague halim"));
            return list;
        }

        private ObservableCollection<Patient> CreateListAllMyPatient()
        {
            ObservableCollection<Patient> allList = CreatePatients();
            ObservableCollection<Patient> allMyList = new ObservableCollection<Patient>();
            foreach (Patient element in allList)
            {
                if (element.CreePar == "fellague halim")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
    }
}
