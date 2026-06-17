namespace SistemaBancario.Domain
{
    public class ContaBancaria
    {
        // O saldo é uma informação interna e só pode ser alterado pelas operações da própria conta
        public decimal Saldo { get; private set; }

        // A conta é criada com um saldo inicial
        public ContaBancaria(decimal saldoInicial)
        {
            if (saldoInicial < 0)
                throw new ArgumentException("O saldo inicial não pode ser negativo.");

            Saldo = saldoInicial;
        }

        // Operação: Depósito
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser positivo.");

            Saldo += valor;
        }

        // Operação: Levantamento
        public void Levantar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do levantamento deve ser positivo.");

            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente para realizar o levantamento.");

            Saldo -= valor;
        }

        // Operação: Transferência
        public void Transferir(ContaBancaria contaDestino, decimal valor)
        {
            if (contaDestino == null)
                throw new ArgumentNullException(nameof(contaDestino), "A conta de destino não pode ser nula.");

            // Reutiliza a lógica de levantamento (se falhar por saldo, lança a exceção automaticamente)
            this.Levantar(valor);
            contaDestino.Depositar(valor);
        }
    }
}