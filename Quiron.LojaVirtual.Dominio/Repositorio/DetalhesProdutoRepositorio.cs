﻿using AutoMapper;
using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class DetalhesProdutoRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public DetalhesProdutoDto ObterProdutoModelo(string codigo, string corCodigo)
        {
            var query = from p in _context.QuironProdutos
                        join c in _context.Cores on p.CorCodigo equals c.CorCodigo
                        join t in _context.Tamanhos on p.TamanhoCodigo equals t.TamanhoCodigo
                        join e in _context.Estoque on p.ProdutoCodigo equals e.ProdutoCodigo
                        where p.ProdutoModeloCodigo == codigo && e.Quantidade > 0
                        select new
                        {
                            p.ProdutoModeloCodigo,
                            p.ProdutoCodigo,
                            p.ProdutoDescricao,
                            p.ProdutoDescricaoResumida,
                            p.MarcaDescricao,
                            p.ModeloDescricao,
                            c.CorCodigo,
                            c.CorDescricao,
                            t.TamanhoCodigo,
                            t.TamanhoDescricaoResumida,
                            e.Quantidade,
                            p.Preco
                        };

            var cores = (from c in query
                         select new
                         {
                             c.CorCodigo,
                             c.CorDescricao
                         }).Distinct();

            var cor = cores.First();

            var tamanhos = (from t in query
                            join c in cores on t.CorCodigo equals c.CorCodigo
                            where t.CorCodigo == cor.CorCodigo
                            select new
                            {
                                t.TamanhoCodigo,
                                t.TamanhoDescricaoResumida
                            });

            var produto = (from p in query where p.CorCodigo == cor.CorCodigo select p).First();



            DetalhesProdutoDto dto = new DetalhesProdutoDto
            {
                Produto = Mapper.Map<QuironProduto>(produto),
                Cores = cores.Select(Mapper.Map<Cor>),
                Tamanhos = tamanhos.Select(Mapper.Map<Tamanho>)
            };

            return dto;
        }

        public DetalhesProdutoDto ObterProdutoPorCodigo(string codigo, string corCodigo, string tamanho)
        {
            var query = from p in _context.QuironProdutos
                        join c in _context.Cores on p.CorCodigo equals c.CorCodigo
                        join t in _context.Tamanhos on p.TamanhoCodigo equals t.TamanhoCodigo
                        join e in _context.Estoque on p.ProdutoCodigo equals e.ProdutoCodigo
                        where p.ProdutoModeloCodigo == codigo && e.Quantidade > 0
                        select new
                        {
                            p.ProdutoModeloCodigo,
                            p.ProdutoCodigo,
                            p.ProdutoDescricao,
                            p.ProdutoDescricaoResumida,
                            p.MarcaDescricao,
                            p.ModeloDescricao,
                            c.CorCodigo,
                            c.CorDescricao,
                            t.TamanhoCodigo,
                            t.TamanhoDescricaoResumida,
                            e.Quantidade,
                            p.Preco
                        };

            var cores = (from c in query
                         select new
                         {
                             c.CorCodigo,
                             c.CorDescricao
                         }).Distinct();

            var cor = cores.First();

            var tamanhos = (from t in query
                            join c in cores on t.CorCodigo equals c.CorCodigo
                            where t.CorCodigo == cor.CorCodigo
                            select new
                            {
                                t.TamanhoCodigo,
                                t.TamanhoDescricaoResumida
                            });

            var produto = (from p in query where p.CorCodigo == cor.CorCodigo select p).First();



            DetalhesProdutoDto dto = new DetalhesProdutoDto
            {
                Produto = Mapper.Map<QuironProduto>(produto),
                Cores = cores.Select(Mapper.Map<Cor>),
                Tamanhos = tamanhos.Select(Mapper.Map<Tamanho>)
            };

            return dto;
        }

        public BreadCrumbDto ObterBreadCrumb(string produtoModeloCodigo)
        {
            var breadCrumb = (from p in _context.ProdutoModelo
                              join g in _context.Generos on p.GeneroCodigo equals g.GeneroCodigo
                              join m in _context.Marcas on p.MarcaCodigo equals m.MarcaCodigo
                              join c in _context.Categorias on p.CategoriaCodigo equals c.CategoriaCodigo
                              join gr in _context.Grupos on p.GrupoCodigo equals gr.GrupoCodigo
                              where p.ProdutoModeloCodigo == produtoModeloCodigo

                              select new
                              {
                                  m.MarcaCodigo,
                                  m.MarcaDescricao,
                                  p.ProdutoDescricao,
                                  g.GeneroCodigo,
                                  g.GeneroDescricao,
                                  c.CategoriaCodigo,
                                  c.CategoriaDescricao,
                                  gr.GrupoCodigo,
                                  gr.GrupoDescricao
                              }).FirstOrDefault();

            return Mapper.Map<BreadCrumbDto>(breadCrumb);
        }

    }
}
