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
    internal abstract class Conta
        (
        string numeroConta, 
        string titular, 
        decimal saldoInicial
        )
    {
        public string NumeroConta { get; set; } = numeroConta;
        public string Titular { get; set; } = titular;
        public decimal Saldo { get; protected set; } = saldoInicial; // protected permite que as filhas alterem o saldo

        // Métodos abstratos: não têm código aqui, apenas a assinatura
        public abstract void Depositar(decimal valor);
        public abstract void Levantar(decimal valor);

        public virtual void ExibirExtrato()
        {
            Console.WriteLine($"\n[EXTRATO] Conta: {NumeroConta} | Titular: {Titular}");
            Console.WriteLine($"Saldo Atual: {Saldo:C2}");
        }
    }
}
