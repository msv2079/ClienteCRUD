using ClienteCRUDModel;
using System.Collections.Generic;
using System.Linq;

namespace ClienteCRUDDados
{
    public interface IEstadoCivilDados
    {
        IEnumerable<EstadoCivilModel> GetAll();
    }

    public class EstadoCivilDados : DIService, IEstadoCivilDados
    {
        public IEnumerable<EstadoCivilModel> GetAll()
        {
            return context.EstadoCivil.ToList();
        }
    }
}
