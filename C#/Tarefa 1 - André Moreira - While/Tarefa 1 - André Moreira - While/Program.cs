namespace Tarefa_1___André_Moreira___While
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::
            // :::::  Declaração de variáveis  :::::
            // :::::::::::::::::::::::::::::::::::::

            double VF, P, r, n;

            // ::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Entrada do Capital Inicial (P)  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Por favor, digite o capital inicial (100 a 1000000):");
            P = double.Parse(Console.ReadLine());

            while (P < 100 || P > 1000000)
            {
                Console.WriteLine("Valor inválido, digite um número entre 100 e 1000000");
                P = double.Parse(Console.ReadLine());
            }

            // ::::::::::::::::::::::::::::::::::::::::::
            // :::::  Entrada da Taxa de Juros (r)  :::::
            // ::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Por favor, digite a taxa de juros anual (1 a 100%):");
            r = double.Parse(Console.ReadLine());

            while (r < 1 || r > 100)
            {
                Console.WriteLine("Valor inválido, digite um número entre 1 e 100");
                r = double.Parse(Console.ReadLine());
            }

            // :::::::::::::::::::::::::::::::::::::::::::
            // :::::  Entrada do Número de Anos (n)  :::::
            // :::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Por favor, digite o número de anos (1 a 100):");
            n = double.Parse(Console.ReadLine());

            while (n < 1 || n > 100)
            {
                Console.WriteLine("Valor inválido, digite um número entre 1 e 100");
                n = double.Parse(Console.ReadLine());
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Cálculo do Valor Futuro (VF)                            :::::
            // :::::  Em C#, a potência é feita com Math.Pow(base, expoente)  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            VF = P * Math.Pow((1 + r / 100), n);

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Saída do resultado formatado com 2 casas decimais  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine($"O valor futuro do seu investimento será: {VF:F2}");
        }
    }
}
