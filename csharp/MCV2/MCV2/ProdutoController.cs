namespace MCV2
{
    public class ProdutoController(Produto model, ProdutoView view)
    {
        private readonly Produto _model = model;
        private readonly ProdutoView _view = view;

        // Métodos para atualizar o Modelo
        public void SetNomeProduto(string nome) => _model.Nome = nome;

        public void SetPrecoProduto(double preco) => _model.Preco = preco;

        public void SetStockProduto(int stock) => _model.Stock = stock;

        // Métodos para obter dados do Modelo
        public string GetNomeProduto() => _model.Nome;
        public double GetPrecoProduto() => _model.Preco;
        public int GetStockProduto() => _model.Stock;

        // Coordena a apresentação dos dados invocando a View
        public void AtualizarView()
        {
            ProdutoView.ExibirDetalhesProduto(_model.Nome, _model.Preco, _model.Stock);
        }
    }
}