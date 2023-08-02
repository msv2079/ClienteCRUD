using ClienteCRUDLogica;
using ClienteCRUDModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClienteCRUDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoLogica enderecoLogica;

        public EnderecoController(IEnderecoLogica enderecoLogica)
        {
            this.enderecoLogica = enderecoLogica;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet("{cep}/GetEnderecoByCep")]

        public IActionResult GetEnderecoByCep(string cep)
        {
            try
            {
                var data = enderecoLogica.GetEnderecoByCep(cep);

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
        /// <param name="endereco"></param>
        /// <returns></returns>
        [HttpPost(Name = "SaveEndereco")]
        public IActionResult SaveEndereco(EnderecoModel endereco)
        {
            try
            {
                var data =  enderecoLogica.Save(endereco);

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
        /// <param name="idEndereco"></param>
        /// <returns></returns>
        [HttpGet("{idEndereco}/GetEndereco")]
        public IActionResult GetEndereco(string idEndereco)
        {
            try
            {
                var data = enderecoLogica.GetEndereco(idEndereco);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}