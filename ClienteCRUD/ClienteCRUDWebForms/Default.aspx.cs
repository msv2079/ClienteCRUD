using ClienteCRUDModel;
using ClienteCRUDWebForms.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteCRUDWebForms
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindOrgaoExpedicao();
                BindSexo();
                BindEstadoCivil();

                if (Request.QueryString["IdCliente"] != null)
                    BindCliente(Request.QueryString["IdCliente"]);
            }
        }

        private void BindCliente(string idCliente)
        {
            try
            {
                LimparFormulario();

                CadastrarButton.Visible = false;
                AtualizarButton.Visible = true;

                var clienteClient = new ClienteServiceClient();

                var cliente = clienteClient.GetCliente(idCliente);

                IdClienteHiddenField.Value = idCliente;
                CPFTextBox.Text = cliente.CPF;

                NomeTextBox.Text = cliente.Nome;
                RGTextBox.Text = cliente.RG;
                UFExpedicaoTextBox.Text = cliente.UFExpedicao;

                if (cliente.DataExpedicao != null)
                    DataExpedicaoTextBox.Text = cliente.DataExpedicao.GetValueOrDefault().ToString("dd/MM/yyyy");

                DataNascimentoTextBox.Text = cliente.DataNascimento.ToString("dd/MM/yyyy");

                OrgaoExpedicaoDropDownList.SelectedValue = cliente.OrgaoExpedicaoId.ToString();
                SexoDropDownList.SelectedValue = cliente.SexoId.ToString();
                EstadoCivilDropDownList.SelectedValue = cliente.EstadoCivilId.ToString();

                var idEndereco = cliente.EnderecoId.ToString();

                var enderecoClient = new EnderecoServiceClient();
                var endereco = enderecoClient.GetEndereco(idEndereco);

                IdEnderecoHiddenField.Value = idEndereco;
                CEPTextBox.Text = endereco.CEP;
                RuaTextBox.Text = endereco.Rua;
                NumeroTextBox.Text = endereco.Numero;
                ComplementoTextBox.Text = endereco.Complemento;
                BairroTextBox.Text = endereco.Bairro;
                CidadeTextBox.Text = endereco.Cidade;
                UFTextBox.Text = endereco.UF;
            }
            catch (FaultException ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        private void BindSexo()
        {
            SexoDropDownList.DataSource = new SexoServiceClient().GetAllSexo();
            SexoDropDownList.DataValueField = "Id";
            SexoDropDownList.DataTextField = "Descricao";
            SexoDropDownList.DataBind();
        }

        private void BindEstadoCivil()
        {
            EstadoCivilDropDownList.DataSource = new EstadoCivilServiceClient().GetAllEstadoCivil();
            EstadoCivilDropDownList.DataValueField = "Id";
            EstadoCivilDropDownList.DataTextField = "Descricao";
            EstadoCivilDropDownList.DataBind();
        }

        private void BindOrgaoExpedicao()
        {
            OrgaoExpedicaoDropDownList.DataSource = new OrgaoExpedicaoServiceClient().GetAllOrgaoExpedicao();
            OrgaoExpedicaoDropDownList.DataValueField = "Id";
            OrgaoExpedicaoDropDownList.DataTextField = "Descricao";
            OrgaoExpedicaoDropDownList.DataBind();
        }

        protected void BuscarCEPLinkButton_Click(object sender, EventArgs e)
        {
            ResetMensagens();

            try
            {
                var dados = new EnderecoServiceClient().GetEnderecoByCep(CEPTextBox.Text);

                RuaTextBox.Text = dados.Rua;
                CidadeTextBox.Text = dados.Cidade;
                BairroTextBox.Text = dados.Bairro;
                ComplementoTextBox.Text = dados.Complemento;
                UFTextBox.Text = dados.UF;
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

        private void ResetMensagens()
        {
            MensagemPanel.Visible = false;
            MensagemLabel.Text = string.Empty;
        }

        private EnderecoModel GetEnderecoForm()
        {
            var endereco = new EnderecoModel
            {
                CEP = CEPTextBox.Text,
                Rua = RuaTextBox.Text,
                Numero = NumeroTextBox.Text,
                Complemento = ComplementoTextBox.Text,
                Bairro = BairroTextBox.Text,
                Cidade = CidadeTextBox.Text,
                UF = UFTextBox.Text
            };

            if (int.TryParse(IdEnderecoHiddenField.Value, out var idEndereco))
            {
                endereco.Id = idEndereco;
            }

            return endereco;
        }

        private ClienteModel GetClienteForm()
        {
            DateTime.TryParse(DataExpedicaoTextBox.Text, out var dtExpedicao);
            DateTime.TryParse(DataNascimentoTextBox.Text, out var dataNascimento);

            int.TryParse(OrgaoExpedicaoDropDownList.SelectedValue, out var orgaoExpedicaoId);
            int.TryParse(SexoDropDownList.SelectedValue, out var sexoId);
            int.TryParse(EstadoCivilDropDownList.SelectedValue, out var estadoCivilId);

            var cliente = new ClienteModel
            {
                CPF = CPFTextBox.Text,
                Nome = NomeTextBox.Text,
                RG = RGTextBox.Text,
                DataExpedicao = dtExpedicao,
                OrgaoExpedicaoId = orgaoExpedicaoId,
                UFExpedicao = UFExpedicaoTextBox.Text,
                DataNascimento = dataNascimento,
                SexoId = sexoId,
                EstadoCivilId = estadoCivilId,
            };

            if (int.TryParse(IdClienteHiddenField.Value, out var idCliente))
            {
                cliente.Id = idCliente;
            }

            return cliente;
        }

        private void LimparFormulario()
        {
            CadastrarButton.Visible = true;
            AtualizarButton.Visible = false;

            IdClienteHiddenField.Value = string.Empty;
            CPFTextBox.Text = string.Empty;
            NomeTextBox.Text = string.Empty;
            RGTextBox.Text = string.Empty;
            DataExpedicaoTextBox.Text = string.Empty;
            OrgaoExpedicaoDropDownList.SelectedIndex = 0;
            UFExpedicaoTextBox.Text = string.Empty;
            DataNascimentoTextBox.Text = string.Empty;
            SexoDropDownList.SelectedIndex = 0;
            EstadoCivilDropDownList.SelectedIndex = 0;

            IdEnderecoHiddenField.Value = string.Empty;
            CEPTextBox.Text = string.Empty;
            RuaTextBox.Text = string.Empty;
            NumeroTextBox.Text = string.Empty;
            ComplementoTextBox.Text = string.Empty;
            BairroTextBox.Text = string.Empty;
            CidadeTextBox.Text = string.Empty;
            UFTextBox.Text = string.Empty;
        }

        private void SalvarDados(string idCliente)
        {
            try
            {
                var cliente = GetClienteForm();
                var endereco = GetEnderecoForm();

                var enderecoDB = new EnderecoServiceClient().SaveEndereco(endereco);
                var clienteClient = new ClienteServiceClient();

                cliente.EnderecoId = enderecoDB.Id;
                var mensagem = "cadastrado";

                if (string.IsNullOrWhiteSpace(idCliente))
                {
                    clienteClient.SaveCliente(cliente);
                }
                else
                {
                    mensagem = "atualizado";
                    clienteClient.AtualizarCliente(idCliente, cliente);
                }

                ExibirMensagem($"Cliente {mensagem} com sucesso", true);

                LimparFormulario();
            }
            catch (FaultException ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        protected void CadastrarButton_Click(object sender, EventArgs e)
        {
            SalvarDados("");
        }

        protected void AtualizarButton_Click(object sender, EventArgs e)
        {
            SalvarDados(IdClienteHiddenField.Value);
        }
    }
}