using System.Diagnostics.Metrics;

namespace Exercicio_3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  3.1 Escreva um programa que:                      :::::
            // :::::                                                    :::::
            // :::::  • Leia DOIS VALORES do teclado(números decimais)  :::::
            // :::::  • Calcule a diferença entre o MAIOR e o MENOR     :::::
            // :::::  • IMPLEMENTE UM MÉTODO que:                       :::::
            // :::::   Receba os 2 valores como parâmetros;            :::::
            // :::::   Faça o cálculo da diferença;                    :::::
            // :::::   Mostre o resultado na consola;                  :::::
            // :::::                                                    :::::
            // :::::  Nota: O Main() só LÊ os valores e CHAMA o método  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Digite o primeiro valor:");
            double valor1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o segundo valor:");
            double valor2 = double.Parse(Console.ReadLine());

            double diferenca = Diferenca(valor1, valor2);
            Mensagem(valor1, valor2, diferenca);

        }

        static public double Diferenca(double valor1, double valor2)
        {
            if (valor1 > valor2)
            {
                return valor1 - valor2;
            }
            else
            {
                return valor2 - valor1;
            }
        }

        static void Mensagem(double valor1, double valor2, double diferenca)
        {
                Console.WriteLine($"O valor de diferença é de {diferenca}");
        }
    }
}
