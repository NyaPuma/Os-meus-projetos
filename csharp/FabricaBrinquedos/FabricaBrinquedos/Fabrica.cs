using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaBrinquedos
{
    internal class Fabrica
    {
        //no padrão factory o codigo deixa criar objetos diretamente
        //e passa a pedir á fabrica para decidir qual o objeto a ser criado

        public static Brinquedo CriarBrinquedo(string tipo)
        {
            return tipo switch
            {
                "UrsoPeluche"          => new UrsoPeluche(),
                "CarroTelecomandado"   => new CarroTelecomandado(),
                "Boneca"               => new Boneca(),
                _                      => throw new ArgumentException("Tipo de brinquedo desconhecido"),
            };
        }
    }
}
