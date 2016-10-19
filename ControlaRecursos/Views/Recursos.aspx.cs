using ControlaRecursos.Control;
using ControlaRecursos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlaRecursos.Views
{
    public partial class Recursos : System.Web.UI.Page
    {
        ControleRecursosControl Controle = new ControleRecursosControl();
        Recurso recurso;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            int perfil = Convert.ToInt32(Session["perfil"]);
            if (perfil != 1)
            {
                Response.Redirect("Logout.aspx");
            }
            btnPesquisar.Focus();
            lblSubTitulo.Text = "Pesquisar Recursos";
            lblMensagem.Text = "Realizar pesquisa";
            btnRecurso.Enabled = false;
            btnExcluir.Enabled = false;
        }

        protected void btnPessoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoas.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnSalvarEdit.Enabled = false;
            chkRecursoAtivo.Enabled = false;
            txtCodigo.Enabled = false;
            txtRecurso.Enabled = false;


            PanelRecurso.Visible = false;
            PanelSelecione.Visible = true;

            List<Recurso> pesquisa = null;
            string valorPesquisa = string.Empty;
            string opcao = string.Empty;

            valorPesquisa = txtPesquisa.Text;
            rblSeleciona.Visible = true;
            lblErro.Visible = false;

            bool ativo;
            if (chkAtivo.Checked)
            {
                ativo = true;
            }
            else
            {
                ativo = false;
            }
            
            pesquisa = Controle.pesquisaGeralRecurso(valorPesquisa, ativo);
            /* retirado teste de nulidade da pesquisa de recurso
            if (pesquisa != null && pesquisa.Count() != 0)
            {
            */
            if (pesquisa.Count() > 50)
                {
                    rblSeleciona.Visible = false;
                    lblErro.Text = "Muitos resultados, por favor refine sua pesquisa";
                    lblErro.Visible = true;
                }
            else
                {
                    carregaRadioList(pesquisa);
                }
            /*resposta em caso de pesquisa = null
            else
            {
                rblSeleciona.Visible = false;
                lblErro.Text = "Pesquisa não encontrou resultados";
                lblErro.Visible = true;
            }
            */

        }
        private void carregaRadioList(List<Recurso> recurso)
        {
            rblSeleciona.DataSource = recurso;
            rblSeleciona.DataTextField = "nome";
            rblSeleciona.DataValueField = "codigo";
            rblSeleciona.DataBind();

            for (int i = 0; i < rblSeleciona.Items.Count; i++)
            {
                rblSeleciona.Items[i].Text = recurso[i].codigo + " - " + rblSeleciona.Items[i].Text;
            }
        }
        protected void rblSeleciona_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelSelecione.Visible = false;
            PanelRecurso.Visible = true;
            btnSalvarNovo.Enabled = true;
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;

            string codigo = (rblSeleciona.SelectedValue);

            recurso = new Recurso();
            recurso = Controle.pesquisaRecursoByCodigo(codigo);

            txtCodigo.Text = recurso.codigo;
            txtId.Text = Convert.ToString(recurso.recurso_id);
            txtRecurso.Text = recurso.nome;
            if (recurso.indicativo_ativo == true)
            {
                chkRecursoAtivo.Checked = true;
            }
            else
            {
                chkRecursoAtivo.Checked = false;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            
            string codigo = (rblSeleciona.SelectedValue);
            recurso = Controle.pesquisaRecursoByCodigo(codigo);
            
            try
            {
                Controle.excluirDadosRecurso(recurso);
                Controle.atualizarDados();
                limpaFunction();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Alteração realizada com sucesso');", true);

            }
            catch (DbUpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao excluir, existem recursos alocados para esta pessoa')", true);
                limpaFunction();
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }
            
        }        

        protected void btnSalvarRecurso_Click(object sender, EventArgs e)
        {
            string codigo = (rblSeleciona.SelectedValue);
            recurso = Controle.pesquisaRecursoByCodigo(codigo);

            try
            {
                recurso.nome = txtRecurso.Text;
                recurso.codigo = txtCodigo.Text;
                recurso.indicativo_ativo = chkRecursoAtivo.Checked;
                recurso.recurso_id = recurso.recurso_id;
                Controle.atualizarDados();
                limpaFunction();

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Alteração realizada com sucesso');", true);            
           
            }        
            catch (DbUpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao atualizar dados, verifique se os dados estão corretos')", true);
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }

        }

        protected void btnLimpaSelec_Click(object sender, EventArgs e)
        {
            limpaFunction();
        }

        protected void btnIncluirDados_Click(object sender, EventArgs e)
        {
            PanelRecurso.Visible = true;
            PanelSelecione.Visible = false;
            btnSalvarEdit.Visible = true;
            btnSalvarEdit.Enabled = true;
            btnSalvarNovo.Visible = false;
            txtCodigo.Enabled = true;
            txtRecurso.Enabled = true;
            chkRecursoAtivo.Enabled = true;           
            txtRecurso.Text = txtPesquisa.Text;
            txtPesquisa.Text = "";            
        }
        public void limpaFunction()
        {           
            PanelPesquisar.Visible = true;
            PanelSelecione.Visible = false;
            PanelRecurso.Visible = false;
            btnIncluirDados.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnIncluirDados.Enabled = true;
            chkAtivo.Checked = true;
            txtPesquisa.Focus();
            txtCodigo.Text = "";
            txtId.Text = "";
            txtRecurso.Text = "";
            txtPesquisa.Text = "";
        }

        protected void btnSalvarEdit_Click(object sender, EventArgs e)
        {
            try
            {
                recurso = new Recurso();
                Controle.salvarDadosRecurso(recurso);
                recurso.nome = txtRecurso.Text;
                recurso.codigo = txtCodigo.Text;
                recurso.indicativo_ativo = chkRecursoAtivo.Checked;
                Controle.atualizarDados();
                limpaFunction();

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Inclusão realizada com sucesso');", true);
            }
            catch (DbUpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao atualizar dados, verifique se os dados estão corretos')", true);
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalvarEdit.Visible = false;
            btnSalvarNovo.Visible = true;
            btnSalvarNovo.Enabled = true;
            txtCodigo.Enabled = true;
            txtRecurso.Enabled = true;
            chkRecursoAtivo.Enabled = true;
        }
                
    }
}