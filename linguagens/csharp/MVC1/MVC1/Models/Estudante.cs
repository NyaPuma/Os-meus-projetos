using System;
using System.Collections.Generic;
using System.Text;

namespace MVC1.Models
{
    public class Estudante
    {
        public string Nome { get; set; }
        private int _idade;

        public int Idade
        {
            get { return _idade; }
            set
            {
                // Regra de negócio
                if (value < 18)
                {
                    throw new ArgumentException("Idade não pode ser menor que 18.");
                }
                _idade = value;
            }
        }
    }
}
