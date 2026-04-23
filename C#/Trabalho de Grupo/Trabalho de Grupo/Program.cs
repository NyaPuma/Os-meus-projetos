using System; // Tipos básicos do .NET (Console, Exception, Math, etc.)
using System.Globalization; // Para suporte a culturas e formatação (CultureInfo)

namespace Trabalho_de_Grupo
{
    // Classe principal do programa. Marca como 'internal' para acesso dentro do assembly.
    internal class Program
    {
        // Cultura usada para formatação (invariável para garantir formato consistente: "." como separador decimal quando necessário)
        private static readonly CultureInfo culture = CultureInfo.InvariantCulture;

        // Produtos disponíveis no frigorífico do hotel.
        // Cada item é uma tupla (Nome, Preco). O cliente pode alterar estes valores conforme necessário.
        private static readonly (string Nome, decimal Preco)[] itensDisponiveis = new (string, decimal)[]
        {
            ("Café", 1.00m),   // "m" indica literal decimal
            ("Chá", 1.00m),
            ("Água", 1.00m),
            ("Leite", 1.20m),
            ("Iogurte", 0.70m),
            ("Sumo", 1.50m)
        };

        // Ponto de entrada da aplicação
        static void Main(string[] args)
        {
            // Loop principal: processa hóspedes até o utilizador escolher terminar
            while (true)
            {
                try
                {
                    // Lança o fluxo normal de processamento de um hóspede
                    ProcessarHóspede();
                }
                catch (Exception ex)
                {
                    // Em caso de erro não tratado dentro de ProcessarHóspede, mostramos a mensagem e continuamos
                    Console.WriteLine($"Ocorreu um erro durante o processamento: {ex.Message}");
                    Console.WriteLine("Voltando ao menu principal.");
                }

                // Pergunta ao utilizador se pretende processar outro hóspede. Se não, sai do loop.
                if (!PerguntarContinuar()) break;
                // Linha em branco para separar entradas no ecrã
                Console.WriteLine();
            }

            // Mensagem de encerramento do programa
            Console.WriteLine("Programa terminado. Obrigado.");
        }

        // Orquestra a leitura dos dados, cálculo e impressão do recibo para um hóspede
        private static void ProcessarHóspede()
        {
            Console.WriteLine("--- Recibo de Checkout ---");

            // Lê nome, tipo de apartamento e número de dias do hóspede
            string nome = LerNome();
            char tipo = LerTipoApartamento();
            int dias = LerNumeroDias();

            // Determina o preço por dia com base no tipo de apartamento
            decimal precoPorDia = ObterPrecoPorDia(tipo);
            // Obtém a lista de itens do frigorífico (poderia vir de outra fonte)
            var itens = ObterItensFrigorifico();
            // Lê as quantidades consumidas para cada item
            int[] quantidades = LerQuantidades(itens);

            // Calcula o valor da estadia sem/ com desconto
            decimal valorEstadia = CalcularValorEstadia(precoPorDia, dias);
            decimal descontoPercent = ObterPercentagemDesconto(dias);
            // Aplica arredondamento a 2 casas decimais ao valor do desconto
            decimal desconto = Math.Round(valorEstadia * descontoPercent, 2);
            decimal valorEstadiaComDesconto = valorEstadia - desconto;

            // Calcula o consumo do frigorífico e total geral a pagar
            decimal consumoTotal = CalcularConsumoTotal(itens, quantidades);
            decimal totalGeral = valorEstadiaComDesconto + consumoTotal;

            // Imprime o recibo com todos os valores calculados
            ImprimirRecibo(nome, tipo, precoPorDia, dias, valorEstadia, descontoPercent, desconto, valorEstadiaComDesconto, itens, quantidades, consumoTotal, totalGeral);
        }

        // Lê o nome do hóspede a partir da consola
        private static string LerNome()
        {
            Console.Write("Nome do hóspede: "); // Mensagem ao utilizador
            // Se for retornado null (por alguma razão), usamos string.Empty como fallback
            return Console.ReadLine() ?? string.Empty;
        }

        // Lê e valida o tipo de apartamento (A, B, C ou D)
        private static char LerTipoApartamento()
        {
            while (true)
            {
                Console.Write("Tipo de apartamento (A, B, C ou D): ");
                // Lê linha, protege contra null, remove espaços e converte para maiúsculas
                var input = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
                // Verifica se o primeiro caractere é uma das letras válidas
                if (input.Length > 0 && "ABCD".Contains(input[0]))
                {
                    // Retorna o primeiro carácter válido
                    return input[0];
                }
                // Mensagem de erro e repetição da leitura caso inválido
                Console.WriteLine("Tipo inválido. Introduza A, B, C ou D.");
            }
        }

        // Lê e valida o número de dias (inteiro positivo)
        private static int LerNumeroDias()
        {
            while (true)
            {
                Console.Write("Número de dias hospedado: ");
                // Tenta converter a linha lida para inteiro e verifica se é > 0
                if (int.TryParse(Console.ReadLine(), out int dias) && dias > 0) return dias;
                Console.WriteLine("Por favor introduza um número inteiro positivo.");
            }
        }

