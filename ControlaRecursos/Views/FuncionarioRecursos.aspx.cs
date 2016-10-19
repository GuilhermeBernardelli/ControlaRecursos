using ControlaRecursos.Control;
using ControlaRecursos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlaRecursos.Views
{
    public partial class FuncionarioRecursos : System.Web.UI.Page
    {
        ControleRecursosControl controle = new ControleRecursosControl();
        Pessoa_Recurso pessoa_recurso;
        Pessoa pessoa = new Pessoa();
        Recurso recurso;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsgErro.Visible = false;                     
            lblSubTitulo.Text = "Recursos da Pessoa";
            lblMensagem.Text = "";
            btnNovo.Focus();
            int perfil = Convert.ToInt32(Session["perfil"]);
            if (perfil != 1)
            {
                Response.Redirect("Logout.aspx");
            }

            if (!IsPostBack)
            {
                carregaSeleção();
            }
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            PanelRecurso.Visible = false;
            PanelPesquisar.Visible = false;
            PanelSelecione.Visible = false;
            carregaSeleção();
        }

        protected void btnPessoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoas.aspx");
        }

        protected void btnRecurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recursos.aspx");
        }

        protected void rblSeleciona_SelectedIndexChanged(object sender, EventArgs e)
        {            
            PanelSelecione.Visible = false;
            PanelRecurso.Visible = true;
            btnSalvarNovo.Enabled = false;
            btnEditar.Enabled = true;

            int id = Convert.ToInt32(rblSeleciona.SelectedValue);
            pessoa_recurso = new Pessoa_Recurso();
            pessoa_recurso = controle.pesquisaPessoa_RecursoById(id);
            int recurso_id = pessoa_recurso.recurso_id;

            recurso = new Recurso();
            recurso = controle.pesquisaRecursoById(recurso_id);

            txtCodigo.Text = recurso.codigo;
            txtIdRecurso.Text = Convert.ToString(recurso.recurso_id);
            txtRecurso.Text = recurso.nome;
            txtValor.Text = pessoa_recurso.valor;

            if (pessoa_recurso.data_termino != null)
            {
                DateTime termino = new DateTime();
                termino = Convert.ToDateTime(pessoa_recurso.data_termino);
                string stdTermino = "dd/MM/yyyy";
                txtTermino.Text = termino.ToString(stdTermino);

            }
            else
            {
                txtTermino.Text = "";
            }

        }

        private void carregaRadioList(List<Pessoa_Recurso> pessoa_recurso)
        {
            rblSeleciona.Visible = true;
            rblSelecionaRecurso.Visible = false;
            rblSeleciona.DataSource = pessoa_recurso;
            rblSeleciona.DataTextField = "pessoa_recurso_id";
            rblSeleciona.DataValueField = "pessoa_recurso_id";
            rblSeleciona.DataBind();

            for (int i = 0; i < rblSeleciona.Items.Count; i++)
            {                                                
                DateTime inicio = new DateTime();
                inicio = Convert.ToDateTime(pessoa_recurso[i].data_inicio);
                string stdInicio = "dd/MM/yyyy";

                string saidaTermino;                               
                           
                if (pessoa_recurso[i].data_termino != null)
                {
                    DateTime termino = new DateTime();
                    termino = Convert.ToDateTime(pessoa_recurso[i].data_termino);
                    string stdTermino = "dd/MM/yyyy";
                    saidaTermino = termino.ToString(stdTermino);

                }
                else
                {
                    saidaTermino = "Não definido";
                }

                if (pessoa_recurso[i].data_termino < DateTime.Now)
                {
                    rblSeleciona.Items[i].Text = pessoa_recurso[i].Recurso.nome + "  - Inicio: " + inicio.ToString(stdInicio) + " - Término: " + saidaTermino + " - EXPIRADO";
                }
                else
                {
                    rblSeleciona.Items[i].Text = pessoa_recurso[i].Recurso.nome + "  - Inicio: " + inicio.ToString(stdInicio) + " - Término: " + saidaTermino;
                }
            }
        }

        protected void btnSalvarRecurso_Click(object sender, EventArgs e)
        {
            pessoa_recurso = new Pessoa_Recurso();

            try
            {
                pessoa_recurso.pessoa_id = Convert.ToInt32(txtId.Text);
                pessoa_recurso.recurso_id = Convert.ToInt32(txtIdRecurso.Text);
                pessoa_recurso.valor = txtValor.Text;
                pessoa_recurso.data_inicio = DateTime.Now;
               
                if (txtTermino.Text != "") { 
                    pessoa_recurso.data_termino = Convert.ToDateTime(txtTermino.Text);
                }
                else
                {
                    pessoa_recurso.data_termino = null;
                }
                controle.salvarDadosPessoa_Recurso(pessoa_recurso);
                controle.atualizarDados();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Inclusão realizada com sucesso');", true);
                carregaSeleção();
            }
            catch (FormatException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Formato de data diferente de DD/MM/AAAA');", true);
                txtTermino.Text = null;
            }       
            catch (UpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao incluir dados, verifique se os dados estão corretos')", true);
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalvarNovo.Visible = false;
            btnSalvar.Visible = true;
            txtTermino.Enabled = true;
            txtValor.Enabled = true;
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            PanelPesquisar.Visible = true;
            PanelSelecione.Visible = false;
            PanelRecurso.Visible = false;
            btnSalvarNovo.Enabled = false;
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }


        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnSalvarNovo.Visible = true;
            btnSalvar.Visible = false;

            if (txtPesquisa.Text == "")
            {
                lblMsgErro.Visible = true;            
            }

            else
            {
                lblMsgErro.Visible = false;
                lblErro.Visible = false;
                PanelSelecione.Visible = true;
                List<Recurso> pesquisa = null;
                string valorPesquisa;

                valorPesquisa = txtPesquisa.Text;
                pesquisa = controle.pesquisaGeralRecurso(valorPesquisa, true);
                                
                if (pesquisa != null && pesquisa.Count() != 0)
                {

                    if (pesquisa.Count() > 50)
                    {
                        rblSeleciona.Visible = false;
                        rblSelecionaRecurso.Visible = false;
                        lblErro.Text = "Muitos resultados, por favor refine sua pesquisa";
                        lblErro.Visible = true;
                    }
                    else
                    {
                        carregaRadioListRecurso(pesquisa);
                    }

                }
                else
                {
                    rblSeleciona.Visible = false;
                    rblSelecionaRecurso.Visible = false;
                    lblErro.Text = "Pesquisa não encontrou resultados";
                    lblErro.Visible = true;
                }
            }
        }

        private void carregaRadioListRecurso(List<Recurso> recurso)
        {
            PanelPesquisar.Visible = false;
            rblSeleciona.Visible = false;
            rblSelecionaRecurso.Visible = true;
            rblSelecionaRecurso.DataSource = recurso;
            rblSelecionaRecurso.DataTextField = "nome";
            rblSelecionaRecurso.DataValueField = "codigo";
            rblSelecionaRecurso.DataBind();

            for (int i = 0; i < rblSelecionaRecurso.Items.Count; i++)
            {
                rblSelecionaRecurso.Items[i].Text = recurso[i].codigo + " - " + rblSelecionaRecurso.Items[i].Text;
            }
        
        }

        protected void rblSelecionaRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelSelecione.Visible = false;
            PanelRecurso.Visible = true;
            btnSalvarNovo.Enabled = true;
            btnEditar.Enabled = true;
            txtTermino.Enabled = true;
            txtValor.Enabled = true;

            txtTermino.Text = null;
            txtValor.Text = null;

            string codigo = (rblSelecionaRecurso.SelectedValue);

            recurso = new Recurso();
            recurso = controle.pesquisaRecursoByCodigoAtivos(codigo);

            txtCodigo.Text = recurso.codigo;
            txtIdRecurso.Text = Convert.ToString(recurso.recurso_id);
            txtRecurso.Text = recurso.nome;
            

        }
        public void carregaSeleção()
        {           
            PanelRecurso.Visible = false;
            PanelSelecione.Visible = true;
            btnEditar.Enabled = false;
            btnSalvarNovo.Visible = true;
            btnSalvar.Visible = false;
            lblErro.Visible = false;
            lblMsgErro.Visible = false;
            txtTermino.Enabled = false;
            txtValor.Enabled = false;
            txtTermino.Text = null;
            txtValor.Text = null;
            
            int ID = Convert.ToInt32(Session["Pessoa"]);
            pessoa = controle.pesquisaPessoaById(ID);
            string cpf = pessoa.cpf_numero;
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");

            txtId.Text = Convert.ToString(pessoa.pessoa_id);
            txtCpf.Text = cpf;
            txtNome.Text = pessoa.nome_completo;
            txtOrigem.Text = pessoa.origem_dados;
            txtInicio.Text = Convert.ToString(pessoa.data_inicio);
            txtTerminoFuncionario.Text = Convert.ToString(pessoa.data_termino);

            List<Pessoa_Recurso> pesquisa = null;
            int valorPesquisa;
            string opcao = string.Empty;

            valorPesquisa = pessoa.pessoa_id;
            pesquisa = controle.pesquisaRecursoByPessoaId(valorPesquisa);

            if (pesquisa != null && pesquisa.Count() != 0)
            {
                carregaRadioList(pesquisa);
            }
            else
            {
                rblSeleciona.Visible = false;
                rblSelecionaRecurso.Visible = false;
                lblErro.Text = "Pesquisa não encontrou resultados";
                lblErro.Visible = true;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            pessoa_recurso = new Pessoa_Recurso();
            int id = Convert.ToInt32(rblSeleciona.SelectedValue);
            pessoa_recurso = controle.pesquisaPessoa_RecursoById(id);

            try
            {

                if (txtTermino.Text != "")
                {
                    pessoa_recurso.data_termino = Convert.ToDateTime(txtTermino.Text);
                }
                else
                {
                    pessoa_recurso.data_termino = null;
                }
                pessoa_recurso.valor = txtValor.Text;
                controle.atualizarDados();
                carregaSeleção();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Alteração realizada com sucesso');", true);
            }
          
            catch (FormatException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Formato de data diferente de DD/MM/AAAA');", true);
                txtTermino.Text = null;
            }
            
            catch (UpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao atualizar dados, verifique se os dados estão corretos')", true);
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoas.aspx");
        }
    }
}