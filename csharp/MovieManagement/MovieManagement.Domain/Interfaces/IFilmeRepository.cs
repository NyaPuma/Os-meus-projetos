using Movie_Management_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Management_Domain.Interfaces
{
    public interface IFilmeRepository
    {
        // Isolar o acesso aos dados da lógica de negócio

        public void Adicionar(Filme filme);

        public List<Filme> ObterTodos();

        public Filme? ObterPorTitulo(string titulo);

        public bool Remover(int id);
    }
}
