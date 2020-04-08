using System.Web.Mvc;
using System.Linq;
using Quiron.LojaVirtual.Dominio.Repositorio;


namespace Quiron.LojaVirtual.Web.Controllers
{
	public class ProdutosController :Controller
	{
		private ProdutosRepositorio _repositorio;
		
		public ActionResult Index()
		{
			_repositorio = new ProdutosRepositorio();
			var produtos = _repositorio.Produtos.Take(3);
			return View(produtos);
		}
	}
}

