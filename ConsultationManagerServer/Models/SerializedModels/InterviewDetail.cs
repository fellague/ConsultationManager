using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models.SerializedModels
{
    [DataContract]
    public class InterviewDetail
    {
        public InterviewDetail()
        {
            Interview = new Interview();
            RdvPatientMedecin = new RdvDetail();
            Conclusion = new Conclusion();
        }

        [DataMember]
        public Interview Interview
        {
            get;
            set;
        }

        [DataMember]
        public RdvDetail RdvPatientMedecin
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
    }
}