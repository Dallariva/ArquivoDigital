using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class TipoPessoaModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<TipoPessoa> todosTipoPessoa()
        {
            var lista = from tp in db.TipoPessoa
                        select tp;
            return lista.ToList();
        }

        public string adicionarTipoPessoa(TipoPessoa tp)
        {
            string erro = null;
            try
            {
                db.TipoPessoa.Add(tp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public TipoPessoa obterTipoPessoa(int idTipoPessoa)
        {
            var lista = from tp in db.TipoPessoa
                        where tp.IdTipoPessoa == idTipoPessoa
                        select tp;
            return lista.ToList().FirstOrDefault();
        }

        public string editarTipoPessoa(TipoPessoa tp)
        {
            string erro = null;
            try
            {
                db.Entry(tp).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirTipoPessoa(TipoPessoa tp)
        {
            string erro = null;
            try
            {
                db.TipoPessoa.Remove(tp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarTipoPessoa(TipoPessoa tp)
        {
            if (tp.Descricao == null || tp.Descricao == "")
            {
                return "Favor preencher a descrição!";
            }
            return null;
        }

        internal TipoPessoa obterTipoPessoa(TipoPessoa tp)
        {
            throw new NotImplementedException();
        }
    }
}