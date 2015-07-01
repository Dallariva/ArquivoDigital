using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class TipoDocumentoModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<TipoDocumento> todosTipoDocumento()
        {
            var lista = from td in db.TipoDocumento
                        select td;
            return lista.ToList();
        }

        public string adicionarTipoDocumento(TipoDocumento td)
        {
            string erro = null;
            try
            {
                db.TipoDocumento.Add(td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public TipoDocumento obterTipoDocumento(int idTipoDocumento)
        {
            var lista = from td in db.TipoDocumento
                        where td.IdTipoDocumento == idTipoDocumento
                        select td;
            return lista.ToList().FirstOrDefault();
        }

        public string editarTipoDocumento(TipoDocumento td)
        {
            string erro = null;
            try
            {
                db.Entry(td).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirTipoDocumento(TipoDocumento td)
        {
            string erro = null;
            try
            {
                db.TipoDocumento.Remove(td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarTipoDocumento(TipoDocumento td)
        {
            if (td.Descricao == null || td.Descricao == "")
            {
                return "Favor preencher a descrição!";
            }
            return null;
        }

        internal TipoDocumento obterTipoDocumento(TipoDocumento td)
        {
            throw new NotImplementedException();
        }
    }
}