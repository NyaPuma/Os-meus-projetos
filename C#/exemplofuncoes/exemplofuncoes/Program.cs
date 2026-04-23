namespace exemplofuncoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resultado;

            Console.WriteLine("Digite o primeiro número:");
            int numero1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número:");
            int numero2 = int.Parse(Console.ReadLine());

            resultado = CalcularSoma( numero1 , numero2 );

            Console.WriteLine($"O resultado da soma é: " + resultado);
        }

        static public int CalcularSoma(int a, int b)
        {
            return a + b;
        }
    }
}
