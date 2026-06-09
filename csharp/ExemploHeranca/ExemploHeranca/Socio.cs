using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploHeranca
{
    internal class Socio(string nome, int idade, string morada, int numeroacoes) : Funcionario(nome,idade,morada)
    {
        public int NumeroAcoes { get; set; } = numeroacoes;

        public void MostrarQtAcoes()
        {
            Console.WriteLine($"O número de ações é {NumeroAcoes}");
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Número de ações: {NumeroAcoes}");
        }
    }
}
