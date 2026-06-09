using System;
using System.Collections.Generic;
using System.Text;

namespace RelacionamentoComposicao
{
    internal class Dependente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Dependente(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}
