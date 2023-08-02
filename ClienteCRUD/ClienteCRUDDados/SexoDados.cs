using ClienteCRUDModel;
using System.Collections.Generic;
using System.Linq;

namespace ClienteCRUDDados
{
    public interface ISexoDados
    {
        IEnumerable<SexoModel> GetAll();
    }

    public class SexoDados : DIService, ISexoDados
    {
        public IEnumerable<SexoModel> GetAll()
        {
            return context.Sexo.ToList();
        }
    }
}
