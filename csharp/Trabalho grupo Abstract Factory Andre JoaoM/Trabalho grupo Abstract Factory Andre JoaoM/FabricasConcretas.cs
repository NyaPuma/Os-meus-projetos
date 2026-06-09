using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_grupo_Abstract_Factory_Andre_JoaoM
{
    // Fábrica para Toyota
    public class FabricaToyota : IFabricaPecas
    {
        public IPeca CriarMotor() => new MotorToyota();
        public IPeca CriarPneu() => new PneuToyota();
    }

    // Fábrica para Ford
    public class FabricaFord : IFabricaPecas
    {
        public IPeca CriarMotor() => new MotorFord();
        public IPeca CriarPneu() => new PneuFord();
    }
}
