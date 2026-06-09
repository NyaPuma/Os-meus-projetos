using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaMoveis
{
    internal interface IMoveisFactory
    {
        ICadeira CriarCadeira();
        IMesa CriarMesa();
    }
}
