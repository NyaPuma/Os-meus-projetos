using System;
using System.Collections.Generic;
using System.Text;

namespace Explicacao_listas
{
    internal class Fruta
    {
        public string Nome { get; set; } // propriedade auto-inplementada

        public int Codigo { get; set; }

        // Construtor
        public Fruta(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

    }
}
