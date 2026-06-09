using System;
using System.Collections.Generic;
using System.Text;

namespace trabalho_grupo_singleton_Andre_JoaoM
{
    public sealed class OficinaSingleton
    {
        // Instância única (estática)
        private static OficinaSingleton _instancia;

        // Construtor privado para evitar new OficinaSingleton()
        private OficinaSingleton() { }

        // Propriedade para acessar a instância
        public static OficinaSingleton Instancia
        {
            get
            {
                _instancia ??= new OficinaSingleton();
                return _instancia;
            }
        }

        // Método de exemplo
        public static void RegistrarServico(string carro)
        {
            Console.WriteLine($"Serviço registado para: {carro}");
        }
    }
}
