using ClienteCRUDModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClienteCRUDWCF
{
    [ServiceContract]
    public interface IOrgaoExpedicaoService
    {

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        IEnumerable<OrgaoExpedicaoModel> GetAllOrgaoExpedicao();
    }
}
