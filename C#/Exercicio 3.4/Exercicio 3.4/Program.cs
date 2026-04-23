namespace Exercicio_3._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExecutarCalculadora();
        }

        static void ExecutarCalculadora()
        {
            while (true)
            {
                MostrarMenu();
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                    continue;
                }

                opcao = opcao.Trim().ToLowerInvariant();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Resultado: {Somar(LerDouble("Primeiro número: "), LerDouble("Segundo número: "))}\n");
                        break;
                    case "2":
                        Console.WriteLine($"Resultado: {Subtrair(LerDouble("Primeiro número: "), LerDouble("Segundo número: "))}\n");
                        break;
                    case "3":
                        Console.WriteLine($"Resultado: {Multiplicar(LerDouble("Primeiro número: "), LerDouble("Segundo número: "))}\n");
                        break;
                    case "4":
                        {
                            double a = LerDouble("Dividendo: ");
                            double b = LerDouble("Divisor: ");
                            var resultado = Dividir(a, b, out var sucesso);
                            if (sucesso)
                                Console.WriteLine($"Resultado: {resultado}\n");
                            else
                                Console.WriteLine("Erro: divisão por zero.\n");
                        }
                        break;
                    case "5":
                        {
                            double a = LerDouble("Número: ");
                            var sucesso = TentarRaizQuadrada(a, out var resultado);
                            if (sucesso)
                                Console.WriteLine($"Resultado: {resultado}\n");
                            else
                                Console.WriteLine("Erro: raiz quadrada de número negativo.\n");
                        }
                        break;
                    case "6":
                        Console.WriteLine($"Resultado: {Potencia(LerDouble("Base: "), LerDouble("Expoente: "))}\n");
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("--- Máquina de Calcular ---");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Raiz quadrada");
            Console.WriteLine("6 - Potência");
            Console.WriteLine("7 - Sair");
        }

        static double LerDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var value))
                    return value;

                // Try with current culture (e.g., comma decimal)
                // Tenta com a cultura atual (por exemplo, vírgula como separador decimal)
                if (double.TryParse(s, out value))
                    return value;

                Console.WriteLine("Entrada inválida. Introduza um número válido.");
            }
        }

        static double Somar(double a, double b) => a + b;
        static double Subtrair(double a, double b) => a - b;
        static double Multiplicar(double a, double b) => a * b;
        static double Dividir(double a, double b, out bool sucesso)
        {
            if (b == 0)
            {
                sucesso = false;
                return double.NaN;
            }
            sucesso = true;
            return a / b;
        }

        static bool TentarRaizQuadrada(double a, out double resultado)
        {
            if (a < 0)
            {
                resultado = double.NaN;
                return false;
            }
            resultado = Math.Sqrt(a);
            return true;
        }

        static double Potencia(double @baseValor, double expoente) => Math.Pow(@baseValor, expoente);
    }
}
