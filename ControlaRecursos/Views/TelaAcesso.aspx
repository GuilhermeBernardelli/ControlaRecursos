<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="TelaAcesso.aspx.cs" Inherits="ControlaRecursos.Views.TelaAcesso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <asp:Panel ID="PanelButtons" runat="server" Height="133px" BorderColor="Silver" BorderWidth="2px" HorizontalAlign="Center">
        <br />
        <asp:Label ID="lblSubTitulo" runat="server" CssClass="labelTitulo" Width="100%">Realizar pesquisa</asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMensagem" runat="server" CssClass="labelMensagem" Width="100%"></asp:Label>
        <br />
        <asp:Button ID="btnPessoa" runat="server" CssClass="buttonCSS" Text="Pessoas" Width="120px" OnClick="btnPessoa_Click" UseSubmitBehavior="false"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRecurso" runat="server" CssClass="buttonCSS" OnClick="btnRecurso_Click" Text="Recursos" Width="120px" UseSubmitBehavior="false"/>
        <br />
    </asp:Panel>
    
</asp:Content>
