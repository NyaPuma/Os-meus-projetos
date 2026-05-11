using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Funcionario_abstracto
{
    internal class Comercial(
                             string nome,
                             int idade,
                             double salario,
                             double totalVendas,
                             double percentagemComissao)
                  :Funcionario(nome,idade)
    {
        public double Salario { get; set; } = salario;
        public double TotalVendas { get; set; } = totalVendas;
        public double PercentagemComissao { get; set; } = percentagemComissao;

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine("Eu sou comercial");
        }

        // Obedecer ao contrato da base
        public override double CalcularSalario()
        {
            return Salario + TotalVendas * PercentagemComissao;
        }
    }
}
