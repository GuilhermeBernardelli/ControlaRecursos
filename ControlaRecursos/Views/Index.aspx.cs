using ControlaRecursos.Control;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlaRecursos.Views
{
    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            btnLogin.Focus();                  
            Button btn = (Button)Master.FindControl("btnLogout");
            btn.Visible = false;
                                    
            string cacString = ConfigurationManager.AppSettings.Get("cacUrlLogin");

            btnLogin.PostBackUrl = cacString;
                                             
            lblSubTitulo.Text = "Interface de Acesso";
            lblMensagem.Text = "Bem vindo a interface de login do Sistema de Cadastro de Recursos, clique em login para acessar o sistema.";

            Session["Pesquisar"] = null;
            Session["Check"] = null;

        }
    }
}