namespace ExemploTryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduza um valor:");

            // ::::: Ler o texto que foi digitado :::::

            string texto = Console.ReadLine();

            // ::::: Tentar converter a string texto num numero :::::

            bool ConseguiuConverter = int.TryParse(texto, out int numero);

            if (ConseguiuConverter)
            {
                Console.WriteLine("Conversão com sucesso");
                Console.WriteLine($"Número introduzido {numero}");
                Console.WriteLine($"O dobro do número é {numero * 2}");
            }
            else
            {
                Console.WriteLine("Erro");
            }

            int resultado = numero;
            Console.WriteLine($"O resultado é {resultado}");
        }
    }
}
