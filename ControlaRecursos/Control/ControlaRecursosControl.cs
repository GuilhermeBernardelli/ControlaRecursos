
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlaRecursos.Model.Repository;
using ControlaRecursos.Model;
using System.Data.Entity;

namespace ControlaRecursos.Control
{
    public partial class ControleRecursosControl : DbContext
    {
        GtiRepository gtiRep = new GtiRepository();

        //
        //Controle Geral 
        //

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }          

        public void atualizarDados()
        {
            gtiRep.salvarAlteracoes();
        }

        //
        //Controle Recursos 
        //

        public void salvarDadosRecurso(Recurso recurso)
        {
            gtiRep.salvarNovoRecurso(recurso);
        }

        public void excluirDadosRecurso(Recurso recurso)
        {
            gtiRep.excluirDadosRecurso(recurso);
        }

        public List<Recurso> pesquisaGeralRecurso(string valor, bool check)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaGeralRecurso(pesquisa, check);

        }

        public Recurso pesquisaRecursoByCodigo(string valor)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaRecursoByCodigo(pesquisa);

        }

        public Recurso pesquisaRecursoByCodigoAtivos(string valor)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaRecursoByCodigoAtivos(pesquisa);

        }

        public Recurso pesquisaRecursoById(int valor)
        {
            int pesquisa = valor;

            return gtiRep.pesquisaRecursoById(pesquisa);
        }

        //
        //Controle Pessoas 
        //

        public void salvarDadosPessoa(Pessoa pessoa)
        {
            gtiRep.salvarNovaPessoa(pessoa);
        }

        public void excluirDadosPessoa(Pessoa pessoa)
        {
            gtiRep.excluirDadosPessoa(pessoa);
        }

        public List<Pessoa> pesquisaGeral(string valor)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaGeralPessoa(pesquisa);

        }
        public List<Pessoa> pesquisaGeralPessoaRecurso(string valor)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaGeralPessoaRecurso(pesquisa);

        }

        public Pessoa pesquisaPessoaByCPF(string valor)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaPessoaByCPF(pesquisa);
        }

        public Pessoa pesquisaPessoaById(int valor)
        {
            int pesquisa = valor;

            return gtiRep.pesquisaPessoaById(pesquisa);
        }

        public Pessoa pesquisaPessoaByNome(string valor)
        {
            string pesquisa = valor;

            return gtiRep.pesquisaPessoaByNome(pesquisa);
        }

        //
        //Controle Pessoas_Recursos
        //

        public void salvarDadosPessoa_Recurso(Pessoa_Recurso pessoa_recurso)
        {
            gtiRep.salvarNovaPessoa_Recurso(pessoa_recurso);
        }

        public void excluirDadosPessoa_Recurso(Pessoa_Recurso pessoa_recurso)
        {
            gtiRep.excluirDadosPessoa_Recurso(pessoa_recurso);
        }

        public List<Pessoa_Recurso> pesquisaRecursoByPessoaId(int valor)
        {
            int pesquisa = valor;

            return gtiRep.pesquisaRecursoByPessoaId(pesquisa);
        }

        public Pessoa_Recurso pesquisaPessoa_RecursoById(int valor)
        {
            int pesquisa = valor;

            return gtiRep.pesquisaPessoa_RecursoById(pesquisa);
        }

    }
}
