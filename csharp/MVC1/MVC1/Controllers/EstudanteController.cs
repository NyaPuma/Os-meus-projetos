using System;
using System.Collections.Generic;
using System.Text;
using MVC1.Models;
using MVC1.Views;

namespace MVC1.Controllers
{
    public class EstudanteController(Estudante model, EstudanteView view)
    {
        // é intermediário entre o model e a view
        private readonly Estudante _model = model ?? throw new ArgumentNullException(nameof(model));
        private readonly EstudanteView _view = view ?? throw new ArgumentNullException(nameof(view));

        public void DefinirNome(string nome)
        {
            _model.Nome = nome; // atualização do model
        }

        public void DefinirIdade(int idade)
        {
            try
            {
                _model.Idade = idade; // atualização do model, pode lançar exceção se a idade for menor que 18
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public void AtualizarView()
        {
            EstudanteView.MostraInformação(_model.Nome, _model.Idade);
        }
    }
}

