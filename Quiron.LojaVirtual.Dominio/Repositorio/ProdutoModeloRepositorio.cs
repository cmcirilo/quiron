using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutoModeloRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();
                
        public List<ProdutoVitrine> ObterProdutosVitrine (
            string categoria = null, string genero = null, string grupo = null,
            string subGrupo = null, string linha =null, string marca=null, 
            string modalidade=null, string busca=null)
        {
            var query = from p in _context.ProdutoVitrine select p;

            if (!String.IsNullOrEmpty(categoria))
                query = query.Where(c => c.CategoriaCodigo == categoria);
            if (!String.IsNullOrEmpty(genero))
                query = query.Where(c => c.GeneroCodigo == genero);
            if (!String.IsNullOrEmpty(grupo))
                query = query.Where(c => c.GrupoCodigo == grupo);
            if (!String.IsNullOrEmpty(subGrupo))
                query = query.Where(c => c.SubGrupoCodigo == subGrupo);
            if (!String.IsNullOrEmpty(linha))
                query = query.Where(c => c.LinhaCodigo == linha);
            if (!String.IsNullOrEmpty(marca))
                query = query.Where(c => c.MarcaCodigo == marca);
            if (!String.IsNullOrEmpty(modalidade))
                query = query.Where(c => c.ModalidadeCodigo == modalidade);
            if (!string.IsNullOrEmpty(busca))
                query = query.Where(b => b.ProdutoDescricao.Contains(busca));

            query = query.OrderBy(o => Guid.NewGuid());
            query = query.Take(20);
            return query.ToList();
        }
        //public List<ProdutoVitrine> ObterProdutos()
        //{

        //    var produtos = _context.ProdutoVitrine
        //        .OrderBy(m => Guid.NewGuid())
        //        .Take(20).ToList();

        //    return produtos;
        //}

    }
}
