using Movie_Management_Domain.Entities;
using Movie_Management_Domain.Interfaces;

namespace Movie_Management_Business.Services
{
    public class FilmeService(IFilmeRepository repositorio)
    {
        // Regras de negócio
        private readonly IFilmeRepository _repositorio = repositorio;

        // Injeção de dependência:
        // o serviço recebe o repositório de fora

        public void AdicionarFilme(string titulo, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("O título não pode ser vazio");
            }

            if (preco <= 0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            Filme novo = new()
            {
                Titulo = titulo,
                Preco = preco
            };

            _repositorio.Adicionar(novo);
        }

        public List<Filme> ListarTodos()
        {
            return _repositorio.ObterTodos();
        }

        public Filme? ProcurarFilme(string titulo)
        {
            return _repositorio.ObterPorTitulo(titulo);
        }

        public void RemoverFilme(int id)
        {
            bool removido = _repositorio.Remover(id);
            if (!removido)
            {
                throw new Exception("Filme não encontrado");
            }
        }
    }
}
