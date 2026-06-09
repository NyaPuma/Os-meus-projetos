using Movie_Management_Business.Services;
using Movie_Management_Data.Repositories;
using Movie_Management_Domain.Interfaces;

namespace Movie_Management_UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFilmeRepository repo = new FilmeSQLiteRepository();
            FilmeService servico = new(repo);

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1 - Adicionar filme");
                Console.WriteLine("2 - Listar filmes");
                Console.WriteLine("3 - Procurar filme");
                Console.WriteLine("4 - Remover filme");
                Console.WriteLine("0 - para sair");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.WriteLine("Título: ");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("Preço: ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    try
                    {
                        servico.AdicionarFilme(titulo, preco);
                        Console.WriteLine("Filme adicionado com sucesso");
                    }
                    catch
                    {
                        Console.WriteLine("Filme não adicionado");
                    }
                }
                else if (opcao == "2")
                {
                    var lista = servico.ListarTodos();
                    foreach (var f in lista)
                    {
                        Console.WriteLine($"{f.Id} - {f.Titulo} - {f.Preco}");
                    }
                }
                else if (opcao == "3") // Procurar por nome
                {
                    Console.WriteLine("Título: ");
                    string titulo = Console.ReadLine();

                    var filme = servico.ProcurarFilme(titulo);

                    if (filme == null)
                    {
                        Console.WriteLine("Não encontrado");
                    }
                    else
                    {
                        Console.WriteLine($"{filme.Id} - {filme.Titulo} - {filme.Preco}");
                    }
                }
                else if (opcao == "4") // Remover por id
                {
                    Console.WriteLine("Id: ");
                    int id = int.Parse(Console.ReadLine());
                    try
                    {
                        servico.RemoverFilme(id);
                        Console.WriteLine("Filme removido com sucesso");
                    }
                    catch
                    {
                        Console.WriteLine("Filme não encontrado");
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