using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_grupo_Abstract_Factory_Andre_JoaoM
{
    // Peças específicas para Ford
    public class MotorFord : IPeca
    {
        public void Instalar() => Console.WriteLine("Motor Ford instalado.");
    }

    public class PneuFord : IPeca
    {
        public void Instalar() => Console.WriteLine("Pneu Ford instalado.");
    }
}
