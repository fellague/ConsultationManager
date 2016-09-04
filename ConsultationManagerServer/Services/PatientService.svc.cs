using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Windows;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PatientService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PatientService.svc or PatientService.svc.cs at the Solution Explorer and start debugging.
    public class PatientService : IPatientService
    {
        public Patient AddPatient(Patient patient)
        {
            DataBaseContext db = new DataBaseContext();
            
            var query = Query.And(Query.EQ("Nom", patient.Nom), Query.EQ("Prenom", patient.Prenom), Query.EQ("DateNaiss", patient.DateNaiss));
            var result = db.Utilisateurs.FindAs<Utilisateur>(query).FirstOrDefault();
            if (result == null)
            {
                db.Patients.Save(patient);
                MessageBox.Show("User Saved");
            }
            else
                MessageBox.Show("Ce Patient Existe Déja");

            return patient;
        }

        public void DeletePatient(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.Patients.Remove(Query.EQ("Id", id));
        }

        public ObservableCollection<Patient> GetAllPatients(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            ObservableCollection<Patient> listPatients = new ObservableCollection<Patient>();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var patients = db.Patients.FindAll().Where(p => p.ServiceId == idService).ToList();
            if (patients.Count() > 0)
                foreach (Patient item in patients)
                    listPatients.Add(item);
            return listPatients;
        }

        //public ObservableCollection<Patient> GetMedecinPatients(string idService, string idMedecin)
        //{
        //    DataBaseContext db = new DataBaseContext();
        //    ObservableCollection<Patient> listPatients = new ObservableCollection<Patient>();
        //    //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
        //    var patients = db.Patients.FindAll().Where(p => p.ServiceId == idService).Where(p => p.MedecinResp == idMedecin).ToList();
        //    if (patients.Count() > 0)
        //        foreach (Patient item in patients)
        //            listPatients.Add(item);
        //    return listPatients;
        //}

        public Patient UpdatePatient(Patient patient)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", patient.Id);
            var update = Update
                .Set("Nom", patient.Nom)
                .Set("DateNaiss", patient.DateNaiss)
                .Set("Raison", patient.Raison)
                .Set("Adresse", patient.Adresse)
                .Set("Telephones", new BsonArray(patient.Telephones))
                .Set("Mariee", patient.Mariee);
            var result = db.Services.FindAndModify(query, null, update);
            return patient;
        }
    }
}
