using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoDependencia
{
    internal class Funcionario
    {
        public string Nome { get; set; }
        public double Salario { get; set; }

        //construtor que aceita 2 parametros
        public Funcionario(string nome, double salario)
        {
            Nome = nome;
            Salario = salario;
            
        }
    }
}
