using System;
using System.Collections.Generic;
using Movie_Management_Domain.Entities;
using Movie_Management_Domain.Interfaces;

namespace Movie_Management_Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly List<Filme> _filmes;
        private int _proximoId;

        public FilmeRepository()
        {
            _filmes = new List<Filme>();
            _proximoId = 1;
        }

        public void Adicionar(Filme filme)
        {
            filme.Id = _proximoId;
            _proximoId++;

            _filmes.Add(filme);
        }

        public List<Filme> ObterTodos()
        {
            return _filmes;
        }

        public Filme? ObterPorTitulo(string titulo)
        {
            foreach(Filme f in _filmes)
            {
                if(f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return f;
                }
            }
            return null;
        }

        public bool Remover(int id)
        {
            Filme? filme = _filmes.Find(f => f.Id == id);
            if (filme != null)
            {
                _filmes.Remove(filme);
                return true;
            }
            return false;
        }
    }
}
