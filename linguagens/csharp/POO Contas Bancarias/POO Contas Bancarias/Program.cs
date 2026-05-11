using System.Globalization;
using System.Threading;
namespace POO_Contas_Bancarias
{
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Partindo do sistema de gestão de contas bancárias desenvolvido anteriormente(Ficha4,   ::::: //
    // ::::: exercicio3), altere a aplicação para aplicar o conceito de classes abstratas e métodos ::::: //
    // ::::: abstratos.                                                                             ::::: //
    // :::::                                                                                        ::::: //
    // ::::: 1. Transformar Conta em classe abstrata                                                ::::: //
    // :::::     A classe Conta passa a ser abstrata                                               ::::: //
    // :::::                                                                                        ::::: //
    // ::::: 2. Metodos Abstratos                                                                   ::::: //
    // ::::: Alterar o método Depositar() e Levantar() para abstrato.                               ::::: //
    // ::::: Cada tipo de conta deve definir as suas próprias regras de movimentação.               ::::: //
    // :::::                                                                                        ::::: //
    // ::::: Regras de negócio:                                                                     ::::: //
    // :::::     ContaPoupanca: ao depositar, aplica um bónus com base numa taxa de juro           ::::: //
    // :::::    (exemplo 5%); só permite levantamentos se o saldo mínimo exigido estiver            ::::: //
    // :::::    assegurado(10000 euros).                                                            ::::: //
    // :::::     ContaOrdenado: permite levantamento até ao limite de descoberto(por               ::::: //
    // :::::    exemplo 300 euros)                                                                  ::::: //
    // :::::     ContaJovem: ao depositar, atribui um bónus fixo(ex.: +10€); o levantamento        ::::: //
    // :::::    está limitado a 50% do saldo disponível.                                            ::::: //
    // :::::                                                                                        ::::: //
    // ::::: Questão de reflexão                                                                    ::::: //
    // :::::     Porque faz sentido que a classe Conta seja abstrata neste sistema?                ::::: //
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definir cultura para Euro
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");

            // Polimorfismo: Uma lista de referências abstratas para objetos concretos
            List<Conta> contas =
            [
                new ContaPoupanca("P01", "Ana Silva", 12000m, 5m), // Tem saldo > 10000
                new ContaOrdenado("O01", "Bruno Costa", 500m, 300m),
                new ContaJovem("J01", "Carla Mendes", 1000m, 10m)
            ];

            Console.WriteLine("=== PROCESSAMENTO DE OPERAÇÕES BANCÁRIAS ===");

            foreach (var conta in contas)
            {
                try
                {
                    Console.WriteLine($"\n=== Processando conta de {conta.Titular} ===");

                    // 1. Efetuar depósito de 100€
                    conta.Depositar(100m);

                    // 2. Efetuar levantamento de 200€
                    conta.Levantar(200m);

                    // 3. Exibir resultado final
                    conta.ExibirExtrato();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erro na conta {conta.NumeroConta}: {ex.Message}");
                }
            }

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Prima qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
