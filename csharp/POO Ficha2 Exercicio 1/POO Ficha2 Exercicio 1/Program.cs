using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace POO_Ficha2_Exercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Criar um programa em C# que permita gerir uma lista de produtos, utilizando os ::::: //
            // ::::: principais métodos da classe List<T>.                                          ::::: //
            // ::::: Requisitos:                                                                    ::::: //
            // :::::     1.Criar uma lista de produtos(nomes do tipo string).                       ::::: //
            // :::::     2.Criar um método MostrarLista(List<string> lista, string mensagem) que    ::::: //
            // :::::     imprima a lista atual e uma mensagem descritiva da operação realizada.     ::::: //
            // :::::     3.Utilizar o método MostrarLista após cada uma das operações seguintes:    ::::: //
            // :::::          Adicionar: Adicionar produtos à lista(método Add).                   ::::: //
            // :::::          Remover por nome: Remover um produto pelo nome                       ::::: //
            // :::::         (método Remove).                                                       ::::: //
            // :::::          Remover por índice: Remover um produto pelo índice                   ::::: //
            // :::::         (método RemoveAt).                                                     ::::: //
            // :::::          Verificar: Verificar se um produto existe na lista(método Contains). ::::: //
            // :::::          Contar: Contar o número total de produtos(propriedade Count).        ::::: //
            // :::::          Ordenar: Ordenar os produtos alfabeticamente(método Sort).           ::::: //
            // :::::          Procurar: Encontrar um produto que começa por uma determinada        ::::: //
            // :::::        letra(método Find).                                                     ::::: //
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            ////////////////////////////////////////////////////////////////////////////////////////////////

            // ::::::::::::::::::::::::::::::::::::: //
            // ::::: Criar a lista de produtos ::::: //
            // ::::::::::::::::::::::::::::::::::::: //
            List<string> produtos = ["Monitor", "Teclado", "Rato", "Auscultadores", "Tapete"];
            MostrarLista(produtos, "Adição de produtos iniciais");

            // ::::::::::::::::::::::::::: //
            // ::::: Adicionar (Add) ::::: //
            // ::::::::::::::::::::::::::: //

            produtos.Add("Cadeira");
            MostrarLista(produtos, "Adição do produto 'Cadeira'");

            // ::::::::::::::::::::::::::::::::::::: //
            // ::::: Remover por nome (Remove) ::::: //
            // ::::::::::::::::::::::::::::::::::::: //
            produtos.Remove("Teclado");
            MostrarLista(produtos, "Remoção do produto 'Teclado'");

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Remover por índice (RemoveAt)                  ::::: //
            // ::::: Remove o primeiro elemento da lista (índice 0) ::::: //
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            produtos.RemoveAt(0);
            MostrarLista(produtos, "Remoção do produto no índice 0");

            // :::::::::::::::::::::::::::::::: //
            // ::::: Verificar (Contains) ::::: //
            // :::::::::::::::::::::::::::::::: //
            string busca = "Rato";
            bool existe = produtos.Contains(busca);
            MostrarLista(produtos, "Verificar: O produto " + busca + " existe na lista?");
            Console.WriteLine(" ");
            if (existe == true) 
            {
                Console.WriteLine("Sim, existe");
            }
            else
            {
                Console.WriteLine("Não existe na lista");
            }

            // :::::::::::::::::::::::::: //
            // ::::: Contar (Count) ::::: //
            // :::::::::::::::::::::::::: //
            int total = produtos.Count;
            MostrarLista(produtos, "Contar: Total de produtos na lista");
            Console.WriteLine(" ");
            Console.WriteLine("O número total de produtos na lista é de " + total);

            // :::::::::::::::::::::::::: //
            // ::::: Ordenar (Sort) ::::: //
            // :::::::::::::::::::::::::: //
            produtos.Sort();
            MostrarLista(produtos, "Lista ordenada alfabeticamente");

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Procurar (Find)                                        ::::: //
            // ::::: Encontra o primeiro produto que começa com a letra 'T' ::::: //
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            string produtoComT = produtos.Find(p => p.StartsWith("T"));
            MostrarLista(produtos, "Procurar: Primeiro produto que começa com 'T'");
            Console.WriteLine(" ");
            Console.WriteLine("O primeiro produto que começa com 'T': " + produtoComT);
        }

        static void MostrarLista(List<string> lista, string mensagem)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"OPERAÇÃO: {mensagem}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            if (lista.Count == 0)
            {
                Console.WriteLine("A lista está vazia.");
            }
            else
            {
                foreach (string p in lista)
                {
                    Console.WriteLine($"- {p}");
                }
            }
        }
    }
}
