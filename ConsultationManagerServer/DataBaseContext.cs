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

        public MongoCollection<Pathologie> Pathologies
        {
            get
            {
                return db.GetCollection<Pathologie>("Pathologie");
            }
        }
    }
}