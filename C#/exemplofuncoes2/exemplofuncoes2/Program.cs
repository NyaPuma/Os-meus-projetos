namespace exemplofuncoes2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::: Calculo da area de um quadrilatero (4 lados) :::::
            // ::::: ou um quadrado ou um rectangulo              :::::

            // double lado1 = 12.5;
            // double lado2 = 3.0;

            Console.WriteLine("Digite um valor para lado1:");
            double lado1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite um valor para lado2:");
            double lado2 = double.Parse(Console.ReadLine());

            double area = CalcularArea(lado1, lado2);
            string nomefigura = NomeFiguraGeometrica(lado1, lado2);
            Mensagem(area, lado1, lado2, nomefigura);
            FiguraGeometrica(lado1, lado2);
        }

        static public double CalcularArea(double a, double b)
        {
            return a * b;
        }

        static public void Mensagem(double area, double lado1, double lado2, string nome)
        {
            Console.WriteLine("::::: Resultados :::::");
            Console.WriteLine($"O valor da área é de {area}");
            Console.WriteLine($"A figura é um {nome}");
        }

        static public void FiguraGeometrica(double lado1, double lado2)
        {
            // ::::: Verifica se é um quadrado ou um retangulo :::::
            if (lado1 == lado2)
            {
                Console.WriteLine("É um quadrado");
            }
            else
            {
                Console.WriteLine("É um retangulo");
            }
        }
        static public string NomeFiguraGeometrica(double lado1, double lado2)
        {
            if (lado1 == lado2)
            {
                return "Quadrado";
            }
            else
            {
                return "Rectangulo";
            }
        }
    }

}

