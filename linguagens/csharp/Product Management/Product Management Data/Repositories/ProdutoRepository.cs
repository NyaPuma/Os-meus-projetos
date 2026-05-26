using System;
using System.Collections.Generic;
using Product_Management_Domain.Entities;
using Product_Management_Domain.Interfaces;

namespace Product_Management_Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> _produtos;
        private int _proximoId;

        public ProdutoRepository()
        {
            _produtos = new List<Produto>();
            _proximoId = 1;
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = _proximoId;
            _proximoId++;

            _produtos.Add(produto);
        }

        public List<Produto> ObterTodos()
        {
            return _produtos;
        }

        public Produto? ObterPorNome(string nome)
        {
            foreach(Produto p in _produtos)
            {
                if(p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
