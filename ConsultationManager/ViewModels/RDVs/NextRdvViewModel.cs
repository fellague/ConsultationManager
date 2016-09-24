using ConsultationManager.ServiceReferencePlanning;
using ConsultationManager.ServiceReferenceRdv;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerClient.ViewModels.Patients;
using ConsultationManagerClient.ViewModels.RDVs;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConsultationManager.ViewModels.RDVs
{
    internal class NextRdvViewModel : INotifyPropertyChanged
    {
        private RdvServiceClient rsc = new RdvServiceClient();
        private ListRvdViewModel rdvsVM;
        private RdvPatientMedecin selectedRdv;
        private ConsultationMedecinsPlanning planning;
        private List<RdvPatientMedecin> listRdvsConsultation;
        private RDV newRdv;

        private ObservableCollection<Utilisateur> listMedecins;
        private Utilisateur selectedMedecin;

        private int diffMois;
        private int diffJours;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;

        private int selectedRang;
        private ObservableCollection<int> listRangs;
        private DateTime heure;

        public NextRdvViewModel(RdvPatientMedecin rdv, ListRvdViewModel pVM)
        {
            rsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            rsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            rsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            selectedRdv = rdv;
            rdvsVM = pVM;
            planning = GetPlanningDetail();

            listRdvsConsultation = GetRdvsConsultation(rdv.Rdv.PathologieId);

            newRdv = new RDV();
            newRdv.DateRdv = DateTime.Now.AddDays(1);

            listRangs = new ObservableCollection<int>(Enumerable.Range(1, 18));
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));

            listMedecins = GetMedecins(planning);
            selectedMedecin = new Utilisateur();
            SelectedMedecin = selectedRdv.Medecin;


            //DiffMois = 3;
            //DiffJours = 0;

            heure = DateTime.Now;
            heure = new DateTime(heure.Year, heure.Month, heure.Day, 8, 0, 0);

            AddNextRdvCommand = new RelayCommand(param => AjouterRdv());
            CancelCommand = new RelayCommand(o => ((Window)o).Close());
        }

        #region RdvNewPatientViewModel Variables

        public RdvPatientMedecin SelectedPatient
        {
            get
            {
                return selectedRdv;
            }
        }

        public ObservableCollection<Utilisateur> ListMedecins
        {
            get
            {
                return listMedecins;
            }
            set
            {
                listMedecins = value;
                OnPropertyChanged("ListMedecins");
            }
        }

        public Utilisateur SelectedMedecin
        {
            get
            {
                return selectedMedecin;
            }
            set
            {
                selectedMedecin = value;
                //MessageBox.Show("Ancienne Date " + NewdRdv.DateRdv.DayOfWeek + " " + NewdRdv.DateRdv);
                GetValideDate();
                //MessageBox.Show("Nouvelle Date " + NewdRdv.DateRdv);
                ListRangs = GetRangs();
                OnPropertyChanged("SelectedMedecin");
            }
        }

        public RDV NewRdv
        {
            get
            {
                //Console.WriteLine("UpdateRdvViewModel : difference date ( " + updatedRdv.DateRdv + " --- " + DateTime.Now + " )  is " + diffMois + " months and " + diffJours + " days");
                return newRdv;
            }
            set
            {
                newRdv = value;
                OnPropertyChanged("NewRdv");
            }
        }

        public int DiffMois
        {
            get
            {
                int Mois = 0;
                while (newRdv.DateRdv.CompareTo(DateTime.Now.Date.AddMonths(++Mois)) >= 0) { }
                diffMois = --Mois;
                //Console.WriteLine("DiffMois get changed" + diffMois);
                return diffMois;
            }
            set
            {
                diffMois = value;
                //Console.WriteLine("DiffMois set changed " + diffMois);
                newRdv.DateRdv = DateTime.Now.Date.AddMonths(diffMois).AddDays(diffJours);
                //MessageBox.Show("Ancienne Date " + NewdRdv.DateRdv.DayOfWeek + " " + NewdRdv.DateRdv);
                GetValideDate();
                //MessageBox.Show("Nouvelle Date " + NewdRdv.DateRdv);
                ListRangs = GetRangs();
                OnPropertyChanged("DiffMois");
            }
        }

        public int DiffJours
        {
            get
            {
                int Jours = 0;
                while (newRdv.DateRdv.CompareTo(DateTime.Now.AddMonths(diffMois).AddDays(++Jours)) >= 0) { }
                diffJours = --Jours;
                return diffJours;
            }
            set
            {
                diffJours = value;
                newRdv.DateRdv = DateTime.Now.AddMonths(diffMois).AddDays(diffJours);

                //MessageBox.Show("Ancienne Date " + NewdRdv.DateRdv.DayOfWeek + " " + NewdRdv.DateRdv);
                GetValideDate();
                //MessageBox.Show("Nouvelle Date " + NewdRdv.DateRdv);
                ListRangs = GetRangs();
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

        public ObservableCollection<int> ListRangs
        {
            get
            {
                return listRangs;
            }
            set
            {
                listRangs = value;
                OnPropertyChanged("ListRangs");
            }
        }
        public int SelectedRang
        {
            get
            {
                return selectedRang;
            }
            set
            {
                selectedRang = value;
                heure = new DateTime(heure.Year, heure.Month, heure.Day, 8, 0, 0);
                if (selectedRang < 12)
                    Heure = Heure.AddMinutes((selectedRang - 1) * 20);
                else
                    Heure = Heure.AddMinutes((selectedRang - 1) * 20 + 60);
                OnPropertyChanged("SelectedRang");
            }
        }

        public DateTime Heure
        {
            get
            {
                return heure;
            }
            set
            {
                heure = value;
                OnPropertyChanged("Heure");
            }
        }
        #endregion

        #region RdvNewPatientViewModel Commands

        public ICommand AddNextRdvCommand
        {
            get;
            private set;
        }
        public ICommand CancelCommand
        {
            get;
            private set;
        }

        #endregion

        #region RdvNewPatientViewModel Methods

        private ConsultationMedecinsPlanning GetPlanningDetail()
        {
            ConsultationMedecinsPlanning plan = new ConsultationMedecinsPlanning();

            PlanningServiceClient psc = new PlanningServiceClient();
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            return psc.GetPlanning(selectedRdv.Rdv.PathologieId);
        }

        private ObservableCollection<Utilisateur> GetMedecins(ConsultationMedecinsPlanning plan)
        {
            List<Utilisateur> list = new List<Utilisateur>();
            //List<Utilisateur> list2 = new List<Utilisateur>();
            foreach (Utilisateur usr in plan.MedecinsDimanche)
            {
                if (list.Count() == 0)
                    list = plan.MedecinsDimanche.ToList();

                if (!list.Any(us => us.Id == usr.Id))
                    list.Add(usr);
            }
            foreach (Utilisateur usr in plan.MedecinsLundi)
            {

                if (list.Count() == 0)
                    list = plan.MedecinsLundi.ToList();

                if (!list.Any(us => us.Id == usr.Id))
                    list.Add(usr);
            }
            foreach (Utilisateur usr in plan.MedecinsMardi)
            {
                if (list.Count() == 0)
                    list = plan.MedecinsMardi.ToList();

                if (!list.Any(us => us.Id == usr.Id))
                    list.Add(usr);
            }
            foreach (Utilisateur usr in plan.MedecinsMercredi)
            {
                if (list.Count() == 0)
                    list = plan.MedecinsMercredi.ToList();

                if (!list.Any(us => us.Id == usr.Id))
                    list.Add(usr);
            }
            foreach (Utilisateur usr in plan.MedecinsJeudi)
            {
                if (list.Count() == 0)
                    list = plan.MedecinsJeudi.ToList();

                if (!list.Any(us => us.Id == usr.Id))
                    list.Add(usr);
            }
            ObservableCollection<Utilisateur> listRet = new ObservableCollection<Utilisateur>();
            foreach (Utilisateur usr in list)
                listRet.Add(usr);
            return listRet;
        }

        private void GetValideDate()
        {
            bool foundDate = false;
            while (!foundDate)
            {
                //MessageBox.Show("Ancienne Date " + NewRdv.DateRdv.DayOfWeek + " " + NewRdv.DateRdv + " " + selectedMedecin.Id);
                switch (NewRdv.DateRdv.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        foreach (Utilisateur usr in planning.MedecinsDimanche)
                        {
                            if (usr.Id == selectedMedecin.Id)
                                foundDate = true;
                        }
                        if (!foundDate)
                            NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                    case DayOfWeek.Monday:
                        foreach (Utilisateur usr in planning.MedecinsLundi)
                        {
                            if (usr.Id == selectedMedecin.Id)
                                foundDate = true;
                        }
                        if (!foundDate)
                            NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                    case DayOfWeek.Tuesday:
                        foreach (Utilisateur usr in planning.MedecinsMardi)
                        {
                            if (usr.Id == selectedMedecin.Id)
                                foundDate = true;
                        }
                        if (!foundDate)
                            NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                    case DayOfWeek.Wednesday:
                        foreach (Utilisateur usr in planning.MedecinsMercredi)
                        {
                            if (usr.Id == selectedMedecin.Id)
                                foundDate = true;
                        }
                        if (!foundDate)
                            NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                    case DayOfWeek.Thursday:
                        foreach (Utilisateur usr in planning.MedecinsJeudi)
                        {
                            if (usr.Id == selectedMedecin.Id)
                                foundDate = true;
                        }
                        if (!foundDate)
                            NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                    case DayOfWeek.Friday:
                        NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                    case DayOfWeek.Saturday:
                        NewRdv.DateRdv = NewRdv.DateRdv.AddDays(1);
                        break;
                }
                //MessageBox.Show("Nouvelle Date " + NewRdv.DateRdv.DayOfWeek + " " + NewRdv.DateRdv + " " + selectedMedecin.Id);
            }
        }

        private List<RdvPatientMedecin> GetRdvsConsultation(string idConsultation)
        {
            List<RdvPatientMedecin> list = new List<RdvPatientMedecin>();
            list = new List<RdvPatientMedecin>(rsc.GetRdvConsultation(idConsultation));
            return list;
        }

        private ObservableCollection<int> GetRangs()
        {
            List<RdvPatientMedecin> listRdvMedecinSelected = new List<RdvPatientMedecin>();

            var toAdd = listRdvsConsultation.Where(rdv => rdv.Medecin.Id == selectedMedecin.Id && rdv.Rdv.DateRdv.Date == NewRdv.DateRdv.Date).ToList();
            foreach (var item in toAdd)
                listRdvMedecinSelected.Add(item);

            ObservableCollection<int> list = new ObservableCollection<int>();
            list = new ObservableCollection<int>(Enumerable.Range(1, 18));

            foreach (var item in listRdvMedecinSelected)
                list.Remove(item.Rdv.Rang);

            return list;
        }

        private void AjouterRdv()
        {
            NewRdv.PatientId = selectedRdv.Patient.Id;
            NewRdv.MedecinRespId = selectedRdv.Medecin.Id;
            NewRdv.Rang = selectedRang;
            NewRdv.CreeDans = DateTime.Now;
            NewRdv.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            NewRdv.ServiceId = AuthenticationViewModel.AuthenticatedUser.ServiceId;
            NewRdv.PathologieId = AuthenticationViewModel.AuthenticatedUser.PathologieId;
            NewRdv.NouvPat = false;

            RdvPatientMedecin rdv = new RdvPatientMedecin();
            rdv.Medecin = selectedRdv.Medecin;
            rdv.Patient = selectedRdv.Patient;
            rdv.Rdv = rsc.AddRdv(NewRdv);

            rdvsVM.ListAllRvd.Add(rdv);
            rdvsVM.ListAllRvd.Remove(selectedRdv);
            rdvsVM.ActualiserLists();

            rdvsVM.NextRdvWindow.Close();
            rdvsVM.DialogInterwiewConclusionView.Close();
            //if(!selectedRdv.Rdv.NouvPat)
            //    rdvsVM.DialogInterviewView.Close();
        }

        #endregion

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
