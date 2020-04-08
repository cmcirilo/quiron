using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastMapper;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(p => p.CategoriaDescricao);
        }

        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(m => m.MarcaDescricao);
        }

        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(cn => cn.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(ci => ci.LinhaDescricao);
        }

        public IEnumerable<Selecoes> ObterSelecoes()
        {
            return _context.Selecoes.OrderBy(s => s.LinhaDescricao);
        }

        public IEnumerable<Categoria> ObterTenisCategoria()
        {
            var categorias = new[] { "0005", "0082", "0112", "0010", "0006", "0063" };
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo)).OrderBy(c => c.CategoriaDescricao);
        }

        public SubGrupo SubGrupoTenis()
        {
            return _context.SubGrupos.FirstOrDefault(s => s.SubGrupoCodigo == "0084");
        }

        #region [Menu Lateral Casual]

        /// <summary>
        /// Retorna Modalidade Casual
        /// </summary>
        /// <returns></returns>
        public Modalidade ObterModalidadeCasual()
        {
            const string CODIGOMODALIDADE = "0001";
            return _context.Modalidades.FirstOrDefault(m => m.ModalidadeCodigo == CODIGOMODALIDADE);
        }

        public IEnumerable<SubGrupoDto> ObterCasualSubGrupo()
        {
            var subGrupos = new[] { "0001", "0102", "0103", "0738", "0084", "0921" };

            var query = from s in _context.SubGrupos
                        .Where(s => subGrupos.Contains(s.SubGrupoCodigo))
                        .Select(s => new { s.SubGrupoCodigo, s.SubGrupoDescricao })
                        .Distinct()
                        .OrderBy(s => s.SubGrupoDescricao)
                        select new 
                        {
                            s.SubGrupoCodigo,
                            s.SubGrupoDescricao
                        };

            return query.Project().To<SubGrupoDto>().ToList();
        }

        #endregion

        #region [Suplementos]

        public Categoria Suplemento()
        {
            var categoriaSuplementos = "0008";
            return _context.Categorias.FirstOrDefault(c => c.CategoriaCodigo == categoriaSuplementos);
        }

        public IEnumerable<SubGrupo> ObterSuplementos()
        {
            var subGrupos = new[]
            {
                "0162","0381","0557","0564","0565","1082","1083","1084","1085"
            };
            return _context.SubGrupos
                .Where(s => subGrupos.Contains(s.SubGrupoCodigo) && s.GrupoCodigo=="0012")
                .OrderBy(s => s.SubGrupoDescricao);
        }
        #endregion


    }
}
