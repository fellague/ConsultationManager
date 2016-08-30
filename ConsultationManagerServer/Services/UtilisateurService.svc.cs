﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using System.Windows;
using MongoDB.Driver.Builders;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UtilisateurService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UtilisateurService.svc or UtilisateurService.svc.cs at the Solution Explorer and start debugging.
    public class UtilisateurService : IUtilisateurService
    {
        

        public Utilisateur GetUtilisateurAuthenticated(string username, string pwd)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Utilisateur> GetUtilisateurs()
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetUtilisateurDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Utilisateur AddUtilisateur(Utilisateur utilisateur)
        {
            DataBaseContext db = new DataBaseContext();
            bool exist = true;
            while (exist)
            {
                var query = Query.EQ("UserName", utilisateur.UserName);
                var result = db.Utilisateurs.FindAs<Utilisateur>(query).FirstOrDefault();
                if (result == null)
                {
                    db.Utilisateurs.Save(utilisateur);
                    exist = false;
                    //MessageBox.Show("User Saved with a UserName " + utilisateur.UserName + " and Password " + utilisateur.Password);
                }
                else
                {
                    utilisateur.UserName += "_";
                    //MessageBox.Show("kjnsk");
                }
            }
            MessageBox.Show("Utilisateur Saved... " + utilisateur.UserName + "  " + utilisateur.Password);
            return utilisateur;
        }

        public Utilisateur UpdateUtilisateur(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUtilisateur(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
