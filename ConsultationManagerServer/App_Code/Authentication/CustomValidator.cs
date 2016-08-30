using System;

using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;
using ConsultationManagerServer.Models;
using MongoDB.Driver.Builders;

namespace ConsultationManagerServer.App_Code.Authentication
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (login(userName, password))
                return;
            throw new NotImplementedException("Nom d'Utilsateur ou Mot de Passe Erroné");
        }

        public bool login(string userName, string passwd)
        {
            DataBaseContext db = new DataBaseContext();
            var query = Query.And(Query.EQ("UserName", userName), Query.EQ("Password", passwd));
            var result = db.Utilisateurs.FindAs<Utilisateur>(query).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;

            //List<Utilisateur> list = new List<Utilisateur>();
            //list.Add(new Utilisateur { UserName = "yow", Password = "123" });
            //list.Add(new Utilisateur { UserName = "yow2", Password = "456" });
            //list.Add(new Utilisateur { UserName = "yow3", Password = "789" });

            //return list.Count(acc => acc.UserName.Equals(userName) && acc.Password.Equals(passwd)) > 0;
        }
    }
}