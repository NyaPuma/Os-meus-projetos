using System;
using Dominio;

namespace TesteMSTest
{
    [TestClass]
    public sealed class CarrinhoTeste
    {
        // Verificar que adicionar um produto aumenta o número total de produtos.
        [TestMethod]
        public void AdicionarProduto_DeveAumentarNumeroTotalDeProdutos()
        {
            // Arrange
            var carrinho = new Carrinho();
            var produto = new Produto { Nome = "Caneta", Preco = 1.50, Stock = 10 };

            // Act
            carrinho.AdicionarProduto(produto);

            // Assert
            Assert.AreEqual(1, carrinho.TotalProdutos());
        }

        // Verificar que o método Total() devolve a soma correta dos preços.
        [TestMethod]
        public void Total_DeveDevolverSomaCorretaDosPrecos()
        {
            // Arrange
            var carrinho = new Carrinho();
            var p1 = new Produto { Nome = "Rato", Preco = 25.00, Stock = 5 };
            var p2 = new Produto { Nome = "Teclado", Preco = 45.50, Stock = 2 };

            carrinho.AdicionarProduto(p1);
            carrinho.AdicionarProduto(p2);

            // Act
            double resultadoObtido = carrinho.Total();
            double resultadoEsperado = 70.50; // 25.00 + 45.50

            // Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtido);
        }

        // Verificar que o total é 0 quando o carrinho está vazio.
        [TestMethod]
        public void Total_DeveSerZero_QuandoCarrinhoEstiverVazio()
        {
            // Arrange
            var carrinho = new Carrinho();

            // Act
            double resultadoObtido = carrinho.Total();

            // Assert
            Assert.AreEqual(0, resultadoObtido);
        }
    }
}