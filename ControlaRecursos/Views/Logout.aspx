<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="ControlaRecursos.Views.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server" onload="removeViewState();">
    <asp:HyperLink ID="lnkIndex" runat="server" align="right" Font-Bold="True" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Views/Index.aspx">Efetuar Login</asp:HyperLink>
    <asp:Label ID="lblLogout" runat="server" CssClass="labelMensagem" Text="Logout Realizado com Sucesso" Width="100%" Height="37px"></asp:Label>
</asp:Content>
