<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dados.aspx.cs" Inherits="ClienteCRUDWebForms.Dados" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <br />
        <asp:Panel runat="server" ID="MensagemPanel">
            <asp:Label Text="" runat="server" ID="MensagemLabel"  />
        </asp:Panel>
        <section class="row">
            <h5 class="text-primary">Dados</h5>
        </section>
        <div class="row">
            <div class="col-12">
                <asp:Repeater runat="server" ID="ClientesRepeater" OnItemCommand="ClientesRepeater_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Nome</th>
                                    <th>Data Nascimento</th>
                                    <th>CPF</th>
                                    <th>Ação</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Nome") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "DataNascimento", "{0:MM/dd/yyyy}") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "CPF") %></td>
                            <td>
                                
                                <asp:LinkButton Text="" runat="server" ID="EditarLinkButton" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>'><i class="fa fa-edit"></i></asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton Text="" runat="server" ID="ExcluirLinkButton" CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="NumeroPaginasRepeater" OnItemCommand="NumeroPaginasRepeater_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered">
                            <tbody>
                                <tr>
                                    <td class="text-center">
                    </HeaderTemplate>
                    <ItemTemplate>
                                        <asp:Button CssClass='<%#  Eval("value") %>' Text='<%#  Eval("key") %>' CommandArgument='<%#  Eval("key") %>' runat="server" />&nbsp;
                    </ItemTemplate>
                    <FooterTemplate>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>
</asp:Content>
