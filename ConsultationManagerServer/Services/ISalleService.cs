using ConsultationManagerServer.Models.Hospitalisations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISalleService" in both code and config file together.
    [ServiceContract]
    public interface ISalleService
    {
        [OperationContract]
        Salle AddSalle(Salle salle);
        
        [OperationContract]
        List<Salle> GetSalles(string idService);

        [OperationContract]
        Salle UpdateSalle(Salle salle);

        [OperationContract]
        void DeleteSalle(string id);
    }
}
