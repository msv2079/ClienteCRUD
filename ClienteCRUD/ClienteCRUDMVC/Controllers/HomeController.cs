using ClienteCRUDModel;
using ClienteCRUDMVC.Models;
using ClienteCRUDMVC.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using webMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace ClienteCRUDMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestUtil _requestUtil;
        private readonly IOptions<ClienteCRUDConfig> _config;
        public HomeController(IRequestUtil requestUtil, IOptions<ClienteCRUDConfig> config)
        {
            _requestUtil = requestUtil;
            _config = config;
        }

        public IActionResult Index(int pagina = 1)
        {
            var model = new List<ClienteModel>();

            try
            {
                var response = _requestUtil.SendRequest($"Cliente/{pagina}/GetAllCliente");

                model = ((JArray)response).ToList<ClienteModel>();

                if (model.Count() > 0)
                {
                    int.TryParse(_config.Value.Paginacao, out var paginacao);

                    var totalPaginas = Math.Ceiling(model[0].TotalClientes * 1.0 / paginacao);

                    var listaBotoes = new Dictionary<int, string>();

                    for (int i = 1; i <= totalPaginas; i++)
                    {
                        listaBotoes.Add(i, i == pagina ? "btn btn-primary" : "btn btn-light");
                    }

                    ViewBag.Paginacao = listaBotoes;
                }
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = ex.Message;
            }

            ExibirMensagens();

            return View(model);
        }

        private void ExibirMensagens()
        {
            var msg = Convert.ToString(TempData["Mensagem"]);
            bool.TryParse(Convert.ToString(TempData["MensagemSucesso"]), out var sucesso);

            if (!string.IsNullOrEmpty(msg))
            {
                var classeCSS = $"alert {(sucesso ? "alert-success" : "alert-danger")} ";
                ViewBag.Mensagem = msg;
                ViewBag.ClasseCSSMensagem = classeCSS;
            }

            TempData["Mensagem"] = string.Empty;
            TempData["MensagemSucesso"] = string.Empty;
        }

        private IActionResult SalvarDados(ClienteViewModel model)
        {
            try
            {
                var endereco = model.Endereco;
                string jsonEndereco = JsonConvert.SerializeObject(endereco, Formatting.Indented);
                var responseEndereco = _requestUtil.SendRequest($"Endereco", webMethod.HttpMethod.Post, jsonEndereco);
                var enderecoDB = JsonConvert.DeserializeObject<EnderecoModel>(responseEndereco.ToString());

                var mensagem = "cadastrado";

                var cliente = model.Cliente;
                cliente.EnderecoId = enderecoDB.Id;

                if (cliente.Id == 0)
                {
                    string jsonCliente = JsonConvert.SerializeObject(cliente, Formatting.Indented);
                    var responseCliente = _requestUtil.SendRequest($"Cliente", webMethod.HttpMethod.Post, jsonCliente);
                }
                else
                {
                    mensagem = "atualizado";
                    string jsonCliente = JsonConvert.SerializeObject(cliente, Formatting.Indented);
                    var responseCliente = _requestUtil.SendRequest($"Cliente?idCliente={cliente.Id}", webMethod.HttpMethod.Put, jsonCliente);
                }

                TempData["Mensagem"] = $"Cliente {mensagem} com sucesso";
                TempData["MensagemSucesso"] = true;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var isValidObject = false;
                dynamic result = null;

                var msgResult = string.Empty;

                if (!string.IsNullOrWhiteSpace(ex.Message))
                {
                    isValidObject = ex.Message.TryParseJson(out result);
                }

                if (isValidObject)
                {
                    //var msg = JsonConvert.DeserializeObject<dynamic>();

                    var stbErros = new StringBuilder();

                    /*foreach (var campos in result["errors"])
                    {
                        var nomeCampo = campos["name"];

                        foreach (var erros in campos)
                        {
                            foreach (var erro in erros)
                            {
                                //stbErros.AppendLine(erro.Value);
                            }
                        }
                    }*/

                    //TODO Pegar mensagens de erro

                    msgResult = stbErros.ToString();
                }
                else
                {
                    msgResult = ex.Message;
                }

                TempData["Mensagem"] = msgResult;

                ExibirMensagens();

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Create(ClienteViewModel model)
        {
            BindSelects();

            return SalvarDados(model);
        }

        [HttpPost]
        public IActionResult Edit(ClienteViewModel model)
        {
            BindSelects();

            return SalvarDados(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BindSelects();

            var model = new ClienteViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BindSelects();

            var responseCliente = _requestUtil.SendRequest($"Cliente/{id}/GetCliente");
            var cliente = JsonConvert.DeserializeObject<ClienteModel>(responseCliente.ToString());

            var responseEndereco = _requestUtil.SendRequest($"Endereco/{cliente.EnderecoId}/GetEndereco");
            var endereco = JsonConvert.DeserializeObject<EnderecoModel>(responseEndereco.ToString());

            var model = new ClienteViewModel
            {
                Cliente = cliente,
                Endereco = endereco
            };

            return View(model);
        }

        private void BindSelects()
        {
            var responseOrgaoExpedicao = _requestUtil.SendRequest($"OrgaoExpedicao");
            var listaOrgaoExpedicao = ((JArray)responseOrgaoExpedicao).ToList<OrgaoExpedicaoModel>();

            ViewBag.OrgaoExpedicao = listaOrgaoExpedicao;

            var responseSexo = _requestUtil.SendRequest($"Sexo");
            var listaSexo = ((JArray)responseSexo).ToList<SexoModel>();

            ViewBag.Sexo = listaSexo;

            var responseEstadoCivil = _requestUtil.SendRequest($"EstadoCivil");
            var listaEstadoCivil = ((JArray)responseEstadoCivil).ToList<EstadoCivilModel>();

            ViewBag.EstadoCivil = listaEstadoCivil;
        }

        public IActionResult Delete(int id)
        {
            var msgResult = string.Empty;
            var sucesso = false;

            try
            {
                var responseEndereco = _requestUtil.SendRequest($"Cliente?idCliente={id}", webMethod.HttpMethod.Delete);

                msgResult = "Cliente Removido com Sucesso";
                sucesso = true;
            }
            catch (Exception ex)
            {
                msgResult = ex.Message;
            }

            TempData["Mensagem"] = msgResult;
            TempData["MensagemSucesso"] = sucesso;

            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}