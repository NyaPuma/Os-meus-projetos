namespace Dominio
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Stock { get; set; }

        // 1º regra: O produto só está disponível se tiver stock > 0
        public bool TemStock()
        {
            if (Stock > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        // 2º regra: O produto final é acrescido da taxa de iva
        public double PrecoComIVA(double taxaIVA)
        {
            return Preco + (Preco * taxaIVA / 100);
        }

        // 3º regra: Preço com desconto
        public double PrecoComDesconto(double percentualDesconto)
        {
            // Validação das regras de negócio
            if (percentualDesconto < 0 || percentualDesconto > 100)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(percentualDesconto),
                    "O desconto deve estar entre 0 e 100%."
                );
            }

            // Cálculo do preço final
            double fatorDesconto = (double)(percentualDesconto / 100.0);
            double valorDesconto = Preco * fatorDesconto;

            return Preco - valorDesconto;
        }
    }
}
