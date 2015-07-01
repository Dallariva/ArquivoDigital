using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class PessoaModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<Pessoa> todasPessoa()
        {
            var lista = from p in db.Pessoa
                        select p;
            return lista.ToList();
        }

        public string adicionarPessoa(Pessoa p)
        {
            string erro = null;
            try
            {
                db.Pessoa.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Pessoa obterPessoa(int idPessoa)
        {
            var lista = from p in db.Pessoa
                        where p.IdPessoa == idPessoa
                        select p;
            return lista.ToList().FirstOrDefault();
        }

        public string editarPessoa(Pessoa p)
        {
            string erro = null;
            try
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirPessoa(Pessoa p)
        {
            string erro = null;
            try
            {
                db.Pessoa.Remove(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarPessoa(Pessoa p)
        {
            if (p.Nome == null || p.Nome == "")
            {
                return "Favor preencher o nome!";
            }
            if (p.Email == null || p.Email == "")
            {
                return "Favor preencher o e-mail!";
            }
            if (p.CPFCNPJ == null || p.CPFCNPJ == "")
            {
                return "Favor preencher CPF / CNPJ!";
            }
            return null;
        }

        internal Pessoa obterPessoa(Pessoa p)
        {
            throw new NotImplementedException();
        }
    }
}