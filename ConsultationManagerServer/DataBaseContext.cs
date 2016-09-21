using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.Hospitalisations;

namespace ConsultationManagerServer
{
    public class DataBaseContext
    {
        private MongoDatabase db;
        public DataBaseContext()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient(settings);
            var server = client.GetServer();
            db = server.GetDatabase("ConsultationManagerDB");
        }

        public MongoCollection<Service> Services
        {
            get
            {
                return db.GetCollection<Service>("Service");
            }
        }

        public MongoCollection<Consultation> Consultations
        {
            get
            {
                return db.GetCollection<Consultation>("Consultation");
            }
        }

        public MongoCollection<Utilisateur> Utilisateurs
        {
            get
            {
                return db.GetCollection<Utilisateur>("Utilisateur");
            }
        }

        public MongoCollection<Planning> Plannings
        {
            get
            {
                return db.GetCollection<Planning>("Planning");
            }
        }

        public MongoCollection<Patient> Patients
        {
            get
            {
                return db.GetCollection<Patient>("Patient");
            }
        }

        public MongoCollection<RDV> RDVs
        {
            get
            {
                return db.GetCollection<RDV>("RDV");
            }
        }

        public MongoCollection<DossierMed> DossierMeds
        {
            get
            {
                return db.GetCollection<DossierMed>("DossierMed");
            }
        }
        public MongoCollection<Interview> Interviews
        {
            get
            {
                return db.GetCollection<Interview>("Interview");
            }
        }
        public MongoCollection<Conclusion> Conclusions
        {
            get
            {
                return db.GetCollection<Conclusion>("Conclusion");
            }
        }

        public MongoCollection<Salle> Salles
        {
            get
            {
                return db.GetCollection<Salle>("Salle");
            }
        }
        public MongoCollection<DemandeHospit> DemandesHospit
        {
            get
            {
                return db.GetCollection<DemandeHospit>("DemandeHospit");
            }
        }
        public MongoCollection<Hospitalisation> Hospitalisations
        {
            get
            {
                return db.GetCollection<Hospitalisation>("Hospitalisation");
            }
        }
        public MongoCollection<Mesure> Mesures
        {
            get
            {
                return db.GetCollection<Mesure>("Mesure");
            }
        }
    }
}