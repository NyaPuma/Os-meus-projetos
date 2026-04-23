namespace Exercicio_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Ler o vetor de 10 numeros inteiros positivos  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            
            int[] numeros = new int[10];  // declaração e alocação na memória

            // :::::::::::::::::::::::::::::::::::
            // :::::  Preenchimento do vetor :::::
            // :::::::::::::::::::::::::::::::::::

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine("Insira um valor para posição " + i);
                numeros[i] = int.Parse(Console.ReadLine());

                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::
                // :::::  Validação - tem de ser um número inteiro  :::::
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::

                while (numeros[i] <= 0)
                {
                    Console.WriteLine("O número tem que ser maior que 0. Insira novamente: ");
                    numeros[i] = int.Parse(Console.ReadLine());
                }
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Pede ao utilizador um valor para X  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Digite um número para X");
            int x = int.Parse(Console.ReadLine());

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Validação - tem de ser um número inteiro  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::

            while (x <= 0)
            {
                Console.WriteLine("O número tem que ser maior que 0. Insira novamente:");
                x = int.Parse(Console.ReadLine());
            }

            // :::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Contar os maiores, menores e iguais  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::

            int maior = 0;
            int menor = 0;
            int igual = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == x)
                {
                    igual = igual + 1;
                }

                else if (numeros[i] >= x)
                {
                    maior = maior + 1;
                }

                else
                {
                    menor = menor + 1;
                }
            }

        }
    }
}
