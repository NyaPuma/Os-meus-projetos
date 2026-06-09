namespace ProjetoCaixaEncapsulamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Caixa caixa1 = new Caixa();
            //caixa1.lado = 5;
            //caixa1.altura = 10;

            //Caixa caixa2 = new Caixa(5, 10);

            //Console.WriteLine($"Lado: {caixa2.Lado}");

            // ::::: Criar um novo objeto a partir de dados do utilizador ::::: //
            Console.WriteLine("Insira um valor para lado:");
            int ladoUtilizador = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira um valor para altura:");
            int alturaUtilizador = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a password:");
            string password = Console.ReadLine();

            Caixa caixa2 = new(ladoUtilizador, alturaUtilizador);
            Console.WriteLine($"Caixa2: Lado: {caixa2.GetLado(password)}, altura: {caixa2.GetAltura()}");

            caixa2.SetLado(25);
            Console.WriteLine("Novo estado do lado");
            Console.WriteLine($"Caixa2: Lado: {caixa2.GetLado(password)}, altura: {caixa2.GetAltura()}");
        }
    }
}
