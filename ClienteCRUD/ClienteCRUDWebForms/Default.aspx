<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClienteCRUDWebForms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <br />
        <asp:Panel runat="server" ID="MensagemPanel">
            <asp:Label Text="" runat="server" ID="MensagemLabel"  />
        </asp:Panel>
        <asp:HiddenField ID="IdClienteHiddenField" runat="server" />
        <section class="row">
            <h5 class="text-primary">Clientes</h5>
        </section>
        <div class="row">
            <div class="col-3">
                <label for="CPFTextBox" class="form-label">CPF*</label>
                <asp:TextBox CssClass="form-control" ID="CPFTextBox" MaxLength="14" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-9">
                <label for="NomeTextBox" class="form-label">Nome*</label>
                <asp:TextBox CssClass="form-control" ID="NomeTextBox" MaxLength="100" ClientIDMode="Static" runat="server" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-3">
                <label for="RGTextBox" class="form-label">RG</label>
                <asp:TextBox CssClass="form-control" ID="RGTextBox" MaxLength="15" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-3">
                <label for="DataExpedicaoTextBox" class="form-label">Data Expedição</label>
                <asp:TextBox CssClass="form-control" MaxLength="10" ID="DataExpedicaoTextBox" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-3">
                <label for="OrgaoExpedicaoTextBox" class="form-label">Órgão Expedição</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="OrgaoExpedicaoDropDownList" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="col-3">
                <label for="UFExpedicaoTextBox" class="form-label">UF Expedição</label>
                <asp:TextBox CssClass="form-control" ID="UFExpedicaoTextBox" MaxLength="2" ClientIDMode="Static" runat="server" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-3">
                <label for="DataNascimentoTextBox" class="form-label">Data Nascimento</label>
                <asp:TextBox CssClass="form-control" MaxLength="10" ID="DataNascimentoTextBox" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-3">
                <label for="SexoTextBox" class="form-label">Sexo</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="SexoDropDownList" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="col-3">
                <label for="EstadoCivilTextBox" class="form-label">Estado Civil</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="EstadoCivilDropDownList" ClientIDMode="Static"></asp:DropDownList>
            </div>
        </div>
        <hr />
        <section class="row">
            <h5 class="text-primary">Endereço</h5>
        </section>
        <asp:HiddenField ID="IdEnderecoHiddenField" runat="server" />
        <div class="row">
            <div class="col-2">
                <label for="CEPTextBox" class="form-label">CEP*</label>
                <div class="input-group">
                    <asp:TextBox CssClass="form-control" ID="CEPTextBox" MaxLength="9" ClientIDMode="Static" runat="server" />
                    <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="BuscarCEPLinkButton" ClientIDMode="Static" OnClick="BuscarCEPLinkButton_Click">
                        <span class="input-group-button">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                                <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
                            </svg>
                        </span>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="col-3">
                <label for="RuaTextBox" class="form-label">Rua*</label>
                <asp:TextBox CssClass="form-control" ID="RuaTextBox" MaxLength="100" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-1">
                <label for="NumeroTextBox" class="form-label">Número*</label>
                <asp:TextBox CssClass="form-control" ID="NumeroTextBox" MaxLength="20" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-2">
                <label for="ComplementoTextBox" class="form-label">Complemento</label>
                <asp:TextBox CssClass="form-control" ID="ComplementoTextBox" MaxLength="100" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-2">
                <label for="BairroTextBox" class="form-label">Bairro*</label>
                <asp:TextBox CssClass="form-control" ID="BairroTextBox" MaxLength="100" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-1">
                <label for="CidadeTextBox" class="form-label">Cidade*</label>
                <asp:TextBox CssClass="form-control" ID="CidadeTextBox" MaxLength="100" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-1">
                <label for="UFTextBox" class="form-label">UF*</label>
                <asp:TextBox CssClass="form-control" ID="UFTextBox" MaxLength="2" ClientIDMode="Static" runat="server" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-1">
                <asp:Button CssClass="btn btn-primary" Text="Cadastrar" ID="CadastrarButton" OnClick="CadastrarButton_Click" runat="server" />
                <asp:Button CssClass="btn btn-warning" Visible="false" Text="Atualizar" OnClick="AtualizarButton_Click" ID="AtualizarButton" runat="server" />
            </div>
        </div>
    </main>
</asp:Content>
