using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models.SerializedModels;
using MongoDB.Driver.Builders;
using ConsultationManagerServer.Models;
using MongoDB.Bson;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DossierMedService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DossierMedService.svc or DossierMedService.svc.cs at the Solution Explorer and start debugging.
    public class DossierMedService : IDossierMedService
    {
        public DossierMed AddDossierMed(DossierMed dossierMed)
        {
            DataBaseContext db = new DataBaseContext();

            db.DossierMeds.Save(dossierMed);

            
            return dossierMed;
        }

        public void DeleteDossierMed(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.DossierMeds.Remove(Query.EQ("Id", id));
        }

        public List<DossierMedDetail> GetAllDossierMeds(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            ObservableCollection<DossierMedDetail> list = new ObservableCollection<DossierMedDetail>();
            List<DossierMedDetail> listDossiers = new List<DossierMedDetail>();
            DossierMedDetail dossierMedDetail = new DossierMedDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var dossiers = db.DossierMeds.FindAll().Where(p => p.ServiceId == idService).ToList();
            if (dossiers.Count() > 0)
                foreach (DossierMed item in dossiers)
                {
                    dossierMedDetail = new DossierMedDetail();
                    dossierMedDetail.DossierMedical = item;
                    dossierMedDetail.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.IdMedecin).First();
                    dossierMedDetail.Patient = db.Patients.FindAll().Where(p => p.Id == item.IdPatient).First();

                    var firstConcl = db.Conclusions.FindAll().Where(p => p.IdSource == "first" && p.IdPatient == item.IdPatient).ToList().First();
                    dossierMedDetail.ConclusionsInterview.Add(firstConcl);
                    foreach (string interv in item.IdInterviews)
                    {
                        var intervConcls = db.Conclusions.FindAll().Where(p => p.IdSource == interv).ToList().First();
                        dossierMedDetail.ConclusionsInterview.Add(intervConcls);
                    }

                    listDossiers.Add(dossierMedDetail);
                }
            return listDossiers;
        }

        public List<DossierMedDetail> GetConsultDossierMeds(string idMedecin)
        {
            DataBaseContext db = new DataBaseContext();
            ObservableCollection<DossierMedDetail> list = new ObservableCollection<DossierMedDetail>();
            List<DossierMedDetail> listDossiers = new List<DossierMedDetail>();
            DossierMedDetail dossierMedDetail = new DossierMedDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var dossiers = db.DossierMeds.FindAll().Where(p => p.PathologieId == idMedecin).ToList();
            if (dossiers.Count() > 0)
                foreach (DossierMed item in dossiers)
                {
                    dossierMedDetail = new DossierMedDetail();
                    dossierMedDetail.DossierMedical = item;
                    dossierMedDetail.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.IdMedecin).First();
                    dossierMedDetail.Patient = db.Patients.FindAll().Where(p => p.Id == item.IdPatient).First();

                    var firstConcl = db.Conclusions.FindAll().Where(p => p.IdSource == "first" && p.IdPatient == item.IdPatient).ToList().First();
                    dossierMedDetail.ConclusionsInterview.Add(firstConcl);
                    foreach (string interv in item.IdInterviews)
                    {
                        var intervConcls = db.Conclusions.FindAll().Where(p => p.IdSource == interv).ToList().First();
                        dossierMedDetail.ConclusionsInterview.Add(intervConcls);
                    }

                    listDossiers.Add(dossierMedDetail);
                }
            return listDossiers;
        }

        public List<DossierMedDetail> GetMedecinDossierMeds(string idMedecin)
        {
            DataBaseContext db = new DataBaseContext();
            ObservableCollection<DossierMedDetail> list = new ObservableCollection<DossierMedDetail>();
            List<DossierMedDetail> listDossiers = new List<DossierMedDetail>();
            DossierMedDetail dossierMedDetail = new DossierMedDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var dossiers = db.DossierMeds.FindAll().Where(p => p.IdMedecin == idMedecin).ToList();
            if (dossiers.Count() > 0)
                foreach (DossierMed item in dossiers)
                {
                    dossierMedDetail = new DossierMedDetail();
                    dossierMedDetail.DossierMedical = item;
                    dossierMedDetail.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.IdMedecin).First();
                    dossierMedDetail.Patient = db.Patients.FindAll().Where(p => p.Id == item.IdPatient).First();

                    var firstConcl = db.Conclusions.FindAll().Where(p => p.IdSource == "first" && p.IdPatient == item.IdPatient).ToList().First();
                    dossierMedDetail.ConclusionsInterview.Add(firstConcl);
                    foreach (string interv in item.IdInterviews)
                    {
                        var intervConcls = db.Conclusions.FindAll().Where(p => p.IdSource == interv).ToList().First();
                        dossierMedDetail.ConclusionsInterview.Add(intervConcls);
                    }

                    listDossiers.Add(dossierMedDetail);
                }
            return listDossiers;
        }

        public DossierMedDetail GetDossierMed(string idPatient)
        {
            DataBaseContext db = new DataBaseContext();
            DossierMedDetail dossierMedDetail = new DossierMedDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var dossier = db.DossierMeds.FindAll().Where(p => p.IdPatient == idPatient).ToList().First();
            dossierMedDetail = new DossierMedDetail();
            dossierMedDetail.DossierMedical = dossier;
            dossierMedDetail.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == dossier.IdMedecin).First();
            dossierMedDetail.Patient = db.Patients.FindAll().Where(p => p.Id == dossier.IdPatient).First();

            var firstConcl = db.Conclusions.FindAll().Where(p => p.IdSource == "first" && p.IdPatient == dossier.IdPatient).ToList().First();
            dossierMedDetail.ConclusionsInterview.Add(firstConcl);
            foreach (string interv in dossier.IdInterviews)
            {
                var intervConcls = db.Conclusions.FindAll().Where(p => p.IdSource == interv).ToList().First();
                dossierMedDetail.ConclusionsInterview.Add(intervConcls);
            }

            return dossierMedDetail;
        }

        public DossierMed UpdateDossierMed(DossierMed dossierMed)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", dossierMed.Id);
            var update = Update
                .Set("IdInterviews", new BsonArray(dossierMed.IdInterviews))
                .Set("IdHospits", new BsonArray(dossierMed.IdHospits))
                .Set("IdChirurgies", new BsonArray(dossierMed.IdChirurgies));
            var result = db.DossierMeds.FindAndModify(query, null, update);
            return dossierMed;
        }
    }
}
