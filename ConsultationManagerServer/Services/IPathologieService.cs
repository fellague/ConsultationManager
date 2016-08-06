using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPathologieService" in both code and config file together.
    [ServiceContract]
    public interface IPathologieService
    {
        [OperationContract]
        [WebGet(UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<Pathologie> GetAllPathologies();

        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Pathologie GetPathologie(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        bool AddPathologie(Pathologie pathologie);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        void UpdatePathologie(string id, Pathologie pathologie);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void DeletePathologie(string id);
    }
}
