namespace TesteUnitarioCalculadora
{
    // 4. Execução dos testes (Ponto de Entrada)
    internal class Program
    {
        static void Main()
        {
            // Instanciação da classe de testes de acordo com o requisito 4
            _ = new // Instanciação da classe de testes de acordo com o requisito 4
            CalculadoraTests();

            // Executa todos os cenários sem interromper abruptamente o programa
            CalculadoraTests.ExecutarTodosOsTestes();

            // Mantém a consola aberta para leitura do relatório
            Console.ReadLine();
        }
    }
}