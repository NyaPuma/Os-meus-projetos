using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ficha_1_exercicio_1
{
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Exercício 1 - Círculo                                                                   ::::: //
    // ::::: Implementar uma classe em C# que represente uma figura geométrica do tipo círculo,      ::::: //
    // ::::: aplicando os conceitos de programação orientada a objetos.                              ::::: //
    // ::::: Requisitos                                                                              ::::: //
    // :::::  Criar uma classe chamada Círculo.                                                     ::::: //
    // :::::  A classe deve possuir um atributo privado chamado raio(do tipo double).               ::::: //
    // :::::  Criar um construtor que permita inicializar o valor do raio.                          ::::: //
    // :::::  Criar métodos públicos para calcular a área do círculo e a circunferência do círculo. ::::: //           
    // :::::  Utilizar as fórmulas:                                                                 ::::: //
    // ::::: Área = π × raio²                                                                        ::::: //
    // ::::: Circunferência = 2 × π × raio.                                                          ::::: //
    // :::::  Demonstrar o funcionamento da classe num programa principal(Main), criando            ::::: //
    // ::::: um objeto circulo e apresentando os resultados dos cálculos.                            ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

    internal class Círculo
    {
        private double raio;

        // ::::: Construtor para inicializar o valor do raio ::::: //
        public Círculo(double raio)
        {
            this.raio = raio;
        }

        // ::::: Calcular a área do círculo usando a fórmula: Área = π × raio². ::::: //
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(raio, 2);
        }

        // ::::: Calcular a circunferência do círculo usando a fórmula: Circunferência = 2 × π × raio. ::::: //
        public double CalcularCircunferencia()
        {
            return 2 * Math.PI * raio;
        }

        // Método com parametro: usa o raio do objeto e um valor instanciado na main
        // Comparar areas

        public void CompararAreas(double outroRaio)
        {
            double areaAtual = CalcularArea(); // Área do círculo atual usando o método da classe
            double areaOutro = Math.PI * Math.Pow(outroRaio, 2); // Área do outro círculo usando a fórmula diretamente
            if (areaAtual > areaOutro)
            {
                Console.WriteLine("O círculo atual tem uma área maior.");
            }
            else if (areaAtual < areaOutro)
            {
                Console.WriteLine("O outro círculo tem uma área maior.");
            }
            else
            {
                Console.WriteLine("Ambos os círculos têm a mesma área.");
            }
        }
    }
}
