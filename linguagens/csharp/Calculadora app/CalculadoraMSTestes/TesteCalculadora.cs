namespace CalculadoraMSTestes
{
    [TestClass]
    public sealed class TesteCalculadora
    {
        [TestMethod]
        public void Somar_ValoresPositivos_RetornarSomaCorreta()
        {
            // Arrange
            var calculadora = new CalculadoraDominio.Calculadora();
            int a = 5;
            int b = 3;

            // Act
            var resultado = calculadora.Somar(a, b);

            // Assert
            Assert.AreEqual(8, resultado);
        }

        [TestMethod]
        public void Subtrair_ValoresPositivos_RetornarSubtracaoCorreta()
        {
            // Arrange
            var calculadora = new CalculadoraDominio.Calculadora();
            int a = 10;
            int b = 4;

            // Act
            var resultado = calculadora.Subtrair(a, b);

            // Assert
            Assert.AreEqual(6, resultado);
        }

        [TestMethod]
        public void Multiplicar_ValoresPositivos_RetornarMultiplicacaoCorreta()
        {
            // Arrange
            var calculadora = new CalculadoraDominio.Calculadora();
            int a = 6;
            int b = 7;

            // Act
            var resultado = calculadora.Multiplicar(a, b);

            // Assert
            Assert.AreEqual(42, resultado);
        }

        [TestMethod]
        public void Dividir_ValoresPositivos_RetornarDivisaoCorreta()
        {
            // Arrange
            var calculadora = new CalculadoraDominio.Calculadora();
            int a = 20;
            int b = 5;

            // Act
            var resultado = calculadora.Dividir(a, b);

            // Assert
            Assert.AreEqual(4, resultado);
        }

        [TestMethod]
        public void Dividir_DivisaoPorZero_LancarExcecao()
        {
            // Arrange
            var calculadora = new CalculadoraDominio.Calculadora();
            int a = 10;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(a, b));

            // neste tipo de teste, a chamada ao método e a verificação acontecem juntas:
            // ACT -> executa a operação
            // ASSERT -> verifica se a operação lançou a exceção esperada
        }

        // Testes dirigidos por dados (Data-Driven Tests)
        [TestMethod]
        [DataRow( 2,  3,  5)]
        [DataRow(10, -4,  6)]
        [DataRow( 6,  7, 13)]
        [DataRow(20,  5, 25)]

        public void Calcular_Soma_Com_VariosCenarios(int a, int b, int resultadoEsperado)
        {
            // Arrange
            var calculadora = new CalculadoraDominio.Calculadora();
            // Act
            var resultado = calculadora.Somar(a, b);
            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
