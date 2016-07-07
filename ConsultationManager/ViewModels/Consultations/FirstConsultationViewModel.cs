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
        private NewAntecedPersWindow dialogNewAntecedPers;
        private NewAntecedFamilWindow dialogNewAntecedFamil;
        private AntecedentPersonel newAntecedPers;
        private AntecedentFamilial newAntecedFamil;
        private ObservableCollection<AntecedentPersonel> listAntecedentPersonel;
        private ObservableCollection<AntecedentFamilial> listAntecedentFamilial;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;

        public FirstConsultationViewModel(RDV rdv)
        {
            rdvConsult = rdv;
            NewAntecedPersDialogCommand = new RelayCommand(param=>ShowDialogNewAntecedPers());
            NewAntecedFamilDialogCommand = new RelayCommand(param => ShowDialogNewAntecedFamil());
            listAntecedentPersonel = new ObservableCollection<AntecedentPersonel>();
            listAntecedentFamilial = new ObservableCollection<AntecedentFamilial>();
            RemoveAntecedPersCommand = new RelayCommand(param => DeleteAntecedPers(param));
            RemoveAntecedFamilCommand = new RelayCommand(param => DeleteAntecedFamil(param));
        }

        #region FirstConsultationViewModel Variables

        public RDV RdvConsult
        {
            get
            {
                return rdvConsult;
            }
        }
        public NewAntecedPersWindow DialogNewAntecedPers
        {
            get
            {
                return dialogNewAntecedPers;
            }
        }
        public NewAntecedFamilWindow DialogNewAntecedFamil
        {
            get
            {
                return dialogNewAntecedFamil;
            }
        }
        public AntecedentPersonel NewAntecedPers
        {
            get
            {
                return newAntecedPers;
            }
        }
        public AntecedentFamilial NewAntecedFamil
        {
            get
            {
                return newAntecedFamil;
            }
        }
        public ObservableCollection<AntecedentPersonel> ListAntecedentPersonel
        {
            get
            {
                return listAntecedentPersonel;
            }
        }
        public ObservableCollection<AntecedentFamilial> ListAntecedentFamilal
        {
            get
            {
                return listAntecedentFamilial;
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

        #endregion

        #region FirstConsultationViewModel Commands

        public ICommand NewAntecedPersDialogCommand
        {
            get;
            private set;
        }
        public ICommand NewAntecedFamilDialogCommand
        {
            get;
            private set;
        }

        public ICommand AddAntecedPersCommand
        {
            get;
            private set;
        }
        public ICommand AddAntecedFamilCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedPersCommand
        {
            get;
            private set;
        }

        public ICommand RemoveAntecedFamilCommand
        {
            get;
            private set;
        }

        #endregion

        #region FirstConsultationViewModel Methods

        public void ShowDialogNewAntecedPers()
        {
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
            dialogNewAntecedPers = new NewAntecedPersWindow();
            dialogNewAntecedPers.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
            AddAntecedPersCommand = new RelayCommand(param => AjouterAntecedPers(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedPers = new AntecedentPersonel("", 0, 0, "");
            dialogNewAntecedPers.ShowDialog();
        }
        public void ShowDialogNewAntecedFamil()
        {
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
            dialogNewAntecedFamil = new NewAntecedFamilWindow();
            dialogNewAntecedFamil.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
            AddAntecedFamilCommand = new RelayCommand(param => AjouterAntecedFamil(param));
            //diffMois = 0;
            //diffJours = 0;
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newAntecedFamil = new AntecedentFamilial("", "");
            dialogNewAntecedFamil.ShowDialog();
        }

        public void AjouterAntecedPers(object ant)
        {
            var newAnteced = ant as AntecedentPersonel;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  "+newAnteced.Organe);
            dialogNewAntecedPers.Close();
            listAntecedentPersonel.Add(newAnteced);
            //dialogNewAntecedent.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
        }
        public void AjouterAntecedFamil(object ant)
        {
            var newAnteced = ant as AntecedentFamilial;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newAnteced.Membre);
            dialogNewAntecedFamil.Close();
            listAntecedentFamilial.Add(newAnteced);
            //dialogNewAntecedent.DataContext = this;
            //dialogFirstRdvView = new FirstConsultationWindow();
            //dialogFirstRdvView.DataContext = new FirstConsultationViewModel(rdv);
        }
        public void DeleteAntecedPers(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as AntecedentPersonel;
            listAntecedentPersonel.Remove(ant);
        }
        public void DeleteAntecedFamil(object selectedAntec)
        {
            Console.WriteLine("FirstConsultationViewModel : Remove RDV  ");
            var ant = selectedAntec as AntecedentFamilial;
            listAntecedentFamilial.Remove(ant);
        }

        #endregion
    }
}
