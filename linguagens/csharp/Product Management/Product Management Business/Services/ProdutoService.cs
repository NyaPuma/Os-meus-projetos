using Product_Management_Domain.Entities;
using Product_Management_Domain.Interfaces;

namespace Product_Management_Business.Services
{
    public class ProdutoService(IProdutoRepository repositorio)
    {
        // Regras de negócio
        private readonly IProdutoRepository _repositorio = repositorio;

        // Injeção de dependência:
        // o serviço recebe o repositório de fora

        public void AdicionarProduto(string nome, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("O nome não pode ser vazio");
            }

            if (preco <= 0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            Produto novo = new()
            {
                Nome = nome,
                Preco = preco
            };

            _repositorio.Adicionar(novo);
        }

        public List<Produto> ListarTodos()
        {
            return _repositorio.ObterTodos();
        }

        public Produto? ProcurarProduto(string nome)
        {
            return _repositorio.ObterPorNome(nome);
        }
    }
}