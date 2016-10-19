<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ControlaRecursos.Views.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
    .auto-style2 {
        margin-left: 200px;
        border: 1px solid #CCC;
        width: 400px;
        height: 168px;
        margin-right: auto;
        margin-top: 0;
        margin-bottom: 0;
    }
        .auto-style3 {
            font-weight: bold;
            line-height: 1;
            padding: 6px 10px 6px 10px;
            cursor: pointer;
            color: #006A35;
            text-align: center;
            background: #CCCCCC;
            border: 1px solid #C1C1C1;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            -moz-box-shadow: inset 0 1px 0 0 #aec3e5;
            -webkit-box-shadow: inset 0 1px 0 0 #aec3e5;
            height: 30px;
            margin-left: 137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    
    <div class="auto-style2">
    <br />
    <asp:Label ID="lblSubTitulo" runat="server" CssClass="labelTitulo" Width="100%"></asp:Label>
        <br />
        <input id="codSis" type="hidden" name="codSis" value="CR01" />
        <input id="codFunc" type="hidden" name="codFunc" runat="server" />
        <asp:Button ID="btnLogin" runat="server" CssClass="auto-style3" Text="Login" Width="120px" UseSubmitBehavior="true" /> 
        <br />
    <br />
    <br />
    <asp:Label ID="lblMensagem" runat="server" CssClass="labelMensagem" Width="100%"></asp:Label>
</div>
</asp:Content>
