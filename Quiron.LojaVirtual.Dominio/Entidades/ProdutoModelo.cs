using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class ProdutoModelo
    {
        [Key]
        public string ProdutoModeloCodigo { get; set; }

        public string ProdutoDescricao { get; set; }

        public string GeneroCodigo { get; set; }

        public string GeneroDescricao { get; set; }

        public string MarcaCodigo { get; set; }

        public string MarcaDescricao { get; set; }

        public string CategoriaCodigo { get; set; }

        public string CategoriaDescricao { get; set; }

        public string GrupoCodigo { get; set; }

        public string GrupoDescricao { get; set; }
    }
}
