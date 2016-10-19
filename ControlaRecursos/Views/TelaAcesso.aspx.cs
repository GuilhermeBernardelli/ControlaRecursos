using System;
using System.Web.SessionState;


namespace ControlaRecursos.Views
{
    public partial class TelaAcesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnPessoa.Focus();
            if (!IsPostBack)
            {

                string registro = Convert.ToString(Request.Form["hddRegFunc"]);
                string nome = Convert.ToString(Request.Form["hddNomeFunc"]);
                string perfil = Convert.ToString(Request.Form["hddEnumPerfil"]);

                Session["ID"] = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                Session["regUsuario"] = registro;
                Session["nome"] = nome;
                Session["perfil"] = perfil;
                                
                if (perfil != "1")
                {
                    Response.Redirect("Logout.aspx");
                }                
            }
        }

        protected void btnRecurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recursos.aspx");
        }

        protected void btnPessoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoas.aspx");
        }
    }
}