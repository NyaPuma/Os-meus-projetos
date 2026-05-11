using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_Sistema_de_formas_geometricas
{
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Exercício 1- Sistema de Formas Geométricas                                     ::::: //
    // :::::                                                                                ::::: //
    // ::::: Crie uma aplicação em C# para representar diferentes formas geométricas.       ::::: //
    // ::::: Implemente uma classe abstrata chamada Forma com:                              ::::: //
    // :::::     atributo Nome                                                             ::::: //
    // :::::     construtor para inicializar o nome                                        ::::: //
    // :::::     método MostrarNome()                                                      ::::: //
    // :::::     método abstrato CalcularArea()                                            ::::: //
    // :::::                                                                                ::::: //
    // ::::: Crie as classes derivadas:                                                     ::::: //
    // :::::     Quadrado(deve possuir atributo Lado)                                      ::::: //
    // :::::     Retangulo(deve possuir atributos Base e Altura)                           ::::: //
    // :::::                                                                                ::::: //
    // ::::: Cada classe deve implementar o método CalcularArea() de acordo com a respetiva ::::: //
    // ::::: fórmula.                                                                       ::::: //
    // :::::                                                                                ::::: //
    // ::::: No método Main():                                                              ::::: //
    // :::::    1. Criar um objeto de cada classe                                           ::::: //
    // :::::    2. Mostrar o nome da forma                                                  ::::: //
    // :::::    3. Mostrar a área calculada                                                 ::::: //
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar objetos
            Forma q1 = new Quadrado(5, "Quadrado");
            Forma r1 = new Retangulo(10, 5, "Retângulo");

            // Exibir dados do Quadrado
            q1.MostrarNome();
            Console.WriteLine($"Área calculada: {q1.CalcularArea()}");

            // Separador
            Console.WriteLine("==================================================================");

            // Exibir dados do Retângulo
            r1.MostrarNome();
            Console.WriteLine($"Área calculada: {r1.CalcularArea()}");
        }
    }
}
