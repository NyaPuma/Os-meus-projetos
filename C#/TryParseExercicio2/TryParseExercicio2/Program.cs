namespace TryParseExercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Exercício 2                                                                              :::::
            // ::::: Escreva um programa em C# que leia uma nota do utilizador, entre 0 e 20.                 :::::
            // ::::: Use TryParse para converter a entrada em número.                                         :::::
            // ::::: Se a conversão for válida e a nota estiver dentro do intervalo, o programa deve mostrar: :::::
            // ::::: • a nota introduzida;                                                                    :::::
            // ::::: • uma mensagem a indicar se o aluno está aprovado ou reprovado, considerando             :::::
            // ::::: aprovação igual ou superior a 10 valores.                                                :::::
            // ::::: Se a entrada não for numérica, o programa deve mostrar uma mensagem de erro.             :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            while (true)
            {
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("Digite a nota do aluno:");

                string? input = Console.ReadLine();
                if (!double.TryParse(input, out double nota))
                {
                    Console.WriteLine("Erro, Insira apenas números");
                    // ::::: Volta a pedir a nota em vez de sair do programa :::::
                    continue;
                }

                Notaaluno(nota);
            }
        }

        static void Notaaluno(double nota)
        {
            if (nota < 0 || nota > 20)
            {
                Console.WriteLine("Nota inválida. Insira um valor entre 0 e 20.");
                return;
            }

            Console.WriteLine($"Nota introduzida: {nota}");
            if (nota >= 10)
            {
                Console.WriteLine("Aluno Aprovado!");
            }
            else
            {
                Console.WriteLine("Aluno Reprovado");
            }
        }
    }
}
