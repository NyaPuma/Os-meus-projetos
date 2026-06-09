namespace MVC3
{
    public class ClienteView
    {
        // Método para mostrar um único cliente
        public static void MostrarCliente(Cliente cliente)
        {
            if (cliente == null) return;
            Console.WriteLine($"-> Nome: {cliente.Nome} | Idade: {cliente.Idade} | Email: {cliente.Email}");
        }

        // Método para mostrar uma lista de clientes
        public static void MostrarListaClientes(List<Cliente> clientes)
        {
            Console.WriteLine("\n=== LISTA DE CLIENTES ===");
            if (clientes == null || clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente registado.");
                return;
            }

            foreach (var cliente in clientes)
            {
                MostrarCliente(cliente);
            }
            Console.WriteLine("=========================\n");
        }
    }
}