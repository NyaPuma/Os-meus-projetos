using System;
using InstitutoFormacao.Dominio;
using Xunit;

namespace InstitutoFormacao.Testes
{
    public class CursoTest
    {
        // Critério: Ser criado com todos os campos obrigatórios e válidos
        [Fact]
        public void DeveCriarCursoComDadosValidos()
        {
            // Arrange
            var nomeEsperado = "Curso de C# Avançado";
            var cargaHorariaEsperada = 40;
            var publicoAlvoEsperado = PublicoAlvo.Empreendedor;
            var valorEsperado = 150.00m;

            // Act
            var curso = new Curso(nomeEsperado, cargaHorariaEsperada, publicoAlvoEsperado, valorEsperado);

            // Assert
            Assert.Equal(nomeEsperado, curso.Nome);
            Assert.Equal(cargaHorariaEsperada, curso.CargaHoraria);
            Assert.Equal(publicoAlvoEsperado, curso.PublicoAlvo);
            Assert.Equal(valorEsperado, curso.Valor);
        }

        // Critério: Não pode ser criado curso com nome vazio ou nulo
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void NaoDeveCriarCursoComNomeInvalido(string nomeInvalido)
        {
            // Arrange
            var cargaHoraria = 20;
            var publicoAlvo = PublicoAlvo.Estudante;
            var valor = 50m;

            // Act & Assert
            var mensagemErro = Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cargaHoraria, publicoAlvo, valor)
            );

            Assert.Contains("nome", mensagemErro.Message);
        }

        // Critério: O curso deve ter carga horária maior que 0
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCriarCursoComCargaHorariaInvalida(int cargaHorariaInvalida)
        {
            // Arrange
            var nome = "Web Design";
            var publicoAlvo = PublicoAlvo.Universitario;
            var valor = 99.90m;

            // Act & Assert
            var mensagemErro = Assert.Throws<ArgumentException>(() =>
                new Curso(nome, cargaHorariaInvalida, publicoAlvo, valor)
            );

            Assert.Contains("carga horária", mensagemErro.Message.ToLower());
        }

        // Critério: O curso deve ter um valor superior a 0 euros
        [Theory]
        [InlineData(0)]
        [InlineData(-0.01)]
        [InlineData(-50)]
        public void NaoDeveCriarCursoComValorInvalido(decimal valorInvalido)
        {
            // Arrange
            var nome = "Gestão de Projetos";
            var cargaHoraria = 16;
            var publicoAlvo = PublicoAlvo.Empregado;

            // Act & Assert
            var mensagemErro = Assert.Throws<ArgumentException>(() =>
                new Curso(nome, cargaHoraria, publicoAlvo, valorInvalido)
            );

            Assert.Contains("valor", mensagemErro.Message.ToLower());
        }
    }
}