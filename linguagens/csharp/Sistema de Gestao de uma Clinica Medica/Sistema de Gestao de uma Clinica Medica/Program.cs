using System;

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
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. GESTÃO DA CLÍNICA: Configuração inicial (Via ConsolaHelper)
                Console.WriteLine("=== INICIALIZAÇÃO DO SISTEMA CLÍNICO ===");

                // Solicitar e validar o nome e a morada da clínica para a sessão atual
                string nomeC = ConsolaHelper.LerTexto("Nome da Clínica", 3, true);
                string moradaC = ConsolaHelper.LerTexto("Morada da Clínica", 5, false);

                // Instanciar o objeto principal da Clínica
                Clinica clinica = new(nomeC, moradaC);

                // 2. CARREGAR DADOS (Via GestorDados)
                Console.WriteLine("\nCarregando dados dos ficheiros...");
                // Restaurar a informação guardada nos ficheiros CSV para a memória
                GestorDados.CarregarDados(clinica);

                // 3. EXECUTAR MENU (Via classe Menu)
                // Transferir o fluxo de controlo para o loop do menu principal
                Menu menuPrincipal = new();
                Menu.Exibir(clinica);

            }
            catch (Exception ex)
            {
                // Intercetar falhas críticas que impeçam o arranque do sistema
                Console.WriteLine($"\n[ERRO FATAL]: O sistema encontrou um problema crítico: {ex.Message}");
            }
            finally
            {
                // Garantir a execução de mensagens de despedida e libertação de recursos
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("Sistema finalizado. Obrigado por utilizar!");
                Console.WriteLine("Prima qualquer tecla para fechar a consola.");
                // Aguardar a interação do utilizador antes de encerrar o processo
                Console.ReadKey();
            }
        }
    }
}