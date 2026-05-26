using Product_Management_Business.Services;
using Product_Management_Data.Repositories;

namespace Product_Management_UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProdutoRepository repo = new();

            ProdutoService servico = new(repo);

            bool continuar = true;

            while (continuar) 
            {
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Procurar produto");
                Console.WriteLine("4 - Remover produto");
                Console.WriteLine("0 - para sair");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.WriteLine("Nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Preço: ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    try
                    {
                        servico.AdicionarProduto(nome, preco);
                        Console.WriteLine("Produto adicionado com sucesso");
                    }
                    catch
                    {
                        Console.WriteLine("Produto não adicionado");
                    }
                }
                else if (opcao == "2")
                {
                    var lista = servico.ListarTodos();
                    foreach (var p in lista)
                    {
                        Console.WriteLine($"{p.Id} - {p.Nome} - {p.Preco}");
                    }
                }
                else if (opcao == "3") // Procurar por nome
                {
                    Console.WriteLine("Nome: ");
                    string nome = Console.ReadLine() ;

                    var produto = servico.ProcurarProduto(nome);

                    if (produto == null)
                    {
                        Console.WriteLine("Não encontrado");
                    }
                    else
                    {
                        Console.WriteLine($"{produto.Id} - {produto.Nome} - {produto.Preco}");
                    }
                }
                else if (opcao == "4") // Remover por id
                {
                    Console.WriteLine("Id: ");
                    int id = int.Parse(Console.ReadLine());
                    try
                    {
                        servico.RemoverProduto(id);
                        Console.WriteLine("Produto removido com sucesso");
                    }
                    catch
                    {
                        Console.WriteLine("Produto não encontrado");
                    }
                }
                else if (opcao == "0")
                {
                    continuar = false;
                }
            }
        }
    }
}