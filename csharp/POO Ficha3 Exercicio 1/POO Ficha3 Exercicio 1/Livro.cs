using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ficha3_Exercicio_1
{
    ///////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Classe Livro: Representa a entidade Livro e a sua associação com um Autor ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    ///////////////////////////////////////////////////////////////////////////////////////////

    // ::::: Utilização de Primary Constructor (recurso do C# 12) para inicializar a classe ::::: //
    internal class Livro(string titulo, string isbn, int ano, Autor autor)
    {
        // ::::: Propriedades ::::: //

        // ::::: Título do livro ::::: //
        public string Titulo { get; set; } = titulo;

        // ::::: Código identificador único do livro ::::: //
        public string ISBN { get; set; } = isbn;

        // ::::: Ano em que a obra foi publicada ::::: //
        public int AnoPublicacao { get; set; } = ano;

        // ::::: Associação ::::: //
        // ::::: Esta propriedade é a peça-chave da associação: o tipo da propriedade é a classe 'Autor'. ::::: //
        // ::::: Significa que cada objeto 'Livro' guarda uma referência a um objeto 'Autor'.             ::::: //
        public Autor AutorAssociado { get; set; } = autor;

        // ::::: Método para imprimir os detalhes do livro na consola.                                  ::::: //
        // ::::: Também invoca o método de exibição do autor associado para mostrar os dados completos. ::::: //
        public void ExibirInformacoes()
        {
            // ::::: Exibe os dados técnicos do livro ::::: //
            Console.WriteLine($"Livro: {Titulo} ({AnoPublicacao}) | ISBN: {ISBN}");

            // ::::: Navegação de associação: acede ao objeto AutorAssociado e chama o seu método ExibirInformacoes ::::: //
            Console.Write("  -> ");
            AutorAssociado.ExibirInformacoes();
        }
    }
}