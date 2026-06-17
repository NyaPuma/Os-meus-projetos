using System;
using Xunit;
using SistemaBancario.Domain;

namespace SistemaBancario.Tests
{
    public class ContaBancariaTests
    {
        [Fact]
        public void CriarConta_ComSaldoInicial_DeveDefinirSaldoCorretamente()
        {
            // Arrange
            decimal saldoInicial = 100m;

            // Act
            var conta = new ContaBancaria(saldoInicial);

            // Assert
            Assert.Equal(saldoInicial, conta.Saldo);
        }

        [Fact]
        public void Depositar_ValorValido_DeveAumentarOSaldo()
        {
            // Arrange
            var conta = new ContaBancaria(50m);
            decimal valorDeposito = 30m;

            // Act
            conta.Depositar(valorDeposito);

            // Assert
            Assert.Equal(80m, conta.Saldo);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Depositar_ValoresInvalidos_DeveLancarArgumentException(decimal valorInvalido)
        {
            // Arrange
            var conta = new ContaBancaria(100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => conta.Depositar(valorInvalido));
        }

        [Fact]
        public void Levantar_ValorValido_DeveDiminuirOSaldo()
        {
            // Arrange
            var conta = new ContaBancaria(100m);
            decimal valorLevantamento = 40m;

            // Act
            conta.Levantar(valorLevantamento);

            // Assert
            Assert.Equal(60m, conta.Saldo);
        }

        [Fact]
        public void Levantar_ValorSuperiorAoSaldo_DeveLancarInvalidOperationException()
        {
            // Arrange
            var conta = new ContaBancaria(50m);
            decimal valorMaior = 60m;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => conta.Levantar(valorMaior));
        }

        [Fact]
        public void Transferir_SaldoSuficiente_DeveAtualizarAmbosOsSaldos()
        {
            // Arrange
            var contaOrigem = new ContaBancaria(100m);
            var contaDestino = new ContaBancaria(50m);
            decimal valorTransferencia = 40m;

            // Act
            contaOrigem.Transferir(contaDestino, valorTransferencia);

            // Assert
            Assert.Equal(60m, contaOrigem.Saldo);
            Assert.Equal(90m, contaDestino.Saldo);
        }

        [Fact]
        public void Transferir_SaldoInsuficiente_NãoDeveAlterarNenhumDosSaldos()
        {
            // Arrange
            var contaOrigem = new ContaBancaria(30m);
            var contaDestino = new ContaBancaria(50m);
            decimal valorTransferencia = 40m;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => contaOrigem.Transferir(contaDestino, valorTransferencia));

            // Garantir o isolamento e integridade: os saldos originais mantêm-se intactos
            Assert.Equal(30m, contaOrigem.Saldo);
            Assert.Equal(50m, contaDestino.Saldo);
        }
    }
}