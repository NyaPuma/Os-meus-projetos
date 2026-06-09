using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaBrinquedos
{
    internal class Boneca:Brinquedo
    {
        public override void Mover()
        {
            Console.WriteLine("A boneca está a dançar");
        }
    }
}
