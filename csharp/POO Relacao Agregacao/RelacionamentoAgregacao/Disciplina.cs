using System;
using System.Collections.Generic;
using System.Text;

namespace RelacionamentoAgregacao
{
    internal class Disciplina
    {
        public string  Nome { get; set; }

        public List<Estudante> Estudantes { get; set; }

        public Disciplina()
        {
            Estudantes = new List<Estudante>();
        }

        //Método para adicionar estudante á disciplina

        public void AdicionarEstudante(Estudante e)
        {
            Estudantes.Add(e);
        }
    }
}