        // Retorna o preço por dia dependendo do tipo de apartamento usando expressão 'switch'
        private static decimal ObterPrecoPorDia(char tipo) => tipo switch
        {
            'A' => 150m, // Apartamento A custa 150
            'B' => 100m, // Apartamento B custa 100
            'C' => 75m,  // Apartamento C custa 75
            'D' => 150m, // Apartamento D custa 150 (igual a A neste exemplo)
            _ => 0m      // Caso não reconhecido, devolve 0
        };

        // Retorna os itens disponíveis no frigorífico
        private static (string Nome, decimal Preco)[] ObterItensFrigorifico() => itensDisponiveis;

        // Lê as quantidades consumidas para cada item do frigorífico
        private static int[] LerQuantidades((string Nome, decimal Preco)[] itens)
        {
            Console.WriteLine("\nConsumo interno (frigorífico). Introduza a quantidade consumida de cada artigo.");
            int[] quantidades = new int[itens.Length]; // Cria array para guardar quantidades
            for (int i = 0; i < itens.Length; i++)
            {
                while (true)
                {
                    // Mostra o nome do item e o seu preço formatado com 2 casas decimais
                    Console.Write($"{itens[i].Nome} (preço {itens[i].Preco.ToString("F2", culture)}): ");
                    // Tenta ler um inteiro não-negativo; se válido, guarda e sai do loop interno
                    if (int.TryParse(Console.ReadLine(), out int q) && q >= 0)
                    {
                        quantidades[i] = q;
                        break;
                    }
                    // Se inválido, alerta o utilizador e repete a leitura
                    Console.WriteLine("Quantidade inválida. Introduza 0 ou um inteiro positivo.");
                }
            }
            return quantidades; // Devolve o array com as quantidades lidas
        }

        // Calcula o valor total da estadia (preço por dia * número de dias)
        private static decimal CalcularValorEstadia(decimal precoPorDia, int dias) => precoPorDia * dias;

        // Determina a percentagem de desconto com base no número de dias
        // Se > 15 dias -> 10%, senão se > 7 -> 5%, caso contrário 0%
        private static decimal ObterPercentagemDesconto(int dias) => dias > 15 ? 0.10m : (dias > 7 ? 0.05m : 0.00m);

        // Calcula o consumo total multiplicando preço pela quantidade para cada item
        private static decimal CalcularConsumoTotal((string Nome, decimal Preco)[] itens, int[] quantidades)
        {
            decimal total = 0m; // acumulador
            for (int i = 0; i < itens.Length; i++) total += itens[i].Preco * quantidades[i];
            return total;
        }

        // Imprime o recibo formatado com valores e consumo detalhado
        private static void ImprimirRecibo(string nome, char tipo, decimal precoPorDia, int dias, decimal valorEstadia, decimal descontoPercent, decimal desconto, decimal valorEstadiaComDesconto, (string Nome, decimal Preco)[] itens, int[] quantidades, decimal consumoTotal, decimal totalGeral)
        {
            Console.WriteLine("\n========== RECIBO ==========");
            Console.WriteLine($"Hóspede: {nome}");
            Console.WriteLine($"Apartamento: {tipo}");
            // Formata valores monetários com 2 casas decimais
            Console.WriteLine($"Preço por noite: €{precoPorDia.ToString("F2", culture)}");
            Console.WriteLine($"Número de dias: {dias}");
            Console.WriteLine($"Valor da estadia (sem desconto): €{valorEstadia.ToString("F2", culture)}");
            // Mostra percentagem como percentagem inteira (P0) e o valor do desconto aplicado
            Console.WriteLine($"Desconto aplicado: {descontoPercent:P0} => -€{desconto.ToString("F2", culture)}");
            Console.WriteLine($"Valor da estadia (com desconto): €{valorEstadiaComDesconto.ToString("F2", culture)}");

            Console.WriteLine("\n--- Consumo interno ---");
            // Percorre itens e imprime apenas os consumos com quantidade > 0
            for (int i = 0; i < itens.Length; i++)
            {
                if (quantidades[i] > 0)
                {
                    decimal subtotal = itens[i].Preco * quantidades[i];
                    Console.WriteLine($"{itens[i].Nome}: {quantidades[i]} x €{itens[i].Preco.ToString("F2", culture)} = €{subtotal.ToString("F2", culture)}");
                }
            }
            Console.WriteLine($"Total consumo interno: €{consumoTotal.ToString("F2", culture)}");

            // Valor total a pagar (estadia com desconto + consumo)
            Console.WriteLine($"\nTOTAL GERAL A PAGAR: €{totalGeral.ToString("F2", culture)}");
            Console.WriteLine("===========================\n");
        }

        // Pergunta ao utilizador se pretende continuar e retorna true para S/ SIM
        private static bool PerguntarContinuar()
        {
            Console.Write("Deseja processar outro hóspede? (S/N): ");
            var considerar = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
            // Aceita tanto "S" como "SIM" como resposta afirmativa
            return (considerar == "S" || considerar == "SIM");
        }
    }
}
