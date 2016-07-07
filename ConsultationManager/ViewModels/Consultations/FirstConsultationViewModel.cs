using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;
using ConsultationManager.Commands;
using ConsultationManager.Views.Consultation;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;

namespace ConsultationManager.ViewModels.Consultations
{
    internal class FirstConsultationViewModel
    {
        private RDV rdvConsult;
        private NewAntecedentWindow dialogNewAntecedent;
        private Antecedent newAntecedent;
        private ObservableCollection<Antecedent> listAntecedentPersonel;
        private ObservableCollection<Antecedent> listAntecedentFamilal;
        //private int diffMois;
        //private int diffJours;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;

        public FirstConsultationViewModel(RDV rdv)
        {
            rdvConsult = rdv;
            NewAntecedentoDialogCommand = new RelayCommand(param=>ShowDialogNewAntecedent());
            listAntecedentPersonel = new ObservableCollection<Antecedent>();
            RemoveAntecedentCommand = new RelayCommand(param => DeleteAntecedent(param));
        }

        public RDV RdvConsult
        {
            get
            {
                return rdvConsult;
            }
        }
        public NewAntecedentWindow DialogNewAntecedent
        {
            get
            {
                return dialogNewAntecedent;
            }
        }
        public Antecedent NewAntecedent
        {
            get
            {
                return newAntecedent;
            }
        }
        public ObservableCollection<Antecedent> ListAntecedentPersonel
        {
            get
            {
                return listAntecedentPersonel;
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
        //public int DiffMois
        //{
        //    get
        //    {
        //        return diffMois;
        //    }
        //}

        //public int DiffJours
        //{
        //    get
        //    {
        //        return diffJours;
        //    }
        //}

        #region FirstConsultationViewModel Commands

        public ICommand NewAntecedentoDialogCommand
        {
            get;
            private set;
        }

        public ICommand AddAntecedentCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedentCommand
        {
            get;
            private set;
        }

        #endregion

        public void ShowDialogNewAntecedent()
        {
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
            dialogNewAntecedent = new NewAntecedentWindow();
            dialogNewAntecedent.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
            AddAntecedentCommand = new RelayCommand(param => AjouterAntecedent(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedent = new Antecedent("", 0, 0, "");
            dialogNewAntecedent.ShowDialog();
        }

        public void AjouterAntecedent(object ant)
        {
            var newAnteced = ant as Antecedent;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  "+newAnteced.Organe);
            dialogNewAntecedent.Close();
            listAntecedentPersonel.Add(newAnteced);
            //dialogNewAntecedent.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
        }
        public void DeleteAntecedent(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as Antecedent;
            listAntecedentPersonel.Remove(ant);
        }
    }
}
