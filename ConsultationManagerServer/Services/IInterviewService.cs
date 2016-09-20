using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInterviewService" in both code and config file together.
    [ServiceContract]
    public interface IInterviewService
    {
        [OperationContract]
        Interview AddInterview(Interview dossierMed);

        [OperationContract]
        InterviewDetail GetInterview(string idRdv);

        [OperationContract]
        List<InterviewDetail> GetInterviews(Patient patient);

        [OperationContract]
        Interview UpdateInterview(Interview dossierMed);

        [OperationContract]
        void DeleteInterview(string id);
    }
}
