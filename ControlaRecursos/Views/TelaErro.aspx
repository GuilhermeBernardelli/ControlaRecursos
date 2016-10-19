<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true"
    CodeBehind="TelaErro.aspx.cs" Inherits="ControlaRecursos.Views.TelaErro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphConteudo" runat="server">
    <div class="divTelaErro">
        <br />
        <asp:Label ID="lblAcessoIndevido" runat="server" Text="Ocorreu um erro em tempo de execução"
            Width="400" CssClass="lblTituloLogin"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMsgErrorTitle" runat="server" Text="Informações do erro :"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMsgErro" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnVoltar" runat="server" Text="Logout" OnClick="btnVoltar_Click"
            CssClass="buttonCSS" UseSubmitBehavior="true"/>
        <br />
        <br />
    </div>
</asp:Content>
