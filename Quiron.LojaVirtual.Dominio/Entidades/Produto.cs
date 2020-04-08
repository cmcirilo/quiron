
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
	public class Produto{

        [HiddenInput(DisplayValue =false)]
		public int ProdutoId {get;set;}

        [Required(ErrorMessage ="Digite o nome do Produto")]
		public string Nome {get;set;}

        [Required(ErrorMessage ="Digite a Descrição")]
        [DataType(DataType.MultilineText)]
		public string Descricao {get;set;}

        [Required(ErrorMessage ="Digite o Valor")]
        [Range(0.01,double.MaxValue,ErrorMessage ="Digite um Valor Válido")]
		public decimal Preco {get;set;}

        [Required(ErrorMessage ="Digite a Categoria")]
		public string Categoria {get;set;}

        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }

	}
}