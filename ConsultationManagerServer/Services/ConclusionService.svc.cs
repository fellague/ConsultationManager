using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConclusionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConclusionService.svc or ConclusionService.svc.cs at the Solution Explorer and start debugging.
    public class ConclusionService : IConclusionService
    {
        public Conclusion AddConclusion(Conclusion conclusion)
        {
            DataBaseContext db = new DataBaseContext();
            
            db.Conclusions.Save(conclusion);

            if(conclusion.IdSource != "first")
            {
                var query = Query.EQ("Id", conclusion.IdSource);
                var update = Update
                    .Set("IdConclusion", conclusion.Id);
                var result = db.Interviews.FindAndModify(query, null, update);

                var dossier = db.DossierMeds.FindAll().Where(p => p.IdPatient == conclusion.IdPatient).ToList().First();
                dossier.IdInterviews.Add(conclusion.IdSource);
                var query3 = Query.EQ("IdPatient", conclusion.IdPatient);
                var update3 = Update
                    .Set("idInterviews", new BsonArray(dossier.IdInterviews));
                var result4 = db.DossierMeds.FindAndModify(query3, null, update3);
            }

            var query2 = Query.EQ("Id", conclusion.IdRdv);
            var update2 = Update
                .Set("DejaFait", true);
            var result2 = db.RDVs.FindAndModify(query2, null, update2);

            return conclusion;
        }

        public void DeleteConclusion(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.Conclusions.Remove(Query.EQ("Id", id));
        }

        public Conclusion UpdateConclusion(Conclusion conclusion)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", conclusion.Id);
            //var update = Update
            //    .Set("Ordonnance", new Bson(conclusion.Ordonnance))
            //    .Set("TraitementsCompl", new BsonArray(conclusion.TraitementsCompl))
            //    .Set("Conseils", new BsonArray(conclusion.Conseils))
            //    .Set("CompteRendu", new BsonArray(conclusion.CompteRendu));
            //var result = db.DossierMeds.FindAndModify(query, null, update);
            return conclusion;
        }
    }
}
