using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class EnderecoModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<Endereco> todosEndereco()
        {
            var lista = from e in db.Endereco
                        select e;
            return lista.ToList();
        }

        public string adicionarEndereco(Endereco e)
        {
            string erro = null;
            try
            {
                db.Endereco.Add(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Endereco obterEndereco(int idEndereco)
        {
            var lista = from e in db.Endereco
                        where e.IdEndereco == idEndereco
                        select e;
            return lista.ToList().FirstOrDefault();
        }

        public string editarEndereco(Endereco e)
        {
            string erro = null;
            try
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirEndereco(Endereco e)
        {
            string erro = null;
            try
            {
                db.Endereco.Remove(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarEndereco(Endereco e)
        {
            if (e.Logradouro == null || e.Logradouro == "")
            {
                return "Favor preencher o Logradouro!";
            }
            if (e.Numero == null || e.Numero == "")
            {
                return "Favor preencher o número!";
            }
            if (e.Bairro == null || e.Bairro == "")
            {
                return "Favor preencher bairro!";
            }
            if (e.CEP == null || e.CEP == "")
            {
                return "Favor preencher CEP!";
            }
            return null;
        }

        internal Endereco obterEndereco(Endereco e)
        {
            throw new NotImplementedException();
        }
    }
}