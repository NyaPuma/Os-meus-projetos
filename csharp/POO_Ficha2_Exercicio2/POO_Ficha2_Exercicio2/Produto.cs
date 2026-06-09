using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ficha2_Exercicio2
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Criar um programa em C# que faça a gestão uma lista de objetos da classe Produto,     ::::: //
    // ::::: aplicando os conceitos de POO e coleções genéricas.                                   ::::: //
    // ::::: Requisitos                                                                            ::::: //
    // ::::: 1. Criar uma classe chamada Produto com:                                              ::::: //
    // :::::     Atributos privados: nome(string) e preco(double).                                ::::: //
    // :::::     Construtor para inicializar os atributos.                                        ::::: //
    // :::::     Propriedades públicas(ou métodos Get/Set) para aceder aos dados.                 ::::: //
    // ::::: 2. No Main, criar uma List<Produto>.                                                  ::::: //
    // ::::: 3. Adicionar pelo menos 3 objetos Produto à lista (usando new Produto(...)).          ::::: //
    // ::::: 4. Utilizar métodos de List<T> para:                                                  ::::: //
    // :::::     Ordenar os produtos pelo preço (usando OrderBy ou Sort com um comparador.        ::::: //
    // :::::     Calcular a média de preços da lista(usando LINQ Average ou um ciclo).            ::::: //
    // :::::     Remover um produto específico da lista.                                          ::::: //
    // ::::: 5. Criar um método para mostrar todos os produtos da lista com o seu preço formatado. ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////

    internal class Produto
    {

            // ::::: Atributos privados ::::: //
            private string nome;
            private double preco;

            // ::::: Propriedades públicas ::::: //
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            public double Preco
            {
                get { return preco; }
                set { preco = value; }
            }

            // ::::: Construtor para inicializar os atributos ::::: //
            public Produto(string nome, double preco)
            {
                this.nome = nome;
                this.preco = preco;
            }
        
    }
}

