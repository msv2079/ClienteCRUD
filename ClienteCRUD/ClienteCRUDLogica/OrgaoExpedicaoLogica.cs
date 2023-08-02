using ClienteCRUDModel;
using System.Collections.Generic;

namespace ClienteCRUDLogica
{
    public interface IOrgaoExpedicaoLogica
    {
        IEnumerable<OrgaoExpedicaoModel> GetAll();
    }

    public class OrgaoExpedicaoLogica : DIService, IOrgaoExpedicaoLogica
    {
        public IEnumerable<OrgaoExpedicaoModel> GetAll()
        {
            return orgaoExpedicaoDados.GetAll();
        }
    }
}
