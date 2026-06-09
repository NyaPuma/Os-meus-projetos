using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Funcionario_abstracto
{
    internal class Programador(
                                string nome, 
                                int idade,
                                double salario)
        :Funcionario(nome, idade)
    {
        public double Salario { get; set; } = salario;

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine("Eu sou programador");
        }

        public override double CalcularSalario() //Estou a cumprir o contrato
        {
            return Salario;
        }
    }
}
