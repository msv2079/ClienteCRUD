using ClienteCRUDModel;
using System.ServiceModel;

namespace ClienteCRUDWCF
{
    [ServiceContract]
    public interface IEnderecoService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        EnderecoModel GetEnderecoByCep(string cep);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        EnderecoModel GetEndereco(string idEndereco);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        EnderecoModel SaveEndereco(EnderecoModel endereco);
    }
}
