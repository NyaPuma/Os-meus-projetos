using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercicio_Sistema_de_Pedidos_Online
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um sistema de pedidos online para uma empresa em C# que permita aos clientes inserir informações pessoais,         ::::: //
    // ::::: fazer pedidos e visualizar o resumo de seus pedidos.                                                                          ::::: //
    // :::::                                                                                                                               ::::: //
    // ::::: Diagrama de classes:                                                                                                          ::::: //
    // :::::    - Cliente representa os clientes do sistema e contém informações como nome, email e data de nascimento.                    ::::: //
    // :::::    - Produto representa os produtos disponíveis para compra e contém informações como nome e preço.                           ::::: //
    // :::::    - ItemPedido representa os itens individuais num pedido e contém informações como quantidade e preço unitário.             ::::: //
    // :::::    - Pedido representa um pedido feito por um cliente e contém informações como a data e hora do pedido, o status do pedido e ::::: //
    // :::::    uma lista de itens do pedido.                                                                                              ::::: //
    // :::::    - StatusPedido é uma classe do tipo enumeração que define os possíveis estados de um pedido, como "Pagamento Pendente",    ::::: //
    // :::::    "A processar", "Enviado" e "Entregue".                                                                                     ::::: //
    // :::::                                                                                                                               ::::: //
    // ::::: As relações entre as classes são mostradas através de associações. Por exemplo, um cliente pode fazer vários pedidos, então   ::::: //
    // ::::: há uma associação de 1 para muitos entre Cliente e Pedido. Similarmente, um pedido pode conter vários itens, então há uma     ::::: //
    // ::::: associação de 1 para muitos entre Pedido e ItemPedido.                                                                        ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== SISTEMA DE PEDIDOS ONLINE ===");

                // 1. Dados do Cliente (Validados e Obrigatórios)
                Console.WriteLine("\n> Dados do Cliente");
                string nome = LerStringObrigatoria("Nome: ");
                string email = LerEmailObrigatorio("Email: ");
                DateTime dataNasc = LerDataComMascara("Data de nascimento (DD/MM/YYYY): ");

                Cliente cliente = new(nome, email, dataNasc);

                // 2. Dados do Pedido
                Console.WriteLine("\n> Dados do Pedido");
                StatusPedido status = LerStatusPedido();
                Pedido pedido = new(DateTime.Now, status, cliente);

                // 3. Adição de Itens
                int n = LerIntPositivo("\nQuantos itens deseja adicionar? ");

                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"\n--- Item #{i} ---");
                    string nomeProd = LerStringObrigatoria("Nome do produto: ");
                    double precoProd = LerDoublePositivo("Preço do produto: ");
                    int qtd = LerIntPositivo("Quantidade: ");

                    Produto produto = new(nomeProd, precoProd);
                    ItemPedido item = new(qtd, precoProd, produto);
                    pedido.AdicionarItem(item);
                }

                // 4. Resumo Final
                Console.Clear();
                Console.WriteLine(pedido);

                Console.WriteLine("\nPrograma finalizado. Pressione qualquer tecla.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO]: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPressione qualquer tecla para sair.");
                Console.ReadKey();
            }

            // ==============================================================================================================================================//

            // --- MÉTODOS DE LEITURA ROBUSTA --- //

            // ==============================================================================================================================================//

            static string LerStringObrigatoria(string mensagem)
            {
                string? input;
                bool valido = false;

                do
                {
                    Console.Write(mensagem);
                    input = Console.ReadLine()?.Trim(); // Trim remove espaços inúteis no início/fim

                    // Validação:
                    // 1. Não pode ser nulo ou vazio
                    // 2. Deve ter pelo menos 2 caracteres
                    // 3. Todos os caracteres devem ser letras (ou espaços, se permitires nomes compostos)
                    if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                    {
                        Console.WriteLine("[ERRO]: O campo deve ter pelo menos 2 letras.");
                    }
                    else if (!ValidarApenasLetras(input))
                    {
                        Console.WriteLine("[ERRO]: Números e símbolos não são permitidos. Use apenas letras.");
                    }
                    else
                    {
                        valido = true;
                    }

                } while (!valido);

                return input!;
            }

            // ==============================================================================================================================================//

            static string LerEmailObrigatorio(string mensagem)
            {
                string? input;
                bool valido = false;

                do
                {
                    Console.Write(mensagem);
                    input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input) || input.Length < 3)
                    {
                        Console.WriteLine("[ERRO]: O campo deve ter pelo menos 3 caracteres.");
                    }
                    else if (!input.Contains('@'))
                    {
                        Console.WriteLine("[ERRO]: Email inválido. Deve conter um '@'.");
                    }
                    else
                    {
                        valido = true;
                    }
                } while (!valido);

                return input!;
            }

            // ==============================================================================================================================================//

            // Método auxiliar para verificar se a string contém apenas letras e espaços
            static bool ValidarApenasLetras(string texto)
            {
                foreach (char c in texto)
                {
                    // Se não for letra e não for um espaço em branco, a string é inválida
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            // ==============================================================================================================================================//

            static int LerIntPositivo(string mensagem)
            {
                int resultado;
                Console.Write(mensagem); // Adiciona isto para mostrar a pergunta!
                while (!int.TryParse(Console.ReadLine(), out resultado) || resultado <= 0)
                {
                    Console.Write("[ERRO]: Entrada inválida. Digite um número inteiro positivo: ");
                }
                return resultado;
            }

            // ==============================================================================================================================================//

            static double LerDoublePositivo(string mensagem)
            {
                double resultado;
                Console.Write(mensagem);
                // Aqui usamos o CultureInfo.InvariantCulture para aceitar o ponto como separador decimal
                while (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out resultado) || resultado <= 0)
                {
                    Console.Write("[ERRO]: Preço inválido. Use ponto para decimais (ex: 10.50): ");
                }
                return resultado;
            }

            // ==============================================================================================================================================//

            static StatusPedido LerStatusPedido()
            {
                while (true)
                {
                    Console.Write("Status (0:Pendente, 1:Processar, 2:Enviado, 3:Entregue): ");
                    string input = Console.ReadLine() ?? "";
                    if (Enum.TryParse(input, true, out StatusPedido status) && Enum.IsDefined(status))
                        return status;

                    Console.WriteLine("[ERRO]: Escolha entre 0 e 3.");
                }
            }

            // ==============================================================================================================================================//

            static DateTime LerDataComMascara(string mensagem)
            {
                Console.Write(mensagem);
                StringBuilder input = new();
                int anoAtual = DateTime.Now.Year;
                int anoLimite = anoAtual - 18;

                while (input.Length < 10)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    // Lógica de Backspace
                    if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (input[^1] == '/')
                        {
                            input.Remove(input.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                        input.Remove(input.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    // Lógica de Inserção com filtros de tempo real
                    else if (char.IsDigit(keyInfo.KeyChar) && input.Length < 10)
                    {
                        char c = keyInfo.KeyChar;
                        bool valido = input.Length switch
                        {
                            0 => c <= '3', // Dia: dezena 0-3
                            1 => input[0] == '3' ? c <= '1' : (input[0] != '0' || c > '0'), // Dia: unidade
                            3 => c <= '1', // Mês: dezena 0-1
                            4 => input[3] == '1' ? c <= '2' : (input[3] != '0' || c > '0'), // Mês: unidade
                            6 => c == '1' || c == '2', // Ano: deve começar com 1 ou 2 (19xx ou 20xx)
                            _ => true
                        };

                        if (valido)
                        {
                            input.Append(c);
                            Console.Write(c);
                            if (input.Length == 2 || input.Length == 5)
                            {
                                input.Append('/');
                                Console.Write('/');
                            }
                        }
                    }
                }

                Console.WriteLine(); // Salta linha após os 10 caracteres

                // Validação Final: Parse e Regras de Idade
                if (DateTime.TryParseExact(input.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                {
                    if (data.Year < 1900)
                    {
                        Console.WriteLine("[ERRO]: O ano não pode ser anterior a 1900.");
                    }
                    else if (data.Year > anoLimite)
                    {
                        Console.WriteLine($"[ERRO]: Cliente deve ser maior de idade (nascido até {anoLimite}).");
                    }
                    else
                    {
                        return data; // Data totalmente válida e dentro das regras
                    }
                }
                else
                {
                    Console.WriteLine("[ERRO]: Data calendário inválida (ex: 31/02).");
                }

                // Se falhar em qualquer regra acima, reinicia a leitura
                return LerDataComMascara(mensagem);
            }
        }
    }
}
