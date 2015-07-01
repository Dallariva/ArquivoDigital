using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArquivoDigital.Entity;
using System.Data.Entity;

namespace ArquivoDigital.Models
{
    public class UsuarioModel
    {
        private ArquivoDigitalTCCEntities db = new ArquivoDigitalTCCEntities();

        public List<Usuario> todosUsuario()
        {
            var lista = from u in db.Usuario
                        select u;
            return lista.ToList();
        }

        public string adicionarUsuario(Usuario u)
        {
            string erro = null;
            try
            {
                db.Usuario.Add(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Usuario obterUsuario(int idPessoaUsuario)
        {
            var lista = from u in db.Usuario
                        where u.IdPessoaUsuario == idPessoaUsuario
                        select u;
            return lista.ToList().FirstOrDefault();
        }

        public Usuario obterUsuarioPorLogin(string login)
        {
            var lista = from u in db.Usuario
                        where u.Login == login
                        select u;
            return lista.ToList().FirstOrDefault();
        }

        public string editarUsuario(Usuario u)
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

        public string excluirUsuario(Usuario u)
        {
            string erro = null;
            try
            {
                db.Usuario.Remove(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarUsuario(Usuario u)
        {
            if (u.Senha == null || u.Senha == "")
            {
                return "Favor preencher a Senha!";
            }
            return null;
        }

        internal Usuario obterUsuario(Usuario e)
        {
            throw new NotImplementedException();
        }
    }
}