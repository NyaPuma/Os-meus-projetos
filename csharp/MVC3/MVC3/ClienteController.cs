namespace MVC3
{
    public class ClienteController(ClienteView view)
    {
        // Lista de clientes interna (simula uma tabela de Base de Dados)
        private readonly List<Cliente> _listaClientes = [];
        private readonly ClienteView _view = view;

        // Método para Adicionar um cliente à lista
        public void AdicionarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                _listaClientes.Add(cliente);
                Console.WriteLine($"Sucesso: Cliente '{cliente.Nome}' adicionado com sucesso.");
            }
        }

        // Método para Remover um cliente pelo nome
        public bool RemoverClientePorNome(string nome)
        {
            // Procura o cliente ignorando maiúsculas/minúsculas
            Cliente clienteParaRemover = _listaClientes.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (clienteParaRemover != null)
            {
                _listaClientes.Remove(clienteParaRemover);
                Console.WriteLine($"Sucesso: Cliente '{nome}' foi removido.");
                return true;
            }

            Console.WriteLine($"Aviso: Cliente '{nome}' não foi encontrado.");
            return false;
        }

        // Método para Obter a lista completa de clientes
        public List<Cliente> ObterListaCompleta()
        {
            return _listaClientes;
        }

        // Pedir à View para mostrar todos os clientes
        public void AtualizarView()
        {
            ClienteView.MostrarListaClientes(_listaClientes);
        }
    }
}