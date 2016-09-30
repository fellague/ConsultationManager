using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using ConsultationManagerServer.Models.SerializedModels;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InterviewService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InterviewService.svc or InterviewService.svc.cs at the Solution Explorer and start debugging.
    public class InterviewService : IInterviewService
    {
        public Interview AddInterview(Interview interview)
        {
            DataBaseContext db = new DataBaseContext();

            db.Interviews.Save(interview);

            return interview;
        }

        public void DeleteInterview(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.Interviews.Remove(Query.EQ("Id", id));
        }

        public InterviewDetail GetInterview(string idRdv)
        {
            DataBaseContext db = new DataBaseContext();
            InterviewDetail interviewDetail = new InterviewDetail();

            var interview = db.Interviews.FindAll().Where(p => p.IdRdv == idRdv).ToList().First();
            interviewDetail.Interview = interview;
            var rdv = db.RDVs.FindAll().Where(p => p.Id == interview.IdRdv).ToList().First();
            interviewDetail.RdvPatientMedecin.Rdv = rdv;
            interviewDetail.RdvPatientMedecin.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == interview.CreePar).First();
            interviewDetail.RdvPatientMedecin.Patient = db.Patients.FindAll().Where(p => p.Id == rdv.PatientId).First();
            interviewDetail.Conclusion = db.Conclusions.FindAll().Where(p => p.Id == interviewDetail.Interview.IdConclusion).First();

            return interviewDetail;
        }

        public int GetInterviewNumber(RdvDetail rdv)
        {
            DataBaseContext db = new DataBaseContext();
            int num = 1;

            num = db.Interviews.FindAll().Where(p => p.IdPatient == rdv.Patient.Id).ToList().Count();

            return num+2;
        }

        public List<InterviewDetail> GetInterviews(Patient patient)
        {
            DataBaseContext db = new DataBaseContext();
            List<InterviewDetail> listRDVs = new List<InterviewDetail>();
            InterviewDetail interviewDetail = new InterviewDetail();

            var interviews = db.Interviews.FindAll().Where(p => p.IdPatient == patient.Id && p.IdConclusion == patient.PathologieId).ToList();
            if (interviews.Count() > 0)
                foreach (Interview item in interviews)
                {
                    interviewDetail = new InterviewDetail();
                    interviewDetail.Interview = item;
                    var rdv = db.RDVs.FindAll().Where(p => p.Id == item.IdRdv).ToList().First();
                    interviewDetail.RdvPatientMedecin.Rdv = rdv;
                    interviewDetail.RdvPatientMedecin.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == rdv.MedecinRespId).First();
                    interviewDetail.RdvPatientMedecin.Patient = db.Patients.FindAll().Where(p => p.Id == rdv.PatientId).First();
                    interviewDetail.Conclusion = db.Conclusions.FindAll().Where(p => p.Id == interviewDetail.Interview.IdConclusion).First();

                    listRDVs.Add(interviewDetail);
                }
            return listRDVs;
        }

        public Interview UpdateInterview(Interview interview)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", interview.Id);
            var update = Update
                .Set("Poids", interview.Poids)
                .Set("TA", interview.TA)
                .Set("Temperature", interview.Temperature)
                .Set("Taille", interview.Taille)
                .Set("CommentsPatient", new BsonArray(interview.CommentsPatient))
                .Set("RemarquesMedecin", new BsonArray(interview.RemarquesMedecin));
            var result = db.Interviews.FindAndModify(query, null, update);
            return interview;
        }
    }
}
