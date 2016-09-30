using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class RdvDetail
    {
        private RDV rdv;
        private Patient patient;
        private Utilisateur medecin;
        private Consultation consultation;

        public RdvDetail()
        {
            rdv = new RDV();
            patient = new Patient();
            medecin = new Utilisateur();
            consultation = new Consultation();
        }

        [DataMember]
        public RDV Rdv
        {
            get
            {
                return rdv;
            }
            set
            {
                rdv=value;
            }
        }
        [DataMember]
        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }
        [DataMember]
        public Utilisateur Medecin
        {
            get
            {
                return medecin;
            }
            set
            {
                medecin = value;
            }
        }
        [DataMember]
        public Consultation Consultation
        {
            get
            {
                return consultation;
            }
            set
            {
                consultation = value;
            }
        }
    }
}