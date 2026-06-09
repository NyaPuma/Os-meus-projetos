using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ficha3_Exercicio2
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um programa que gere Clientes e os seus Dados Pessoais.O objetivo é      ::::: //
    // ::::: aplicar o conceito de Composição, onde as informações de identificação do cliente   ::::: //
    // ::::: fazem parte do "todo".                                                              ::::: //
    // :::::                                                                                     ::::: //
    // ::::: Funcionalidades                                                                     ::::: //
    // :::::    1. Criar um Cliente(nome e numeroCliente).                                       ::::: //
    // :::::    2. Definir os Dados Pessoais(Morada, Email, NIF, Data de Nascimento,             ::::: //
    // :::::    Telemovel) no momento da criação do cliente.                                     ::::: //
    // :::::    3. Listar o cliente com todas as suas informações detalhadas.                    ::::: //
    // :::::    Estrutura das Classes                                                            ::::: //
    // :::::                                                                                     ::::: //
    // :::::  Classe DadosPessoais (A parte)                                                    ::::: //
    // :::::     NIF (string)                                                                   ::::: //
    // :::::     DataNascimento (string)                                                        ::::: //
    // :::::     Método ExibirInfo()                                                            ::::: //
    // :::::                                                                                     ::::: //
    // :::::  Classe Cliente (O todo)                                                           ::::: //
    // :::::     Nome (string)                                                                  ::::: //
    // :::::     NumeroCliente (int)                                                            ::::: //
    // :::::     DadosPessoais (do tipo DadosPessoais)                                          ::::: //
    // :::::     Método ExibirInfo()                                                            ::::: //
    // :::::                                                                                     ::::: //
    // ::::: O objeto Cliente deve gerir os seus DadosPessoais.A lógica de composição exige que, ::::: //
    // ::::: ao criar um cliente, os seus dados pessoais sejam instanciados internamente.        ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Cliente
    {
        public string Nome { get; set; } = string.Empty;
        public int NumeroCliente { get; set; }

        // Campo privado que representa a composição: o Cliente "tem um" DadosPessoais
        private DadosPessoais detalhes;

        // O construtor do Cliente recebe tudo o que é necessário para criar a si mesmo e à sua "parte"
        public Cliente(string nome, int numero, string morada, string email, string nif, string data, string tel)
        {
            Nome = nome;
            NumeroCliente = numero;

            // COMPOSIÇÃO: O objeto DadosPessoais é instanciado DENTRO do Cliente.
            // Se o Cliente for destruído, os detalhes também serão.
            detalhes = new DadosPessoais(morada, email, nif, data, tel);
        }

        public void ExibirInfo()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine($"CLIENTE Nº: {NumeroCliente}");
            Console.WriteLine($"NOME: {Nome}");
            Console.WriteLine("----------------------------------------");

            // Delegação: O Cliente pede aos seus detalhes para se exibirem
            detalhes.ExibirInfo();

            Console.WriteLine("========================================\n");
        }
    }
}
