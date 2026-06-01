using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaMoveis
{
    internal class FabricaModerna : IMoveisFactory
    {
        public ICadeira CriarCadeira()
        {
            return new CadeiraModerna();
        }

        public IMesa CriarMesa()
        {
            return new MesaModerna();
        }
    }
}
