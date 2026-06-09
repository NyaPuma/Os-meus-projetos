using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_Ficha3_Exercicio2
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um programa que gere Clientes e os seus Dados Pessoais.O objetivo é      ::::: //
    // ::::: aplicar o conceito de Composição, onde as informações de identificação do cliente   ::::: //
    // ::::: fazem parte do "todo".                                                              ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Funcionalidades                                                                     ::::: //
    // :::::    1. Criar um Cliente(nome e numeroCliente).                                       ::::: //
    // :::::    2. Definir os Dados Pessoais(Morada, Email, NIF, Data de Nascimento,             ::::: //
    // :::::    Telemovel) no momento da criação do cliente.                                     ::::: //
    // :::::    3. Listar o cliente com todas as suas informações detalhadas.                    ::::: //
    // :::::    Estrutura das Classes                                                            ::::: //
    // :::::                                                                                     ::::: //
    // :::::  Classe DadosPessoais (A parte)                                                    ::::: //
    // :::::     NIF (string)                                                                   ::::: //
    // :::::     DataNascimento (string)                                                        ::::: //
    // :::::     Método ExibirInfo()                                                            ::::: //
    // :::::                                                                                     ::::: //
    // :::::  Classe Cliente (O todo)                                                           ::::: //
    // :::::     Nome (string)                                                                  ::::: //
    // :::::     NumeroCliente (int)                                                            ::::: //
    // :::::     DadosPessoais (do tipo DadosPessoais)                                          ::::: //
    // :::::     Método ExibirInfo()                                                            ::::: //
    // :::::                                                                                     ::::: //
    // ::::: O objeto Cliente deve gerir os seus DadosPessoais.A lógica de composição exige que, ::::: //
    // ::::: ao criar um cliente, os seus dados pessoais sejam instanciados internamente.        ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Program
    {
        static void Main(string[] args)
        {
            // Blocos try-catch para garantir que erros de input não fechem o programa bruscamente
            try
            {
                Console.WriteLine("--- Registo de Novo Cliente ---");

                // Uso de ?? string.Empty para evitar warnings de possíveis nulos do Console.ReadLine()
                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? string.Empty;

                Console.Write("Número do Cliente: ");
                // O parse pode gerar uma FormatException se o utilizador não digitar um número
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    throw new FormatException("O número do cliente deve ser um valor numérico inteiro.");
                }

                Console.Write("Morada: ");
                string morada = Console.ReadLine() ?? string.Empty;

                Console.Write("Email: ");
                string email = Console.ReadLine() ?? string.Empty;

                Console.Write("NIF: ");
                string nif = Console.ReadLine() ?? string.Empty;

                Console.Write("Data Nascimento (dd/mm/aaaa): ");
                string data = Console.ReadLine() ?? string.Empty;

                Console.Write("Telemóvel: ");
                string tel = Console.ReadLine() ?? string.Empty;

                // Instanciação do objeto "Todo"
                Cliente c1 = new Cliente(nome, num, morada, email, nif, data, tel);

                // Saída de dados
                c1.ExibirInfo();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"\n[ERRO DE FORMATO]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO INESPERADO]: {ex.Message}");
            }
            finally
            {
                // Este bloco executa sempre, independentemente de haver erro ou não
                Console.WriteLine("\nOperação finalizada. Prima qualquer tecla para sair...");
                Console.ReadKey();
            }
        }
    }
}
