using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaModel pessoaModel = new PessoaModel();
        private TipoPessoaModel tipoPessoaModel = new TipoPessoaModel();

        public ActionResult Index()
        {
            return View(pessoaModel.todasPessoa());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Pessoa p = new Pessoa();
            ViewBag.Titulo = "Nova Pessoa";

            int tipoPessoaSelecao = 3;

            if (id != 0)
            {
                p = pessoaModel.obterPessoa(id);
                tipoPessoaSelecao = p.IdTipoPessoa;
                ViewBag.Titulo = "Editar Pessoa";
            }
            ViewBag.IdTipoPessoa = new SelectList(tipoPessoaModel.todosTipoPessoa(), "IdTipoPessoa", "Descricao", tipoPessoaSelecao);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Pessoa p)
        {
            string erro = null;
            if (p.IdPessoa == 0)
                erro = pessoaModel.adicionarPessoa(p);
            else
                erro = pessoaModel.editarPessoa(p);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(p);
            }
        }

        public ActionResult Delete(int id)
        {
            Pessoa p = pessoaModel.obterPessoa(id);
            pessoaModel.excluirPessoa(p);
            return RedirectToAction("Index");
        }
	}
}