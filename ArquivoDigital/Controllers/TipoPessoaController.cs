using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class TipoPessoaController : Controller
    {
        private TipoPessoaModel tipoPessoaModel = new TipoPessoaModel();

        public ActionResult Index()
        {
            return View(tipoPessoaModel.todosTipoPessoa());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoPessoa tp)
        {
            tipoPessoaModel.adicionarTipoPessoa(tp);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TipoPessoa tp = new TipoPessoa();
            ViewBag.Titulo = "Novo Tipo Pessoa";
            if (id != 0)
            {
                tp = tipoPessoaModel.obterTipoPessoa(id);
                ViewBag.Titulo = "Editar Tipo Pessoa";
            }
            return View(tp);
        }

        [HttpPost]
        public ActionResult Edit(TipoPessoa tp)
        {
            string erro = null;
            if (tp.IdTipoPessoa == 0)
                erro = tipoPessoaModel.adicionarTipoPessoa(tp);
            else
                erro = tipoPessoaModel.editarTipoPessoa(tp);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(tp);
            }
        }

        public ActionResult Delete(int id)
        {
            TipoPessoa tp = tipoPessoaModel.obterTipoPessoa(id);
            tipoPessoaModel.excluirTipoPessoa(tp);
            return RedirectToAction("Index");
        }
	}
}