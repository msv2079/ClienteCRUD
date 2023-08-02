using ClienteCRUDModel;
using System.Collections.Generic;

namespace ClienteCRUDLogica
{
    public interface ISexoLogica
    {
        IEnumerable<SexoModel> GetAll();
    }

    public class SexoLogica : DIService, ISexoLogica
    {
        public IEnumerable<SexoModel> GetAll()
        {
            return sexoDados.GetAll();
        }
    }
}
