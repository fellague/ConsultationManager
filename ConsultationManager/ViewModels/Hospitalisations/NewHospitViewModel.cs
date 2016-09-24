using ConsultationManager.ServiceReferenceHospit;
using ConsultationManagerClient.Commands;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerClient.ViewModels.Hospitalisations;
using ConsultationManagerServer.Models.Hospitalisations;
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

namespace ConsultationManager.ViewModels.Hospitalisations
{
    internal class NewHospitViewModel : INotifyPropertyChanged
    {
        private HospitServiceClient hsc = new HospitServiceClient();
        private ListHospitalisationViewModel hospitsVM;
        private DemandeHospitDetail selectDemande;

        private List<SalleHospitPlanning> planning;
        private Hospitalisation newHospit;

        private string selectedTypeSalle;

        private int diffMois;
        private int diffJours;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;

        private int dureJours;
        private ObservableCollection<int> listDureJours;

        private Salle chosenSalle;
        //private ObservableCollection<Salle> listSalle;
        //private Salle selectSalle;

        //private ObservableCollection<int> listLits;
        //private int selectLit;

        public NewHospitViewModel(DemandeHospitDetail demand, ListHospitalisationViewModel hVM)
        {
            hsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            hsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            hsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            selectDemande = demand;
            hospitsVM = hVM;
            planning = GetPlanningDetail();
            
            newHospit = new Hospitalisation();
            //newHospit.DateRdv = DateTime.Now.AddDays(1);
            newHospit.IdPatient = demand.Patient.Id;
            newHospit.IdMedecin = demand.Medecin.Id;

            SelectedTypeSalle = "Plombée";
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 7));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 31));
            DiffMois = 0;
            DiffJours = 0;

            listDureJours = new ObservableCollection<int>(Enumerable.Range(1, 30));
            DureJours = 1;

            //listLits = new ObservableCollection<int>(Enumerable.Range(1, 18));

            AddNewHospitCommand = new RelayCommand(param => AjouterHospit());
            CancelCommand = new RelayCommand(o => ((Window)o).Close());
        }

        #region RdvNewPatientViewModel Variables

        public DemandeHospitDetail SelectedDemande
        {
            get
            {
                return selectDemande;
            }
        }

        public string SelectedTypeSalle
        {
            get
            {
                return selectedTypeSalle;
            }
            set
            {
                selectedTypeSalle = value;
                GetValideDate();
                OnPropertyChanged("SelectedTypeSalle");
            }
        }

        public Hospitalisation NewHospit
        {
            get
            {
                return newHospit;
            }
            set
            {
                newHospit = value;
                OnPropertyChanged("NewHospit");
            }
        }

        public int DiffMois
        {
            get
            {
                int Mois = 0;
                while (newHospit.DateDebutPrevu.CompareTo(DateTime.Now.Date.AddMonths(++Mois)) >= 0) { }
                diffMois = --Mois;
                //Console.WriteLine("DiffMois get changed" + diffMois);
                return diffMois;
            }
            set
            {
                diffMois = value;
                //Console.WriteLine("DiffMois set changed " + diffMois);
                newHospit.DateDebutPrevu = DateTime.Now.Date.AddMonths(diffMois).AddDays(diffJours);
                //MessageBox.Show("Ancienne Date " + NewdRdv.DateRdv.DayOfWeek + " " + NewdRdv.DateRdv);
                GetValideDate();
                OnPropertyChanged("DiffMois");
            }
        }

        public int DiffJours
        {
            get
            {
                int Jours = 0;
                while (newHospit.DateDebutPrevu.CompareTo(DateTime.Now.AddMonths(diffMois).AddDays(++Jours)) >= 0) { }
                diffJours = --Jours;
                return diffJours;
            }
            set
            {
                diffJours = value;
                newHospit.DateDebutPrevu = DateTime.Now.AddMonths(diffMois).AddDays(diffJours);

                //MessageBox.Show("Ancienne Date " + NewdRdv.DateRdv.DayOfWeek + " " + NewdRdv.DateRdv);
                GetValideDate();
                OnPropertyChanged("DiffJours");
            }
        }

        public int DureJours
        {
            get
            {
                return dureJours;
            }
            set
            {
                dureJours = value;
                newHospit.DateFinPrevu = newHospit.DateDebutPrevu.AddDays(dureJours);

                //MessageBox.Show("Ancienne Date " + NewdRdv.DateRdv.DayOfWeek + " " + NewdRdv.DateRdv);
                GetValideDate();
                OnPropertyChanged("DureJours");
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
        public ObservableCollection<int> ListDureJours
        {
            get
            {
                return listDureJours;
            }
        }

        public Salle ChosenSalle
        {
            get
            {
                return chosenSalle;
            }
            set
            {
                chosenSalle = value;
                OnPropertyChanged("ChosenSalle");
            }
        }

        #endregion

        #region RdvNewPatientViewModel Commands

        public ICommand AddNewHospitCommand
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

        private List<SalleHospitPlanning> GetPlanningDetail()
        {
            List<SalleHospitPlanning> plan = new List<SalleHospitPlanning>();

            plan = new List<SalleHospitPlanning>(hsc.GetSallePlanning(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            return plan;
        }

        private void GetValideDate()
        {
            ObservableCollection<Hospitalisation> listChoix = new ObservableCollection<Hospitalisation>();

            ObservableCollection<Hospitalisation> listHospSalle = new ObservableCollection<Hospitalisation>();

            foreach(SalleHospitPlanning plan in planning)
            {
                if(plan.Salle.Type == SelectedTypeSalle)
                {
                    listHospSalle = new ObservableCollection<Hospitalisation>();
                    int lit = 1;
                    while (lit <= plan.Salle.NbLit)
                    {
                        Hospitalisation meilHospLit = new Hospitalisation();
                        //NewHospit.IdSalle = plan.Salle.Id;
                        meilHospLit.IdSalle = plan.Salle.Id;
                        meilHospLit.DateDebutPrevu = NewHospit.DateDebutPrevu;
                        meilHospLit.DateFinPrevu = NewHospit.DateFinPrevu;
                        meilHospLit.Lit = lit;
                        if(plan.Hospits.Count() > 0)
                            foreach (Hospitalisation hosp in plan.Hospits)
                            {
                                if(hosp.Lit == lit)
                                {
                                    if(meilHospLit.DateDebutPrevu.Date.CompareTo(hosp.DateDebutPrevu.Date) >= 0 && meilHospLit.DateDebutPrevu.Date.CompareTo(hosp.DateFinPrevu.Date) <= 0)
                                    {
                                        //MessageBox.Show("<----*---> ");
                                        meilHospLit.DateDebutPrevu = hosp.DateFinPrevu.AddDays(1); ///////Cas num 1 : <----*---> 
                                    }
                                    else
                                    {
                                        if(meilHospLit.DateDebutPrevu.Date.CompareTo(hosp.DateDebutPrevu.Date) < 0)
                                        {
                                            if(meilHospLit.DateFinPrevu.Date.CompareTo(hosp.DateDebutPrevu.Date) < 0)
                                            {
                                                //MessageBox.Show(" *-----* <-------> ");
                                                //listHospPoss.Add(meilHosp); ///////Cas num 2 :  *-----* <-------> 
                                            }
                                            else
                                            {
                                                //MessageBox.Show("*---<------->");
                                                meilHospLit.DateDebutPrevu = hosp.DateFinPrevu.AddDays(1); ///////Cas num 3 :  *---<-------> 
                                            }
                                        }
                                        else
                                        {
                                            //MessageBox.Show("<-------> *------*");
                                            //listHospPoss.Add(meilHosp);///////Cas num 4 : <-------> *------*
                                        }
                                    }
                                }
                            }
                        else
                        {

                        }
                        listHospSalle.Add(meilHospLit);
                        lit++;
                    }
                    ///////////get the best hospitalisation in listHospSalle
                    Hospitalisation hos = new Hospitalisation();
                    hos = listHospSalle.First();
                    //int i = 0;
                    for (int i = 0; i < listHospSalle.Count(); i++)
                    {
                        if (hos.DateDebutPrevu.Date.CompareTo(listHospSalle[i].DateDebutPrevu.Date) > 0)
                            hos = listHospSalle[i];
                    }
                    listChoix.Add(hos);
                }
            }
            ///////////get the best hospitalisation
            Hospitalisation BestHos = new Hospitalisation();
            BestHos = listChoix.First();
            //int j = 0;
            for (int j = 0; j < listChoix.Count(); j++)
            {
                if (BestHos.DateDebutPrevu.Date.CompareTo(listChoix[j].DateDebutPrevu.Date) > 0)
                    BestHos = listChoix[j];
            }
            ChosenSalle = planning.Where(p => p.Salle.Id == BestHos.IdSalle).First().Salle;
            NewHospit = BestHos;
        }

        private void AjouterHospit()
        {
            NewHospit.IdPatient = selectDemande.Patient.Id;
            NewHospit.IdMedecin = selectDemande.Medecin.Id;
            NewHospit.IdDemande = selectDemande.DemandeHospit.Id;
            NewHospit.CreeDans = DateTime.Now;
            NewHospit.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            NewHospit.ServiceId = AuthenticationViewModel.AuthenticatedUser.ServiceId;

            HospitalisationDetail newHospDetail = new HospitalisationDetail();
            newHospDetail.Patient = selectDemande.Patient;
            newHospDetail.Medecin = selectDemande.Medecin;
            newHospDetail.Hospitalisation = hsc.AddHospit(NewHospit);
            hospitsVM.ListAllHospitalisation.Add(newHospDetail);

            //hospitsVM.ListAllHospitalisation.Add(NewHospit);
            hospitsVM.ListDemandeHospit.Remove(selectDemande);
            hospitsVM.ActualiserLists();

            hospitsVM.DialogNewHospit.Close();
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

    class Choix
    {
        public DateTime DateEntre
        {
            get;
            set;
        }
        public Salle Salle
        {
            get;
            set;
        }
    }
}
