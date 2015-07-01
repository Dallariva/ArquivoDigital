using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class UnidadeFederativaController : Controller
    {
        private UnidadeFederativaModel unidadeFederativaModel = new UnidadeFederativaModel();

        public ActionResult Index()
        {
            return View(unidadeFederativaModel.todasUnidadeFederativa());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            UnidadeFederativa uf = new UnidadeFederativa();
            ViewBag.Titulo = "Novo Estado";
            if (id != null)
            {
                uf = unidadeFederativaModel.obterUnidadeFederativa(id);
                ViewBag.Titulo = "Editar Estado";
            }
            return View(uf);
        }

        [HttpPost]
        public ActionResult Edit(String UF, String NomeEstado)
        {
            UnidadeFederativa uf = new UnidadeFederativa();
            uf.UF = UF;
            uf.NomeEstado = NomeEstado;
            string erro = null;
            if (uf.UF == null)
                erro = unidadeFederativaModel.adicionarUnidadeFederativa(uf);
            else
                erro = unidadeFederativaModel.editarUnidadeFederativa(uf);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(uf);
            }
        }

        public ActionResult Delete(string id)
        {
            UnidadeFederativa uf = unidadeFederativaModel.obterUnidadeFederativa(id);
            unidadeFederativaModel.excluirUnidadeFederativa(uf);
            return RedirectToAction("Index");
        }
	}
}