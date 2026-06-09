namespace ProjetoCaixa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Construir objeto caixa 1 -> INSTANCIAR ::::: //
            // :::::::::::::::::::::::::::::::::::::::::::::::::: //

            Caixa caixa1 = new(); // Instanciando o objeto caixa1 a partir da classe Caixa
            Console.WriteLine(caixa1.altura);

            caixa1.altura = 10; // Atribuindo o valor 10 à variável altura do objeto caixa1
            caixa1.largura = 20; // Atribuindo o valor 20 à variável largura do objeto caixa1
            Console.WriteLine($"lado: {caixa1.altura}");
            Console.WriteLine($"largura: {caixa1.largura}");

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Chamada do método que calcula o volume da caixa 1 ::::: //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

            Console.WriteLine($"Volume: {caixa1.CalcularVolume()}");

            // ::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Criar um segundo objeto caixa 2 ::::: //
            // ::::::::::::::::::::::::::::::::::::::::::: //

            Caixa caixa2 = new(); // Instanciando o objeto caixa2 a partir da classe Caixa
            caixa2.altura = 20;
            caixa2.largura = 30;
            Console.WriteLine($"lado: {caixa2.altura}");
            Console.WriteLine($"largura: {caixa2.largura}");
            Console.WriteLine($"Volume: {caixa2.CalcularVolume()}");

            // :::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Prova que são objetos diferentes ::::: //
            // :::::::::::::::::::::::::::::::::::::::::::: //

            Console.WriteLine($"São objetos diferentes? {object.ReferenceEquals(caixa1,caixa2)}");

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Construir um novo objeto a partir do construtor de parametros ::::: //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

            Caixa caixa3 = new(15, 25); // Instanciando o objeto caixa3 a partir do construtor com parâmetros
            Console.WriteLine($"Caixa 3: largura: {caixa3.largura}, altura: {caixa3.altura}");
            Console.WriteLine($"Volume: {caixa3.CalcularVolume()}");

            // ::::: No final do programa, quero saber quantas caixas foram criadas ::::: //
            Console.WriteLine($"Número de caixas criadas: {Caixa.contadorCaixas}");
        }
    }
}
