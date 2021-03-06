﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using MongoDB.Driver.Builders;
using System.Windows;
using ConsultationManagerServer.Models.SerializedModels;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RdvService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RdvService.svc or RdvService.svc.cs at the Solution Explorer and start debugging.
    public class RdvService : IRdvService
    {
        public RDV AddRdv(RDV rdv)
        {
            DataBaseContext db = new DataBaseContext();
            
            db.RDVs.Save(rdv);
            
            if (rdv.NouvPat)
            {

                var query2 = Query.EQ("Id", rdv.PatientId);
                var update2 = Update
                    .Set("Nouveau", false)
                    .Set("MedecinResp", rdv.MedecinRespId);
                var result2 = db.Patients.FindAndModify(query2, null, update2);
            }
            
            return rdv;
        }

        public void DeleteRdv(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.RDVs.Remove(Query.EQ("Id", id));
        }

        public List<RdvDetail> GetAllRdv(string idService)
        {
            DataBaseContext db = new DataBaseContext();
            List<RdvDetail> listRDVs = new List<RdvDetail>();
            RdvDetail rdvPatientMedecin = new RdvDetail();
            var rdvs = db.RDVs.FindAll().Where(p => p.ServiceId == idService).ToList();
            if (rdvs.Count() > 0)
                foreach (RDV item in rdvs)
                {
                    rdvPatientMedecin = new RdvDetail();
                    rdvPatientMedecin.Rdv = item;
                    rdvPatientMedecin.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.MedecinRespId).First();
                    rdvPatientMedecin.Patient = db.Patients.FindAll().Where(p => p.Id == item.PatientId).First();
                    rdvPatientMedecin.Consultation = db.Consultations.FindAll().Where(p => p.Id == item.PathologieId).First();

                    listRDVs.Add(rdvPatientMedecin);
                }
            return listRDVs;
        }

        public List<RdvDetail> GetRdvConsultation(string idConsultation)
        {
            DataBaseContext db = new DataBaseContext();
            //ObservableCollection<RDV> list = new ObservableCollection<RDV>();
            List<RdvDetail> listRDVs = new List<RdvDetail>();
            RdvDetail rdvPatientMedecin = new RdvDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var rdvs = db.RDVs.FindAll().Where(p => p.PathologieId == idConsultation && p.DejaFait == false).ToList();
            if (rdvs.Count() > 0)
                foreach (RDV item in rdvs)
                {
                    rdvPatientMedecin = new RdvDetail();
                    rdvPatientMedecin.Rdv = item;
                    rdvPatientMedecin.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.MedecinRespId).First();
                    rdvPatientMedecin.Patient = db.Patients.FindAll().Where(p => p.Id == item.PatientId).First();

                    listRDVs.Add(rdvPatientMedecin);
                }
            return listRDVs;
        }

        public List<RdvDetail> GetRdvMedecin(string idMedecin)
        {
            DataBaseContext db = new DataBaseContext();
            ObservableCollection<RDV> list = new ObservableCollection<RDV>();
            List<RdvDetail> listRDVs = new List<RdvDetail>();
            RdvDetail rdvPatientMedecin = new RdvDetail();
            //var patients = db.Patients.AsQueryable().Where(p => p.ServiceId == idService).ToList();
            var rdvs = db.RDVs.FindAll().Where(p => p.MedecinRespId == idMedecin).ToList();
            if (rdvs.Count() > 0)
                foreach (RDV item in rdvs)
                {
                    rdvPatientMedecin = new RdvDetail();
                    rdvPatientMedecin.Rdv = item;
                    rdvPatientMedecin.Medecin = db.Utilisateurs.FindAll().Where(p => p.Id == item.MedecinRespId).First();
                    rdvPatientMedecin.Patient = db.Patients.FindAll().Where(p => p.Id == item.PatientId).First();

                    listRDVs.Add(rdvPatientMedecin);
                }
            return listRDVs;
        }

        public RDV UpdateRdv(RDV rdv)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", rdv.Id);
            var update = Update
                .Set("DateRdv", rdv.DateRdv)
                .Set("Rang", rdv.Rang)
                .Set("DejaFait", rdv.DejaFait)
                .Set("MedecinRespId", rdv.MedecinRespId);
            var result = db.RDVs.FindAndModify(query, null, update);
            return rdv;
        }
    }
}
