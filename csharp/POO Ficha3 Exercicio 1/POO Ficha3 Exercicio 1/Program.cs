using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_Ficha3_Exercicio_1
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva, em C#, um pequeno sistema para gerir livros e autores, aplicando o     ::::: //
    // ::::: conceito de associação entre classes.                                              ::::: //
    // ::::: O programa deve permitir:                                                          ::::: //
    // :::::     Criar autores, indicando nome e nacionalidade.                                ::::: //
    // :::::     Criar livros, indicando título, ISBN e ano de publicação.                     ::::: //
    // :::::     Associar cada livro a um autor previamente criado.                            ::::: //
    // :::::     Construir um menu que permita:                                                ::::: //
    // :::::         Listar os livros registados com os dados do livro e do respetivo autor    ::::: //
    // :::::         Listar todos os autores.                                                  ::::: //
    // ::::: Estrutura                                                                          ::::: //
    // ::::: O programa deve conter, pelo menos, duas classes:                                  ::::: //
    // :::::     Autor                                                                         ::::: //
    // :::::         Nome                                                                      ::::: //
    // :::::         Nacionalidade                                                             ::::: //
    // :::::         Método: ExibirInformações                                                 ::::: //
    // :::::     Livro                                                                         ::::: //
    // :::::         Título                                                                    ::::: //
    // :::::         ISBN                                                                      ::::: //
    // :::::         AnoPublicacao                                                             ::::: //
    // :::::         Autor                                                                     ::::: //
    // :::::         Método: ExibirInformações                                                 ::::: //
    // ::::: Relação entre classes                                                              ::::: //
    // :::::     Um livro tem um autor.                                                        ::::: //
    // :::::     Um autor pode estar associado a vários livros.                                ::::: //
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    internal class Program
    {
        static void Main(string[] args)
        {
            // Listas dinâmicas para armazenar os objetos criados durante a execução
            List<Autor> autores = [];
            List<Livro> livros = [];
            int opcao;

            // Ciclo principal do menu
            do
            {
                Console.WriteLine("\n--- Sistema de Gestão de Livros ---");
                Console.WriteLine("1. Criar Autor");
                Console.WriteLine("2. Criar Livro e Associar Autor");
                Console.WriteLine("3. Listar Livros");
                Console.WriteLine("4. Listar Autores");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                // Validação de entrada para garantir que o utilizador insere um número
                if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

                switch (opcao)
                {
                    case 1:
                        // --- Criar Autor ---
                        Console.Write("Nome do Autor: ");
                        string nome = Console.ReadLine() ?? "Sem Nome";
                        Console.Write("Nacionalidade: ");
                        string nac = Console.ReadLine() ?? "Desconhecida";

                        // Instancia um novo objeto Autor e adiciona à lista
                        autores.Add(new Autor(nome, nac));
                        Console.WriteLine("Autor registado com sucesso!");
                        break;

                    case 2:
                        // --- Criar Livro e Associar Autor ---
                        // Verifica se já existem autores, pois um livro obrigatoriamente tem um autor nesta lógica
                        if (autores.Count == 0)
                        {
                            Console.WriteLine("Erro: Crie um autor primeiro!");
                            break;
                        }

                        Console.Write("Título do livro: ");
                        string titulo = Console.ReadLine() ?? "Sem Título";
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine() ?? "000-000";
                        Console.Write("Ano de publicação: ");

                        // Validação do ano: se falhar, assume o ano atual
                        if (!int.TryParse(Console.ReadLine(), out int ano)) ano = DateTime.Now.Year;

                        // Listagem de autores existentes para seleção por índice
                        Console.WriteLine("\nSelecione o autor:");
                        for (int i = 0; i < autores.Count; i++)
                        {
                            Console.WriteLine($"{i}. {autores[i].Nome}");
                        }

                        Console.Write("Índice do autor: ");
                        // Validação do índice escolhido para evitar erros de fora de intervalo (IndexOutOfRangeException)
                        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < autores.Count)
                        {
                            // Cria o livro passando o objeto Autor selecionado (Associação)
                            livros.Add(new Livro(titulo, isbn, ano, autores[index]));
                            Console.WriteLine("Livro registado e associado!");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido. Operação cancelada.");
                        }
                        break;

                    case 3:
                        // --- Listar Livros ---
                        Console.WriteLine("\n--- Lista de Livros ---");
                        if (livros.Count == 0) Console.WriteLine("Nenhum livro registado.");
                        // Invoca o método de exibição de cada objeto Livro
                        foreach (var l in livros) l.ExibirInformacoes();
                        break;

                    case 4:
                        // --- Listar Autores ---
                        Console.WriteLine("\n--- Lista de Autores ---");
                        if (autores.Count == 0) Console.WriteLine("Nenhum autor registado.");
                        // Invoca o método de exibição de cada objeto Autor
                        foreach (var a in autores) a.ExibirInformacoes();
                        break;
                }
            } while (opcao != 0); // O programa corre até o utilizador digitar 0
        }
    }

    // Nota: Certifica-te de que as classes 'Autor' e 'Livro' estão definidas 
    // no mesmo namespace ou em ficheiros separados para o código compilar.
}