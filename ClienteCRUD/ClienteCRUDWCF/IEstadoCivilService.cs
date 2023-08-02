using ClienteCRUDModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClienteCRUDWCF
{
    [ServiceContract]
    public interface IEstadoCivilService
    {

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        IEnumerable<EstadoCivilModel> GetAllEstadoCivil();

    }
}
