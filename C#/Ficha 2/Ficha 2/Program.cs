namespace Ficha_2
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // :::::::::::::::::::::::::::::::::::::::::::
            // :::::  Leitura e escrita de um array  :::::
            // :::::::::::::::::::::::::::::::::::::::::::

            // ::::::::::::::::::::::::::::::::::::
            // :::::  Declarar e inicializar  :::::
            // ::::::::::::::::::::::::::::::::::::

            int[] vetor1 = { 10, 20, 30, 40, 50 };
            Console.WriteLine(vetor1[0]);  // Mostra o primeiro elemento - 10
            Console.WriteLine(vetor1[4]);  // Mostra o ultimo elemento - 50

            foreach (int valor in vetor1)
            {
                Console.WriteLine(valor);
            }

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Apagar e escrever em cima de outro elemento a partir de input do utilizador  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            vetor1[1] = int.Parse(Console.ReadLine());

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Percorrer todos os elementos por indice  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::

            for (int i = 0; i < vetor1.Length; i++)
            {
                Console.WriteLine(vetor1[i]);
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  é o utilizador que vai defenir o tamanho do array   :::::
            // :::::  vai ser ele tambem que vai preencher e              :::::
            // :::::  vai inicializar um vetor de tamanho N (utilizador)  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Qual o tamanho?:");
            int N = int.Parse(Console.ReadLine());
            int[] lista = new int[N];

            // :::::::::::::::::::::::::::::::::::
            // :::::  Preenchimento do vetor :::::
            // :::::::::::::::::::::::::::::::::::

            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine("Insira um valor para posição " + i);
                lista[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine("Vetor do utilizador");
                Console.WriteLine(lista[i]);
            }
        }
    }
}
