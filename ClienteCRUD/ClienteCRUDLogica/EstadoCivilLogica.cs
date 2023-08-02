using ClienteCRUDModel;
using System.Collections.Generic;

namespace ClienteCRUDLogica
{
    public interface IEstadoCivilLogica
    {
        IEnumerable<EstadoCivilModel> GetAll();
    }

    public class EstadoCivilLogica : DIService, IEstadoCivilLogica
    {
        public IEnumerable<EstadoCivilModel> GetAll()
        {
            return estadoCivilDados.GetAll();
        }
    }
}
