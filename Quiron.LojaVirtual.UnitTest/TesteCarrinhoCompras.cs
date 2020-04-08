using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Descricao = "Teste 1"
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Descricao = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);

        }

        public void AdicionarProdutoExistenteAoCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Descricao = "Teste 1"
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Descricao = "Teste 2"
            };
            
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c=> c.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade,11);
            Assert.AreEqual(resultado[0].Quantidade, 1);

        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Descricao = "Teste 1"
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Descricao = "Teste 2"
            };
            Produto produto3 = new Produto()
            {
                ProdutoId = 3,
                Descricao = "Teste 3"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(p => p.Produto == produto2).Count(), 0);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Descricao = "Teste 1",
                Preco=100M
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Descricao = "Teste 2",
                Preco=50M

            };
          

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 450M);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Descricao = "Teste 1",
                Preco = 100M
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Descricao = "Teste 2",
                Preco = 50M

            };


            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);


            carrinho.LimparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
