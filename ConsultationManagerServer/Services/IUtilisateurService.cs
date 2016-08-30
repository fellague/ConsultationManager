using ConsultationManagerServer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUtilisateurService" in both code and config file together.
    [ServiceContract]
    public interface IUtilisateurService
    {
        [OperationContract]
        Utilisateur GetUtilisateurAuthenticated(string username, string pwd);

        [OperationContract]
        ObservableCollection<Utilisateur> GetUtilisateurs();

        [OperationContract]
        Utilisateur GetUtilisateurDetails(string id);

        [OperationContract]
        Utilisateur AddUtilisateur(Utilisateur utilisateur);

        [OperationContract]
        Utilisateur UpdateUtilisateur(Utilisateur utilisateur);

        [OperationContract]
        bool DeleteUtilisateur(Utilisateur utilisateur);
    }
}
