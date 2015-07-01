using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArquivoDigital.Entity;
using ArquivoDigital.Models;

namespace ArquivoDigital.Controllers
{
    public class EnderecoController : Controller
    {
        private EnderecoModel enderecoModel = new EnderecoModel();
        private CidadeModel cidadeModel = new CidadeModel();
        private UnidadeFederativaModel unidadeFederativaModel = new UnidadeFederativaModel();
        private PessoaModel pessoaModel = new PessoaModel();

        public ActionResult Index()
        {
            return View(enderecoModel.todosEndereco());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Endereco e = new Endereco();
            ViewBag.Titulo = "Novo Endereço";

            string ufSelecionada = "MG";
            int cidadeSelecionada = 1;
            int pessoaSelecionada = 1;

            if (id != 0)
            {
                e = enderecoModel.obterEndereco(id);
                ufSelecionada = e.Cidade.UF;
                cidadeSelecionada = e.IdCidade;
                pessoaSelecionada = e.IdPessoa;
                ViewBag.Titulo = "Editar Endereço";
            }
            ViewBag.UF = new SelectList(unidadeFederativaModel.todasUnidadeFederativa(), "UF", "NomeEstado", ufSelecionada);
            ViewBag.IdCidade = new SelectList(cidadeModel.todasCidade(), "IdCidade", "NomeCidade", cidadeSelecionada);
            ViewBag.IdPessoa = new SelectList(pessoaModel.todasPessoa(), "IdPessoa", "Nome", pessoaSelecionada);
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Endereco e)
        {
            string erro = null;
            if (e.IdEndereco == 0)
                erro = enderecoModel.adicionarEndereco(e);
            else
                erro = enderecoModel.editarEndereco(e);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(e);
            }
        }

        public ActionResult Delete(int id)
        {
            Endereco e = enderecoModel.obterEndereco(id);
            enderecoModel.excluirEndereco(e);
            return RedirectToAction("Index");
        }
	}
}