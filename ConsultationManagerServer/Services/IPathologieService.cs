using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using System.Collections.ObjectModel;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPathologieService" in both code and config file together.
    [ServiceContract]
    public interface IPathologieService
    {
        [OperationContract]
        [WebGet(UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        ServicePathologies GetServiceDetails();

        //[OperationContract]
        //[WebGet(UriTemplate = "{id}")]
        //Pathologie GetPathologie(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Pathologies", Method = "POST")]
        Pathologie AddPathologie(Pathologie pathologie);

        [OperationContract]
        [WebInvoke(UriTemplate = "Pathologies/{id}", Method = "PUT")]
        Pathologie UpdatePathologie(string id, Pathologie pathologie);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        Service UpdateService(string id, Service service);

        [OperationContract]
        [WebInvoke(UriTemplate = "Pathologies/{id}", Method = "DELETE")]
        void DeletePathologie(string id);
    }
}
