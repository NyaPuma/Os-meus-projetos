namespace TesteUnitarioCalculadora
{
    // 1. Classe Principal (A testar)
    internal class Calculadora
    {
        public static int Somar(int a, int b)
        {
            return a + b;
        }

        public static int Subtrair(int a, int b)
        {
            return a - b;
        }

        public static int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public static int Dividir(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("O divisor não pode ser zero.");
            }
            return a / b;
        }
    }
}