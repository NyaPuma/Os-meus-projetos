using System;
using System.Collections.Generic;
using System.Text;

namespace MVC1.Views
{
    public class EstudanteView
    {
        // é responsável por exibir as informações ao utilizador

        public static void MostraInformação(string nome, int idade) 
        {
            Console.WriteLine("=== Estudante ===");
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Idade: " + idade);
        }
    }
}
