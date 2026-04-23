namespace exercicio_2._4_matriz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::
            // :::::  Matriz : [codigos, preco]  :::::
            // :::::::::::::::::::::::::::::::::::::::

            int[,] tabela =
            {
                { 100, 120 },
                { 101, 130 },
                { 102, 150 },
                { 103, 120 },
                { 104, 130 },
                { 105, 100 }
            };

            int codigo;
            int quantidade;
            double total = 0;

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: ler o codigo do produto que o utilizador quer  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Introduza o código:");
            codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduza a quantidade:");
            quantidade = int.Parse(Console.ReadLine());

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Percorrer a matriz para consultar o preço do produto escolhido  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                // ::::: coluna 0 - codigo :::::

                if (tabela[i, 0] == codigo)
                {
                    // ::::: coluna 1 - preço :::::

                    double preco = tabela[i, 1] / 100.00;
                    total = preco * quantidade;
                }
            }

            // :::::::::::::::::::::::::::::::::::
            // :::::  Mostrar os resultados  :::::
            // :::::::::::::::::::::::::::::::::::

            Console.WriteLine($"Total para a compra {total:F2}");
        }
    }
}
