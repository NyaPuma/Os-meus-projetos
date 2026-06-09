using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_grupo_Abstract_Factory_Andre_JoaoM
{
    // Abstract Factory para criar famílias de peças
    public interface IFabricaPecas
    {
        IPeca CriarMotor();
        IPeca CriarPneu();
    }
}
