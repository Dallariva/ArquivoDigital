using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class CidadeModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<Cidade> todasCidade()
        {
            var lista = from c in db.Cidade
                        select c;
            return lista.ToList();
        }

        public string adicionarCidade(Cidade c)
        {
            string erro = null;
            try
            {
                db.Cidade.Add(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Cidade obterCidade(int idCidade)
        {
            var lista = from c in db.Cidade
                        where c.IdCidade == idCidade
                        select c;
            return lista.ToList().FirstOrDefault();
        }

        public string editarCidade(Cidade c)
        {
            string erro = null;
            try
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirCidade(Cidade c)
        {
            string erro = null;
            try
            {
                db.Cidade.Remove(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarCidade(Cidade c)
        {
            if (c.NomeCidade == null || c.NomeCidade == "")
            {
                return "Favor preencher o nome da cidade!";
            }
            return null;
        }

        internal Cidade obterCidade(Cidade c)
        {
            throw new NotImplementedException();
        }

        public List<Cidade> obterCidadesPorEstado(string UF)
        {
            var lista = from c in db.Cidade
                        where c.UF == UF
                        select c;

            return lista.ToList();
        }
    }
}