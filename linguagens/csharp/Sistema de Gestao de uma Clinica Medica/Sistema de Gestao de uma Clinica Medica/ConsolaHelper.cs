using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; // Necessário para .Any() e .All()
using System.Text;

namespace Sistema_de_Gestao_de_uma_Clinica_Medica
{
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um programa em C# para gerir uma clínica médica.                                   ::::: //
    // ::::: O objetivo é aplicar os conceitos fundamentais de Programação Orientada a Objetos,            ::::: //
    // ::::: nomeadamente a criação de classes, objetos, propriedades e diferentes tipos de relações       ::::: //
    // ::::: entre classes(associação, agregação e composição).                                            ::::: //
    // :::::                                                                                               ::::: //
    // ::::: Funcionalidades do Sistema:                                                                   ::::: //
    // ::::: 1. Gestão da Clínica                                                                          ::::: //
    // :::::     Registar nome e morada da clínica                                                        ::::: //
    // :::::     Adicionar pacientes à clínica                                                            ::::: //
    // :::::     Adicionar médicos à clínica                                                              ::::: //
    // :::::     Registar consultas realizadas                                                            ::::: //
    // ::::: 2. Registo de Pacientes                                                                       ::::: //
    // :::::     Nome completo                                                                            ::::: //
    // :::::     Data de nascimento                                                                       ::::: //
    // :::::     Número de processo único                                                                 ::::: //
    // ::::: 3.Registo de Médicos                                                                          ::::: //
    // :::::     Nome completo                                                                            ::::: //
    // :::::     Especialidade médica                                                                     ::::: //
    // :::::     Número de cédula profissional                                                            ::::: //
    // ::::: 4.Gestão de Consultas                                                                         ::::: //
    // :::::     Data e hora da consulta                                                                  ::::: //
    // :::::     Associar paciente à consulta                                                             ::::: //
    // :::::     Associar médico à consulta                                                               ::::: //
    // :::::     Adicionar observações à consulta                                                         ::::: //
    // ::::: 5. Gestão de Observações                                                                      ::::: //
    // :::::     Texto da observação clínica                                                              ::::: //
    // :::::     Data/hora da anotação                                                                    ::::: //
    // :::::     Nível de prioridade(Baixa / Média / Alta)                                                ::::: //
    // ::::: 6. Consultas e Listagens                                                                      ::::: //
    // :::::     Listar todos os pacientes da clínica                                                     ::::: //
    // :::::     Listar todos os médicos da clínica                                                       ::::: //
    // :::::     Listar todas as consultas com detalhes completos                                         ::::: //
    // :::::                                                                                               ::::: //
    // ::::: Relações entre classes:                                                                       ::::: //
    // ::::: 1. Relação entre Clínica e Paciente                                                           ::::: //
    // ::::: Existe uma relação de agregação entre as classes Clínica e Paciente.                          ::::: //
    // :::::     Uma clínica pode possuir vários pacientes                                                ::::: //
    // :::::     Cada paciente pertence a uma única clínica                                               ::::: //
    // :::::    Cardinalidade: 1..* (um para muitos)                                                       ::::: //
    // :::::    Isto significa que a clínica mantém uma lista de pacientes registados, mas os pacientes    ::::: //
    // :::::    podem existir independentemente da clínica.                                                ::::: //
    // ::::: 2. Relação entre Paciente e Consulta                                                          ::::: //
    // ::::: Existe uma relação de associação entre as classes Paciente e Consulta.                        ::::: //
    // :::::     Um paciente pode ter várias consultas                                                    ::::: //
    // :::::     Cada consulta está associada a um único paciente                                         ::::: //
    // :::::    Cardinalidade: 1..* (um para muitos)                                                       ::::: //
    // :::::    Esta relação representa o histórico clínico de cada paciente.                              ::::: //
    // ::::: 3. Relação entre Consulta e Médico                                                            ::::: //
    // ::::: Existe uma relação de associação entre as classes Consulta e Médico.                          ::::: //
    // :::::     Um médico pode realizar várias consultas                                                 ::::: //
    // :::::     Cada consulta é realizada por um único médico                                            ::::: //
    // :::::    Cardinalidade: 1..* (um para muitos)                                                       ::::: //
    // :::::    Esta associação permite identificar qual o profissional responsável por cada atendimento.  ::::: //
    // ::::: 4. Relação entre Consulta e Observação                                                        ::::: //
    // ::::: Existe uma relação de composição entre as classes Consulta e Observação.                      ::::: //
    // :::::     Uma consulta pode conter várias observações                                              ::::: //
    // :::::     Cada observação pertence exclusivamente a uma única consulta                             ::::: //
    // :::::    Cardinalidade: 1..* (um para muitos)                                                       ::::: //
    // :::::    Sendo uma composição, as observações não existem sem a consulta à qual pertencem.Caso      ::::: //
    // :::::    a consulta seja eliminada, todas as observações associadas também serão removidas.         ::::: //
    // ::::: 5. Relação entre Clínica e Médico                                                             ::::: //
    // ::::: A clínica mantém uma associação com os médicos que nela exercem funções.                      ::::: //
    // :::::     Uma clínica pode ter vários médicos                                                      ::::: //
    // :::::     Um médico encontra - se registado na clínica                                             ::::: //
    // :::::    Esta relação representa a equipa médica disponível para realização de consultas.           ::::: //
    // :::::                                                                                               ::::: //
    // ::::: Requisitos Técnicos:                                                                          ::::: //
    // ::::: Linguagem de Programação:                                                                     ::::: //
    // ::::: O sistema deve ser desenvolvido em C#, aplicando rigorosamente os princípios da programação   ::::: //
    // ::::: orientada a objetos (POO).                                                                    ::::: //
    // ::::: Modularidade:                                                                                 ::::: //
    // ::::: O código deve ser organizado de maneira modular, maximizando a reutilização de componentes.   ::::: //
    // ::::: Para isso, utilize classes e métodos bem definidos, que permitam a essa manutenção e expansão ::::: //
    // ::::: do sistema.Cada responsabilidade deve ser atribuída a um módulo específico, minimizando o     ::::: //
    // ::::: acoplamento entre eles.                                                                       ::::: //
    // :::::                                                                                               ::::: //
    // ::::: Propostas de Expansão e Melhorias:                                                            ::::: //
    // ::::: Além das funcionalidades básicas descritas, os formandos têm liberdade para propor novas      ::::: //
    // ::::: funcionalidades ou melhorar as existentes, desde que essas propostas sejam bem                ::::: //
    // ::::: fundamentadas e implementadas de acordo com os princípios de programação orientada a          ::::: //
    // ::::: objetos.                                                                                      ::::: //
    // :::::                                                                                               ::::: //
    // ::::: Toda proposta de melhoria ou nova funcionalidade deve ser apresentada com uma breve           ::::: //
    // ::::: justificação:                                                                                 ::::: //
    // :::::    - Por que a ideia foi escolhida.E como ela melhora o sistema.                              ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    public static class ConsolaHelper
    {
        // 1. LER TEXTO
        public static string LerTexto(string campo, int minLetras, bool apenasLetras, bool apenasNumeros = false)
        {
            while (true)
            {
                try
                {
                    Console.Write($"{campo}: ");
                    string entrada = Console.ReadLine()?.Trim() ?? "";

                    if (string.IsNullOrEmpty(entrada) || entrada.Length < minLetras)
                    {
                        throw new ArgumentException($"O campo '{campo}' é obrigatório e deve ter pelo menos {minLetras} caracteres.");
                    }

                    if (apenasLetras && entrada.Any(char.IsDigit))
                    {
                        throw new FormatException($"O campo '{campo}' não pode conter números.");
                    }

                    if (apenasNumeros && !entrada.All(char.IsDigit))
                    {
                        throw new FormatException($"O campo '{campo}' deve conter apenas algarismos numéricos.");
                    }

                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entrada.ToLower());
                }
                catch (ArgumentException ex) { Console.WriteLine($"[ERRO]: {ex.Message}"); }
                catch (FormatException ex) { Console.WriteLine($"[ERRO]: {ex.Message}"); }
                catch (Exception ex) { Console.WriteLine($"[ERRO INESPERADO]: {ex.Message}"); }
            }
        }

