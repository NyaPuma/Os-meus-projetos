using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_grupo_Factory_Andre_JoaoM
{
    using System;

    // Peças concretas
    public class Motor : IPeca
    {
        public void Instalar() => Console.WriteLine("Motor instalado.");
    }

    public class Pneu : IPeca
    {
        public void Instalar() => Console.WriteLine("Pneu instalado.");
    }

    public class Bateria : IPeca
    {
        public void Instalar() => Console.WriteLine("Bateria instalada.");
    }
}
