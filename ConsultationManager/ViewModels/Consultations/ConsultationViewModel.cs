using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;
using System.Collections.ObjectModel;
using ConsultationManager.Views.Consultation;
using System.Windows.Input;
using ConsultationManager.Commands;

namespace ConsultationManager.ViewModels.Consultations
{
    internal class ConsultationViewModel
    {
        private RDV rdvConsult;
        private Consultation consultation;
        private NewAntecedPersWindow dialogNewAntecedPers;
        private NewRemarqMedWindow dialogNewRemarqMed;
        private NewMedicamentWindow dialogNewMedicament;
        private RemarqueMedecin newRemarqMed;
        private Medicament newMedicament;
        private Ordonnance ordonnance;

        private AntecedentPersonel newAntecedPers;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;
        private ObservableCollection<int> listNbFois;

        public ConsultationViewModel(RDV rdv)
        {
            this.rdvConsult = rdv;
            NewAntecedPersDialogCommand = new RelayCommand(param => ShowDialogNewAntecedPers());
            NewRemarqMedDialogCommand = new RelayCommand(param => ShowDialogNewRemarqMed());
            NewMedicamentDialogCommand = new RelayCommand(param => ShowDialogNewMedicament());
            consultation = new Consultation(new ObservableCollection < AntecedentPersonel > (), new ObservableCollection < RemarqueMedecin > (), 0, 0, 0, 0, "", "");
            ordonnance = new Ordonnance(new ObservableCollection<Medicament>());
            RemoveAntecedPersCommand = new RelayCommand(param => DeleteAntecedPers(param));
            RemoveRemarqMedCommand = new RelayCommand(param => DeleteRemarqMed(param));
            RemoveMedicamentCommand = new RelayCommand(param => DeleteMedicament(param));
        }

        #region ConsultationViewModel Variables

        public RDV RdvConsult
        {
            get
            {
                return rdvConsult;
            }
        }
        public Consultation Consultation
        {
            get
            {
                return consultation;
            }
        }
        public NewAntecedPersWindow DialogNewAntecedPers
        {
            get
            {
                return dialogNewAntecedPers;
            }
        }
        public NewRemarqMedWindow DialogNewRemarqMed
        {
            get
            {
                return dialogNewRemarqMed;
            }
        }
        public AntecedentPersonel NewAntecedPers
        {
            get
            {
                return newAntecedPers;
            }
        }
        public RemarqueMedecin NewRemarqMed
        {
            get
            {
                return newRemarqMed;
            }
        }
        public Medicament NewMedicament
        {
            get
            {
                return newMedicament;
            }
        }
        public Ordonnance Ordonnance
        {
            get
            {
                return ordonnance;
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
        public ObservableCollection<int> ListNbFois
        {
            get
            {
                return listNbFois;
            }
        }
        #endregion

            #region ConsultationViewModel Commands

        public ICommand NewAntecedPersDialogCommand
        {
            get;
            private set;
        }
        public ICommand NewRemarqMedDialogCommand
        {
            get;
            private set;
        }

        public ICommand NewMedicamentDialogCommand
        {
            get;
            private set;
        }

        public ICommand AddAntecedPersCommand
        {
            get;
            private set;
        }
        public ICommand AddRemarqMedCommand
        {
            get;
            private set;
        }
        public ICommand AddMedicamentCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedPersCommand
        {
            get;
            private set;
        }
        public ICommand RemoveRemarqMedCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedicamentCommand
        {
            get;
            private set;
        }

        #endregion

        #region ConsultationViewModel Methods

        public void ShowDialogNewAntecedPers()
        {
            Console.WriteLine("ConsultationViewModel : Dialog Antecedent Personnel opened with RDV  ");
            dialogNewAntecedPers = new NewAntecedPersWindow();
            dialogNewAntecedPers.DataContext = this;
            AddAntecedPersCommand = new RelayCommand(param => AjouterAntecedPers(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedPers = new AntecedentPersonel("", 0, 0, "");
            dialogNewAntecedPers.ShowDialog();
        }
        public void ShowDialogNewRemarqMed()
        {
            Console.WriteLine("ConsultationViewModel : Dialog Remarque Medecin opened with RDV  ");
            dialogNewRemarqMed = new NewRemarqMedWindow();
            dialogNewRemarqMed.DataContext = this;
            AddRemarqMedCommand = new RelayCommand(param => AjouterRemarqMed(param));
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newRemarqMed = new RemarqueMedecin("", "");
            dialogNewRemarqMed.ShowDialog();
        }
        public void ShowDialogNewMedicament()
        {
            Console.WriteLine("ConsultationViewModel : Dialog Ordonnance opened with RDV  ");
            dialogNewMedicament = new NewMedicamentWindow();
            dialogNewMedicament.DataContext = this;
            AddMedicamentCommand = new RelayCommand(param => AjouterMedicament(param));
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            listNbFois = new ObservableCollection<int>(Enumerable.Range(1, 3));
            newMedicament = new Medicament("", 0, 0, 1, "", "");
            dialogNewMedicament.ShowDialog();
        }

        public void AjouterAntecedPers(object ant)
        {
            var newAnteced = ant as AntecedentPersonel;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newAnteced.Organe);
            dialogNewAntecedPers.Close();
            consultation.CommentsPatient.Add(newAnteced);
        }
        public void AjouterRemarqMed(object ant)
        {
            var newAnteced = ant as RemarqueMedecin;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newAnteced.Organe);
            dialogNewRemarqMed.Close();
            consultation.RemarquesMedecin.Add(newRemarqMed);
        }
        public void AjouterMedicament(object med)
        {
            var newMed = med as Medicament;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newMed.Nom);
            dialogNewMedicament.Close();
            ordonnance.ListMedicaments.Add(newMed);
        }
        public void DeleteAntecedPers(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as AntecedentPersonel;
            consultation.CommentsPatient.Remove(ant);
        }
        public void DeleteRemarqMed(object selectedRem)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var rem = selectedRem as RemarqueMedecin;
            consultation.RemarquesMedecin.Remove(rem);
        }
        public void DeleteMedicament(object selectedMed)
        {
            Console.WriteLine("ConsultationViewModel : Remove RDV  ");
            var med = selectedMed as Medicament;
            ordonnance.ListMedicaments.Remove(med);
        }

        #endregion
    }
}
