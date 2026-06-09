using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_grupo_Abstract_Factory_Andre_JoaoM
{
    // Peças específicas para Toyota
    public class MotorToyota : IPeca
    {
        public void Instalar() => Console.WriteLine("Motor Toyota instalado.");
    }

    public class PneuToyota : IPeca
    {
        public void Instalar() => Console.WriteLine("Pneu Toyota instalado.");
    }
}
