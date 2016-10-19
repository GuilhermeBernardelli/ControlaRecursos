using ControlaRecursos.Control;
using ControlaRecursos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlaRecursos.Views
{
    
    public partial class Pessoas : System.Web.UI.Page
    {
        ControleRecursosControl Controle = new ControleRecursosControl();
        ValidadorCpf valido = new ValidadorCpf();
        Pessoa pessoa;
        int perfil = 0;

        protected void Page_Load(object sender, EventArgs e)
        {            
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            
            if (!IsPostBack)
            {                
                perfil = Convert.ToInt32(Session["perfil"]);
                if (perfil != 1)
                {
                    Response.Redirect("Logout.aspx");
                }
                
                if (Session["Pesquisar"]!=null)
                {
                    if (Session["Check"]!= null)
                    {
                        chkVlRecurso.Checked = true;
                    }
                    txtPesquisa.Text = Session["Pesquisar"].ToString();
                    btnPesquisar_Click(sender, e);
                }
            }      

            btnPesquisar.Focus();
            lblSubTitulo.Text = "Pesquisar Pessoas";
            lblMensagem.Text = "Realizar pesquisa";
        }

        protected void btnRecurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recursos.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            lblOrigem.Visible = false;
            btnRecursos.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;       
            btnSalvarEdit.Enabled = false;
            btnLimpa.Enabled = false;
            txtCpf.Enabled = false;
            txtNome.Enabled = false;
            txtOrigem.Enabled = false;
            txtInicio.Enabled = false;
            txtTermino.Enabled = false;


            if (txtPesquisa.Text == "")
            {
                lblMsgErro.Visible = true;
            }
            else
            {
                lblMsgErro.Visible = false;
                lblOrigem.Visible = false;
                PanelSelecione.Visible = true;

                List<Pessoa> pesquisa = null;
                string valorPesquisa = string.Empty;
                string opcao = string.Empty;

                valorPesquisa = txtPesquisa.Text;
                rblSeleciona.Visible = true;
                lblErro.Visible = false;
                if (!chkVlRecurso.Checked)
                {
                    pesquisa = Controle.pesquisaGeral(valorPesquisa);

                    Session["Check"] = null;

                    if (pesquisa != null && pesquisa.Count() != 0)
                    {
                        if (pesquisa.Count() > 50)
                        {
                            rblSeleciona.Visible = false;
                            lblErro.Text = "Muitos resultados, por favor refine sua pesquisa";
                            lblErro.Visible = true;
                        }
                        else
                        {
                            Session["Pesquisar"] = txtPesquisa.Text;
                            carregaRadioList(pesquisa);
                        }
                    }
                    else
                    {
                        rblSeleciona.Visible = false;
                        lblErro.Text = "Pesquisa não encontrou resultados";
                        lblErro.Visible = true;
                    }
                }
                else
                {
                    pesquisa = Controle.pesquisaGeralPessoaRecurso(valorPesquisa);

                    Session["Check"] = "1";

                    if (pesquisa != null && pesquisa.Count() != 0)
                    {
                        if (pesquisa.Count() > 50)
                        {
                            rblSeleciona.Visible = false;
                            lblErro.Text = "Muitos resultados, por favor refine sua pesquisa";
                            lblErro.Visible = true;
                        }
                        else
                        {
                            Session["Pesquisar"] = txtPesquisa.Text;
                            carregaRadioList(pesquisa);
                        }
                    }
                    else
                    {
                        rblSeleciona.Visible = false;
                        lblErro.Text = "Pesquisa não encontrou resultados";
                        lblErro.Visible = true;
                    }
                }

            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {           
            pessoa = new Pessoa();
            pessoa = Controle.pesquisaPessoaByNome(txtNome.Text);

            txtCpf.Text = pessoa.cpf_numero;

            btnSalvarEdit.Visible = true;
            btnSalvarEdit.Enabled = true;
            btnLimpa.Enabled = true;
            btnSalvarNovo.Visible = false;            
            txtCpf.Enabled = true;
            txtNome.Enabled = true;
            txtOrigem.Enabled = true;
            txtInicio.Enabled = true;
            txtTermino.Enabled = true;
            PanelPesquisar.Visible = false;

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            string codigo = (rblSeleciona.SelectedValue);
            pessoa = Controle.pesquisaPessoaByCPF(codigo);

            try
            {
                Controle.excluirDadosPessoa(pessoa);
                Controle.atualizarDados();
                limpaFunction();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Exclusão realizada com sucesso');", true);

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

        protected void btnIncluirDados_Click(object sender, EventArgs e)
        {
            btnRecursos.Enabled = false;
            PanelPesquisar.Visible = false;
            lblOrigem.Visible = true;
            PanelSelecione.Visible = false;
           
            btnSalvarNovo.Visible = true;
            btnSalvarNovo.Enabled = true;
            btnSalvarEdit.Visible = false;
            
            btnLimpa.Enabled = true;
            txtCpf.Enabled = true;
            txtNome.Enabled = true;
            txtOrigem.Enabled = true;
            txtInicio.Enabled = true;
            txtTermino.Enabled = true;
            txtNome.Text = txtPesquisa.Text;
            txtPesquisa.Text = "";
        }

        protected void btnLimpaSelec_Click(object sender, EventArgs e)
        {
            limpaFunction();
        }

        protected void btnSalvarRecurso_Click(object sender, EventArgs e)
        {            
            try
            {
                pessoa = new Pessoa();
                Controle.salvarDadosPessoa(pessoa);
                pessoa.nome_completo = txtNome.Text;
                pessoa.cpf_numero = txtCpf.Text;
                pessoa.data_inicio = Convert.ToDateTime(txtInicio.Text);
                pessoa.data_termino = Convert.ToDateTime(txtTermino.Text);
                pessoa.origem_dados = txtOrigem.Text;

                if (valido.validadorCPF(pessoa.cpf_numero))
                {                     
                    Controle.atualizarDados();                    
                    btnRecursos.Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Inclusão realizada com sucesso.');", true);
                    Controle.pesquisaPessoaByCPF(txtCpf.Text);
                    Session["Pessoa"] = pessoa.pessoa_id;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Dados de CPF invalidos, digite somente números.');", true);
                }                
            }
            catch (DbUpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao atualizar dados, verifique se os dados estão corretos.')", true);
                limpaFunction();
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }
            
        }

        protected void btnSalvarEdit_Click(object sender, EventArgs e)
        {
            string codigo = (rblSeleciona.SelectedValue);
            pessoa = Controle.pesquisaPessoaByCPF(codigo);

            try
            {
                pessoa.nome_completo = txtNome.Text;
                pessoa.cpf_numero = txtCpf.Text;
                pessoa.pessoa_id = pessoa.pessoa_id;
                pessoa.data_inicio = Convert.ToDateTime(txtInicio.Text);
                pessoa.data_termino = Convert.ToDateTime(txtTermino.Text);
                pessoa.origem_dados = txtOrigem.Text;

                if (valido.validadorCPF(pessoa.cpf_numero))
                {
                    Controle.atualizarDados();
                    
                    btnRecursos.Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Inclusão realizada com sucesso.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaAtualizadoOK", "alert('Dados de CPF invalidos, digite somente números.');", true);
                }
            }
            catch (DbUpdateException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertaSelecionar", "alert('Erro ao atualizar dados, verifique se os dados estão corretos.')", true);
                limpaFunction();
            }
            catch (Exception ex)
            {
                TelaErro.ExceptionMessage = ex.Message;
                Response.Redirect("TelaErro.aspx", false);
            }
        }

        private void carregaRadioList(List<Pessoa> pessoa)
        {
            rblSeleciona.DataSource = pessoa;
            rblSeleciona.DataTextField = "nome_completo";
            rblSeleciona.DataValueField = "cpf_numero";
            rblSeleciona.DataBind();

            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;

            for (int i = 0; i < rblSeleciona.Items.Count; i++)
            {
                string cpf = pessoa[i].cpf_numero;
                cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");

                rblSeleciona.Items[i].Text = cpf + " - " + rblSeleciona.Items[i].Text;
            }
        }

        protected void rblSeleciona_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelSelecione.Visible = false;
            PanelFuncionario.Visible = true;
            lblOrigem.Visible = true;
            //btnSalvarNovo.Enabled = true;
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;

            string cpf = (rblSeleciona.SelectedValue);
            
            pessoa = new Pessoa();
            pessoa = Controle.pesquisaPessoaByCPF(cpf);

            string Formatedcpf = pessoa.cpf_numero;
            Formatedcpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");

            Session["Pessoa"] = pessoa.pessoa_id;
            txtCpf.Text = Formatedcpf;
            txtId.Text = Convert.ToString(pessoa.pessoa_id);
            txtNome.Text = pessoa.nome_completo;
            txtInicio.Text = Convert.ToString(pessoa.data_inicio);
            txtTermino.Text = Convert.ToString(pessoa.data_termino);
            txtOrigem.Text = pessoa.origem_dados;


        }
        public void limpaFunction()
        {
            PanelPesquisar.Visible = true;
            PanelSelecione.Visible = false;
            PanelFuncionario.Visible = false;
            lblOrigem.Visible = false;
            btnIncluirDados.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnIncluirDados.Enabled = true;
            lblMsgErro.Visible = false;
            txtPesquisa.Focus();
            txtCpf.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            txtPesquisa.Text = "";
            txtOrigem.Text = "";
            txtInicio.Text = "";
            txtTermino.Text = "";
            chkVlRecurso.Checked = false;
        }

        protected void btnRecursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("FuncionarioRecursos.aspx");   
        }
    }
}