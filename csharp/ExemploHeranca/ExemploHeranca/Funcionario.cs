using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploHeranca
{
    internal class Funcionario(string nome, int idade, string morada)
    {
        public string Nome { get; set; } = nome;
        public int Idade { get; set; } = idade;
        public string Morada { get; set; } = morada;

        // Método
        // Adicionar a palavra virtual ao método para que este possa ser redefinido pelas classes derivadas
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Funcionário: {Nome}, idade: {Idade}, morada: {Morada}");
        }
    }
}
