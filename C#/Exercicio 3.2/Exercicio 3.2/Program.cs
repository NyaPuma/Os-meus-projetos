using System.Security.Cryptography;

namespace Exercicio_3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: 3.2 Desenvolva um programa do tipo console em C# que permita a ou utilizador converter :::::
            // ::::: temperaturas de Celsius para Fahrenheit e vice-versa.                                  :::::
            // :::::                                                                                        :::::
            // ::::: O programa deve apresentar um menu com as seguintes opções:                            :::::
            // :::::    1 - Converter de Celsius para Fahrenheit                                            :::::
            // :::::    2 - Converter de Fahrenheit para Celsius                                            :::::
            // :::::    3 - Sair                                                                            :::::
            // :::::                                                                                        :::::
            // ::::: Implemente métodos.                                                                    :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            int opcao = 0;

            while (opcao != 3)
            {
                Menu();
                opcao = Escolhamenu(opcao);

                if (opcao == 1 || opcao == 2)
                {
                    double resultado = ConversorDeTemperatura(opcao);
                    Console.WriteLine($"O resultado da conversão é: {resultado:F2}");
                    Console.WriteLine("-----------------------------------------------------------------------");
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("A sair do programa...");
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.WriteLine("-----------------------------------------------------------------------");
                }

            }

            static double ConversorDeTemperatura(int opcao)
            {
                double valorInput;

                if (opcao == 1)
                {
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.Write("Digite o valor em Celsius: ");
                    valorInput = double.Parse(Console.ReadLine());
                    // Fórmula: (C * 9/5) + 32
                    return (valorInput * 9 / 5) + 32;
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.Write("Digite o valor em Fahrenheit: ");
                    valorInput = double.Parse(Console.ReadLine());
                    // Fórmula: (F - 32) * 5/9
                    return (valorInput - 32) * 5 / 9;
                }
            }

            static void Menu()
            {
                Console.WriteLine("1 - Converter de Celsius para Fahrenheit");
                Console.WriteLine("2 - Converter de Fahrenheit para Celsius");
                Console.WriteLine("3 - Sair");
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            static int Escolhamenu(int opcao)
            {
                Console.WriteLine("Digite um valor:");
                return int.Parse(Console.ReadLine());
            }
        }
    }
}