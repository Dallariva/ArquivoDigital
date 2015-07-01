using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class TipoAutorizacaoController : Controller
    {
        private TipoAutorizacaoModel tipoAutorizacaoModel = new TipoAutorizacaoModel();

        public ActionResult Index()
        {
            return View(tipoAutorizacaoModel.todosTipoAutorizacao());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            TipoAutorizacao ta = new TipoAutorizacao();
            ViewBag.Titulo = "Novo Tipo Autorização";
            if (id != 0)
            {
                ta = tipoAutorizacaoModel.obterTipoAutorizacao(id);
                ViewBag.Titulo = "Editar Tipo Autorização";
            }
            return View(ta);
        }

        [HttpPost]
        public ActionResult Edit(TipoAutorizacao ta)
        {
            string erro = null;
            if (ta.IdTipoAutorizacao == 0)
                erro = tipoAutorizacaoModel.adicionarTipoAutorizacao(ta);
            else
                erro = tipoAutorizacaoModel.editarTipoAutorizacao(ta);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(ta);
            }
        }

        public ActionResult Delete(int id)
        {
            TipoAutorizacao ta = tipoAutorizacaoModel.obterTipoAutorizacao(id);
            tipoAutorizacaoModel.excluirTipoAutorizacao(ta);
            return RedirectToAction("Index");
        }
	}
}