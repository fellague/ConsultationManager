using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class RdvPatientMedecin
    {
        private RDV rdv;
        private Patient patient;
        private Utilisateur medecin;

        public RdvPatientMedecin()
        {
            rdv = new RDV();
            patient = new Patient();
            medecin = new Utilisateur();
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
    }
}