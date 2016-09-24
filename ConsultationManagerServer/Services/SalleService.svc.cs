using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models.Hospitalisations;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SalleService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SalleService.svc or SalleService.svc.cs at the Solution Explorer and start debugging.
    public class SalleService : ISalleService
    {
        public Salle AddSalle(Salle salle)
        {
            DataBaseContext db = new DataBaseContext();

            db.Salles.Save(salle);

            return salle;
        }

        public void DeleteSalle(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.Salles.Remove(Query.EQ("Id", id));
        }

        public List<Salle> GetSalles(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            var dossiers = db.Salles.FindAll().Where(p => p.IdService == idService).ToList();
            return dossiers;
        }

        public Salle UpdateSalle(Salle salle)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", salle.Id);
            var update = Update
                .Set("Nom", salle.Nom)
                .Set("Type", salle.Type)
                .Set("NbLit", salle.NbLit)
                .Set("LitsLibres", new BsonArray(salle.LitsLibres))
                .Set("HorService", salle.HorService);
            var result = db.Salles.FindAndModify(query, null, update);
            return salle;
        }
    }
}
