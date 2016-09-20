using ConsultationManagerServer.Models.Hospitalisations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    public class HospitalisationDetail
    {
        public HospitalisationDetail()
        {
            Hospitalisation = new Hospitalisation();

            Patient = new Patient();
            Medecin = new Utilisateur();
            Conclusion = new Conclusion();

            FicheTA = new ObservableCollection<Mesure>();
            FichePoids = new ObservableCollection<Mesure>();
            FicheTemperature = new ObservableCollection<Mesure>();
            FicheGlycemique = new ObservableCollection<Mesure>();

        }

        public Hospitalisation Hospitalisation
        {
            get;
            set;
        }
        public Patient Patient
        {
            get;
            set;
        }
        public Utilisateur Medecin
        {
            get;
            set;
        }

        public Conclusion Conclusion
        {
            get;
            set;
        }

        public ObservableCollection<Mesure> FicheTA
        {
            get;
            set;
        }
        public ObservableCollection<Mesure> FichePoids
        {
            get;
            set;
        }
        public ObservableCollection<Mesure> FicheTemperature
        {
            get;
            set;
        }
        public ObservableCollection<Mesure> FicheGlycemique
        {
            get;
            set;
        }
    }
}