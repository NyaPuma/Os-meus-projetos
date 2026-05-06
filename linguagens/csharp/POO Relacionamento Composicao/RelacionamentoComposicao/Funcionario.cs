using System;
using System.Collections.Generic;
using System.Text;

namespace RelacionamentoComposicao
{
    internal class Funcionario
    {
        public string Nome  { get; set; }

        //Composição: o funcionário é o "dono" dos dependentes
        private List<Dependente> dependentes;

        public Funcionario(string nome)
        {
            Nome = nome;

            //criação interna da lista de dependentes (controlo do ciclo de vida)
            dependentes = new List<Dependente>();
        }

        //Método para adicionar dependente
        public void AdicionarDependente (string nome,int idade)
        {
            //o funcionario cria o dependente
            Dependente d = new Dependente(nome, idade);
            dependentes.Add(d);
        }
        public void ListarDependentes()
        {
            Console.WriteLine($"Dependentes de {Nome}");
            foreach(Dependente d in dependentes)
            {
                Console.WriteLine($"-{d.Nome}, {d.Idade} anos");
            }
        }
    }
}
