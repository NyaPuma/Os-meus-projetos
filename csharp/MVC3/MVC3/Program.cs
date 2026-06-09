namespace MVC3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Inicializa a View e o Controller (Injeção de dependência manual da View no Controller)
            ClienteView view = new();
            ClienteController controller = new(view);

            Console.WriteLine("--- Teste 1: Adicionar Clientes Válidos ---");
            try
            {
                Cliente c1 = new("Ana Silva", 25, "ana@email.com");
                Cliente c2 = new("Pedro Santos", 17, "pedro@email.com");

                controller.AdicionarCliente(c1);
                controller.AdicionarCliente(c2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Pede ao controller para atualizar o ecrã através da View
            controller.AtualizarView();

            Console.WriteLine("--- Teste 2: Tentar adicionar cliente com Idade Inválida (< 16) ---");
            try
            {
                // Dispara a exceção do Model na propriedade Idade
                Cliente cQuebraIdade = new("Lucas Menor", 14, "lucas@email.com");
                controller.AdicionarCliente(cQuebraIdade);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exceção Capturada: {ex.Message}");
            }

            Console.WriteLine("\n--- Teste 3: Tentar adicionar cliente com Email Inválido (sem @) ---");
            try
            {
                // Dispara a exceção do Model na propriedade Email
                Cliente cQuebraEmail = new("Maria Souza", 30, "maria_email.com");
                controller.AdicionarCliente(cQuebraEmail);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exceção Capturada: {ex.Message}");
            }

            // Garante que os clientes inválidos não foram inseridos na lista
            controller.AtualizarView();

            Console.WriteLine("--- Teste 4: Remover um cliente pelo Nome ---");
            controller.RemoverClientePorNome("Ana Silva");

            // Mostra o estado final da lista após a remoção
            controller.AtualizarView();

            Console.WriteLine("Premir qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}