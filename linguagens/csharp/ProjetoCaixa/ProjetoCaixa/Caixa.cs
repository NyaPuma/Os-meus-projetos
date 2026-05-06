using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCaixa
{
    internal class Caixa
    {
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Declarar o meu atributo publico para altura da caixa ::::: //
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

        public int altura;

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Declarar o meu atributo publico para largura da caixa ::::: //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

        public int largura;

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Declarar uma variável estática para contar o número de caixas criadas ::::: //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //

        public static int contadorCaixas = 0; //iniciar o contador com 0

        // ::::::::::::::::::::::::::::: //
        // ::::: Método construtor ::::: //
        // ::::::::::::::::::::::::::::: //

        public Caixa() // Construtor vazio
        {
            contadorCaixas++; // Incrementar o contador de caixas a cada vez que um novo objeto for criado
        }

        // :::::::::::::::::::::::::::::::::::::::::::::::::: //
        // ::::: Construir um construtor com parametros ::::: //
        // :::::::::::::::::::::::::::::::::::::::::::::::::: //

        public Caixa(int altura, int largura) // Construtor com parâmetros
        {
            this.altura = altura; // Atribuir o valor do parâmetro altura ao atributo da classe
            this.largura = largura; // Atribuir o valor do parâmetro largura ao atributo da classe
            contadorCaixas++; // Incrementar o contador de caixas a cada vez que um novo objeto for criado
        }

        // ::::::::::::::::::::::::::::::::::::::: //
        // ::::: Método de calcúlo do volume ::::: //
        // ::::::::::::::::::::::::::::::::::::::: //

        public int CalcularVolume()
        {
            return altura * largura * altura; // Fórmula do volume: V = A x L x A
        }
    }
}
