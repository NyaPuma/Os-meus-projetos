namespace SimuladorDeDescontos
{
    public class SimuladorDescontos
    {
        public double CalcularValorFinal(double valorOriginal, double percentualDesconto, double cupao = 0)
        {
            if (valorOriginal < 0)
            {
                throw new ArgumentException("O preço original não pode ser negativo.");
            }

            if (percentualDesconto < 0) 
            { 
                throw new ArgumentException("A percentagem de desconto não pode ser negativa.");
            }

            // Limitar o desconto a 50%
            if (percentualDesconto > 50)
            {
                percentualDesconto = 50;
            }

            double valorDesconto = valorOriginal * (percentualDesconto / 100);

            // Subtrair o valor do cupão do desconto total
            double valorFinal = valorOriginal - valorDesconto - cupao;

            if (valorFinal < 0)
            {
                valorFinal = 0; // O valor final não pode ser negativo
            }

            return valorFinal;
        }
    }
}
