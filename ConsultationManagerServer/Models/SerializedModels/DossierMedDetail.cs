using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class DossierMedDetail
    {
        public DossierMedDetail()
        {
            DossierMedical = new DossierMed();
            Patient = new Patient();
            Medecin = new Utilisateur();
            Consultation = new Consultation();
            ConclusionsInterview = new ObservableCollection<Conclusion>();
            ConclusionsHospit = new ObservableCollection<Conclusion>();
            ConclusionsChirurgie = new ObservableCollection<Conclusion>();
        }

        [DataMember]
        public DossierMed DossierMedical
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
        public Consultation Consultation
        {
            get;
            set;
        }

        [DataMember]
        public ObservableCollection<Conclusion> ConclusionsInterview
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Conclusion> ConclusionsHospit
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Conclusion> ConclusionsChirurgie
        {
            get;
            set;
        }
    }
}