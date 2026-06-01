using System;
using System.Collections.Generic;
using System.Text;

namespace Castelo
{
    internal class Tesouro
    {
        // Com constructor privado não posso utilizar o new fora
        // mas vou precisar de um ponto de criação interno
        private Tesouro()
        {

        }

        private static Tesouro? instancia;

        public static Tesouro GetInstancia()
        {
            instancia ??= new Tesouro();
            return instancia;
        }

        // Criar uma propriedade que vai devolver um objeto singleton
        public static Tesouro Instance
        {
            get
            {
                instancia ??= new Tesouro();
                return instancia;
            }
        }

        // Metodo normal
        public static void Guardar()
        {
            Console.WriteLine("O tesouro está guardado.");
        }
    }
}
