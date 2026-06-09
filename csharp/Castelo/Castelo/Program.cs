namespace Castelo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tesouro tesouro1 = new Tesouro();
            //Tesouro tesouro2 = new Tesouro();

            // Cada vez que faço new estou a criar um novo objeto

            //Tesouro tesouro1 = Tesouro.GetInstancia();
            //Tesouro tesouro2 = Tesouro.GetInstancia();

            Tesouro tesouro1 = Tesouro.Instance;
            Tesouro tesouro2 = Tesouro.Instance;

            Console.WriteLine(tesouro1.GetHashCode());
            Console.WriteLine(tesouro2.GetHashCode());
            Tesouro.Guardar();
        }
    }
}
