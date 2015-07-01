using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class TipoAutorizacaoModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<TipoAutorizacao> todosTipoAutorizacao()
        {
            var lista = from ta in db.TipoAutorizacao
                        select ta;
            return lista.ToList();
        }

        public string adicionarTipoAutorizacao(TipoAutorizacao ta)
        {
            string erro = null;
            try
            {
                db.TipoAutorizacao.Add(ta);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public TipoAutorizacao obterTipoAutorizacao(int idTipoAutorizacao)
        {
            var lista = from ta in db.TipoAutorizacao
                        where ta.IdTipoAutorizacao == idTipoAutorizacao
                        select ta;
            return lista.ToList().FirstOrDefault();
        }

        public string editarTipoAutorizacao(TipoAutorizacao ta)
        {
            string erro = null;
            try
            {
                db.Entry(ta).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirTipoAutorizacao(TipoAutorizacao ta)
        {
            string erro = null;
            try
            {
                db.TipoAutorizacao.Remove(ta);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarTipoAutorizacao(TipoAutorizacao ta)
        {
            if (ta.Descricao == null || ta.Descricao == "")
            {
                return "Favor preencher a descrição!";
            }
            return null;
        }

        internal TipoAutorizacao obterTipoAutorizacao(TipoAutorizacao ta)
        {
            throw new NotImplementedException();
        }
    }
}