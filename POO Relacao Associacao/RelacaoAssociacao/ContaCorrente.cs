using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoAssociacao
{
    internal class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public string Agencia { get; set; }
        public  string Numero { get; set; }
        public double Saldo { get; set; }


        //métodos

        public void Depositar(double valor)
        {
            
            Saldo += valor;
        }
        public void Levantar(double valor)
        {
            if (valor >= Saldo)
            {
                Saldo -= valor;
            }
        }
    }
}
