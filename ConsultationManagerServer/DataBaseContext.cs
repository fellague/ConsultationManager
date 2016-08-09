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
        private IMongoDatabase db;
        public DataBaseContext()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient(settings);
            db = client.GetDatabase("ConsultationManagerDB");
            //var collection = db.GetCollection<Service>("Service");
        }

        public IMongoCollection<Service> Services
        {
            get
            {
                return db.GetCollection<Service>("Service");
            }
        }
    }
}