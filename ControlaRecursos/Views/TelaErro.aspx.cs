using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlaRecursos.Views
{
    public partial class TelaErro : System.Web.UI.Page
    {
        private static string exceptionMessage;

        public static string ExceptionMessage
        {
            get { return exceptionMessage; }
            set { exceptionMessage = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Button btn = (Button)Master.FindControl("btnLogout");
            btn.Visible = false;

            if (!IsPostBack)
            {
                pageLoad();
            }
        }

        public void pageLoad()
        {
            lblMsgErro.Text = exceptionMessage;
            ExceptionMessage = string.Empty;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}