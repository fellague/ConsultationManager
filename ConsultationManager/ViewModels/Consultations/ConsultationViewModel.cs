﻿using System;
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
        private RemarqueMedecin newRemarqMed;

        private AntecedentPersonel newAntecedPers;
        private ObservableCollection<int> listMois;
        private ObservableCollection<int> listJours;
        
        public ConsultationViewModel(RDV rdv)
        {
            this.rdvConsult = rdv;
            NewAntecedPersDialogCommand = new RelayCommand(param => ShowDialogNewAntecedPers());
            NewRemarqMedDialogCommand = new RelayCommand(param => ShowDialogNewRemarqMed());
            consultation = new Consultation(new ObservableCollection < AntecedentPersonel > (), new ObservableCollection < RemarqueMedecin > (), 0, 0, 0, 0, "", "");
            RemoveAntecedPersCommand = new RelayCommand(param => DeleteAntecedPers(param));
            RemoveRemarqMedCommand = new RelayCommand(param => DeleteRemarqMed(param));
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

        #endregion

        #region ConsultationViewModel Methods

        public void ShowDialogNewAntecedPers()
        {
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
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
            Console.WriteLine("FirstConsultationViewModel : Dialog opened with RDV  ");
            dialogNewRemarqMed = new NewRemarqMedWindow();
            dialogNewRemarqMed.DataContext = this;
            AddRemarqMedCommand = new RelayCommand(param => AjouterRemarqMed(param));
            listMois = new ObservableCollection<int>(Enumerable.Range(0, 24));
            listJours = new ObservableCollection<int>(Enumerable.Range(0, 30));
            newRemarqMed = new RemarqueMedecin("", "");
            dialogNewRemarqMed.ShowDialog();
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

        #endregion
    }
}