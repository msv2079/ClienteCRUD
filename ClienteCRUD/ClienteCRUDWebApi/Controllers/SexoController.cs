using ClienteCRUDLogica;
using ClienteCRUDModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClienteCRUDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexoController : ControllerBase
    {
        private readonly ISexoLogica sexoLogica;

        public SexoController(ISexoLogica sexoLogica)
        {
            this.sexoLogica = sexoLogica;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllSexo")]
        public ActionResult GetAllSexo()
        {
            try
            {
                var data = sexoLogica.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
