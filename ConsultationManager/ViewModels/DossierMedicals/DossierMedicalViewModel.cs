using ConsultationManagerServer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.ViewModels.DossierMedicals
{
    class DossierMedicalViewModel : INotifyPropertyChanged
    {
        private Patient patient;
        private ObservableCollection<CompteRendu> listCRInterview;
        private ObservableCollection<CompteRendu> listCRHospit;
        public DossierMedicalViewModel(Patient patient)
        {
            this.patient = patient;
            listCRInterview = new ObservableCollection<CompteRendu>();
            listCRHospit = new ObservableCollection<CompteRendu>();

            //listCRInterview.Add(new CompteRendu("1", "Bilan étiologique négatif. A recontrôler dans un an.", new DateTime(2012, 10, 12)));
            //listCRInterview.Add(new CompteRendu("2", "Implantation d'un stimulateur cardiaque triple chambre chez un patient de 79 ans, porteur dune cardiomyopathie dilatée primitive avec un bloc de branche gauche et un stade III de la NYHA malgré un traitement médical maximal.", new DateTime(2013, 1, 20)));
            //listCRInterview.Add(new CompteRendu("3", "LLC depuis 8 ans remarquablement stable de stade B de Binet. A revoir dans deux ans. Absence de lésion suspecte endodigestive à contrôler dans 5 ans.", new DateTime(2013, 5, 4)));
            //listCRInterview.Add(new CompteRendu("4", "Le volume du ganglion a developpé, le patient doit etre hospitalisé une autre fois pour le traitement du radioactif", new DateTime(2014, 10, 2)));
            //listCRInterview.Add(new CompteRendu("5", "Le volume du ganglion a diminué, a revoir après trois mois", new DateTime(2015, 6, 15)));
            //listCRInterview.Add(new CompteRendu("6", "La santé du patient est stable, le patient peut etre transféré après la prochaine consultation", new DateTime(2016, 1, 1)));
            //listCRInterview.Add(new CompteRendu("7", "D'après le bilan, le patient va etre transféré pour un chirurgie", new DateTime(2016, 7, 7)));
            //listCRInterview.Add(new CompteRendu("8", "Le volume du ganglion a diminué, a revoir après trois mois", new DateTime(2015, 6, 15)));
            //listCRInterview.Add(new CompteRendu("9", "La santé du patient est stable, le patient peut etre transféré après la prochaine consultation", new DateTime(2016, 1, 1)));
            //listCRInterview.Add(new CompteRendu("10", "D'après le bilan, le patient va etre transféré pour un chirurgie", new DateTime(2016, 7, 7)));

            //listCRHospit.Add(new CompteRendu("1", "Le patient a subi une rectocolectomie gauche avec une radiothérapie post - opératoire le 25.01.03 nécessitant une surveillance.On diagnostique 3 lésions hépatiques et une augmentation de l'ACE. Le patient est traité par chimiothérapie par LV5FU2.IL reçoit 6 cures.La tolérance clinique et hématologique est excellente.", new DateTime(2014, 1, 7)));
            //listCRHospit.Add(new CompteRendu("2", "Le patient présente une pleurésie bilatérale, une lésion de 30 mm latéromédiastinale gauche ainsi qu'une adénopathie médiastinale.", new DateTime(2015, 6, 25)));
            //listCRHospit.Add(new CompteRendu("3", "Au total, apparition d'une lésion pulmonaire et disparition des lésions hépatiques.Cette réponse dissociée au traitement est assez troublante.Pour cette raison, je demande l'avis du Docteur DUMON, pneumologue, pour savoir si la lésion pulmonaire peut être en rapport avec une lésion primitive plutôt qu'une lésion secondaire.", new DateTime(2016, 3, 16)));
        }

        #region DossierMedicalViewModel Variables

        public Patient Patient
        {
            get
            {
                return patient;
            }
        }

        public ObservableCollection<CompteRendu> ListCRInterview
        {
            get
            {
                return listCRInterview;
            }
        }

        public ObservableCollection<CompteRendu> ListCRHospit
        {
            get
            {
                return listCRHospit;
            }
        }

        #endregion

        #region DossierMedicalViewModel Methods

        private void GetDossierMed(string idPatient)
        {

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
