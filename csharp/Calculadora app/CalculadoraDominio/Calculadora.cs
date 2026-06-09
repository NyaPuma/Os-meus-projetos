namespace CalculadoraDominio
{
    public class Calculadora
    {
        public double Somar(int a, int b)
        {
            return a + b;
        }
        public double Subtrair(int a, int b)
        {
            return a - b;
        }
        public double Multiplicar(int a, int b)
        {
            return a * b;
        }
        public double Dividir(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Não é possível dividir por zero.");
            }
            return a / b;
        }
    }
}
