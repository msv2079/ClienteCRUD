using ClienteCRUDLogica;
using ClienteCRUDModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClienteCRUDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteLogica clienteLogica;

        public ClienteController(IClienteLogica clienteLogica)
        {
            this.clienteLogica = clienteLogica;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost(Name = "SaveCliente")]
        public ActionResult SaveCliente(ClienteModel cliente)
        {
            try
            {
                var data = clienteLogica.Save(cliente);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut(Name = "AtualizarCliente")]
        public ActionResult AtualizarCliente(string idCliente, ClienteModel cliente)
        {
            try
            {
                var data = clienteLogica.Save(idCliente, cliente);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        [HttpDelete(Name = "DeleteCliente")]
        public ActionResult DeleteCliente(string idCliente)
        {
            try
            {
                clienteLogica.Delete(idCliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagina"></param>
        /// <returns></returns>
        [HttpGet("{pagina:int}/GetAllCliente")]
        public ActionResult GetAllCliente(int pagina)
        {
            try
            {
                var data = clienteLogica.GetAll(pagina);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        [HttpGet("{idCliente}/GetCliente")]
        public ActionResult GetCliente(string idCliente)
        {
            try
            {
                var data = clienteLogica.Get(idCliente);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}