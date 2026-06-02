namespace MCV2
{
    public class Produto
    {
        private string _nome;
        private double _preco;
        private int _stock;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public double Preco
        {
            get => _preco;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("O preço deve ser estritamente maior que 0.");
                }
                _preco = value;
            }
        }

        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("O stock não pode ser negativo.");
                }
                _stock = value;
            }
        }

        // Construtor que garante a validação logo na criação do objeto
        public Produto(string nome, double preco, int stock)
        {
            Nome = nome;
            Preco = preco; // Aciona o setter e valida
            Stock = stock; // Aciona o setter e valida
        }
    }
}