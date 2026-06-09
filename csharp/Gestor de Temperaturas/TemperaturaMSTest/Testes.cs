using GestorTemperaturas;
namespace TemperaturaMSTest
{
    [TestClass]
    public sealed class Testes
    {
        [TestMethod]
        public void CelsiusParaFahrenheit_PontoCongelacao_DeveRetornar32()
        {
            // Arrange
            double celsius = 0.0;
            double esperado = 32.0;
            double tolerancia = 0.001;

            // Act
            double resultado = GestorDeTemperaturas.CelsiusParaFahrenheit(celsius);

            // Assert
            Assert.AreEqual(esperado, resultado, tolerancia);
        }

        [TestMethod]
        public void CelsiusParaFahrenheit_TemperaturaNormal_DeveConverterCorretamente()
        {
            // Arrange
            double celsius = 37.0;
            double esperado = 98.6;
            double tolerancia = 0.001;

            // Act
            double resultado = GestorDeTemperaturas.CelsiusParaFahrenheit(celsius);

            // Assert
            Assert.AreEqual(esperado, resultado, tolerancia);
        }

        [TestMethod]
        public void FahrenheitParaCelsius_PontoEbulicao_DeveRetornar100()
        {
            // Arrange
            double fahrenheit = 212.0;
            double esperado = 100.0;
            double tolerancia = 0.001;

            // Act
            double resultado = GestorDeTemperaturas.FahrenheitParaCelsius(fahrenheit);

            // Assert
            Assert.AreEqual(esperado, resultado, tolerancia);
        }

        [TestMethod]
        public void FahrenheitParaCelsius_TemperaturaNegativa_DeveConverterCorretamente()
        {
            // Arrange
            double fahrenheit = -40.0;
            double esperado = -40.0;
            double tolerancia = 0.001;

            // Act
            double resultado = GestorDeTemperaturas.FahrenheitParaCelsius(fahrenheit);

            // Assert
            Assert.AreEqual(esperado, resultado, tolerancia);

        }
        [TestMethod]
        public void TemFebreCelsius_AbaixoDoLimite_DeveRetornarFalse()
        {
            // Arrange
            double celsius = 37.9;
            bool esperado = false;

            // Act
            bool resultado = GestorDeTemperaturas.TemFebreCelsius(celsius);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TemFebreCelsius_ExatamenteNoLimite_DeveRetornarTrue()
        {
            // Arrange
            double celsius = 38.0;
            bool esperado = true;

            // Act
            bool resultado = GestorDeTemperaturas.TemFebreCelsius(celsius);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TemFebreCelsius_AcimaDoLimite_DeveRetornarTrue()
        {
            // Arrange
            double celsius = 39.5;
            bool esperado = true;

            // Act
            bool resultado = GestorDeTemperaturas.TemFebreCelsius(celsius);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TemFebreFahrenheit_AbaixoDoLimite_DeveRetornarFalse()
        {
            // Arrange
            double fahrenheit = 100.3;
            bool esperado = false;

            // Act
            bool resultado = GestorDeTemperaturas.TemFebreFahrenheit(fahrenheit);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TemFebreFahrenheit_ExatamenteNoLimite_DeveRetornarTrue()
        {
            // Arrange
            double fahrenheit = 100.4;
            bool esperado = true;

            // Act
            bool resultado = GestorDeTemperaturas.TemFebreFahrenheit(fahrenheit);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TemFebreFahrenheit_AcimaDoLimite_DeveRetornarTrue()
        {
            // Arrange
            double fahrenheit = 102.0;
            bool esperado = true;

            // Act
            bool resultado = GestorDeTemperaturas.TemFebreFahrenheit(fahrenheit);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }
    }
}
