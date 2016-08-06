using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;

namespace ConsultationManagerClient.ViewModels.Employees
{
    internal class ListEmployeesViewModel
    {
        private ObservableCollection<Employee> listAllEmployee;
        private ObservableCollection<Employee> listMedecin;
        private ObservableCollection<Employee> listInfirmier;
        private ObservableCollection<Employee> listChefService;
        private ObservableCollection<Employee> listAssistant;

        public ListEmployeesViewModel()
        {
            listAllEmployee = CreateEmployees();
            listMedecin = CreateListMedecin();
            listInfirmier = CreateListInfirmier();
            listChefService = CreateListChefService();
            listAssistant = CreateListAssistant();
        }

        public ObservableCollection<Employee> ListAllEmployee
        {
            get
            {
                return listAllEmployee;
            }
        }
        public ObservableCollection<Employee> ListMedecin
        {
            get
            {
                return listMedecin;
            }
        }
        public ObservableCollection<Employee> ListInfirmier
        {
            get
            {
                return listInfirmier;
            }
        }
        public ObservableCollection<Employee> ListChefService
        {
            get
            {
                return listChefService;
            }
        }
        public ObservableCollection<Employee> ListAssistant
        {
            get
            {
                return listAssistant;
            }
        }

        private ObservableCollection<Employee> CreateEmployees()
        {
            ObservableCollection<Employee> list = new ObservableCollection<Employee>();
            list.Add(new Employee("Mimouni", "Soumia", "admin", new DateTime(1975, 7, 13), "chlef hay essalem n 3", "06 98 75 65 90", DateTime.Today, "admin"));
            list.Add(new Employee("Jack", "Rodman", "infirmier", new DateTime(1965, 3, 23), "blida hay el amal n 98", "07 99 87 54 76", new DateTime(2009, 5, 10), "Mimouni Soumia"));
            list.Add(new Employee("Sandra", "Sherry", "chef_service", new DateTime(1967, 1, 10), "alger harrach bouraoui A 33", "05 87 09 54 34", new DateTime(2008, 12, 22), "Mimouni Soumia"));
            list.Add(new Employee("Sabrina", "Vilk", "medecin", new DateTime(1987, 7, 8), "tyaret hay essaada nu 381", "07 98 65 34 98", DateTime.Today, "Mimouni Soumia"));
            list.Add(new Employee("Mike", "Pearson", "medecin", new DateTime(1952, 8, 30), "oran la korniche nup 929", "07 87 87 98 09", new DateTime(2008, 10, 18), "Mimouni Soumia"));
            list.Add(new Employee("Bill", "Watson", "infirmier", new DateTime(1978, 4, 20), "Khenchla bouhmema nu 098", "06 65 34 23 87", new DateTime(2016, 1, 18), "Mimouni Soumia"));
            list.Add(new Employee("Christiano", "Ronaldo", "medecin", new DateTime(1987, 3, 10), "Purtugal hay el amal 054", "05 34 53 23 24", new DateTime(2014, 7, 10), "Mimouni Soumia"));
            list.Add(new Employee("Maria", "Klara", "infirmier", new DateTime(1962, 1, 10), "alger harrach bouraoui A 33", "05 87 09 54 34", new DateTime(2012, 2, 20), "Mimouni Soumia"));
            list.Add(new Employee("Amaouri", "Benjamen", "chef_service", new DateTime(1978, 3, 23), "blida hay el amal n 98", "07 99 87 54 76", new DateTime(2003, 7, 1), "Mimouni Soumia"));
            list.Add(new Employee("Bouraoui", "ElMerioul", "medecin", new DateTime(1955, 6, 12), "Herrach hay essalem n 3", "06 97 75 65 89", DateTime.Today, "Mimouni Soumia"));
            list.Add(new Employee("Henni", "El Alia", "assistant", new DateTime(1982, 8, 3), "Betna la korniche nup 929", "07 89 76 76 54", new DateTime(2005, 10, 18), "Mimouni Soumia"));
            list.Add(new Employee("Keyta", "Ben yamina", "infirmier", new DateTime(1954, 1, 1), "Chlef hey essalem A 33", "05 65 87 98 65", new DateTime(2012, 12, 22), "Mimouni Soumia"));
            list.Add(new Employee("Gabriel", "Pepe", "assistant", new DateTime(1943, 11, 16), "Anaba hay el amal 054", "05 87 33 21 24", new DateTime(2011, 7, 10), "Mimouni Soumia"));
            list.Add(new Employee("Khoukhi", "Doukkich", "medecin", new DateTime(1990, 4, 20), "Chlef hay essalem nu 098", "07 76 98 09 54", new DateTime(2009, 4, 8), "Mimouni Soumia"));
            return list;
        }

        private ObservableCollection<Employee> CreateListMedecin()
        {
            ObservableCollection<Employee> allList = CreateEmployees();
            ObservableCollection<Employee> allMyList = new ObservableCollection<Employee>();
            foreach (Employee element in allList)
            {
                if (element.Role == "medecin")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Employee> CreateListInfirmier()
        {
            ObservableCollection<Employee> allList = CreateEmployees();
            ObservableCollection<Employee> allMyList = new ObservableCollection<Employee>();
            foreach (Employee element in allList)
            {
                if (element.Role == "infirmier")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Employee> CreateListChefService()
        {
            ObservableCollection<Employee> allList = CreateEmployees();
            ObservableCollection<Employee> allMyList = new ObservableCollection<Employee>();
            foreach (Employee element in allList)
            {
                if (element.Role == "chef_service")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<Employee> CreateListAssistant()
        {
            ObservableCollection<Employee> allList = CreateEmployees();
            ObservableCollection<Employee> allMyList = new ObservableCollection<Employee>();
            foreach (Employee element in allList)
            {
                if (element.Role == "assistant")
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
    }
}
