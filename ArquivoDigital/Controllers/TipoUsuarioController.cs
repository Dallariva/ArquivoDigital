using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private TipoUsuarioModel tipoUsuarioModel = new TipoUsuarioModel();

        public ActionResult Index()
        {
            return View(tipoUsuarioModel.todosTipoUsuario());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            TipoUsuario tu = new TipoUsuario();
            ViewBag.Titulo = "Novo Tipo Usuario";
            if (id != 0)
            {
                tu = tipoUsuarioModel.obterTipoUsuario(id);
                ViewBag.Titulo = "Editar Tipo Usuario";
            }
            return View(tu);
        }

        [HttpPost]
        public ActionResult Edit(TipoUsuario tu)
        {
            string erro = null;
            if (tu.IdTipoUsuario == 0)
                erro = tipoUsuarioModel.adicionarTipoUsuario(tu);
            else
                erro = tipoUsuarioModel.editarTipoUsuario(tu);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(tu);
            }
        }

        public ActionResult Delete(int id)
        {
            TipoUsuario tu = tipoUsuarioModel.obterTipoUsuario(id);
            tipoUsuarioModel.excluirTipoUsuario(tu);
            return RedirectToAction("Index");
        }
	}
}