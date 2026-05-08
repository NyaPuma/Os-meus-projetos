namespace Sistema_de_Gestao_de_Contas_Bancarias
{
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Exercício 3- Sistema de Gestão de Contas Bancárias                                  ::::: //
    // ::::: Desenvolva uma pequena aplicação em C# que simule a gestão de diferentes tipos de   ::::: //
    // ::::: contas bancárias.                                                                   ::::: //
    // :::::                                                                                     ::::: //
    // ::::: O sistema deve permitir representar várias contas bancárias,                        ::::: //
    // ::::: aplicando herança e polimorfismo, com comportamentos específicos para operações     ::::: //
    // ::::: financeiras.                                                                        ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Objetivo                                                                            ::::: //
    // ::::: Criar uma classe base chamada Conta e três classes derivadas:                       ::::: //
    // :::::     ContaPoupanca                                                                  ::::: //
    // :::::     ContaOrdenado                                                                  ::::: //
    // :::::     ContaJovem                                                                     ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Cada tipo de conta deve ter comportamentos próprios para depósitos, levantamentos e ::::: //
    // ::::: apresentação de informação.                                                         ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Regras de negócio:                                                                  ::::: //
    // :::::     ContaPoupanca: ao depositar, aplica um bónus com base numa taxa de juro        ::::: //
    // :::::    (exemplo 5%)                                                                     ::::: //
    // :::::     ContaOrdenado: permite levantamento até ao limite de descoberto(por            ::::: //
    // :::::    exemplo 300 euros)                                                               ::::: //
    // :::::     ContaJovem: ao depositar atribui um bónus fixo(por exemplo adiciona 10 euros)  ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Métodos                                                                             ::::: //
    // ::::: Classe base: Conta                                                                  ::::: //
    // ::::: A classe Conta representa uma conta bancária genérica.                              ::::: //
    // :::::     virtual void Depositar(decimal valor)                                          ::::: //
    // :::::    Acrescenta o valor ao saldo da conta.                                            ::::: //
    // :::::     virtual void Levantar(decimal valor)                                           ::::: //
    // :::::    Retira o valor do saldo da conta, caso exista saldo suficiente.                  ::::: //
    // :::::     virtual void ExibirExtrato()                                                   ::::: //
    // :::::    Apresenta o titular e o saldo atual da conta.                                    ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Classe derivada: ContaPoupanca                                                      ::::: //
    // ::::: A classe ContaPoupanca representa uma conta poupança.                               ::::: //
    // ::::: Comportamentos específicos:                                                         ::::: //
    // :::::     override void Depositar(decimal valor)                                         ::::: //
    // :::::    Ao depositar, deve ser aplicado um acréscimo associado à taxa de juro.           ::::: //
    // :::::     override void ExibirExtrato()                                                  ::::: //
    // :::::    Deve apresentar também a taxa de juro anual associada à conta.                   ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Classe derivada: ContaOrdenado                                                      ::::: //
    // ::::: A classe ContaOrdenado representa uma conta com possibilidade de descoberto.        ::::: //
    // ::::: Comportamentos específicos:                                                         ::::: //
    // :::::     override void Levantar(decimal valor)                                          ::::: //
    // :::::    O levantamento só deve ser permitido até ao limite de descoberto definido.       ::::: //
    // :::::     override void ExibirExtrato()                                                  ::::: //
    // :::::    Deve apresentar também o limite de descoberto da conta.                          ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Classe derivada: ContaJovem                                                         ::::: //
    // ::::: A classe ContaJovem representa uma conta destinada a clientes jovens.               ::::: //
    // ::::: Comportamentos específicos:                                                         ::::: //
    // :::::     override void Depositar(decimal valor)                                         ::::: //
    // :::::    Ao depositar, deve ser acrescentado um bónus fixo ao valor depositado.           ::::: //
    // :::::     override void ExibirExtrato()                                                  ::::: //
    // :::::    Deve apresentar também o valor do bónus fixo.                                    ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Exemplos de teste:                                                                  ::::: //
    // ::::: Crie as seguintes contas:                                                           ::::: //
    // :::::     C001 — Ana Silva — saldo inicial de 1000€                                      ::::: //
    // :::::     C002 — Bruno Costa — saldo inicial de 1500€ e taxa de juro de 5%               ::::: //
    // :::::     C003 — Carla Mendes — saldo inicial de 500€ e limite de descoberto de 300€     ::::: //
    // :::::     C004 — Diogo Lopes — saldo inicial de 300€ e bónus de depósito de 10€          ::::: //
    // :::::    Em cada conta, efetue um depósito de 100€ e um levantamento de 200€.             ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    internal class ContaPoupanca(string numero, string titular, decimal saldo, decimal taxa)
        : Conta(numero, titular, saldo)
    {
        public decimal TaxaJuro { get; set; } = taxa;

        public override void Depositar(decimal valor)
        {
            // Aplica bónus: valor + (valor * taxa/100)
            decimal valorComJuros = valor + (valor * (TaxaJuro / 100));
            base.Depositar(valorComJuros);
        }

        public override void ExibirExtrato()
        {
            base.ExibirExtrato();
            Console.WriteLine($"Taxa de Juro Anual: {TaxaJuro}%");
        }
    }
}
