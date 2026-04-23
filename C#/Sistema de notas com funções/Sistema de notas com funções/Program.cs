namespace Sistema_de_notas_com_funções
{
    internal class Program
    {
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Enunciado - Sistema de Notas com Funções                                          :::::
            // ::::: Crie um programa em C# que gere um sistema de notas de alunos utilizando funções. :::::
            // :::::                                                                                   :::::
            // ::::: O programa deve:                                                                  :::::
            // ::::: Receber 5 notas(0 a 20) digitadas pelo utilizador                                 :::::
            // ::::: Calcular a média das notas                                                        :::::
            // ::::: Classificar cada nota como: Aprovado(>14), Recuperação(10-14) ou Reprovado(<10)   :::::
            // :::::                                                                                   :::::
            // ::::: Requisitos obrigatórios:                                                          :::::
            // ::::: 2 funções mínimas:                                                                :::::
            // ::::: CalcularMedia(double[] notas) - retorna a média                                   :::::
            // ::::: ClassificarNota(double nota) - retorna "Aprovado", "Recuperação" ou "Reprovado"   :::::
            // :::::                                                                                   :::::
            // ::::: Usar array de 5 posições para armazenar as notas                                  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::
            // ::::: Criamos o array de 5 posições :::::
            // :::::::::::::::::::::::::::::::::::::::::
            double[] notas = new double[5];

            // :::::::::::::::::::::::::::::::::::::::
            // ::::: Ciclo para receber as notas :::::
            // :::::::::::::::::::::::::::::::::::::::
            for (int i = 0; i < notas.Length; i++)
            {
                double notaDigitada = -1;

                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                // ::::: Validação: garante que a nota está entre 0 e 20 :::::
                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                while (notaDigitada < 0 || notaDigitada > 20)
                {
                    Console.WriteLine($"Insira a {i + 1}ª nota (0-20): ");
                    if (double.TryParse(Console.ReadLine(), out notaDigitada))
                    {
                        if (notaDigitada < 0 || notaDigitada > 20)
                        {
                            Console.WriteLine("Nota inválida! Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, insira um número válido.");
                        notaDigitada = -1; // Força a continuação do loop
                    }
                }
                notas[i] = notaDigitada;
            }
            // ::::::::::::::::::::::::::::
            // ::::: Cálculo da média :::::
            // ::::::::::::::::::::::::::::
            double media = CalcularMedia(notas);

            // :::::::::::::::::::::::::::::::::::
            // ::::: Exibição dos resultados :::::
            // :::::::::::::::::::::::::::::::::::
            Console.WriteLine("\n--- Resultados ---");
            for (int i = 0; i < notas.Length; i++)
            {
                string resultado = ClassificarNota(notas[i]);
                Console.WriteLine($"Nota {i + 1}: {notas[i]} - Status: {resultado}");
            }

            Console.WriteLine($"\nMédia Final: {media:F2}");
        }
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // ::::: Função para calcular a média (Retorna double) :::::
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        static double CalcularMedia(double[] notas)
        {
            double soma = 0;
            foreach (double nota in notas)
            {
                soma += nota;
            }
            return soma / notas.Length;
        }
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // ::::: Função para classificar a nota (Retorna string) :::::
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        static string ClassificarNota(double nota)
        {
            if (nota > 14)
                return "Aprovado";
            else if (nota >= 10)
                return "Recuperação";
            else
                return "Reprovado";
        }
    }
}