        // 2. LER DATA
        public static DateTime LerData(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string entrada = "";

                    while (true)
                    {
                        ConsoleKeyInfo tecla = Console.ReadKey(true);
                        if (tecla.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }

                        if (tecla.Key == ConsoleKey.Backspace && entrada.Length > 0)
                        {
                            if (entrada.EndsWith('/'))
                            {
                                entrada = entrada[..^1];
                                Console.Write("\b \b");
                            }
                            entrada = entrada[..^1];
                            Console.Write("\b \b");
                            continue;
                        }

                        if (char.IsDigit(tecla.KeyChar) && entrada.Length < 10)
                        {
                            entrada += tecla.KeyChar;
                            Console.Write(tecla.KeyChar);

                            if (entrada.Length == 2 || entrada.Length == 5)
                            {
                                entrada += "/";
                                Console.Write("/");
                            }
                        }
                    }

                    if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                    {
                        if (data > DateTime.Now)
                        {
                            throw new Exception("A data não pode ser no futuro.");
                        }
                        return data;
                    }
                    else
                    {
                        throw new FormatException("Data inválida ou formato incompleto.");
                    }
                }
                catch (Exception ex) { Console.WriteLine($"\n[ERRO]: {ex.Message}"); }
            }
        }

        // 3. LER INTEIRO
        public static int LerInteiro(string campo)
        {
            while (true)
            {
                try
                {
                    Console.Write($"{campo}: ");
                    string entrada = Console.ReadLine() ?? "";

                    if (!int.TryParse(entrada, out int valor))
                    {
                        throw new FormatException("A entrada deve ser um número inteiro válido.");
                    }

                    if (valor < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(campo), "O valor não pode ser negativo.");
                    }

                    return valor;
                }
                catch (Exception ex) { Console.WriteLine($"[ERRO]: {ex.Message.Split('\r')[0]}"); }
            }
        }

        // 4. LER INTEIRO RANGE
        public static int LerInteiroRange(string campo, int min, int max)
        {
            while (true)
            {
                try
                {
                    int valor = LerInteiro(campo);

                    if (valor < min || valor > max)
                    {
                        throw new ArgumentOutOfRangeException(null, $"O valor deve estar entre {min} e {max}.");
                    }

                    return valor;
                }
                catch (Exception ex) { Console.WriteLine($"[ERRO]: {ex.Message.Split('\r')[0]}"); }
            }
        }
    }
}