using ClienteCRUDModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClienteCRUDWCF
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        IEnumerable<ClienteModel> GetAllCliente(int pagina);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        ClienteModel GetCliente(string idCliente);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        ClienteModel SaveCliente(ClienteModel cliente);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        ClienteModel AtualizarCliente(string idCliente, ClienteModel cliente);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void DeleteCliente (string idCliente);
    }
}
