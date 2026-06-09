using System;
using System.Collections.Generic;
using System.Text;

namespace PropriedadesAutoincrementadas
{
    internal class Cliente
    {
        // ::::: Propriedades AutoImplementadas                                              ::::: //
        // ::::: Reduz a escrita; torna o código mais limpo + legivel e mais fácil de manter ::::: //
        public string Nome { get; set; }
        public int idade { get; set; }

        public Cliente()
        {

        }

    }
}
