using ConsultationManagerServer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPatientService" in both code and config file together.
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        ObservableCollection<Patient> GetAllPatients(string idService);

        //[OperationContract]
        //ObservableCollection<Patient> GetMedecinPatients(string idService, string idMedecin);

        [OperationContract]
        Patient AddPatient(Patient patient);

        [OperationContract]
        Patient UpdatePatient(Patient patient);

        [OperationContract]
        void DeletePatient(string id);
    }
}
