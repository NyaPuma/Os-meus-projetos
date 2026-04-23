using System.Globalization;
namespace SegundoProjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pedir ao utilizador que introduza o:
            // Nome, Morada, Idade, Nota1, Nota2
            // Pretendo mostrar na consola a informação do utilizador
            // e apresentar a média das notas

            // :::::::::::::::::::::::
            // :::::  Variaveis  :::::
            // :::::::::::::::::::::::

            string nome;
            string morada;
            int idade;
            double nota1;
            double nota2;
            double media;

            // ::::::::::::::::::::::::::::::::::::::::::
            // :::::  Pedir os dados ao utilizador  :::::
            // ::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine("Digite o seu nome:");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a sua morada:");
            morada = Console.ReadLine();

            Console.WriteLine("Digite a sua idade:");
            idade = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Digite a nota1:");
            nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Digite a nota2:");
            nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // ::::::::::::::::::::::::::::::
            // :::::  Calcular a média  :::::
            // ::::::::::::::::::::::::::::::

            media = (nota1 + nota2) / 2;
            Console.WriteLine($"Nome: {nome} Morada: {morada} Idade: {idade}");
            Console.WriteLine($"A média das notas é: {media:F2}");
        }
    }
}
