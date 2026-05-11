using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

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
    internal abstract class Forma
        (
            string nome
        )

    {
        public string Nome { get; set; } = nome;

        // Método comum a todos
        public void MostrarNome()
        {
            Console.WriteLine($"Forma: {Nome}");
        }

        // Método abstrato (deve ser implementado nas classes filhas)
        public abstract double CalcularArea();
    }
}
