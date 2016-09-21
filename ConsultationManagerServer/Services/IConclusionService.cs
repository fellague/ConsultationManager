using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.Hospitalisations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConclusionService" in both code and config file together.
    [ServiceContract]
    public interface IConclusionService
    {
        [OperationContract]
        Conclusion AddConclusion(Conclusion dossierMed);

        [OperationContract]
        DemandeHospit AddDemandeHospit(DemandeHospit demandeHospit);

        [OperationContract]
        Conclusion UpdateConclusion(Conclusion dossierMed);

        [OperationContract]
        void DeleteConclusion(string id);
    }
}
