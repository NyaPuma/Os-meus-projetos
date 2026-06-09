using Dominio;

namespace TesteMSTest
{
    [TestClass]
    public sealed class ProdutoTeste
    {
        [TestMethod]
        public void TemStock_QuandoStockMaiorQueZero_RetornaTrue()
        {
            // Arrange
            var produto = new Produto
            {
                Nome  = "Produto A",
                Preco = 10.0,
                Stock = 5
            };

            // Act
            var resultado = produto.TemStock();

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TemStock_QuandoStockMaiorQueZero_RetornaFalse()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "Produto B",
                Preco = 15.0,
                Stock = 0
            };

            // Act
            var resultado = produto.TemStock();

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void PrecoComIVA_DeveCalcularCorretamente_IVA23()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "Produto C",
                Preco = 20.0,
                Stock = 10
            };
            double taxaIVA = 23.0;

            // Act
            var precoComIVA = produto.PrecoComIVA(taxaIVA);

            // Assert
            double precoEsperado = 20.0 + (20.0 * taxaIVA / 100);
            Assert.AreEqual(precoEsperado, precoComIVA, 0.01);
        }

        [TestMethod]
        public void PrecoComIVA_DeveCalcularCorretamente_IVA0()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "Produto C",
                Preco = 20.0,
                Stock = 10
            };
            double taxaIVA = 0.0;

            // Act
            var precoComIVA = produto.PrecoComIVA(taxaIVA);

            // Assert
            double precoEsperado = 20.0 + (20.0 * taxaIVA / 100);
            Assert.AreEqual(precoEsperado, precoComIVA, 0.01);
        }

        // Aplicação correta de um desconto (ex.: 10%)
        [TestMethod]
        public void PrecoComDesconto_DeveAplicarDescontoCorretamente_QuandoPercentualValido()
        {
            // Arrange
            var produto = new Produto { Preco = 100.00 };
            var percentualDesconto = 10.0; // 10%
            var precoEsperado = 90.00;

            // Act
            var resultado = produto.PrecoComDesconto(percentualDesconto);

            // Assert
            Assert.AreEqual(precoEsperado, resultado);
        }

        // Desconto de 0% → devolve o preço original
        [TestMethod]
        public void PrecoComDesconto_DeveDevolverPrecoOriginal_QuandoDescontoForZero()
        {
            // Arrange
            var produto = new Produto { Preco = 150.50 };

            // Act
            var resultado = produto.PrecoComDesconto(0);

            // Assert
            Assert.AreEqual(produto.Preco, resultado);
        }

        // Desconto de 100% → devolve 0
        [TestMethod]
        public void PrecoComDesconto_DeveDevolverZero_QuandoDescontoForCemPorCento()
        {
            // Arrange
            var produto = new Produto { Preco = 299.99 };

            // Act
            var resultado = produto.PrecoComDesconto(100);

            // Assert
            Assert.AreEqual(0, resultado);
        }

        // Desconto negativo → deve lançar exceção
        [TestMethod]
        public void PrecoComDesconto_DeveLancarExcecao_QuandoDescontoForNegativo()
        {
            // Arrange
            var produto = new Produto { Preco = 50.00 };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => produto.PrecoComDesconto(-5));
        }

        // Desconto superior a 100% → deve lançar exceção
        [TestMethod]
        public void PrecoComDesconto_DeveLancarExcecao_QuandoDescontoForMaiorQueCem()
        {
            // Arrange
            var produto = new Produto { Preco = 50.00 };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => produto.PrecoComDesconto(100.01));
        }
    }
}
