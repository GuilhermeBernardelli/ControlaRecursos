using ControlaRecursos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Configuration;

namespace ControlaRecursos.Model.Repository
{
    public class GtiRepository
    {
        GTIEntities gtiModel = new GTIEntities();

        //
        //Pesquisa de Pessoa
        //                           
        public Pessoa pesquisaPessoaByCPF(string cpf)
        {
            return (from pessoa in gtiModel.Pessoa
                    where (pessoa.cpf_numero == cpf)
                    select pessoa).SingleOrDefault();
        }

        public Pessoa pesquisaPessoaById(int id)
        {
            return (from pessoa in gtiModel.Pessoa
                    where (pessoa.pessoa_id == id)
                    select pessoa).SingleOrDefault();
        }

        public Pessoa pesquisaPessoaByNome(string nome)
        {
            return (from pessoa in gtiModel.Pessoa
                    where (pessoa.nome_completo == nome)
                    select pessoa).SingleOrDefault();
        }

        public List<Pessoa> pesquisaGeralPessoa(string valor)
        {
            List<Pessoa> pes;

            pes = (from pessoa in gtiModel.Pessoa
                   where (pessoa.nome_completo.Contains(valor)                   
                   || pessoa.cpf_numero == valor)
                   orderby pessoa.nome_completo
                   select pessoa).ToList();

            return pes;
        }
        public List<Pessoa> pesquisaGeralPessoaRecurso(string valor)
        {
            List<Pessoa> pes;

            pes = (from pessoa_recurso in gtiModel.Pessoa_Recurso
                   where (pessoa_recurso.valor.Contains(valor))
                   orderby pessoa_recurso.pessoa_id
                   select pessoa_recurso.Pessoa).ToList();

            return pes;
        }

        //
        //Pesquisa de recursos
        //

        public Recurso getRecurso(string codigo)
        {
            return (from recurso in gtiModel.Recurso
                    where recurso.codigo == codigo
                    && recurso.indicativo_ativo == true
                    select recurso).SingleOrDefault();
        }


        public List<Recurso> pesquisaRecursoByNome(string nome)
        {
            return (from recurso in gtiModel.Recurso
                    where (recurso.nome.Contains(nome))
                    && recurso.indicativo_ativo == true
                    select recurso).ToList();
        }

        public Recurso pesquisaRecursoByCodigoAtivos(string codigo)
        {
            return (from recurso in gtiModel.Recurso
                    where (recurso.codigo == codigo
                    && recurso.indicativo_ativo == true)
                    select recurso).SingleOrDefault();
        }

        public Recurso pesquisaRecursoByCodigo(string codigo)
        {
            return (from recurso in gtiModel.Recurso
                    where (recurso.codigo == codigo)
                    select recurso).SingleOrDefault();
        }

        public Recurso pesquisaRecursoById(int id)
        {
            return (from recurso in gtiModel.Recurso
                    where (recurso.recurso_id == id)
                    select recurso).SingleOrDefault();
        }

        public List<Recurso> pesquisaGeralRecurso(string valor, bool check)
        {
            List<Recurso> rec;
            if (check)
            {
                rec = (from recurso in gtiModel.Recurso
                       where (recurso.nome.Contains(valor)
                       || recurso.codigo == valor)
                       && recurso.indicativo_ativo == true
                       orderby recurso.nome
                       select recurso).ToList();
            }
            else
            {
                rec = (from recurso in gtiModel.Recurso
                       where (recurso.nome.Contains(valor)
                       || recurso.codigo == valor)
                       orderby recurso.nome
                       select recurso).ToList();
            }
                return rec;
        }
        //
        //Pesquisa de recursos associados a pessoas
        //
        public List<Pessoa_Recurso> pesquisaRecursoByPessoaId(int id)
        {
            List<Pessoa_Recurso> pes;

            pes = (from pessoa_recurso in gtiModel.Pessoa_Recurso
                   where (pessoa_recurso.pessoa_id == id)
                   orderby pessoa_recurso.pessoa_recurso_id
                   select pessoa_recurso).ToList();

            return pes;
        }

        public Pessoa_Recurso pesquisaPessoa_RecursoById(int pessoa_recurso_id)
        {
            return (from pessoa_recurso in gtiModel.Pessoa_Recurso
                    where (pessoa_recurso.pessoa_recurso_id == pessoa_recurso_id)
                    select pessoa_recurso).SingleOrDefault();
        }
        
        //
        //Realizando alterações no banco
        //

        public void salvarAlteracoes()
        {
            gtiModel.SaveChanges();
        }

        public void salvarNovoRecurso(Recurso recurso)
        {
            gtiModel.Recurso.Add(recurso);
        }

        public void excluirDadosRecurso(Recurso recurso)
        {
            gtiModel.Recurso.Remove(recurso);
        }

        public void salvarNovaPessoa(Pessoa pessoa)
        {
            gtiModel.Pessoa.Add(pessoa);
        }

        public void excluirDadosPessoa(Pessoa pessoa)
        {
            gtiModel.Pessoa.Remove(pessoa);
        }

        public void salvarNovaPessoa_Recurso(Pessoa_Recurso pessoa_recurso)
        {
            gtiModel.Pessoa_Recurso.Add(pessoa_recurso);
        }

        public void excluirDadosPessoa_Recurso(Pessoa_Recurso pessoa_recurso)
        {
            gtiModel.Pessoa_Recurso.Remove(pessoa_recurso);
        }
    }
}