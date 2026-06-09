using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Explicacao_listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::: Criar uma lista para armazenar valores ::::: //

            // ::::: Declaração e construção do objeto para depois adicionar ::::: //
            List<int> numeros = new List<int>();
            numeros.Add(10);
            numeros.Add(100);
            numeros.Add(1000);

            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            numeros.Add(10000);
            Console.WriteLine("Nova Lista");

            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            // ::::: Declarar e instanciar ao mesmo tempo ::::: //

            List<string> listaFrutas = new List<string>()
            {"maçã", "pera", "morango", "laranja", "maracuja", "banana", "melão", "abacaxi"};

            foreach (string n in listaFrutas)
            {
                Console.Write(n + " ");
            }

            // ::::: Pedir ao utilizador para preeencher a minha lista ::::: //

            List<int> codigo = new List<int>(); // Lista vazia para ser preenchida pelo utilizador

            Console.WriteLine("Insira o seu código:");
            Console.WriteLine("Quantos códigos deseja inserir?");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidade; i++) // Adicionado o limite 'quantidade'
            {
                Console.WriteLine($"Código {i + 1}:");
                int cod = int.Parse(Console.ReadLine());
                codigo.Add(cod);
            }

            // ::::: 2 Insert e Remove ::::: //

            // ::::: Vamos inserir na posição 2 a fruta pitaia ::::: //
            listaFrutas.Insert(2, "pitaia");
            Console.WriteLine("INSERT");
            ExibirLista(listaFrutas);

            // ::::: Remover a fruta maçã ::::: //
            listaFrutas.Remove("maçã");
            Console.WriteLine("REMOVE");
            ExibirLista(listaFrutas);

            // ::::: Remover por posição ::::: //
            listaFrutas.RemoveAt(5);
            Console.WriteLine("REMOVEAT");
            ExibirLista(listaFrutas);

            // ::::: Remover a partir de uma condição ::::: //
            // ::::: Vamos eliminar todos os elementos começados por l ::::: //
            listaFrutas.RemoveAll(f => f.StartsWith("l"));
            Console.WriteLine("REMOVEALL - Por condição");
            ExibirLista(listaFrutas);

            // ::::: Procura CONTAINS ::::: //
            Console.WriteLine("Qual a fruta que deseja procurar?: ");
            string procura = Console.ReadLine();

            if (listaFrutas.Contains(procura))
            {
                int indice = listaFrutas.IndexOf(procura);
                Console.WriteLine("Existe esse elemento na posição " + indice);
            }
            else
            {
                Console.WriteLine("Não existe o elemento");
            }

            // ::::: ORDENAÇÃO: SORT e REVERSE ::::: //
            Console.WriteLine("Lista ordenada de A até Z - Ascendente");
            listaFrutas.Sort();
            ExibirLista(listaFrutas);

            Console.WriteLine("Lista ordenada do Z até ao A - Descendente");
            listaFrutas.Reverse();
            ExibirLista(listaFrutas);

            // ::::: Consultas LINQ ::::: //
            var consulta = listaFrutas.Where(f => f.StartsWith("a"));
            Console.WriteLine("Mostrar resultado da consulta");

            foreach (string item in consulta) 
            {
                Console.WriteLine(item + " ");
            }

            var consulta2 = listaFrutas.Select(f => f.ToUpper()).ToList();
            Console.WriteLine("Mostrar consulta maiusculas");
            foreach (string item in consulta2)
            {
                Console.WriteLine(item + " ");
            }
        }

        // ::::: Criar a função para exibir a lista ::::: //
        static void ExibirLista(List<string> lista) 
        {
            foreach (string f in lista) 
            {
                Console.WriteLine(f + " ");
            }
        }
    }
}
