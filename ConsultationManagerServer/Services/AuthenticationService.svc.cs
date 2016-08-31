using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using MongoDB.Driver.Builders;
using System.Windows;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticationService : IAuthenticationService
    {
        public Utilisateur Authenticate(string userName, string password)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.And(Query.EQ("UserName", userName), Query.EQ("Password", password));
            var result = db.Utilisateurs.FindAs<Utilisateur>(query).FirstOrDefault();
            if (result == null)
            {
                //MessageBox.Show("Wrong Username or Password");
            }
            return result;
        }
    }
}
