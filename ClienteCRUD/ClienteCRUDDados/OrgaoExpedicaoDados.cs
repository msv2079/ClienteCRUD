using ClienteCRUDModel;
using System.Collections.Generic;
using System.Linq;

namespace ClienteCRUDDados
{
    public interface IOrgaoExpedicaoDados
    {
        IEnumerable<OrgaoExpedicaoModel> GetAll();
    }

    public class OrgaoExpedicaoDados : DIService, IOrgaoExpedicaoDados
    {
        public IEnumerable<OrgaoExpedicaoModel> GetAll()
        {
            return context.OrgaoExpedicao.ToList();
        }
    }
}
