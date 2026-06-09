namespace MCV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuração para suportar caracteres especiais e moeda local na consola
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Inicializando o Sistema MVC ---");

            try
            {
                // 1. Criar o Modelo com dados válidos
                Produto meuProduto = new("Rato Sem Fios", 24.99, 15);

                // 2. Criar a Vista
                ProdutoView minhaView = new();

                // 3. Criar o Controlador interligando o Modelo e a Vista
                ProdutoController controlador = new(meuProduto, minhaView);

                // Apresentar os dados iniciais
                controlador.AtualizarView();

                // Alterar dados de forma válida através do Controlador
                Console.WriteLine("-> A atualizar o preço e o stock de forma válida...");
                controlador.SetPrecoProduto(19.99);
                controlador.SetStockProduto(10);
                controlador.AtualizarView();

                // --- TESTE DE VALIDAÇÃO 1: Preço Inválido ---
                Console.WriteLine("-> A tentar definir um preço inválido (0)...");
                controlador.SetPrecoProduto(0);
            }
            catch (ArgumentException ex)
            {
                // A View é usada para mostrar o erro de forma amigável
                ProdutoView.ExibirMensagemErro(ex.Message);
            }

            try
            {
                // --- TESTE DE VALIDAÇÃO 2: Stock Inválido ---
                Console.WriteLine("\n-> A tentar criar um produto com stock negativo (-5)...");
                Produto produtoInvalido = new("Teclado Mecânico", 59.90, -5);
            }
            catch (ArgumentException ex)
            {
                ProdutoView.ExibirMensagemErro(ex.Message);
            }

            Console.WriteLine("\nSessão terminada. Prime qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}