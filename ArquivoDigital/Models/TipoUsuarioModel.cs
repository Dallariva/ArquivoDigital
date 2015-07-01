using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class TipoUsuarioModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<TipoUsuario> todosTipoUsuario()
        {
            var lista = from tu in db.TipoUsuario
                        select tu;
            return lista.ToList();
        }

        public string adicionarTipoUsuario(TipoUsuario tu)
        {
            string erro = null;
            try
            {
                db.TipoUsuario.Add(tu);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public TipoUsuario obterTipoUsuario(int idTipoUsuario)
        {
            var lista = from tu in db.TipoUsuario
                        where tu.IdTipoUsuario == idTipoUsuario
                        select tu;
            return lista.ToList().FirstOrDefault();
        }

        public string editarTipoUsuario(TipoUsuario tu)
        {
            string erro = null;
            try
            {
                db.Entry(tu).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirTipoUsuario(TipoUsuario tu)
        {
            string erro = null;
            try
            {
                db.TipoUsuario.Remove(tu);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarTipoUsuario(TipoUsuario tu)
        {
            if (tu.Descricao == null || tu.Descricao == "")
            {
                return "Favor preencher a descrição!";
            }
            return null;
        }

        internal TipoUsuario obterTipoUsuario(TipoUsuario tu)
        {
            throw new NotImplementedException();
        }
    }
}