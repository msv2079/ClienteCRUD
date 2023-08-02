using ClienteCRUDModel;
using ClienteCRUDWebForms.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteCRUDWebForms
{
    public partial class Dados : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClientes(1);
            }
        }

        private void BindClientes(int pagina)
        {
            var listaClientes = new ClienteServiceClient().GetAllCliente(pagina);

            ClientesRepeater.DataSource = listaClientes;
            ClientesRepeater.DataBind();

            if (listaClientes.Length > 0)
            {
                int.TryParse(ConfigurationManager.AppSettings["Paginacao"], out var paginacao);

                var totalPaginas = Math.Ceiling(listaClientes[0].TotalClientes * 1.0 / paginacao);

                var listaBotoes = new Dictionary<int, string>();

                for (int i = 1; i <= totalPaginas; i++)
                {
                    listaBotoes.Add(i, i == pagina ? "btn btn-primary" : "btn btn-light");
                }

                NumeroPaginasRepeater.DataSource = listaBotoes;
                NumeroPaginasRepeater.DataBind();
            }
        }

        protected void ClientesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var idCliente = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "Excluir")
                {
                    new ClienteServiceClient().DeleteCliente(idCliente);

                    ExibirMensagem("Cliente Removido com sucesso", true);

                    BindClientes(1);
                }
                else if (e.CommandName == "Editar")
                {
                    Response.Redirect($"~/Default.aspx?IdCliente={idCliente}");
                }
            }
            catch (FaultException ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        private void ExibirMensagem(string msg, bool sucesso = false)
        {
            MensagemPanel.Visible = true;
            MensagemLabel.Text = msg;

            var classeCSS = $"alert {(sucesso ? "alert-success" : "alert-danger")} ";
            MensagemPanel.CssClass = classeCSS;
        }

        protected void NumeroPaginasRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var pagina = Convert.ToInt32(e.CommandArgument);

            BindClientes(pagina);
        }
    }
}