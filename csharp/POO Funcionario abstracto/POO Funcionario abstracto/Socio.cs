using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Funcionario_abstracto
{
    internal class Socio(
                        string nome, 
                        int idade,
                        int numeroAcoes, 
                        int fator) 
        :Funcionario(nome, idade)
    {
        public int NumeroAcoes { get; set; } = numeroAcoes;

        public int Fator { get; set; } = fator;

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine("Eu sou sócio");
        }

        public override double CalcularSalario()
        {
            return NumeroAcoes + Fator;
        }
    }
}
