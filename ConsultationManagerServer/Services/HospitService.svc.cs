using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models.Hospitalisations;
using ConsultationManagerServer.Models.SerializedModels;
using MongoDB.Driver.Builders;
using System.Collections.ObjectModel;
using MongoDB.Bson;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HospitService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HospitService.svc or HospitService.svc.cs at the Solution Explorer and start debugging.
    public class HospitService : IHospitService
    {
        public Hospitalisation AddHospit(Hospitalisation hospit)
        {
            DataBaseContext db = new DataBaseContext();

            db.Hospitalisations.Save(hospit);

            var query = Query.EQ("Id", hospit.IdDemande);
            var update = Update
                .Set("IdHospit", hospit.Id);
            var result = db.DemandesHospit.FindAndModify(query, null, update);

            return hospit;
        }

        public Intervention AddIntervention(Intervention interv, ObservableCollection<string> ids)
        {
            DataBaseContext db = new DataBaseContext();

            db.Interventions.Save(interv);

            ids.Add(interv.Id);

            var query = Query.EQ("Id", interv.IdHospitalisation);
            var update = Update
                .Set("IdInterventions", new BsonArray(ids));
            var result = db.Hospitalisations.FindAndModify(query, null, update);

            return interv;
        }

        public Mesure AddMesureGlycemique(Mesure mesure, ObservableCollection<string> ids)
        {
            DataBaseContext db = new DataBaseContext();

            db.Mesures.Save(mesure);

            ids.Add(mesure.Id);

            var query = Query.EQ("Id", mesure.IdHospitalisation);
            var update = Update
                .Set("IdMesuresFicheGlycemique", new BsonArray(ids));
            var result = db.Hospitalisations.FindAndModify(query, null, update);

            return mesure;
        }

        public Mesure AddMesurePoids(Mesure mesure, ObservableCollection<string> ids)
        {
            DataBaseContext db = new DataBaseContext();

            db.Mesures.Save(mesure);

            ids.Add(mesure.Id);

            var query = Query.EQ("Id", mesure.IdHospitalisation);
            var update = Update
                .Set("IdMesuresFichePoids", new BsonArray(ids));
            var result = db.Hospitalisations.FindAndModify(query, null, update);

            return mesure;
        }

        public Mesure AddMesureTa(Mesure mesure, ObservableCollection<string> ids)
        {
            DataBaseContext db = new DataBaseContext();

            db.Mesures.Save(mesure);

            ids.Add(mesure.Id);

            var query = Query.EQ("Id", mesure.IdHospitalisation);
            var update = Update
                .Set("IdMesuresFicheTA", new BsonArray(ids));
            var result = db.Hospitalisations.FindAndModify(query, null, update);

            return mesure;
        }

        public Mesure AddMesureTemperature(Mesure mesure, ObservableCollection<string> ids)
        {
            DataBaseContext db = new DataBaseContext();

            db.Mesures.Save(mesure);

            ids.Add(mesure.Id);

            var query = Query.EQ("Id", mesure.IdHospitalisation);
            var update = Update
                .Set("IdMesuresFicheTemperature", new BsonArray(ids));
            var result = db.Hospitalisations.FindAndModify(query, null, update);

            return mesure;
        }

        public void DeleteHospit(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.Hospitalisations.Remove(Query.EQ("Id", id));
        }

        public List<DemandeHospitDetail> GetDemandesHospit(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            List<DemandeHospitDetail> listDemandes = new List<DemandeHospitDetail>();
            DemandeHospitDetail demandDetail = new DemandeHospitDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var demands = db.DemandesHospit.FindAll().Where(p => p.ServiceId == idService && p.IdHospit == "").ToList();
            if (demands.Count() > 0)
                foreach (DemandeHospit item in demands)
                {
                    demandDetail = new DemandeHospitDetail();
                    demandDetail.DemandeHospit = item;
                    demandDetail.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.IdMedecin).First();
                    demandDetail.Patient = db.Patients.FindAll().Where(p => p.Id == item.IdPatient).First();
                    demandDetail.IntervConclus = db.Conclusions.FindAll().Where(p => p.Id == item.IdIntervConclus).ToList().First();
                    
                    listDemandes.Add(demandDetail);
                }
            return listDemandes;
        }

        public List<HospitalisationDetail> GetHospits(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            List<HospitalisationDetail> listHospits = new List<HospitalisationDetail>();
            HospitalisationDetail hospitDetail = new HospitalisationDetail();
            var hospits = db.Hospitalisations.FindAll().Where(p => p.ServiceId == idService).ToList();
            if (hospits.Count() > 0)
                foreach (Hospitalisation item in hospits)
                {
                    hospitDetail = new HospitalisationDetail();
                    hospitDetail.Hospitalisation = item;
                    hospitDetail.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.IdMedecin).First();
                    hospitDetail.Patient = db.Patients.FindAll().Where(p => p.Id == item.IdPatient).First();
                    hospitDetail.Demande = db.DemandesHospit.FindAll().Where(p => p.Id == item.IdDemande).First();
                    hospitDetail.Salle = db.Salles.FindAll().Where(p => p.Id == item.IdSalle).First();
                    if (item.IdConclusion != "")
                        hospitDetail.Conclusion = db.Conclusions.FindAll().Where(p => p.Id == item.IdConclusion).First();

                    foreach (string id in item.IdInterventions)
                    {
                        var intervention = db.Interventions.FindAll().Where(p => p.Id == id).ToList().First();
                        hospitDetail.Inetrventions.Add(intervention);
                    }
                    foreach (string id in item.IdSallesChange)
                    {
                        var salle = db.Salles.FindAll().Where(p => p.Id == id).ToList().First();
                        hospitDetail.SallesChange.Add(salle);
                    }

                    foreach (string id in item.IdMesuresFicheTA)
                    {
                        var mesure = db.Mesures.FindAll().Where(p => p.Id == id).ToList().First();
                        hospitDetail.FicheTA.Add(mesure);
                    }
                    foreach (string id in item.IdMesuresFichePoids)
                    {
                        var mesure = db.Mesures.FindAll().Where(p => p.Id == id).ToList().First();
                        hospitDetail.FichePoids.Add(mesure);
                    }
                    foreach (string id in item.IdMesuresFicheTemperature)
                    {
                        var mesure = db.Mesures.FindAll().Where(p => p.Id == id).ToList().First();
                        hospitDetail.FicheTemperature.Add(mesure);
                    }
                    foreach (string id in item.IdMesuresFicheGlycemique)
                    {
                        var mesure = db.Mesures.FindAll().Where(p => p.Id == id).ToList().First();
                        hospitDetail.FicheGlycemique.Add(mesure);
                    }

                    listHospits.Add(hospitDetail);
                }
            return listHospits;
        }

        public List<SalleHospitPlanning> GetSallePlanning(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            List<SalleHospitPlanning> listSallePlan = new List<SalleHospitPlanning>();
            SalleHospitPlanning hospitDetail = new SalleHospitPlanning();
            var salles = db.Salles.FindAll().Where(p => p.IdService == idService && !p.HorService).ToList();
            if (salles.Count() > 0)
                foreach (Salle item in salles)
                {
                    hospitDetail = new SalleHospitPlanning();
                    hospitDetail.Salle = item;
                    hospitDetail.Hospits = db.Hospitalisations.FindAll().Where(p => p.IdSalle == item.Id).ToList();

                    listSallePlan.Add(hospitDetail);
                }
            return listSallePlan;
        }

        public Hospitalisation UpdateHospit(Hospitalisation hosp)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", hosp.Id);
            var update = Update
                .Set("DateDebutReel", hosp.DateDebutReel)
                .Set("DateFinReel", hosp.DateFinReel)
                .Set("IdSalle", hosp.IdSalle)
                .Set("Lit", hosp.Lit)
                .Set("Garde.Nom", hosp.Garde.Nom)
                .Set("Garde.Prenom", hosp.Garde.Prenom)
                .Set("Garde.DateNaiss", hosp.Garde.DateNaiss)
                .Set("Garde.NumeroCarte", hosp.Garde.NumeroCarte)
                .Set("Garde.Telephones", new BsonArray(hosp.Garde.Telephones))
                .Set("IdSallesChange", new BsonArray(hosp.IdSallesChange))
                .Set("IdInterventions", new BsonArray(hosp.IdInterventions));
            var result = db.Hospitalisations.FindAndModify(query, null, update);
            return hosp;
        }
    }
}
