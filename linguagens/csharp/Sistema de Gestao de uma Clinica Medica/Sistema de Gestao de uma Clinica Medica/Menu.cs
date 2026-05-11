using System;
using System.Collections.Generic;

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
    internal class Menu
    {
        // Método principal que gere o loop do menu
        public static void Exibir(Clinica clinica)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine($"\n--- MENU GESTÃO: {clinica.Nome.ToUpper()} ---");
                Console.WriteLine("1. Adicionar Paciente");
                Console.WriteLine("2. Adicionar Médico");
                Console.WriteLine("3. Registar Consulta");
                Console.WriteLine("4. Listar Pacientes");
                Console.WriteLine("5. Listar Médicos");
                Console.WriteLine("6. Listar Consultas");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        // Usamos a classe auxiliar ConsolaHelper para as validações
                        string np = ConsolaHelper.LerTexto("Nome do Paciente", 3, true);
                        DateTime dn = ConsolaHelper.LerData("Data de Nascimento (dd/mm/aaaa)");
                        int proc = ConsolaHelper.LerInteiro("Número de Processo");

                        clinica.pacientes.Add(new Paciente(np, dn, proc));
                        Console.WriteLine("✔ Paciente adicionado!");
                        break;

                    case "2":
                        string nm = ConsolaHelper.LerTexto("Nome do Médico", 3, true);
                        string esp = ConsolaHelper.LerTexto("Especialidade", 4, true);
                        string ced = ConsolaHelper.LerTexto("Nº Cédula", 2, false, true);

                        clinica.medicos.Add(new Medico(nm, esp, ced));
                        Console.WriteLine("✔ Médico adicionado!");
                        break;

                    case "3":
                        if (clinica.pacientes.Count == 0 || clinica.medicos.Count == 0)
                        {
                            Console.WriteLine("⚠ Erro: Precisa de ter médicos e pacientes registados.");
                            break;
                        }

                        // Seleção de Paciente
                        Console.WriteLine("\n--- Selecione o Paciente ---");
                        for (int i = 0; i < clinica.pacientes.Count; i++)
                            Console.WriteLine($"{i}. {clinica.pacientes[i].Nome}");
                        int idxP = ConsolaHelper.LerInteiroRange("Índice do Paciente", 0, clinica.pacientes.Count - 1);

                        // Seleção de Médico
                        Console.WriteLine("\n--- Selecione o Médico ---");
                        for (int i = 0; i < clinica.medicos.Count; i++)
                            Console.WriteLine($"{i}. {clinica.medicos[i].Nome}");
                        int idxM = ConsolaHelper.LerInteiroRange("Índice do Médico", 0, clinica.medicos.Count - 1);

                        Consulta novaCons = new(DateTime.Now, clinica.pacientes[idxP], clinica.medicos[idxM]);

                        // Gestão de Observações
                        Console.Write("Adicionar observação? (s/n): ");
                        while ((Console.ReadLine() ?? "").Equals("s", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string txt = ConsolaHelper.LerTexto("Observação", 5, false);
                            int pInt = ConsolaHelper.LerInteiroRange("Prioridade (0-Baixa, 1-Media, 2-Alta)", 0, 2);

                            novaCons.AdicObs(txt, (Prioridade)pInt);
                            Console.Write("Adicionar outra? (s/n): ");
                        }

                        clinica.consultas.Add(novaCons);
                        Console.WriteLine("✔ Consulta registada!");
                        break;

                    case "4":
                        clinica.ListarTodosPacientes();
                        break;

                    case "5":
                        clinica.ListarTodosMedicos();
                        break;

                    case "6":
                        clinica.ListarTodasConsultas();
                        break;

                    case "0":
                        // Alterar de GuardarTudo para GuardarDados
                        GestorDados.GuardarDados(clinica);
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("⚠ Opção inválida!");
                        break;
                }
            }
        }
    }
}