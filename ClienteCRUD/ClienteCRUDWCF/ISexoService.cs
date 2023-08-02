using ClienteCRUDModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClienteCRUDWCF
{
    [ServiceContract]
    public interface ISexoService
    {

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        IEnumerable<SexoModel> GetAllSexo();

    }
}
