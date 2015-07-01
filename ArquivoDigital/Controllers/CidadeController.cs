using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class CidadeController : Controller
    {
        private CidadeModel cidadeModel = new CidadeModel();
        private UnidadeFederativaModel unidadeFederativaModel = new UnidadeFederativaModel();

        public ActionResult Index()
        {
            return View(cidadeModel.todasCidade());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Cidade c = new Cidade();
            ViewBag.Titulo = "Nova Cidade";

            string ufSelecionada = "MG";

            if (id != 0)
            {
                c = cidadeModel.obterCidade(id);
                ufSelecionada = c.UF;
                ViewBag.Titulo = "Editar Cidade";
            }
            ViewBag.UF = new SelectList(unidadeFederativaModel.todasUnidadeFederativa(), "UF", "NomeEstado", ufSelecionada);
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Cidade c)
        {
            string erro = null;
            if (c.IdCidade == 0)
                erro = cidadeModel.adicionarCidade(c);
            else
                erro = cidadeModel.editarCidade(c);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(c);
            }
        }

        public ActionResult Delete(int id)
        {
            Cidade c = cidadeModel.obterCidade(id);
            cidadeModel.excluirCidade(c);
            return RedirectToAction("Index");
        }
	}
}