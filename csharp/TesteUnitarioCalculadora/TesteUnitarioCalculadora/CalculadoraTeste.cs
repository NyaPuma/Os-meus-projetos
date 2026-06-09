namespace TesteUnitarioCalculadora
{
    // 2. Classe de testes
    internal class CalculadoraTests
    {
        // Instanciação da classe Calculadora como campo da classe de testes
        private readonly Calculadora _calculadora = new();

        // Método auxiliar para formatar o output dos testes de forma clara
        private static void ValidarResultado(string nomeTeste, int resultadoObtido, int resultadoEsperado)
        {
            if (resultadoObtido == resultadoEsperado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASSOU] {nomeTeste}: {resultadoObtido} == {resultadoEsperado}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FALHOU] {nomeTeste}: Obtido {resultadoObtido}, Esperado {resultadoEsperado}");
            }
            Console.ResetColor();
        }

        // 3. Implementação dos Casos de Teste Obrigatórios
        public static void ExecutarTodosOsTestes()
        {
            Console.WriteLine("=== A Iniciar Testes Unitários Manuais ===\n");

            // --- Testes de Soma ---
            ValidarResultado("Soma (2 + 3)", Calculadora.Somar(2, 3), 5);
            ValidarResultado("Soma (-2 + -3)", Calculadora.Somar(-2, -3), -5);

            // --- Testes de Subtração ---
            ValidarResultado("Subtração (10 - 3)", Calculadora.Subtrair(10, 3), 7);
            ValidarResultado("Subtração (5 - 10)", Calculadora.Subtrair(5, 10), -5);

            // --- Testes de Multiplicação ---
            ValidarResultado("Multiplicação (2 x 3)", Calculadora.Multiplicar(2, 3), 6);
            ValidarResultado("Multiplicação (5 x 0)", Calculadora.Multiplicar(5, 0), 0);

            // --- Testes de Divisão ---
            ValidarResultado("Divisão (10 ÷ 2)", Calculadora.Dividir(10, 2), 5);
            ValidarResultado("Divisão (9 ÷ 3)", Calculadora.Dividir(9, 3), 3);

            Console.WriteLine("\n=== Testes Concluídos ===");
        }
    }
}