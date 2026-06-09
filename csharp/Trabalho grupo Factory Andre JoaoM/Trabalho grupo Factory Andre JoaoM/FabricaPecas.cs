using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_grupo_Factory_Andre_JoaoM
{
    // Fábrica abstrata
    public abstract class FabricaPecas
    {
        // Método fábrica (retorna uma peça)
        public abstract IPeca CriarPeca();
    }

    // Fábricas concretas
    public class FabricaMotor : FabricaPecas
    {
        public override IPeca CriarPeca() => new Motor();
    }

    public class FabricaPneu : FabricaPecas
    {
        public override IPeca CriarPeca() => new Pneu();
    }

    public class FabricaBateria : FabricaPecas
    {
        public override IPeca CriarPeca() => new Bateria();
    }
}
