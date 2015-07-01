using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class UnidadeController : Controller
    {
        private UnidadeModel unidadeModel = new UnidadeModel();
        private EnderecoModel enderecoModel = new EnderecoModel();

        public ActionResult Index()
        {
            return View(unidadeModel.todasUnidade());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Unidade u = new Unidade();
            ViewBag.Titulo = "Nova Unidade";

            int enderecoSelecionado = 1;

            if (id != 0)
            {
                u = unidadeModel.obterUnidade(id);
                enderecoSelecionado = u.IdEndereco;
                ViewBag.Titulo = "Editar Unidade";
            }
            ViewBag.IdEndereco = new SelectList(enderecoModel.todosEndereco(), "IdEndereco", "Logradouro", enderecoSelecionado);
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(Unidade u)
        {
            string erro = null;
            if (u.IdUnidade == 0)
                erro = unidadeModel.adicionarUnidade(u);
            else
                erro = unidadeModel.editarUnidade(u);
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
            Unidade u = unidadeModel.obterUnidade(id);
            unidadeModel.excluirUnidade(u);
            return RedirectToAction("Index");
        }
	}
}