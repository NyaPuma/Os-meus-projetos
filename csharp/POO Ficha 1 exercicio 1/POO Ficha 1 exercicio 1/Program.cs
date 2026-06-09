using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace POO_Ficha_1_exercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Exercício 1 - Círculo                                                                   ::::: //
            // ::::: Implementar uma classe em C# que represente uma figura geométrica do tipo círculo,      ::::: //
            // ::::: aplicando os conceitos de programação orientada a objetos.                              ::::: //
            // ::::: Requisitos                                                                              ::::: //
            // :::::  Criar uma classe chamada Círculo.                                                     ::::: //
            // :::::  A classe deve possuir um atributo privado chamado raio(do tipo double).               ::::: //
            // :::::  Criar um construtor que permita inicializar o valor do raio.                          ::::: //
            // :::::  Criar métodos públicos para calcular a área do círculo e a circunferência do círculo. ::::: //           
            // :::::  Utilizar as fórmulas:                                                                 ::::: //
            // ::::: Área = π × raio²                                                                        ::::: //
            // ::::: Circunferência = 2 × π × raio.                                                          ::::: //
            // :::::  Demonstrar o funcionamento da classe num programa principal(Main), criando            ::::: //
            // ::::: um objeto circulo e apresentando os resultados dos cálculos.                            ::::: //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

            // ::::: 1. Instanciar um objeto da classe Círculo com um raio ::::: //
            Console.WriteLine("Insira um valor para lado:");
            string input = Console.ReadLine();
            input = input.Replace(',', '.');

            if (double.TryParse(input, CultureInfo.InvariantCulture, out double raio))
            {
                Círculo meuCirculo = new Círculo(raio);

                // ::::: 2. Chamar os métodos e armazenar os resultados ::::: //
                double area = meuCirculo.CalcularArea();
                double circunferencia = meuCirculo.CalcularCircunferencia();

                // ::::: 3. Exibir os resultados formatados (com 2 casas decimais) ::::: //
                Console.WriteLine("\n--- Resultados do Círculo ---");
                Console.WriteLine($"Raio: {raio:F2}");
                Console.WriteLine($"Área: {area:F2}");
                Console.WriteLine($"Circunferência: {circunferencia:F2}");
            }
            else
            {
                Console.WriteLine("Erro: O valor inserido não é um número válido.");
            }
        }
    }
}
