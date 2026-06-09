using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ficha1_Exercicio3
{
    internal class ContaBancaria
    {
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // ::::: Implementar uma classe em C# que represente uma conta bancária, aplicando           :::::
        // ::::: conceitos de programação orientada a objetos, incluindo o uso de variável estática. :::::
        // :::::    Requisitos                                                                       :::::
        // :::::  Criar uma classe chamada ContaBancaria.                                           :::::
        // :::::  A classe deve possuir:                                                            :::::
        // :::::      um atributo privado numero(do tipo int), que identifica a conta;              :::::
        // :::::      um atributo privado saldo(do tipo double), que guarda o saldo da              :::::
        // :::::     conta;                                                                          :::::
        // :::::      uma variável estática privada chamada totalContas(do tipo int), que           :::::
        // :::::     conta quantas contas já foram criadas.                                          :::::
        // :::::  Criar um construtor que:                                                          :::::
        // :::::      permita inicializar o numero e o saldo;                                       :::::
        // :::::      incremente a variável estática totalContas sempre que uma nova                :::::
        // :::::     conta é criada.                                                                 :::::
        // :::::  Criar:                                                                            :::::
        // :::::      métodos públicos para depositar(Depositar(double valor)) e levantar           :::::
        // :::::     (Levantar(double valor));                                                       :::::
        // :::::      um método público MostrarDados() que apresente o número da conta              :::::
        // :::::     e o seu saldo;                                                                  :::::
        // :::::      um método estático TotalContas() que devolva o valor da                       :::::
        // :::::     variável totalContas(sem parâmetros).                                           :::::
        // :::::  Demonstrar o funcionamento da classe num programa principal(Main):                :::::
        // :::::      criar várias contas(ContaBancaria conta1 = ..., conta2 = ...);                :::::
        // :::::      efetuar depósitos e levantamentos nas contas;                                 :::::
        // :::::      no final, invocar o método estático TotalContas() para mostrar quantas        :::::
        // :::::     contas foram criadas.                                                           :::::
        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        // Atributos
        private int numero;
        private double saldo;
        private static int totalContas = 0;

        // Construtor
        public ContaBancaria(int numero, double saldo)
        {
            this.numero = numero;
            this.saldo = saldo;
            totalContas++;
        }

        // Métodos públicos para depositar
        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
            else
            {
                Console.WriteLine("Valor de depósito deve ser positivo.");
            }
        }

        // Método para levantar dinheiro, verificando se o saldo é suficiente
        public void Levantar(double valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para levantar o valor solicitado.");
            }
        }

        // Método para mostrar os dados da conta
        public void MostrarDados()
        {
            Console.WriteLine($"Número da conta: {numero}, Saldo: {saldo}");
        }

        // Método estático para obter o total de contas
        public static int TotalContas()
        {
            return totalContas;
        }
    }
}
