using MVC1.Models;
using MVC1.Views;
using MVC1.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC1
{
    internal class program
    {
        static void Main(string[] args)
        {
            try
            {
                // model
                Estudante estudante = new();

                // view
                EstudanteView view = new();

                // controller
                EstudanteController controller = new(estudante, view);

                controller.DefinirNome("João");
                controller.DefinirIdade(20);

                // mostrar dados
                controller.AtualizarView();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
