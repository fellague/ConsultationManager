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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDossierMedService" in both code and config file together.
    [ServiceContract]
    public interface IDossierMedService
    {
        [OperationContract]
        List<DossierMedDetail> GetAllDossierMeds(string idService);

        [OperationContract]
        List<DossierMedDetail> GetConsultDossierMeds(string idMedecin);

        [OperationContract]
        List<DossierMedDetail> GetMedecinDossierMeds(string idMedecin);
        
        [OperationContract]
        DossierMedDetail GetDossierMed(string idPatient);

        [OperationContract]
        int GetDossierMedNum(RdvDetail patient);

        [OperationContract]
        DossierMed AddDossierMed(DossierMed dossierMed);

        [OperationContract]
        DossierMed UpdateDossierMed(DossierMed dossierMed);

        [OperationContract]
        void DeleteDossierMed(string id);
    }
}
