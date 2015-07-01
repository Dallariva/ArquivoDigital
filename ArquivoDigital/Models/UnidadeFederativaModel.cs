using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class UnidadeFederativaModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<UnidadeFederativa> todasUnidadeFederativa()
        {
            var lista = from uf in db.UnidadeFederativa
                        select uf;
            return lista.ToList();
        }

        public string adicionarUnidadeFederativa(UnidadeFederativa uf)
        {
            string erro = null;
            try
            {
                db.UnidadeFederativa.Add(uf);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public UnidadeFederativa obterUnidadeFederativa(string idUF)
        {
            var lista = from uf in db.UnidadeFederativa
                        where uf.UF == idUF
                        select uf;
            return lista.ToList().FirstOrDefault();
        }

        public string editarUnidadeFederativa(UnidadeFederativa uf)
        {
            string erro = null;
            try
            {
                db.Entry(uf).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirUnidadeFederativa(UnidadeFederativa uf)
        {
            string erro = null;
            try
            {
                db.UnidadeFederativa.Remove(uf);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarUnidadeFederativa(UnidadeFederativa uf)
        {
            if (uf.UF == null || uf.UF == "")
            {
                return "Favor preencher a sigla do estado!";
            }
            if (uf.NomeEstado == null || uf.NomeEstado == "")
            {
                return "Favor preencher o nome do estado!";
            }
            return null;
        }

        internal UnidadeFederativa obterUnidadeFederativa(UnidadeFederativa uf)
        {
            throw new NotImplementedException();
        }

        public List<UnidadeFederativa> listarUnidadeFederativa(string UF)
        {
            var lista = from uf in db.UnidadeFederativa
                        select uf;
            return lista.ToList();
        }
    }
}