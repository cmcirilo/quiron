using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private MenuRepositorio _repositorio;

        [OutputCache(Duration =3600, Location =OutputCacheLocation.Server, VaryByParam ="none" )]
        public JsonResult ObterEsportes()
        {
            _repositorio = new MenuRepositorio();
            var cat = _repositorio.ObterCategorias();

            var categorias = from c in cat
                             select new
                             {
                                 c.CategoriaDescricao,
                                 CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                 c.CategoriaCodigo
                             };

            return Json(categorias, JsonRequestBehavior.AllowGet);                        
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterMarcas()
        {
            _repositorio = new MenuRepositorio();
            var listaMarcas = _repositorio.ObterMarcas();

            var marcas = from m in listaMarcas
                         select new
                         {
                             m.MarcaDescricao,
                             MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                             m.MarcaCodigo
                         };
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesNacionais()
        {
            _repositorio = new MenuRepositorio();
            var listaClubesNacionais = _repositorio.ObterClubesNacionais();

            var clubesNacionais = from cn in listaClubesNacionais
                                  select new
                                  {
                                      Clube = cn.LinhaDescricao,
                                      ClubeSeo = cn.LinhaDescricao.ToSeoUrl(),
                                      ClubeCodigo = cn.LinhaCodigo
                                  };
            return Json(clubesNacionais, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            _repositorio = new MenuRepositorio();
            var listaClubesInternacionais = _repositorio.ObterClubesInternacionais();

            var clubesInternacionais = from ci in listaClubesInternacionais
                                       select new
                                       {
                                           Clube = ci.LinhaDescricao,
                                           ClubeSeo = ci.LinhaDescricao.ToSeoUrl(),
                                           ClubeCodigo = ci.LinhaCodigo
                                       };

            return Json(clubesInternacionais, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterSelecoes()
        {
            _repositorio = new MenuRepositorio();
            var listaSelecoes = _repositorio.ObterSelecoes();

            var selecoes = from s in listaSelecoes
                                       select new
                                       {
                                           Clube = s.LinhaDescricao,
                                           ClubeSeo = s.LinhaDescricao.ToSeoUrl(),
                                           ClubeCodigo = s.LinhaCodigo
                                       };

            return Json(selecoes, JsonRequestBehavior.AllowGet);
        }


    }
}