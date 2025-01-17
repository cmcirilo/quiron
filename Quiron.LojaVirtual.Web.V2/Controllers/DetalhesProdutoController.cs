﻿using AutoMapper;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    [RoutePrefix("produto")]
    public class DetalhesProdutoController : Controller
    {
        [Route("{codigo}/{marca}/{produto}/{corcodigo}")]
        public ActionResult Detalhes(string codigo, string corCodigo)
        {
            var repositorio = new DetalhesProdutoRepositorio();
            var produto = repositorio.ObterProdutoModelo(codigo, corCodigo);
            var model = Mapper.Map<DetalhesProdutoViewModel>(produto);
            model.CoresList = new SelectList(produto.Cores, "CorCodigo", "CorDescricao", corCodigo);
            model.TamanhosList = new SelectList(produto.Tamanhos, "TamanhoCodigo", "TamanhoDescricaoResumida");
            model.BreadCrumb = repositorio.ObterBreadCrumb(codigo);
            return View(model);
        }
    }
}