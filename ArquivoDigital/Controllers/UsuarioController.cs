using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;
using System.Web.Security;

namespace ArquivoDigital.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioModel usuarioModel = new UsuarioModel();
        private UnidadeModel unidadeModel = new UnidadeModel();
        private TipoUsuarioModel tipoUsuarioModel = new TipoUsuarioModel();
        private PessoaModel pessoaModel = new PessoaModel();

        public ActionResult Index()
        {
            return View(usuarioModel.todosUsuario());
        }

        public ActionResult Login()
        {
            return View(new Usuario());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Usuario u = new Usuario();
            ViewBag.Titulo = "Novo Usuário";

            int pessoaSelecionada = 1;
            int tipoUsuarioSelecionado = 1;
            int unidadeSelecionada = 1;

            if (id != 0)
            {
                u = usuarioModel.obterUsuario(id);
                pessoaSelecionada = u.Pessoa.IdPessoa;
                tipoUsuarioSelecionado = u.TipoUsuario.IdTipoUsuario;
                unidadeSelecionada = u.Unidade.IdUnidade;
                ViewBag.Titulo = "Editar Usuário";
            }
            ViewBag.IdPessoa = new SelectList(pessoaModel.todasPessoa(), "IdPessoa", "Nome", pessoaSelecionada);
            ViewBag.IdTipoUsuario = new SelectList(tipoUsuarioModel.todosTipoUsuario(), "IdTipoUsuario", "Descricao", tipoUsuarioSelecionado);
            ViewBag.IdUnidade = new SelectList(unidadeModel.todasUnidade(), "IdUnidade", "NomeUnidade", unidadeSelecionada);
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(Usuario u)
        {
            string erro = null;
            if (u.IdPessoaUsuario == 0)
                erro = usuarioModel.adicionarUsuario(u);
            else
                erro = usuarioModel.editarUsuario(u);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(u);
            }
        }

        public ActionResult Delete(int id)
        {
            Usuario u = usuarioModel.obterUsuario(id);
            usuarioModel.excluirUsuario(u);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {
            Usuario banco = usuarioModel.obterUsuarioPorLogin(u.Login);
            if (banco == null || banco == new Usuario())
            {
                ViewBag.Erro = "Usuário inexistente!";
                return View(u);
            }
            if (u.Senha != banco.Senha)
            {
                ViewBag.Erro = "Senha Incorreta!";
                return View(u);
            }
            FormsAuthentication.SetAuthCookie(u.Login, true);
            return Redirect("/");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
	}
}