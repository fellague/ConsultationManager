using System;

using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;
using ConsultationManagerServer.Models;

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
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { UserName = "yow", Password = "123" });
            list.Add(new Employee { UserName = "yow2", Password = "456" });
            list.Add(new Employee { UserName = "yow3", Password = "789" });

            return list.Count(acc => acc.UserName.Equals(userName) && acc.Password.Equals(passwd)) > 0;
        }
    }
}