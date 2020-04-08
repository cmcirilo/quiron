using System;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite um Login")]
        [Display(Name ="Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite uma Senha")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}   
