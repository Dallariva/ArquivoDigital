using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class UnidadeModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<Unidade> todasUnidade()
        {
            var lista = from u in db.Unidade
                        select u;
            return lista.ToList();
        }

        public string adicionarUnidade(Unidade u)
        {
            string erro = null;
            try
            {
                db.Unidade.Add(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Unidade obterUnidade(int idUnidade)
        {
            var lista = from u in db.Unidade
                        where u.IdUnidade == idUnidade
                        select u;
            return lista.ToList().FirstOrDefault();
        }

        public string editarUnidade(Unidade u)
        {
            string erro = null;
            try
            {
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirUnidade(Unidade u)
        {
            string erro = null;
            try
            {
                db.Unidade.Remove(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarUnidade(Unidade u)
        {
            if (u.NomeUnidade == null || u.NomeUnidade == "")
            {
                return "Favor preencher o nome da unidade!";
            }
            return null;
        }

        internal Unidade obterUnidade(Unidade u)
        {
            throw new NotImplementedException();
        }
    }
}