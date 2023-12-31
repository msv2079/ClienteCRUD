﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteCRUDWebForms.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IClienteService")]
    public interface IClienteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetAllCliente", ReplyAction="http://tempuri.org/IClienteService/GetAllClienteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IClienteService/GetAllClienteFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.ClienteModel[] GetAllCliente(int pagina);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetAllCliente", ReplyAction="http://tempuri.org/IClienteService/GetAllClienteResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel[]> GetAllClienteAsync(int pagina);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetCliente", ReplyAction="http://tempuri.org/IClienteService/GetClienteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IClienteService/GetClienteFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.ClienteModel GetCliente(string idCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetCliente", ReplyAction="http://tempuri.org/IClienteService/GetClienteResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel> GetClienteAsync(string idCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/SaveCliente", ReplyAction="http://tempuri.org/IClienteService/SaveClienteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IClienteService/SaveClienteFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.ClienteModel SaveCliente(ClienteCRUDModel.ClienteModel cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/SaveCliente", ReplyAction="http://tempuri.org/IClienteService/SaveClienteResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel> SaveClienteAsync(ClienteCRUDModel.ClienteModel cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/AtualizarCliente", ReplyAction="http://tempuri.org/IClienteService/AtualizarClienteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IClienteService/AtualizarClienteFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.ClienteModel AtualizarCliente(string idCliente, ClienteCRUDModel.ClienteModel cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/AtualizarCliente", ReplyAction="http://tempuri.org/IClienteService/AtualizarClienteResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel> AtualizarClienteAsync(string idCliente, ClienteCRUDModel.ClienteModel cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/DeleteCliente", ReplyAction="http://tempuri.org/IClienteService/DeleteClienteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IClienteService/DeleteClienteFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        void DeleteCliente(string idCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/DeleteCliente", ReplyAction="http://tempuri.org/IClienteService/DeleteClienteResponse")]
        System.Threading.Tasks.Task DeleteClienteAsync(string idCliente);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClienteServiceChannel : ClienteCRUDWebForms.ServiceReference1.IClienteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClienteServiceClient : System.ServiceModel.ClientBase<ClienteCRUDWebForms.ServiceReference1.IClienteService>, ClienteCRUDWebForms.ServiceReference1.IClienteService {
        
        public ClienteServiceClient() {
        }
        
        public ClienteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClienteCRUDModel.ClienteModel[] GetAllCliente(int pagina) {
            return base.Channel.GetAllCliente(pagina);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel[]> GetAllClienteAsync(int pagina) {
            return base.Channel.GetAllClienteAsync(pagina);
        }
        
        public ClienteCRUDModel.ClienteModel GetCliente(string idCliente) {
            return base.Channel.GetCliente(idCliente);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel> GetClienteAsync(string idCliente) {
            return base.Channel.GetClienteAsync(idCliente);
        }
        
        public ClienteCRUDModel.ClienteModel SaveCliente(ClienteCRUDModel.ClienteModel cliente) {
            return base.Channel.SaveCliente(cliente);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel> SaveClienteAsync(ClienteCRUDModel.ClienteModel cliente) {
            return base.Channel.SaveClienteAsync(cliente);
        }
        
        public ClienteCRUDModel.ClienteModel AtualizarCliente(string idCliente, ClienteCRUDModel.ClienteModel cliente) {
            return base.Channel.AtualizarCliente(idCliente, cliente);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.ClienteModel> AtualizarClienteAsync(string idCliente, ClienteCRUDModel.ClienteModel cliente) {
            return base.Channel.AtualizarClienteAsync(idCliente, cliente);
        }
        
        public void DeleteCliente(string idCliente) {
            base.Channel.DeleteCliente(idCliente);
        }
        
        public System.Threading.Tasks.Task DeleteClienteAsync(string idCliente) {
            return base.Channel.DeleteClienteAsync(idCliente);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ISexoService")]
    public interface ISexoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISexoService/GetAllSexo", ReplyAction="http://tempuri.org/ISexoService/GetAllSexoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/ISexoService/GetAllSexoFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.SexoModel[] GetAllSexo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISexoService/GetAllSexo", ReplyAction="http://tempuri.org/ISexoService/GetAllSexoResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.SexoModel[]> GetAllSexoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISexoServiceChannel : ClienteCRUDWebForms.ServiceReference1.ISexoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SexoServiceClient : System.ServiceModel.ClientBase<ClienteCRUDWebForms.ServiceReference1.ISexoService>, ClienteCRUDWebForms.ServiceReference1.ISexoService {
        
        public SexoServiceClient() {
        }
        
        public SexoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SexoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SexoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SexoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClienteCRUDModel.SexoModel[] GetAllSexo() {
            return base.Channel.GetAllSexo();
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.SexoModel[]> GetAllSexoAsync() {
            return base.Channel.GetAllSexoAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IEstadoCivilService")]
    public interface IEstadoCivilService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstadoCivilService/GetAllEstadoCivil", ReplyAction="http://tempuri.org/IEstadoCivilService/GetAllEstadoCivilResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IEstadoCivilService/GetAllEstadoCivilFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.EstadoCivilModel[] GetAllEstadoCivil();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstadoCivilService/GetAllEstadoCivil", ReplyAction="http://tempuri.org/IEstadoCivilService/GetAllEstadoCivilResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.EstadoCivilModel[]> GetAllEstadoCivilAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEstadoCivilServiceChannel : ClienteCRUDWebForms.ServiceReference1.IEstadoCivilService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EstadoCivilServiceClient : System.ServiceModel.ClientBase<ClienteCRUDWebForms.ServiceReference1.IEstadoCivilService>, ClienteCRUDWebForms.ServiceReference1.IEstadoCivilService {
        
        public EstadoCivilServiceClient() {
        }
        
        public EstadoCivilServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EstadoCivilServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EstadoCivilServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EstadoCivilServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClienteCRUDModel.EstadoCivilModel[] GetAllEstadoCivil() {
            return base.Channel.GetAllEstadoCivil();
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.EstadoCivilModel[]> GetAllEstadoCivilAsync() {
            return base.Channel.GetAllEstadoCivilAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IOrgaoExpedicaoService")]
    public interface IOrgaoExpedicaoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrgaoExpedicaoService/GetAllOrgaoExpedicao", ReplyAction="http://tempuri.org/IOrgaoExpedicaoService/GetAllOrgaoExpedicaoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IOrgaoExpedicaoService/GetAllOrgaoExpedicaoFaultExceptionFault" +
            "", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.OrgaoExpedicaoModel[] GetAllOrgaoExpedicao();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrgaoExpedicaoService/GetAllOrgaoExpedicao", ReplyAction="http://tempuri.org/IOrgaoExpedicaoService/GetAllOrgaoExpedicaoResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.OrgaoExpedicaoModel[]> GetAllOrgaoExpedicaoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrgaoExpedicaoServiceChannel : ClienteCRUDWebForms.ServiceReference1.IOrgaoExpedicaoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrgaoExpedicaoServiceClient : System.ServiceModel.ClientBase<ClienteCRUDWebForms.ServiceReference1.IOrgaoExpedicaoService>, ClienteCRUDWebForms.ServiceReference1.IOrgaoExpedicaoService {
        
        public OrgaoExpedicaoServiceClient() {
        }
        
        public OrgaoExpedicaoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrgaoExpedicaoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrgaoExpedicaoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrgaoExpedicaoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClienteCRUDModel.OrgaoExpedicaoModel[] GetAllOrgaoExpedicao() {
            return base.Channel.GetAllOrgaoExpedicao();
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.OrgaoExpedicaoModel[]> GetAllOrgaoExpedicaoAsync() {
            return base.Channel.GetAllOrgaoExpedicaoAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IEnderecoService")]
    public interface IEnderecoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnderecoService/GetEnderecoByCep", ReplyAction="http://tempuri.org/IEnderecoService/GetEnderecoByCepResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IEnderecoService/GetEnderecoByCepFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.EnderecoModel GetEnderecoByCep(string cep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnderecoService/GetEnderecoByCep", ReplyAction="http://tempuri.org/IEnderecoService/GetEnderecoByCepResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.EnderecoModel> GetEnderecoByCepAsync(string cep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnderecoService/GetEndereco", ReplyAction="http://tempuri.org/IEnderecoService/GetEnderecoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IEnderecoService/GetEnderecoFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.EnderecoModel GetEndereco(string idEndereco);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnderecoService/GetEndereco", ReplyAction="http://tempuri.org/IEnderecoService/GetEnderecoResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.EnderecoModel> GetEnderecoAsync(string idEndereco);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnderecoService/SaveEndereco", ReplyAction="http://tempuri.org/IEnderecoService/SaveEnderecoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IEnderecoService/SaveEnderecoFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        ClienteCRUDModel.EnderecoModel SaveEndereco(ClienteCRUDModel.EnderecoModel endereco);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnderecoService/SaveEndereco", ReplyAction="http://tempuri.org/IEnderecoService/SaveEnderecoResponse")]
        System.Threading.Tasks.Task<ClienteCRUDModel.EnderecoModel> SaveEnderecoAsync(ClienteCRUDModel.EnderecoModel endereco);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEnderecoServiceChannel : ClienteCRUDWebForms.ServiceReference1.IEnderecoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EnderecoServiceClient : System.ServiceModel.ClientBase<ClienteCRUDWebForms.ServiceReference1.IEnderecoService>, ClienteCRUDWebForms.ServiceReference1.IEnderecoService {
        
        public EnderecoServiceClient() {
        }
        
        public EnderecoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EnderecoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EnderecoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EnderecoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClienteCRUDModel.EnderecoModel GetEnderecoByCep(string cep) {
            return base.Channel.GetEnderecoByCep(cep);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.EnderecoModel> GetEnderecoByCepAsync(string cep) {
            return base.Channel.GetEnderecoByCepAsync(cep);
        }
        
        public ClienteCRUDModel.EnderecoModel GetEndereco(string idEndereco) {
            return base.Channel.GetEndereco(idEndereco);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.EnderecoModel> GetEnderecoAsync(string idEndereco) {
            return base.Channel.GetEnderecoAsync(idEndereco);
        }
        
        public ClienteCRUDModel.EnderecoModel SaveEndereco(ClienteCRUDModel.EnderecoModel endereco) {
            return base.Channel.SaveEndereco(endereco);
        }
        
        public System.Threading.Tasks.Task<ClienteCRUDModel.EnderecoModel> SaveEnderecoAsync(ClienteCRUDModel.EnderecoModel endereco) {
            return base.Channel.SaveEnderecoAsync(endereco);
        }
    }
}
