using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ficha3_Exercicio_1
{
    ///////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Classe Autor: Representa a entidade Autor, independente de outras classes ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    ///////////////////////////////////////////////////////////////////////////////////////////

    // ::::: Utilização de Primary Constructor (C# 12) para definir e inicializar as propriedades base ::::: //
    internal class Autor(string nome, string nacionalidade)
    {
        // ::::: Propriedades ::::: //

        // ::::: Nome completo do autor ::::: //
        public string Nome { get; set; } = nome;

        // ::::: País de origem ou nacionalidade do autor ::::: //
        public string Nacionalidade { get; set; } = nacionalidade;

        // ::::: Método para imprimir os detalhes do autor na consola.                 ::::: //
        // ::::: Este método é chamado tanto diretamente pelo menu principal (Opção 4) ::::: //
        // ::::: como pela classe Livro através da associação.                         ::::: //
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Autor: {Nome} | Nacionalidade: {Nacionalidade}");
        }
    }
}