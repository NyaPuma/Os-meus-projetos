using System.Net;

namespace Exercicio_2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Desenvolva um programa do tipo console em C# que permita ao utilizador inserir 5 números inteiros e 5 palavras.  :::::
            // :::::  Em seguida o programa deve realizar as seguintes operações:                                                      :::::
            // :::::  • Calcular a soma e o produto de todos os números inseridos.                                                     :::::
            // :::::  • Calcular o produto de todos os números inseridos.                                                              :::::
            // :::::  • Exibir a soma e o produto dos números inseridos.                                                               :::::
            // :::::  • Concatenar todas as palavras e exibir a frase resultante.                                                      :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // :::::::::::::::::::::::::::::::::::::::::
            // :::::  Arrays para armazenar dados  :::::
            // :::::::::::::::::::::::::::::::::::::::::

            int[] numeros = new int[5];
            string[] nomes = new string[5];

            int somaprodutos = 0;
            int produto = 1;

            string concatnomes = "";

            // ::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Preencher um vetor com números  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Digite o " + (i + 1) + "ª número:");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Digite o " + (i + 1) + "ª nome:");
                nomes[i] = Console.ReadLine();
            }

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Calcular a soma e o produto dos numeros + concatenar os nomes  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            for (int i = 0; i < 5; i++)
            {
                somaprodutos += numeros[i]; // soma = soma + numeros[i]
                produto *= numeros[i]; // produto = produto anterior * numeros[i]
                concatnomes += nomes[i]; // frase = frase + palavra na posição
            }

            Console.WriteLine("A soma é de " + somaprodutos + " e o produto é de " + produto);
            Console.WriteLine("A concatenação dos nomes dá " + concatnomes);
        
        }
    }
}
