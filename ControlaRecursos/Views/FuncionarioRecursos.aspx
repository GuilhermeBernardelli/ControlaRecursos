<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="FuncionarioRecursos.aspx.cs" Inherits="ControlaRecursos.Views.FuncionarioRecursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style22 {
            margin-top: 9px;
        }
        .auto-style11 {
        margin-top: 8px;
        }
        .auto-style18 {
            margin-top: 12px;
        }
        .auto-style19 {
            margin-left: 21px;
        }
        .auto-style20 {
            margin-left: 27px;
        }
        .auto-style21 {
            margin-left: 37px;
        }
        
        .auto-style6 {
            margin-top: 0px;
        }
        .auto-style8 {
            margin-left: 20px;
        }
        .auto-style24 {
            margin-left: 43px;
        }
        .auto-style25 {
            margin-left: 15px;
        }
        .auto-style26 {
            margin-left: 35px;
        }
        .auto-style27 {
            margin-left: 44px;
        }
        .auto-style28 {
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
            margin-left: 390px;
        }
        .auto-style23 {
            margin-left: 14px;
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
        <asp:Button ID="btnPessoa" runat="server" CssClass="buttonCSS" Text="Pessoas" Width="120px" OnClick="btnPessoa_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRecurso" runat="server" CssClass="buttonCSS" OnClick="btnRecurso_Click" Text="Recursos" Width="120px" />
        <br />
    </asp:Panel>
    
    <asp:Panel ID="PanelFuncionario" runat="server" CssClass="auto-style18" GroupingText="Dados Funcionário" Height="100%">
        <br />
        <asp:Label ID="lblRecursoId" runat="server" Text="Id Func. :" Visible="False"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" CssClass="auto-style19" Enabled="False" Width="50px" Visible="False"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Label ID="lblNome" runat="server" Text="Nome :"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server" CssClass="auto-style20" Width="462px" Enabled="False"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCodigo" runat="server" Text="CPF :"></asp:Label>
        <asp:TextBox ID="txtCpf" runat="server" CssClass="auto-style21" Enabled="False" Width="204px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="lblOrigem" runat="server" Text="Origem:"></asp:Label>
        <asp:TextBox ID="txtOrigem" runat="server" CssClass="auto-style24" Enabled="False" Width="383px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="lblInicio" runat="server" Text="Data Inicio:"></asp:Label>
        <asp:TextBox ID="txtInicio" runat="server" CssClass="auto-style23" Enabled="False" Width="169px"></asp:TextBox>
        <asp:Label ID="lblTermino0" runat="server" Text="Data Término:"></asp:Label>
        <asp:TextBox ID="txtTerminoFuncionario" runat="server" CssClass="auto-style23" Enabled="False" Width="169px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnNovo" runat="server" CssClass="buttonCSS" Text="Adc. Recurso" Width="120px" OnClick="btnNovo_Click"/>
        &nbsp;
        <asp:Button ID="btnEditar" runat="server" CssClass="buttonCSS" Text="Edit. Recurso" Width="120px" Enabled="False" OnClick="btnEditar_Click" />
        <asp:Button ID="btnVoltar" runat="server" CssClass="auto-style28" OnClick="btnVoltar_Click" Text="Voltar" Width="120px" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelPesquisar" runat="server" CssClass="auto-style6" Height="130px" GroupingText="Pesquisar Recursos " HorizontalAlign="left" Visible="False">
        <br />
        <asp:Label ID="lblPesquisar" runat="server" Text="Pesquisar:"></asp:Label>
        <asp:TextBox ID="txtPesquisa" runat="server" CssClass="auto-style8" Width="584px"></asp:TextBox>
        &nbsp;*&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMsgErro" runat="server" CssClass="labelMensagem" ForeColor="Red" Text="*Preenchimento do campo pesquisar obrigatório" Visible="False" Width="52%"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnPesquisar" runat="server" CssClass="buttonCSS" OnClick="btnPesquisar_Click" Text="Pesquisar" Width="120px" UseSubmitBehavior="true" />
            &nbsp;&nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" CssClass="buttonCSS" OnClick="btnCancela_Click" Text="Cancelar" Width="120px" />
        &nbsp;
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelRecurso" runat="server" CssClass="auto-style18" GroupingText="Detalhes Recurso" Height="100%">
        <br />
        <asp:Label ID="lblRecursoId0" runat="server" Text="Id Recurso :"></asp:Label>
        <asp:TextBox ID="txtIdRecurso" runat="server" CssClass="auto-style25" Enabled="False" Width="50px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Label ID="lblRecurso" runat="server" Text="Recurso :"></asp:Label>
        <asp:TextBox ID="txtRecurso" runat="server" CssClass="auto-style24" Width="449px" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCodigo0" runat="server" Text="Codigo :"></asp:Label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="auto-style26" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblTermino" runat="server" Text="Termino :"></asp:Label>
&nbsp;<asp:TextBox ID="txtTermino" runat="server" CssClass="auto-style8" Enabled="False" Width="96px" TextAlign="rigth" TextMode="Date"></asp:TextBox>
        <br /><br /><asp:Label ID="lblValor" runat="server" Text="Valor :"></asp:Label>
        <asp:TextBox ID="txtValor" runat="server" CssClass="auto-style27" Enabled="False" Width="617px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnSalvarNovo" runat="server" CssClass="buttonCSS" Enabled="False" OnClick="btnSalvarRecurso_Click" Text="Adicionar" Width="120px" />
        &nbsp;
        <asp:Button ID="btnLimpa" runat="server" CssClass="buttonCSS" OnClick="btnCancela_Click" Text="Cancelar" Width="120px" />
        &nbsp;
        <asp:Button ID="btnSalvar" runat="server" CssClass="buttonCSS" OnClick="btnSalvar_Click" Text="Salvar" Width="120px" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelSelecione" runat="server" Height="100%" GroupingText="Lista de Recursos" CssClass="auto-style22">
        <asp:RadioButtonList ID="rblSeleciona" runat="server" AutoPostBack="true" CssClass="auto-style11" TabIndex="2" OnSelectedIndexChanged="rblSeleciona_SelectedIndexChanged" ViewStateMode="Enabled" Visible="False">
        </asp:RadioButtonList>
                <asp:RadioButtonList ID="rblSelecionaRecurso" runat="server" AutoPostBack="true" CssClass="auto-style11" OnSelectedIndexChanged="rblSelecionaRecurso_SelectedIndexChanged" TabIndex="2" ViewStateMode="Enabled" Visible="False">
        </asp:RadioButtonList>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
    </asp:Panel>
    </asp:Content>
