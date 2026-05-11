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
    internal class ContaJovem
        (
        string numero, 
        string titular, 
        decimal saldo, 
        decimal bonus
        ) 
        : Conta
            (
            numero, 
            titular, 
            saldo
            )
    {
        public decimal BonusDeposito { get; set; } = bonus;

        public override void Depositar(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("Valor inválido.");
            Saldo += (valor + BonusDeposito);
            Console.WriteLine($"✔ Depósito Jovem: {valor:C2} (+ bónus fixo de {BonusDeposito:C2}).");
        }

        public override void Levantar(decimal valor)
        {
            decimal limiteMaximo = Saldo * 0.5m;
            if (valor > limiteMaximo)
                throw new InvalidOperationException($"Limite de 50% ({limiteMaximo:C2}) excedido.");
            Saldo -= valor;
            Console.WriteLine($"✔ Levantamento de {valor:C2} efetuado.");
        }
    }
}
