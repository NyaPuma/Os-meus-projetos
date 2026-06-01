using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaBrinquedos
{
    internal class CarroTelecomandado:Brinquedo
    {
        public override void Mover()
        {
            Console.WriteLine("O carro de controlo remoto está a acelerar");
        }
    }
}
