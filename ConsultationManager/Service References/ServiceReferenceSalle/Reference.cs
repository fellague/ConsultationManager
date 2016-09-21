﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsultationManager.ServiceReferenceSalle {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceSalle.ISalleService")]
    public interface ISalleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/AddSalle", ReplyAction="http://tempuri.org/ISalleService/AddSalleResponse")]
        ConsultationManagerServer.Models.Hospitalisations.Salle AddSalle(ConsultationManagerServer.Models.Hospitalisations.Salle salle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/AddSalle", ReplyAction="http://tempuri.org/ISalleService/AddSalleResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Hospitalisations.Salle> AddSalleAsync(ConsultationManagerServer.Models.Hospitalisations.Salle salle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/GetSalles", ReplyAction="http://tempuri.org/ISalleService/GetSallesResponse")]
        ConsultationManagerServer.Models.Hospitalisations.Salle[] GetSalles(string idService);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/GetSalles", ReplyAction="http://tempuri.org/ISalleService/GetSallesResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Hospitalisations.Salle[]> GetSallesAsync(string idService);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/UpdateSalle", ReplyAction="http://tempuri.org/ISalleService/UpdateSalleResponse")]
        ConsultationManagerServer.Models.Hospitalisations.Salle UpdateSalle(ConsultationManagerServer.Models.Hospitalisations.Salle salle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/UpdateSalle", ReplyAction="http://tempuri.org/ISalleService/UpdateSalleResponse")]
        System.Threading.Tasks.Task<ConsultationManagerServer.Models.Hospitalisations.Salle> UpdateSalleAsync(ConsultationManagerServer.Models.Hospitalisations.Salle salle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/DeleteSalle", ReplyAction="http://tempuri.org/ISalleService/DeleteSalleResponse")]
        void DeleteSalle(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalleService/DeleteSalle", ReplyAction="http://tempuri.org/ISalleService/DeleteSalleResponse")]
        System.Threading.Tasks.Task DeleteSalleAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISalleServiceChannel : ConsultationManager.ServiceReferenceSalle.ISalleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SalleServiceClient : System.ServiceModel.ClientBase<ConsultationManager.ServiceReferenceSalle.ISalleService>, ConsultationManager.ServiceReferenceSalle.ISalleService {
        
        public SalleServiceClient() {
        }
        
        public SalleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SalleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsultationManagerServer.Models.Hospitalisations.Salle AddSalle(ConsultationManagerServer.Models.Hospitalisations.Salle salle) {
            return base.Channel.AddSalle(salle);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Hospitalisations.Salle> AddSalleAsync(ConsultationManagerServer.Models.Hospitalisations.Salle salle) {
            return base.Channel.AddSalleAsync(salle);
        }
        
        public ConsultationManagerServer.Models.Hospitalisations.Salle[] GetSalles(string idService) {
            return base.Channel.GetSalles(idService);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Hospitalisations.Salle[]> GetSallesAsync(string idService) {
            return base.Channel.GetSallesAsync(idService);
        }
        
        public ConsultationManagerServer.Models.Hospitalisations.Salle UpdateSalle(ConsultationManagerServer.Models.Hospitalisations.Salle salle) {
            return base.Channel.UpdateSalle(salle);
        }
        
        public System.Threading.Tasks.Task<ConsultationManagerServer.Models.Hospitalisations.Salle> UpdateSalleAsync(ConsultationManagerServer.Models.Hospitalisations.Salle salle) {
            return base.Channel.UpdateSalleAsync(salle);
        }
        
        public void DeleteSalle(string id) {
            base.Channel.DeleteSalle(id);
        }
        
        public System.Threading.Tasks.Task DeleteSalleAsync(string id) {
            return base.Channel.DeleteSalleAsync(id);
        }
    }
}
