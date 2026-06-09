using System.ComponentModel.Design.Serialization;

namespace RelacionamentoAgregacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criar estudantes (eles existem separadamente)

            Estudante c1 = new Estudante { Nome = "Ana", Numero = 1 };
            Estudante c2 = new Estudante { Nome = "Bruno", Numero = 2 };

            //criar a disciplina
            Disciplina d1 = new Disciplina { Nome = "Programação" };

            //Agregar estudantes á disciplina
            d1.AdicionarEstudante(c1);
            d1.AdicionarEstudante(c2);

            Console.WriteLine($"Diciplina: {d1.Nome} tem {d1.Estudantes.Count} alunos inscritos: ");
            foreach(Estudante e in d1.Estudantes)
            {
                Console.WriteLine($" {e.Nome}, nº{e.Numero}");
            }
        }
    }
}
