using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCaixaEncapsulamento
{
    internal class Caixa
    {
        // ::::: Atributos ::::: //
        private int lado;
        private int altura;

        // ::::: Construtor padrão ::::: //

        public Caixa()
        {
            // ::::: Construtor vazio, sem parâmetros ::::: //
        }

        public Caixa(int lado, int altura)
        {
            this.lado = lado;
            this.altura = altura;
        }

        // ::::: Métodos de acesso (getters e setters) ::::: //
        public int GetLado(string pass)
        {
            if (pass == "1234")
            {
                return lado;
            }
            else
            {
                return -1;
            }
        }

        public int GetAltura()
        {
            return altura;
        }

        public void SetLado(int novolado) 
        { 
            lado = novolado; 
        }
    }
}
