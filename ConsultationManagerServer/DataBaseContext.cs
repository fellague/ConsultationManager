using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsultationManagerServer.Models;

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
    }
}