using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaMoveis
{
    internal class FabricaClassica : IMoveisFactory
    {
        public ICadeira CriarCadeira()
        {
            return new CadeiraClassica();
        }
        public IMesa CriarMesa()
        {
            return new MesaClassica();
        }
    }
}
