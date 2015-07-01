using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private TipoDocumentoModel tipoDocumentoModel = new TipoDocumentoModel();

        public ActionResult Index()
        {
            return View(tipoDocumentoModel.todosTipoDocumento());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            TipoDocumento td = new TipoDocumento();
            ViewBag.Titulo = "Novo Tipo Documento";
            if (id != 0)
            {
                td = tipoDocumentoModel.obterTipoDocumento(id);
                ViewBag.Titulo = "Editar Tipo Documento";
            }
            return View(td);
        }

        [HttpPost]
        public ActionResult Edit(TipoDocumento td)
        {
            string erro = null;
            if (td.IdTipoDocumento == 0)
                erro = tipoDocumentoModel.adicionarTipoDocumento(td);
            else
                erro = tipoDocumentoModel.editarTipoDocumento(td);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(td);
            }
        }

        public ActionResult Delete(int id)
        {
            TipoDocumento td = tipoDocumentoModel.obterTipoDocumento(id);
            tipoDocumentoModel.excluirTipoDocumento(td);
            return RedirectToAction("Index");
        }
	}
}