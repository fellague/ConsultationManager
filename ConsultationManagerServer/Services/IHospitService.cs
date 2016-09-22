using ConsultationManagerServer.Models.Hospitalisations;
using ConsultationManagerServer.Models.SerializedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHospitService" in both code and config file together.
    [ServiceContract]
    public interface IHospitService
    {
        [OperationContract]
        Hospitalisation AddHospit(Hospitalisation hospit);

        [OperationContract]
        List<DemandeHospitDetail> GetDemandesHospit(string idService);

        [OperationContract]
        List<HospitalisationDetail> GetHospits(string idService);

        [OperationContract]
        Hospitalisation UpdateHospit(Hospitalisation salle);

        [OperationContract]
        void DeleteHospit(string id);
    }
}
