using System.Collections;
using System.Security.Cryptography;

namespace POO_Ficha2_Exercicio2
{
    internal class Program
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Criar um programa em C# que faça a gestão uma lista de objetos da classe Produto,     ::::: //
        // ::::: aplicando os conceitos de POO e coleções genéricas.                                   ::::: //
        // ::::: Requisitos                                                                            ::::: //
        // ::::: 1. Criar uma classe chamada Produto com:                                              ::::: //
        // :::::     Atributos privados: nome(string) e preco(double).                                ::::: //
        // :::::     Construtor para inicializar os atributos.                                        ::::: //
        // :::::     Propriedades públicas(ou métodos Get/Set) para aceder aos dados.                 ::::: //
        // ::::: 2. No Main, criar uma List<Produto>.                                                  ::::: //
        // ::::: 3. Adicionar pelo menos 3 objetos Produto à lista (usando new Produto(...)).          ::::: //
        // ::::: 4. Utilizar métodos de List<T> para:                                                  ::::: //
        // :::::     Ordenar os produtos pelo preço (usando OrderBy ou Sort com um comparador.        ::::: //
        // :::::     Calcular a média de preços da lista(usando LINQ Average ou um ciclo).            ::::: //
        // :::::     Remover um produto específico da lista.                                          ::::: //
        // ::::: 5. Criar um método para mostrar todos os produtos da lista com o seu preço formatado. ::::: //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            // ::::: 2. Criar uma List<Produto> ::::: //
            List<Produto> listaProdutos =
            [
                // ::::: 3. Adicionar pelo menos 3 objetos ::::: //
                new Produto("Monitor", 180.50),
                new Produto("Teclado", 45.90),
                new Produto("Rato", 25.00),
            ];

            Console.WriteLine("--- Lista Original ---");
            MostrarLista(listaProdutos);

            // ::::: 4. Ordenar os produtos pelo preço (Crescente) ::::: //
            var listaOrdenada = listaProdutos.OrderBy(static p => p.Preco).ToList();
            Console.WriteLine("\n--- Lista Ordenada por Preço ---");
            MostrarLista(listaOrdenada);

            // ::::: 4. Calcular a média de preços ::::: //
            double media = listaProdutos.Average(static p => p.Preco);
            Console.WriteLine($"\nA média de preços é: {media:C2}");

            // ::::: 4. Remover um produto específico (Ex: Teclado) ::::: //
            listaProdutos.RemoveAt(1);
            Console.WriteLine("\nProduto 'Teclado' removido.");

            // ::::: Mostra a lista final ::::: //
            Console.WriteLine("\n--- Lista Final ---");
            MostrarLista(listaProdutos);

        }

        // ::::: 5. Método para mostrar todos os produtos formatados ::::: //
        static void MostrarLista(List<Produto> lista)
        {
            foreach (var p in lista)
            {
                // ::::: :C2 formata para Moeda (Currency) ::::: //
                Console.WriteLine($"Produto: {p.Nome,-10} | Preço: {p.Preco:C2}");
            }
        }
    }
}
