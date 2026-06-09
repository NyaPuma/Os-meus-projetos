using System;
using System.Collections.Generic;
using System.Linq; // OBRIGATÓRIO para o método .Sum() funcionar
using System.Text;

namespace Dominio
{
    public class Carrinho
    {
        // Uma lista de produtos
        public List<Produto> Produtos { get; set; } = [];

        // Método AdicionarProduto(Produto produto)
        public void AdicionarProduto(Produto produto)
        {
            if (produto == null) return;

            // Integração com a sua regra de negócio: só adiciona se tiver stock
            if (produto.TemStock())
            {
                Produtos.Add(produto);
                Console.WriteLine($"{produto.Nome} adicionado ao carrinho.");
            }
            else
            {
                Console.WriteLine($"Não foi possível adicionar {produto.Nome}: Produto sem stock.");
            }
        }

        // Método Total()
        public double Total()
        {
            // Utiliza o LINQ para somar o preço de todos os produtos
            return Produtos.Sum(p => p.Preco);
        }

        // Método TotalProdutos()
        public int TotalProdutos()
        {
            // Devolve a quantidade de itens na lista
            return Produtos.Count;
        }
    }
}