using ConsultationManagerServer.Models.Hospitalisations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class HospitalisationDetail
    {
        public HospitalisationDetail()
        {
            Hospitalisation = new Hospitalisation();

            Patient = new Patient();
            Medecin = new Utilisateur();
            Demande = new DemandeHospit();
            Salle = new Salle();
            Conclusion = new Conclusion();

            FicheTA = new ObservableCollection<Mesure>();
            FichePoids = new ObservableCollection<Mesure>();
            FicheTemperature = new ObservableCollection<Mesure>();
            FicheGlycemique = new ObservableCollection<Mesure>();

            SallesChange = new ObservableCollection<Salle>();
            Inetrventions = new ObservableCollection<Intervention>();
        }

        [DataMember]
        public Hospitalisation Hospitalisation
        {
            get;
            set;
        }
        [DataMember]
        public Patient Patient
        {
            get;
            set;
        }
        [DataMember]
        public Utilisateur Medecin
        {
            get;
            set;
        }
        [DataMember]
        public DemandeHospit Demande
        {
            get;
            set;
        }
        [DataMember]
        public Salle Salle
        {
            get;
            set;
        }


        [DataMember]
        public Conclusion Conclusion
        {
            get;
            set;
        }

        [DataMember]
        public ObservableCollection<Mesure> FicheTA
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Mesure> FichePoids
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Mesure> FicheTemperature
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Mesure> FicheGlycemique
        {
            get;
            set;
        }

        [DataMember]
        public ObservableCollection<Salle> SallesChange
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Intervention> Inetrventions
        {
            get;
            set;
        }
        //[DataMember]
        //public ObservableCollection<GardeMalade> GardesMalade
        //{
        //    get;
        //    set;
        //}
    }
}