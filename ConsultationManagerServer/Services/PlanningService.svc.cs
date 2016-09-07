using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Windows;
using MongoDB.Driver.Linq;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlanningService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlanningService.svc or PlanningService.svc.cs at the Solution Explorer and start debugging.
    public class PlanningService : IPlanningService
    {
        public ObservableCollection<ConsultationMedecinsPlanning> GetAllPlannings(string serviceId)
        {
            ObservableCollection<ConsultationMedecinsPlanning> list = new ObservableCollection<ConsultationMedecinsPlanning>();
            ConsultationMedecinsPlanning consultMedsPlans = new ConsultationMedecinsPlanning();
            
            DataBaseContext db = new DataBaseContext();

            var consults = db.Consultations.AsQueryable().Where(p => p.IdService == serviceId).ToList();
            if (consults.Count() > 0)
                foreach (Consultation item in consults)
                {
                    consultMedsPlans = new ConsultationMedecinsPlanning();
                    consultMedsPlans.Consult = item;
                    var plannings = db.Plannings.AsQueryable().Where(p => p.Id == consultMedsPlans.Consult.IdPlanning).First();

                    foreach (string idUser in plannings.MedecinsDimanche)
                    {
                        var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                        foreach (Utilisateur user in users)
                            consultMedsPlans.MedecinsDimanche.Add(user);
                    }
                    foreach (string idUser in plannings.MedecinsLundi)
                    {
                        var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                        foreach (Utilisateur user in users)
                            consultMedsPlans.MedecinsLundi.Add(user);
                    }
                    foreach (string idUser in plannings.MedecinsMardi)
                    {
                        var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                        foreach (Utilisateur user in users)
                            consultMedsPlans.MedecinsMardi.Add(user);
                    }
                    foreach (string idUser in plannings.MedecinsMercredi)
                    {
                        var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                        foreach (Utilisateur user in users)
                            consultMedsPlans.MedecinsMercredi.Add(user);
                    }
                    foreach (string idUser in plannings.MedecinsJeudi)
                    {
                        var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                        foreach (Utilisateur user in users)
                            consultMedsPlans.MedecinsJeudi.Add(user);
                    }
                    list.Add(consultMedsPlans);
                }

            return list;
        }

        public ConsultationMedecinsPlanning GetPlanning(string consultationId)
        {
            ConsultationMedecinsPlanning consultMedsPlans = new ConsultationMedecinsPlanning();

            DataBaseContext db = new DataBaseContext();

            var result = db.Consultations.AsQueryable().Where(p => p.Id == consultationId).First();
            consultMedsPlans.Consult = result;

            var plannings = db.Plannings.AsQueryable().Where(p => p.Id == consultMedsPlans.Consult.IdPlanning).First();

            foreach (string idUser in plannings.MedecinsDimanche)
            {
                var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                foreach (Utilisateur user in users)
                    consultMedsPlans.MedecinsDimanche.Add(user);
            }
            foreach (string idUser in plannings.MedecinsLundi)
            {
                var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                foreach (Utilisateur user in users)
                    consultMedsPlans.MedecinsLundi.Add(user);
            }
            foreach (string idUser in plannings.MedecinsMardi)
            {
                var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                foreach (Utilisateur user in users)
                    consultMedsPlans.MedecinsMardi.Add(user);
            }
            foreach (string idUser in plannings.MedecinsMercredi)
            {
                var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                foreach (Utilisateur user in users)
                    consultMedsPlans.MedecinsMercredi.Add(user);
            }
            foreach (string idUser in plannings.MedecinsJeudi)
            {
                var users = db.Utilisateurs.AsQueryable().Where(p => p.Id == idUser).ToList();
                foreach (Utilisateur user in users)
                    consultMedsPlans.MedecinsJeudi.Add(user);
            }

            return consultMedsPlans;
        }

        public Planning UpdatePlanning(Planning planning)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", planning.Id);
            var update = Update
                .Set("MedecinsDimanche", new BsonArray(planning.MedecinsDimanche))
                .Set("MedecinsLundi", new BsonArray(planning.MedecinsLundi))
                .Set("MedecinsMardi", new BsonArray(planning.MedecinsMardi))
                .Set("MedecinsMercredi", new BsonArray(planning.MedecinsMercredi))
                .Set("MedecinsJeudi", new BsonArray(planning.MedecinsJeudi));
            var result = db.Plannings.FindAndModify(query, null, update);
            return planning;
        }
    }
}
