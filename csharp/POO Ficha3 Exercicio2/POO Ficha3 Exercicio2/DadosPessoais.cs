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
    internal class DadosPessoais
    {
        // Propriedades com inicialização padrão para remover warnings de "non-nullable"
        public string Morada { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nif { get; set; } = string.Empty;
        public string DataNascimento { get; set; } = string.Empty;
        public string Telemovel { get; set; } = string.Empty;

        // Construtor para inicializar todos os campos da "parte"
        public DadosPessoais(string morada, string email, string nif, string dataNascimento, string telemovel)
        {
            Morada = morada;
            Email = email;
            Nif = nif;
            DataNascimento = dataNascimento;
            Telemovel = telemovel;
        }

        // Método para exibir apenas os detalhes pessoais
        public void ExibirInfo()
        {
            Console.WriteLine($"Morada: {Morada}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"NIF: {Nif}");
            Console.WriteLine($"Data de Nascimento: {DataNascimento}");
            Console.WriteLine($"Telemóvel: {Telemovel}");
        }
    }   
}
