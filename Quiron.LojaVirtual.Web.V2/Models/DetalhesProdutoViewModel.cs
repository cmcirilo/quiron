﻿using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class DetalhesProdutoViewModel
    {
        public QuironProduto Produto { get; set; }

        public IEnumerable<Cor> Cores { get; set; }

        public IEnumerable<Tamanho> Tamanhos { get; set; }

        public BreadCrumbDto BreadCrumb { get; set; }

        public SelectList CoresList { get; set; }

        public SelectList TamanhosList { get; set; }
    }
}
