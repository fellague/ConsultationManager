﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsultationManager.ServiceReferenceUtilisateur {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceUtilisateur.IUtilisateurService")]
    public interface IUtilisateurService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/GetUtilisateurAuthenticated", ReplyAction="http://tempuri.org/IUtilisateurService/GetUtilisateurAuthenticatedResponse")]
        ConsultationManagerServer.Models.Utilisateur GetUtilisateurAuthenticated(string username, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/GetUtilisateurAuthenticated", ReplyAction="http://tempuri.org/IUtilisateurService/GetUtilisateurAuthenticatedResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> GetUtilisateurAuthenticatedAsync(string username, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/GetUtilisateurs", ReplyAction="http://tempuri.org/IUtilisateurService/GetUtilisateursResponse")]
        ConsultationManagerServer.Models.Utilisateur[] GetUtilisateurs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/GetUtilisateurs", ReplyAction="http://tempuri.org/IUtilisateurService/GetUtilisateursResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur[]> GetUtilisateursAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/GetUtilisateurDetails", ReplyAction="http://tempuri.org/IUtilisateurService/GetUtilisateurDetailsResponse")]
        ConsultationManagerServer.Models.Utilisateur GetUtilisateurDetails(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/GetUtilisateurDetails", ReplyAction="http://tempuri.org/IUtilisateurService/GetUtilisateurDetailsResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> GetUtilisateurDetailsAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/AddUtilisateur", ReplyAction="http://tempuri.org/IUtilisateurService/AddUtilisateurResponse")]
        ConsultationManagerServer.Models.Utilisateur AddUtilisateur(ConsultationManagerServer.Models.Utilisateur utilisateur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/AddUtilisateur", ReplyAction="http://tempuri.org/IUtilisateurService/AddUtilisateurResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> AddUtilisateurAsync(ConsultationManagerServer.Models.Utilisateur utilisateur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/UpdateUtilisateur", ReplyAction="http://tempuri.org/IUtilisateurService/UpdateUtilisateurResponse")]
        ConsultationManagerServer.Models.Utilisateur UpdateUtilisateur(ConsultationManagerServer.Models.Utilisateur utilisateur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/UpdateUtilisateur", ReplyAction="http://tempuri.org/IUtilisateurService/UpdateUtilisateurResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> UpdateUtilisateurAsync(ConsultationManagerServer.Models.Utilisateur utilisateur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/DeleteUtilisateur", ReplyAction="http://tempuri.org/IUtilisateurService/DeleteUtilisateurResponse")]
        bool DeleteUtilisateur(ConsultationManagerServer.Models.Utilisateur utilisateur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilisateurService/DeleteUtilisateur", ReplyAction="http://tempuri.org/IUtilisateurService/DeleteUtilisateurResponse")]
        System.Threading.Tasks.Task<bool> DeleteUtilisateurAsync(ConsultationManagerServer.Models.Utilisateur utilisateur);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUtilisateurServiceChannel : ConsultationManager.ServiceReferenceUtilisateur.IUtilisateurService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UtilisateurServiceClient : System.ServiceModel.ClientBase<ConsultationManager.ServiceReferenceUtilisateur.IUtilisateurService>, ConsultationManager.ServiceReferenceUtilisateur.IUtilisateurService {
        
        public UtilisateurServiceClient() {
        }
        
        public UtilisateurServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UtilisateurServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UtilisateurServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UtilisateurServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsultationManagerServer.Models.Utilisateur GetUtilisateurAuthenticated(string username, string pwd) {
            return base.Channel.GetUtilisateurAuthenticated(username, pwd);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> GetUtilisateurAuthenticatedAsync(string username, string pwd) {
            return base.Channel.GetUtilisateurAuthenticatedAsync(username, pwd);
        }
        
        public ConsultationManagerServer.Models.Utilisateur[] GetUtilisateurs() {
            return base.Channel.GetUtilisateurs();
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur[]> GetUtilisateursAsync() {
            return base.Channel.GetUtilisateursAsync();
        }
        
        public ConsultationManagerServer.Models.Utilisateur GetUtilisateurDetails(string id) {
            return base.Channel.GetUtilisateurDetails(id);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> GetUtilisateurDetailsAsync(string id) {
            return base.Channel.GetUtilisateurDetailsAsync(id);
        }
        
        public ConsultationManagerServer.Models.Utilisateur AddUtilisateur(ConsultationManagerServer.Models.Utilisateur utilisateur) {
            return base.Channel.AddUtilisateur(utilisateur);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> AddUtilisateurAsync(ConsultationManagerServer.Models.Utilisateur utilisateur) {
            return base.Channel.AddUtilisateurAsync(utilisateur);
        }
        
        public ConsultationManagerServer.Models.Utilisateur UpdateUtilisateur(ConsultationManagerServer.Models.Utilisateur utilisateur) {
            return base.Channel.UpdateUtilisateur(utilisateur);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Utilisateur> UpdateUtilisateurAsync(ConsultationManagerServer.Models.Utilisateur utilisateur) {
            return base.Channel.UpdateUtilisateurAsync(utilisateur);
        }
        
        public bool DeleteUtilisateur(ConsultationManagerServer.Models.Utilisateur utilisateur) {
            return base.Channel.DeleteUtilisateur(utilisateur);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUtilisateurAsync(ConsultationManagerServer.Models.Utilisateur utilisateur) {
            return base.Channel.DeleteUtilisateurAsync(utilisateur);
        }
    }
}
