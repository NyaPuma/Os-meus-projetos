using Product_Management_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Management_Domain.Interfaces
{
    public interface IProdutoRepository
    {
        // Isolar o acesso aos dados da lógica de negócio

        public void Adicionar(Produto produto);

        public List<Produto> ObterTodos();

        public Produto? ObterPorNome(string nome);
    }
}
