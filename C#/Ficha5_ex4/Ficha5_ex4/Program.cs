using System.Runtime.ConstrainedExecution;

namespace Ficha5_ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Cria um programa em C# que trabalhe com um ficheiro .csv chamado alunos.csv.    :::::
            // ::::: O programa deve:                                                                :::::
            // :::::     • Ler o conteúdo do ficheiro e mostrá - lo na consola.                      :::::
            // :::::     • Pedir ao utilizador que introduza o nome de um aluno.                     :::::
            // :::::     • Procurar esse aluno no ficheiro.                                          :::::
            // :::::     • Se encontrar o nome, mostrar a respetiva morada e o curso.                :::::
            // :::::     • Se não encontrar, mostrar uma mensagem a informar que o aluno não existe. :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            string caminho = @"C:\Users\Cesae\Downloads\C#\Ficha5_ex4\Ficha5_ex4\bin\Debug\net10.0\alunos.csv";

            if (!File.Exists(caminho))
            {
                Console.WriteLine("O ficheiro não existe");
                return;
            }

            // ::::: Ler conteúdo do ficheiro :::::
            Console.WriteLine("Conteúdo do Ficheiro:");
            Console.WriteLine();

            string[] linhas = File.ReadAllLines(caminho);

            foreach(string linha in linhas)
            {
                Console.WriteLine(linha);
            }

            // ::::: Inserir nome :::::
            Console.WriteLine();
            Console.WriteLine("Insira um nome de um aluno:");
            string nomeProcurar = Console.ReadLine();

            bool encontrado = false;

            for (int i = 1; i < linhas.Length; i++)
            {
                string[] campos = linhas[i].Split(",");

                if (campos.Length == 3 && campos[0].Equals(nomeProcurar, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Aluno Encontrado");
                    Console.WriteLine($"Morada: {campos[1]}");
                    Console.WriteLine($"Curso: {campos[2]}");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Aluno não encontrado");
            }
        }
    }
}
