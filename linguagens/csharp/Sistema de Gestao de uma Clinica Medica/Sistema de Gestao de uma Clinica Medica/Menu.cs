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
        // Gerir o loop principal e a navegação do utilizador
        public static void Exibir(Clinica clinica)
        {
            bool sair = false;

            while (!sair)
            {
                // Apresentar as opções visualmente na consola
                Console.WriteLine($"\n--- MENU GESTÃO: {clinica.Nome.ToUpper()} ---");
                Console.WriteLine("1. Adicionar Paciente");
                Console.WriteLine("2. Adicionar Médico");
                Console.WriteLine("3. Registar Consulta");
                Console.WriteLine("4. Listar Pacientes");
                Console.WriteLine("5. Listar Médicos");
                Console.WriteLine("6. Listar Consultas");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: ");

                // Ler a escolha do utilizador
                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        try
                        {
                            // Obter dados do novo paciente através do helper
                            string np = ConsolaHelper.LerTexto("Nome do Paciente", 3, true);
                            DateTime dn = ConsolaHelper.LerData("Data de Nascimento (dd/mm/aaaa)");
                            int proc = ConsolaHelper.LerInteiro("Número de Processo");

                            // Validar se o número de processo já existe na lista
                            if (clinica.Pacientes.Any(p => p.NumProcesso == proc))
                            {
                                // Interromper o fluxo caso o paciente seja duplicado
                                throw new Exception("Já existe um paciente com este número de processo!");
                            }

                            // Criar e inserir o paciente na clínica
                            clinica.AdicionarPaciente(new Paciente(np, dn, proc));
                            Console.WriteLine("✔ Paciente adicionado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            // Tratar e exibir mensagens de erro capturadas
                            Console.WriteLine($"\n[ERRO NO REGISTO]: {ex.Message}");
                        }
                        break;

                    case "2":
                        // Solicitar dados do médico e validar entradas
                        string nm = ConsolaHelper.LerTexto("Nome do Médico", 3, true);
                        string esp = ConsolaHelper.LerTexto("Especialidade", 4, true);
                        string ced = ConsolaHelper.LerTexto("Nº Cédula", 2, false, true);

                        // Adicionar o novo médico diretamente à lista da clínica
                        clinica.Medicos.Add(new Medico(nm, esp, ced));
                        Console.WriteLine("✔ Médico adicionado!");
                        break;

                    case "3":
                        // Impedir a criação de consultas sem entidades registadas
                        if (clinica.Pacientes.Count == 0 || clinica.Medicos.Count == 0)
                        {
                            throw new Exception("Operação cancelada: Precisa de ter médicos e pacientes registados.");
                        }

                        // Selecionar o paciente através de um índice da lista
                        Console.WriteLine("\n--- Selecione o Paciente ---");
                        for (int i = 0; i < clinica.Pacientes.Count; i++)
                            Console.WriteLine($"{i}. {clinica.Pacientes[i].Nome}");
                        int idxP = ConsolaHelper.LerInteiroRange("Índice do Paciente", 0, clinica.Pacientes.Count - 1);

                        // Selecionar o médico através de um índice da lista
                        Console.WriteLine("\n--- Selecione o Médico ---");
                        for (int i = 0; i < clinica.Medicos.Count; i++)
                            Console.WriteLine($"{i}. {clinica.Medicos[i].Nome}");
                        int idxM = ConsolaHelper.LerInteiroRange("Índice do Médico", 0, clinica.Medicos.Count - 1);

                        // Instanciar uma nova consulta com a data atual
                        Consulta novaCons = new(DateTime.Now, clinica.Pacientes[idxP], clinica.Medicos[idxM]);

                        // Adicionar múltiplas observações através de um loop iterativo
                        Console.Write("Adicionar observação? (s/n): ");
                        while ((Console.ReadLine() ?? "").Equals("s", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string txt = ConsolaHelper.LerTexto("Observação", 5, false);
                            int pInt = ConsolaHelper.LerInteiroRange("Prioridade (0-Baixa, 1-Media, 2-Alta)", 0, 2);

                            // Anexar a observação ao objeto da consulta
                            novaCons.AdicObs(txt, (Prioridade)pInt);
                            Console.Write("Adicionar outra? (s/n): ");
                        }

                        // Finalizar o registo guardando a consulta na lista
                        clinica.Consultas.Add(novaCons);
                        Console.WriteLine("✔ Consulta registada!");
                        break;

                    case "4":
                        // Invocar o método de listagem de pacientes
                        clinica.ListarTodosPacientes();
                        break;

                    case "5":
                        // Invocar o método de listagem de médicos
                        clinica.ListarTodosMedicos();
                        break;

                    case "6":
                        // Invocar o método de listagem de todas as consultas
                        clinica.ListarTodasConsultas();
                        break;

                    case "0":
                        // Instancie o objeto primeiro
                        GestorDados gestor = new();
                        gestor.Guardar(clinica);
                        sair = true;
                        break;

                    default:
                        // Informar o utilizador sobre entradas não reconhecidas
                        Console.WriteLine("⚠ Opção inválida!");
                        break;
                }
            }
        }
    }
}