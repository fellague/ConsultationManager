using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlanningService" in both code and config file together.
    [ServiceContract]
    public interface IPlanningService
    {
        [OperationContract]
        ObservableCollection<ConsultationMedecinsPlanning> GetAllPlannings(string serviceId);

        [OperationContract]
        ConsultationMedecinsPlanning GetPlanning(string consultationId);

        [OperationContract]
        Planning UpdatePlanning(Planning planning);
    }
}
