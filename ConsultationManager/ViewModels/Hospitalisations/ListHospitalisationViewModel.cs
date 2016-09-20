using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models.Hospitalisations;

namespace ConsultationManagerClient.ViewModels.Hospitalisations
{
    internal class ListHospitalisationViewModel
    {
        private string nomUtilisateur;
        private ObservableCollection<Hospitalisation> listAllHospitalisation;
        private ObservableCollection<Hospitalisation> listActiveHospitalisation;

        public ListHospitalisationViewModel()
        {
            listAllHospitalisation = CreateHospitalisations();
            listActiveHospitalisation = CreateListActiveHospitalisation();
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;
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
        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        private ObservableCollection<Hospitalisation> CreateHospitalisations()
        {
            ObservableCollection<Hospitalisation> list = new ObservableCollection<Hospitalisation>();
            //list.Add(new Hospitalisation("", "Kaddour Aissa", "Kamel", "5", "14", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-3), DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-11), "Adda hanifi Omar"));
            //list.Add(new Hospitalisation("1", "Hadj Henni", "Abdelkader" , "3", "7", DateTime.Today.AddDays(-5), DateTime.Today.AddDays(2), DateTime.Today, DateTime.Today.AddDays(-32), "Mokrane Fatiha"));
            //list.Add(new Hospitalisation("2", "Koidri", "Fatma", "1", "3", DateTime.Today, DateTime.Today.AddDays(7),new DateTime(1, 1, 1), DateTime.Today.AddDays(-1), "Halim Imed"));
            //list.Add(new Hospitalisation("", "Chergou", "Abdelhak" , "5", "10", DateTime.Today.AddDays(-20), DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-30), "Fellague chebra Abdelhalim"));
            //list.Add(new Hospitalisation("3", "Bouzidi", "Brahim", "3", "5", DateTime.Today.AddDays(-1), DateTime.Today.AddDays(10), DateTime.Today, DateTime.Today.AddDays(-19), "bennouna el khebith"));
            //list.Add(new Hospitalisation("", "Aissawi", "Oussama", "5", "6", DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-4), "fellague halim"));
            //list.Add(new Hospitalisation("", "Nouri", "Hakim", "3", "2", DateTime.Today.AddMonths(-3), DateTime.Today.AddMonths(-3).AddDays(10), DateTime.Today.AddMonths(-3).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-1), "Sakraoui Imed"));
            //list.Add(new Hospitalisation("", "Berroudji", "Bakhta", "5", "8", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "Melloul Abdellah"));
            //list.Add(new Hospitalisation("", "Amaouri", "Saiid", "5", "3", DateTime.Today.AddMonths(1).AddDays(3), DateTime.Today.AddMonths(1).AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "Adda hanifi Omar"));
            //list.Add(new Hospitalisation("", "Bouraoui", "Ammar", "1", "4", DateTime.Today.AddMonths(-4), DateTime.Today.AddMonths(-4).AddDays(7), DateTime.Today.AddMonths(-4).AddDays(10), DateTime.Today.AddMonths(-4).AddDays(-4), "Halim Imed"));
            //list.Add(new Hospitalisation("4", "Henni", "El Alia", "3", "4", DateTime.Today.AddDays(-4), DateTime.Today.AddDays(5), new DateTime(1, 1, 1), DateTime.Today.AddDays(-6), "Melloul Abdellah"));
            //list.Add(new Hospitalisation("", "Ben yamina", "Abdelkader", "5", "11", DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(10), DateTime.Today.AddMonths(-2).AddDays(-4), "Sakraoui Imed"));
            //list.Add(new Hospitalisation("5", "Bougara", "Brahim", "1", "2", DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1), new DateTime(1, 1, 1), DateTime.Today.AddDays(-10), "Melloul Abdellah"));
            //list.Add(new Hospitalisation("", "Khoukhi", "Doukkich", "5", "9", DateTime.Today.AddDays(3), DateTime.Today.AddDays(10), new DateTime(1, 1, 1), DateTime.Today, "Sakraoui Imed"));
            return list;
        }

        private ObservableCollection<Hospitalisation> CreateListActiveHospitalisation()
        {
            ObservableCollection<Hospitalisation> allList = CreateHospitalisations();
            ObservableCollection<Hospitalisation> allMyList = new ObservableCollection<Hospitalisation>();
            foreach (Hospitalisation element in allList)
            {
                if (element.DateFinPrevu.Date.CompareTo(DateTime.Now) > 0 && element.DateDebut.Date.CompareTo(DateTime.Now.Date) <= 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
    }
}
