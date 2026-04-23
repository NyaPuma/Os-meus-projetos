namespace Exercicio_3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: 3.3 Faça um programa do tipo console em C# que simule um conversor de moeda,               :::::
            // ::::: usando taxas de cambio fixas(taxa dólar = 1.12 e taxa libra= 0.85) e uma opção que permita :::::
            // ::::: ao utilizador definir o nome da moeda e a taxa de cambio para realizar a conversão:        :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            int opcao = 0;
            int quantidade = 0;

            while (opcao != 4)
            {
                Menu();
                opcao = Escolhamenu(opcao);

                if (opcao == 1 || opcao == 2 || opcao == 3)
                {
                    quantidade = Quantidade(quantidade);
                    double resultado = ConversorMoeda(opcao);
                    Console.WriteLine($"O resultado da conversão é: {resultado * quantidade:F2}");
                    Console.WriteLine("-----------------------------------------------------------------------");
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("A sair do programa...");
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.WriteLine("-----------------------------------------------------------------------");
                }
            }
        }

        static double ConversorMoeda(int opcao)
        {
            // ::::: Conversor dólar :::::
            if (opcao == 1) 
            {
                double dolar = 1.12;
                return dolar / 1;
            }
            // ::::: Conversor libra :::::
            else if (opcao == 2)
            {
                double libra = 0.85;
                return libra / 1;
            }
            // ::::: Conversor moeda customizada :::::
            else if (opcao == 3)
            {
                Console.WriteLine("Indique a taxa de cambio da sua moeda");
                double outramoedavalor = double.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------------------------");
                return outramoedavalor / 1;
            }
            else
            {
                return 0.0;
            }
        }

        static void Menu()
        {
            Console.WriteLine("=== Conversor de moeda ===");
            Console.WriteLine("1 - Converter euros para dólares");
            Console.WriteLine("2 - Converter euros para libras");
            Console.WriteLine("3 - Converter euros para outra moeda");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        static int Escolhamenu(int opcao)
        {
            Console.WriteLine("Escolha uma opção do menu:");
            return int.Parse(Console.ReadLine());
        }

        static int Quantidade(int quantidade)
        {
            Console.WriteLine("Escolha a quantidade de euros a converter:");
            return int.Parse(Console.ReadLine());
        }
    }
}
