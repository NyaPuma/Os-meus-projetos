using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploHeranca
{
    internal class Outsourcing(string nome, int idade, string morada, int n_horas) : Funcionario(nome, idade, morada)
    {
        public int N_Horas { get; set; } = n_horas;
        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Trabalhou {N_Horas}");
        }
    }
}
