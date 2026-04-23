namespace Primeiro_Projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Olá, bem vindo a programação C#");

            // ::::::::::::::::::::::::::::::::::::
            // :::::  Variáveis e Constantes  :::::
            // ::::::::::::::::::::::::::::::::::::

            // Variáveis

            int idade;
            idade = 28;
            int numero = 3;

            // Constantes

            const double taxadeimposto = 0.25;

            float temperatura = 25.5f;
            decimal preco = 33.33m;
            double media = 56.4567;

            // :::::::::::::::::::::::
            // :::::  Conversão  :::::
            // :::::::::::::::::::::::

            double con1 = numero;
            Console.WriteLine(numero.GetType());
            Console.WriteLine(con1.GetType());

            // ::::::::::::::::::::::::::::
            // :::::  Cast explicito  :::::
            // ::::::::::::::::::::::::::::

            int con2 = (int)temperatura;
            Console.WriteLine("Temperatura" + con1.GetType() + "Valor" + con2);

            // ::::::::::::::::::::::::
            // :::::  Caracteres  :::::
            // ::::::::::::::::::::::::

            char letra = 'A';
            string palavra = "Olá";
            string nome = "Sara";

            string saudacao = palavra + nome;
            Console.WriteLine(saudacao);

            string texto = "C# é incrivel";
            Console.WriteLine("Tamanho do texto" + texto.Length);
            Console.WriteLine(texto.ToUpper());                          // Maísculas
            Console.WriteLine(texto.ToLower());                          // Minusculas

            // ::::::::::::::::::::::::::
            // :::::  Interpolação  :::::
            // ::::::::::::::::::::::::::

            Console.WriteLine($"Interpolação: {palavra} {nome}");

            // ::::::::::::::::::::::::::
            // :::::  Concatenação  :::::
            // ::::::::::::::::::::::::::

            Console.WriteLine("Concatenação" + palavra + " " + nome);

            // ::::::::::::::::::::::::::::::::::::
            // :::::  Expressões matemáticas  :::::
            // ::::::::::::::::::::::::::::::::::::

            int a = 10;
            int b = 3;

            int soma = a + b;
            int diferenca = a - b;
            int multiplicacao = a * b;
            double divisao = a / b;

            // ::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Operadores de atribuição combinada  :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::

            a += 5;         //a = a + 5
            a -= 2;         //a = a - 2
            a *= 2;         //a = a * 2

            // :::::::::::::::::::::::::::::::::
            // :::::  Expressões boleanas  :::::
            // :::::::::::::::::::::::::::::::::

            bool emaior = a > b;
            Console.WriteLine(emaior);

            bool eigual = a == b;
            Console.WriteLine(eigual);

            bool ediferente = a != b;
            Console.WriteLine(ediferente);

            // :::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Utilização de funções matemáticas  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::

            double x = Math.Sqrt(2.5);
            Console.WriteLine(x);

            // :::::::::::::::::::::::
            // :::::  if / else  :::::
            // :::::::::::::::::::::::

            int idade2 = 18;

            if (idade2 >= 18)
            {
                Console.WriteLine("É maior de idade!");
            }

            else if (idade2 >= 16)
            {
                Console.WriteLine("Já pode conduzir!");
            }

            else
            {
                Console.WriteLine("É menor de idade!");
            }
        }
    }
}
