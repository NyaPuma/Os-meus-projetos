namespace Exercicio_2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            double soma = 0;
            int acimaDe7 = 0;
            bool existeAcimaDe5 = false;

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Pede ao utilizador para inserir o número de alunos  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.Write("Digite a quantidade de alunos: ");
            N = int.Parse(Console.ReadLine());

            double[] notas = new double[N];

            for (int i = 0; i < N; i++)
            {

                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                // :::::  Pede ao utilizador para inserir as notas dos alunos  :::::
                // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                Console.Write($"Digite a nota do aluno {i + 1}: ");
                notas[i] = double.Parse(Console.ReadLine());

                soma += notas[i];

                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                // :::::  Verifica se a nota está acima de 7, se sim incrementa o contador acimaDe7 (+1)  :::::
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                if (notas[i] > 7.0)
                {
                    acimaDe7++;
                }

                // ::::::::::::::::::::::::::::::::::::::::::::::::
                // :::::  Verifica se a nota está acima de 5  :::::
                // ::::::::::::::::::::::::::::::::::::::::::::::::

                if (notas[i] > 5.0)
                {
                    existeAcimaDe5 = true;
                }
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Calcula a média das notas dos alunos  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::

            double media = soma / N;

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Apresenta ao utilizador as médias com duas casas decimais e o número de alunos com notas acima de 7  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine($"Média das notas: {media:F2}");
            Console.WriteLine($"Quantidade de alunos com nota acima de 7.0: {acimaDe7}");

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Apresenta ao utilizador se não existem notas acima de 5  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            if (existeAcimaDe5 == false)
            {
                Console.WriteLine("Não há nenhum aluno com nota acima de 5.");
            }
        }
    }
}
