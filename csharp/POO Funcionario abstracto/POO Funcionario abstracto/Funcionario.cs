using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace POO_Funcionario_abstracto
{
    internal abstract class Funcionario(string nome, 
                                        int idade)
    {
        public string Nome { get; set; } = nome;
        public int Idade { get; set; } = idade;

        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"{Nome} - {Idade}");
        }

        // Todos os meus funcionarios recebem salario
        // Mas cada um calcula-o de forma diferente
        // Socio - Recebe dividendos
        // Programador - Salario fixo
        // Comercial - Salario + Comissões de vendas

        public abstract double CalcularSalario(); //contrato
    }
}
