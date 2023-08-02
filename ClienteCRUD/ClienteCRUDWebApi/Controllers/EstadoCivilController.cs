using ClienteCRUDLogica;
using ClienteCRUDModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClienteCRUDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoCivilController : ControllerBase
    {
        private readonly IEstadoCivilLogica estadoCivilLogica;

        public EstadoCivilController(IEstadoCivilLogica estadoCivilLogica)
        {
            this.estadoCivilLogica = estadoCivilLogica;
        }

        /// <summary>
        /// Retorna lista de sexos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllEstadoCivil")]
        public IActionResult GetAllEstadoCivil()
        {
            try
            {
                var data = estadoCivilLogica.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
