<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="Pessoas.aspx.cs" Inherits="ControlaRecursos.Views.Pessoas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
         .auto-style6 {
            margin-top: 0px;
        }
        .auto-style8 {
            margin-left: 20px;
        }
        .auto-style18 {
            margin-top: 12px;
        }
        .auto-style19 {
            margin-left: 21px;
        }
        .auto-style20 {
            margin-left: 11px;
        }
        .auto-style21 {
            margin-left: 12px;
        }
        .auto-style22 {
            margin-top: 9px;
        }
        .auto-style11 {
        margin-top: 8px;
    }
        .auto-style23 {
            margin-left: 14px;
        }
        .auto-style24 {
            margin-left: 16px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <asp:Panel ID="PanelButtons" runat="server" Height="133px" BorderColor="Silver" BorderWidth="2px" HorizontalAlign="Center">
        <br />
        <asp:Label ID="lblSubTitulo" runat="server" CssClass="labelTitulo" Width="100%">Realizar pesquisa</asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMensagem" runat="server" CssClass="labelMensagem" Width="100%"></asp:Label>
        <br />
        <asp:Button ID="btnPessoa" runat="server" CssClass="buttonCSS" Text="Pessoas" Width="120px" Enabled="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRecurso" runat="server" CssClass="buttonCSS" OnClick="btnRecurso_Click" Text="Recursos" Width="120px" />
        <br />
    </asp:Panel>
    
    <asp:Panel ID="PanelPesquisar" runat="server" CssClass="auto-style6" Height="130px" GroupingText="Pesquisar" HorizontalAlign="left">
        <br />
        <asp:Label ID="lblPesquisar" runat="server" Text="Pesquisar:"></asp:Label>
        <asp:TextBox ID="txtPesquisa" runat="server" CssClass="auto-style8" Width="565px"></asp:TextBox>
        &nbsp;*&nbsp;&nbsp; &nbsp;<asp:CheckBox ID="chkVlRecurso" runat="server" Text="Valor do Recurso" />
        &nbsp; &nbsp;&nbsp;<asp:Label ID="lblMsgErro" runat="server" align="rigth" CssClass="labelMensagem" ForeColor="Red" Text="*Preenchimento do campo pesquisar obrigatório" Visible="False" Width="56%"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnPesquisar" runat="server" CssClass="buttonCSS" OnClick="btnPesquisar_Click" Text="Pesquisar" Width="120px" UseSubmitBehavior="true" />
            &nbsp;
        <asp:Button ID="btnEditar" runat="server" CssClass="buttonCSS" Text="Editar" Width="120px" OnClick="btnEditar_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnExcluir" runat="server" CssClass="buttonCSS" OnClick="btnExcluir_Click" Text="Excluir" Width="120px" />
&nbsp;&nbsp;<asp:Button ID="btnIncluirDados" runat="server" CssClass="buttonCSS" OnClick="btnIncluirDados_Click" Text="Incluir" Width="120px" />
&nbsp;
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelSelecione" runat="server" Height="100%" Visible="false" GroupingText="Selecione" CssClass="auto-style22">
        <asp:RadioButtonList ID="rblSeleciona" runat="server" AutoPostBack="true" CssClass="auto-style11" TabIndex="2" OnSelectedIndexChanged="rblSeleciona_SelectedIndexChanged" ViewStateMode="Enabled">
        </asp:RadioButtonList>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
                &nbsp;&nbsp;
        <asp:Button ID="btnLimpaSelec" runat="server" CssClass="buttonCSS" OnClick="btnLimpaSelec_Click" Text="Limpar" Width="120px" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelFuncionario" runat="server" CssClass="auto-style18" GroupingText="Dados Funcionário" Height="100%" Visible="False">
        <br />
        <asp:Label ID="lblRecursoId" runat="server" Text="Id Func. :" Visible="False"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" CssClass="auto-style19" Enabled="False" Width="50px" Visible="False"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Label ID="lblNome" runat="server" Text="Nome :"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server" CssClass="auto-style20" Width="539px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="lblCodigo" runat="server" Text="CPF :"></asp:Label>
        <asp:TextBox ID="txtCpf" runat="server" CssClass="auto-style21" Width="204px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Label ID="lblOrigem" runat="server" Text="Origem:"></asp:Label>
        <asp:TextBox ID="txtOrigem" runat="server" CssClass="auto-style24" Enabled="False" Width="383px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="lblInicio" runat="server" Text="Data Inicio:"></asp:Label>
        <asp:TextBox ID="txtInicio" runat="server" CssClass="auto-style23" Enabled="False" Width="169px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTermino" runat="server" Text="Data Término:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtTermino" runat="server" CssClass="auto-style23" Enabled="False" Width="169px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnRecursos" runat="server" CssClass="buttonCSS" OnClick="btnRecursos_Click" Text="Recursos" Width="120px" />
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSalvarNovo" runat="server" CssClass="buttonCSS" Enabled="False" OnClick="btnSalvarRecurso_Click" Text="Salvar" Width="120px" />
&nbsp;&nbsp;<asp:Button ID="btnSalvarEdit" runat="server" CssClass="buttonCSS" Enabled="False" OnClick="btnSalvarEdit_Click" Text="Salvar" Visible="False" Width="120px" />
&nbsp;
        <asp:Button ID="btnLimpa" runat="server" CssClass="buttonCSS" OnClick="btnLimpaSelec_Click" Text="Cancelar" Width="120px" Enabled="False" />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
