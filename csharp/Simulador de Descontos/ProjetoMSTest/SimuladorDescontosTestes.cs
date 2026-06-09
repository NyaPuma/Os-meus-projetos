using SimuladorDeDescontos;
namespace ProjetoMSTest
{
    [TestClass]
    public sealed class SimuladorDescontosTestes
    {
        [TestMethod]
        // Um produto de 100€ com 10% de desconto fica a 90€.
        public void Produto100_Com10PorCentoDeDesconto_Retorna90Euros()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(100, 10);

            // Assert
            Assert.AreEqual(90, resultado);
        }

        // Um produto de 50€ com 0% de desconto mantém o preço original.
        [TestMethod]
        public void Produto50_Com0PorCentoDeDesconto_Retorna50Euros()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(50, 0);

            // Assert
            Assert.AreEqual(50, resultado);
        }

        // Um produto de 100€ com 100% de desconto fica a 50€ (porque o desconto é limitado a 50%).
        [TestMethod]
        public void Produto100_Com100PorCentoDeDesconto_Retorna50Euros()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(100, 100);

            // Assert
            Assert.AreEqual(50, resultado);
        }

        // Um desconto superior a 50% deve ser limitado a 50%.
        [TestMethod]
        public void Produto100_Com150PorCentoDeDesconto_Retorna50Euros()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(100, 150);

            // Assert
            Assert.AreEqual(50, resultado);
        }

        // Um preço negativo deve lançar uma exceção.
        [TestMethod]
        public void ProdutoNegativo_RetornaExcecao()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => simulador.CalcularValorFinal(-100, 10));
        }

        // Um desconto negativo deve lançar uma exceção.
        [TestMethod]
        public void DescontoNegativo_RetornaExcecao()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => simulador.CalcularValorFinal(100, -10));
        }

        // O preço final nunca pode ser negativo.
        [TestMethod]
        public void PrecoFinalNuncaPodeSerNegativo()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(30, 10, 50);

            // Assert
            Assert.AreEqual(0, resultado);
        }

        // Um cupão fixo deve ser subtraído ao preço final.
        [TestMethod]
        public void CupaoFixo_RetornaPrecoFinalComDesconto()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(100, 10, 10);

            // Assert
            Assert.AreEqual(80, resultado);
        }

        // Um produto de 100€ com 10% de desconto e cupão de 5€ deve resultar em 85€.
        [TestMethod]
        public void Produto100_Com10PorCentoDeDescontoECupaoDe5Euros_Retorna85Euros()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(100, 10, 5);

            // Assert
            Assert.AreEqual(85, resultado);
        }

        // Um produto de 20€ com cupão de 50€ deve resultar em 0€.
        [TestMethod]
        public void Produto20_ComCupaoDe50Euros_Retorna0Euros()
        {
            // Arrange
            var simulador = new SimuladorDescontos();

            // Act
            double resultado = simulador.CalcularValorFinal(20, 0, 50);

            // Assert
            Assert.AreEqual(0, resultado);
        }
    }
}
