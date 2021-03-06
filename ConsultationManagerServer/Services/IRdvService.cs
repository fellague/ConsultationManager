﻿using ConsultationManagerServer.Models;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRdvService" in both code and config file together.
    [ServiceContract]
    public interface IRdvService
    {
        [OperationContract]
        List<RdvDetail> GetAllRdv(string idService);

        [OperationContract]
        List<RdvDetail> GetRdvMedecin(string idMedecin);

        [OperationContract]
        List<RdvDetail> GetRdvConsultation(string idConsultation);

        [OperationContract]
        RDV AddRdv(RDV rdv);
        
        [OperationContract]
        RDV UpdateRdv(RDV rdv);
        
        [OperationContract]
        void DeleteRdv(string id);
    }
}
