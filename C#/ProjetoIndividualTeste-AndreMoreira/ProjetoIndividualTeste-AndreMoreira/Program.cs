namespace ProjetoIndividualTeste_AndreMoreira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Valores de PM10 para os últimos 7 dias (exemplo) ::::: //
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            int[] valores = [45, 55, 60, 50, 40, 38, 19];

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Loop principal da aplicação: apresenta um menu até o utilizador escolher sair ::::: //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            while (true)
            {
                try
                {   
                    // ::::::::::::::::::::::::: //
                    // ::::: Mostra o Menu ::::: //
                    // ::::::::::::::::::::::::: //
                    Menu();

                    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                    // ::::: Pede input ao utilizador sobre o que pretende aceder ::::: //
                    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int opcao))
                    {
                        Console.WriteLine("Letra, número decimal ou espaço em branco introduzido. Tente novamente com um número inteiro.");
                        continue;
                    }

                    Console.WriteLine();
                    switch (opcao)
                    {
                        // ::::::::::::::::::::::::::::::::::::: //
                        // ::::: Mostra valores dos 7 dias ::::: //
                        // ::::::::::::::::::::::::::::::::::::: //
                        case 1:
                            MostrarValores(valores);
                            break;

                        // :::::::::::::::::::::::::::::::::::::::: //
                        // ::::: Classifica cada valor diário ::::: //
                        // :::::::::::::::::::::::::::::::::::::::: //
                        case 2:
                            ClassificarDiario(valores);
                            break;

                        // ::::::::::::::::::::::::::::::::::::::::::::::: //
                        // ::::: Calcula e apresenta a média semanal ::::: //
                        // ::::::::::::::::::::::::::::::::::::::::::::::: //
                        case 3:
                            double media = CalcularMediaSemanal(valores);
                            Console.WriteLine($"Média semanal: {media:F2} µg/m³");
                            break;

                        // ::::::::::::::::::::::::::::::::::::::::::::::::: //
                        // ::::: Classifica a semana com base na média ::::: //
                        // :::::::::::::::::::::::::::::::::::::::::::::::::: //
                        case 4:
                            double mediaSemana = CalcularMediaSemanal(valores);
                            string classificacaoSemana = ClassificarValor((int)Math.Round(mediaSemana));
                            Console.WriteLine($"Média semanal: {mediaSemana:F2} µg/m³ - Classificação da semana: {classificacaoSemana}");
                            break;

                        // ::::::::::::::::::::::::::: //
                        // ::::: Sai do programa ::::: //
                        // ::::::::::::::::::::::::::: //
                        case 5:
                            Console.WriteLine("A sair...");
                            return;

                        // :::::::::::::::::::::::::::::::::::::::: //
                        // ::::: Opção para valores inválidos ::::: //
                        // :::::::::::::::::::::::::::::::::::::::: //
                        default:
                            Console.WriteLine("O número escolhido não existe no menu. Tente novamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                    // ::::: Captura exceções inesperadas no loop principal e informa o utilizador ::::: //
                    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Mostra os valores de PM10 dia a dia ::::: //
        // ::::::::::::::::::::::::::::::::::::::::::::::: //
        static void MostrarValores(int[] valores)
        {
            try
            {
                // ::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Mostra os valores de PM10 dia a dia ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::::: //
                Console.WriteLine("Valores de PM10 por dia:");
                for (int i = 0; i < valores.Length; i++)
                {
                    Console.WriteLine($"Dia {i + 1}: {valores[i]} µg/m³");
                }
            }
            catch (Exception ex)
            {
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Em caso de erro devolve uma mensagem genérica ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                Console.WriteLine($"Erro ao mostrar valores: {ex.Message}");
            }
        }

        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Classifica cada valor diário utilizando ClassificarValor ::::: //
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        static void ClassificarDiario(int[] valores)
        {
            try
            {
                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Classifica cada valor diário utilizando ClassificarValor ::::: //
                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                Console.WriteLine("Classificação diária:");
                for (int i = 0; i < valores.Length; i++)
                {
                    string classificacao = ClassificarValor(valores[i]);
                    Console.WriteLine($"Dia {i + 1}: {valores[i]} µg/m³ - {classificacao}");
                }
            }
            catch (Exception ex)
            {
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Em caso de erro devolve uma mensagem genérica ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                Console.WriteLine($"Erro ao classificar valores diários: {ex.Message}");
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Classifica um único valor de PM10 ::::: //
        // ::::::::::::::::::::::::::::::::::::::::::::: //
        static string ClassificarValor(int valor)
        {
            try
            {
                // ::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Classifica um único valor de PM10 ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::: //
                if (valor < 0) return "Valor inválido";
                if (valor <= 20) return "Bom";
                if (valor <= 50) return "Moderado";
                return "Mau";
            }
            catch (Exception ex)
            {
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Em caso de erro devolve uma mensagem genérica ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                Console.WriteLine($"Erro ao classificar valor: {ex.Message}");
                return "Erro";
            }
        }

        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Calcula a média semanal dos valores fornecidos ::::: //
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        static double CalcularMediaSemanal(int[] valores)
        {
            try
            {
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Verifica se o valor é nulo ou o comprimento é 0 ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                if (valores == null || valores.Length == 0) return 0.0;

                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Calcula a média semanal dos valores fornecidos ::::: //
                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                int soma = 0;
                for (int i = 0; i < valores.Length; i++)
                {
                    soma += valores[i];
                }
                return (double)soma / valores.Length;
            }
            catch (Exception ex)
            {
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                // ::::: Em caso de erro devolve uma mensagem genérica ::::: //
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
                Console.WriteLine($"Erro ao calcular média semanal: {ex.Message}");
                return 0.0;
            }
        }

        // :::::::::::::::: //
        // ::::: Menu ::::: //
        // :::::::::::::::: //
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Monitorização PM10 - Braga (7 dias)");
            Console.WriteLine("1 - Mostrar valores dos 7 dias");
            Console.WriteLine("2 - Classificar cada valor diário");
            Console.WriteLine("3 - Calcular e apresentar a média semanal");
            Console.WriteLine("4 - Classificar a semana com base na média");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
        }
    }
}
