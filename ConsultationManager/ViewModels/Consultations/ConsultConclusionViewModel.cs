using System;
using System.Linq;
using ConsultationManagerServer.Models;
using ConsultationManagerClient.ViewModels.RDVs;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ConsultationManagerClient.Views.Consultation;
using ConsultationManagerClient.Commands;
using System.ComponentModel;

namespace ConsultationManagerClient.ViewModels.Consultations
{
    internal class ConsultConclusionViewModel : INotifyPropertyChanged
    {
        private RDV rdvConsult;
        private ListRvdViewModel rdvsViewModel;
        private Consultation consultation;

        private NewMedicamentWindow dialogNewMedicament;
        private Ordonnance ordonnance;
        private Medicament newMedicament;

        private NewTraitemComplWindow dialogNewTraitement;
        private TraitementsComplemtaires traitementsCompl;
        private Traitement newTraitement;

        private LettreOrientation lettreOrientation;

        private string newConseil;
        private ObservableCollection<string> conseils;

        private CompteRendu compteRendu;

        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;
        private ObservableCollection<int> listNbFois;


        public ConsultConclusionViewModel(RDV rdv, Consultation consult, ListRvdViewModel rdvVM)
        {
            this.rdvConsult = rdv;
            this.consultation = consult;
            rdvsViewModel = rdvVM;

            NewMedicamentDialogCommand = new RelayCommand(param => ShowDialogNewMedicament());
            ordonnance = new Ordonnance(new ObservableCollection<Medicament>());
            RemoveMedicamentCommand = new RelayCommand(param => DeleteMedicament(param));

            NewTraitementDialogCommand = new RelayCommand(param => ShowDialogNewTraitement());
            traitementsCompl = new TraitementsComplemtaires(new ObservableCollection<Traitement>());
            RemoveTraitementCommand = new RelayCommand(param => DeleteTraitement(param));

            lettreOrientation = new LettreOrientation("", "", "");

            newConseil = "";
            conseils = new ObservableCollection<string>();
            AddConseilCommand = new RelayCommand(param => AjouterConseil());
            RemoveConseilCommand = new RelayCommand(param => DeleteConseil(param));

            compteRendu = new CompteRendu("");
        }

        #region ConsultationViewModel Variables

        public RDV RdvConsult
        {
            get
            {
                return rdvConsult;
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

        public Traitement NewTraitement
        {
            get
            {
                return newTraitement;
            }
        }
        public TraitementsComplemtaires TraitementsCompl
        {
            get
            {
                return traitementsCompl;
            }
        }

        public LettreOrientation LettreOrientation
        {
            get
            {
                return lettreOrientation;
            }
        }

        public string NewConseil
        {
            get
            {
                return newConseil;
            }
            set
            {
                newConseil = value;
                OnPropertyChanged("NewConseil");
            }
        }
        public ObservableCollection<string> Conseils
        {
            get
            {
                return conseils;
            }
        }

        public CompteRendu CompteRendu
        {
            get
            {
                return compteRendu;
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
        
        public ICommand NewMedicamentDialogCommand
        {
            get;
            private set;
        }
        public ICommand AddMedicamentCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMedicamentCommand
        {
            get;
            private set;
        }

        public ICommand NewTraitementDialogCommand
        {
            get;
            private set;
        }
        public ICommand AddTraitementCommand
        {
            get;
            private set;
        }
        public ICommand RemoveTraitementCommand
        {
            get;
            private set;
        }

        public ICommand AddConseilCommand
        {
            get;
            private set;
        }
        public ICommand RemoveConseilCommand
        {
            get;
            private set;
        }

        public ICommand PrecedentCommand
        {
            get;
            private set;
        }

        #endregion

        #region ConsultationViewModel Methods

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
        public void AjouterMedicament(object med)
        {
            var newMed = med as Medicament;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newMed.Nom);
            dialogNewMedicament.Close();
            ordonnance.ListMedicaments.Add(newMed);
        }
        public void DeleteMedicament(object selectedMed)
        {
            Console.WriteLine("ConsultationViewModel : Remove RDV  ");
            var med = selectedMed as Medicament;
            ordonnance.ListMedicaments.Remove(med);
        }

        public void ShowDialogNewTraitement()
        {
            Console.WriteLine("ConsultationViewModel : Dialog Traitements Complémentaires opened with RDV  ");
            dialogNewTraitement = new NewTraitemComplWindow();
            dialogNewTraitement.DataContext = this;
            AddTraitementCommand = new RelayCommand(param => AjouterTraitement(param));
            newTraitement = new Traitement("", "");
            dialogNewTraitement.ShowDialog();
        }
        public void AjouterTraitement(object trait)
        {
            var newTrait = trait as Traitement;
            Console.WriteLine("FirstConsultationViewModel : Dialog Closed with RDV  " + newTrait.Nom);
            dialogNewTraitement.Close();
            traitementsCompl.ListTraitements.Add(newTrait);
        }
        public void DeleteTraitement(object selectedTrait)
        {
            Console.WriteLine("ConsultationViewModel : Remove RDV  ");
            var trait = selectedTrait as Traitement;
            traitementsCompl.ListTraitements.Remove(trait);
        }

        public void AjouterConseil()
        {
            //var newCsl = csl as string;
            if (newConseil != "")
            {
                conseils.Add(newConseil);
                NewConseil = "";
            }
                
        }
        public void DeleteConseil(object selectedConseil)
        {
            Console.WriteLine("ConsultationViewModel : Remove RDV  ");
            var consl = selectedConseil as string;
            conseils.Remove(consl);
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
