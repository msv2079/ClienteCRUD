using ClienteCRUDLogica;
using ClienteCRUDModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClienteCRUDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrgaoExpedicaoController : ControllerBase
    {
        private readonly IOrgaoExpedicaoLogica orgaoExpedicaoLogica;

        public OrgaoExpedicaoController(IOrgaoExpedicaoLogica orgaoExpedicaoLogica)
        {
            this.orgaoExpedicaoLogica = orgaoExpedicaoLogica;
        }

        /// <summary>
        /// Retorna lista de sexos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllOrgaoExpedicao")]
        public ActionResult GetAllOrgaoExpedicao()
        {
            try
            {
                var data =  orgaoExpedicaoLogica.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
