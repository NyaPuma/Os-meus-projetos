using System;
using System.Collections.Generic;
using System.IO; // Necessário para File.ReadAllLines e WriteAllLines
using System.Linq; // Necessário para .Skip(), .Select(), .FirstOrDefault()
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
    internal class GestorDados
    {
        // Constantes para evitar erros de digitação ao longo do código
        private const string FichPacientes = "pacientes.csv";
        private const string FichMedicos = "medicos.csv";
        private const string FichConsultas = "consultas.csv";
        private const string FichObs = "observacoes.csv";

        // Método Público e Estático para carregar tudo
        public static void CarregarDados(Clinica clinica)
        {
            try
            {
                // 1. Carregar Pacientes
                if (File.Exists(FichPacientes))
                {
                    foreach (var linha in File.ReadAllLines(FichPacientes).Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;
                        var dados = linha.Split(',');
                        if (int.TryParse(dados[0], out int idConvertido))
                        {
                            clinica.pacientes.Add(new Paciente(dados[1], DateTime.Parse(dados[2]), idConvertido));
                        }
                    }
                }

                // 2. Carregar Médicos
                if (File.Exists(FichMedicos))
                {
                    foreach (var linha in File.ReadAllLines(FichMedicos).Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;
                        var dados = linha.Split(',');
                        clinica.medicos.Add(new Medico(dados[1], dados[2], dados[0]));
                    }
                }

                // 3. Carregar Consultas e Observações
                if (File.Exists(FichConsultas))
                {
                    var linhasConsultas = File.ReadAllLines(FichConsultas).Skip(1);
                    // Carregar as observações para uma lista em memória para facilitar a busca
                    var linhasObs = File.Exists(FichObs) ? [.. File.ReadAllLines(FichObs).Skip(1)] : new List<string>();

                    foreach (var linha in linhasConsultas)
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;

                        var dados = linha.Split(',');
                        string dataHoraStr = dados[0];
                        DateTime dataConvertida = DateTime.Parse(dataHoraStr);

                        int idBuscaPac = int.Parse(dados[1]);
                        string idMed = dados[2];

                        var p = clinica.pacientes.FirstOrDefault(x => x.NumProcesso == idBuscaPac);
                        var m = clinica.medicos.FirstOrDefault(x => x.NumCedula == idMed);

                        if (p != null && m != null)
                        {
                            Consulta novaConsulta = new(dataConvertida, p, m);

                            // 4. Carregar Observações ligadas a esta consulta
                            var obsDaConsulta = linhasObs.Where(o => o.Split(',')[0] == dataHoraStr);
                            foreach (var o in obsDaConsulta)
                            {
                                var dObs = o.Split(',');
                                if (dObs.Length >= 3)
                                {
                                    if (Enum.TryParse(dObs[2], true, out Prioridade prio))
                                    {
                                        novaConsulta.AdicObs(dObs[1], prio);
                                    }
                                }
                            }
                            clinica.consultas.Add(novaConsulta);
                        }
                    }
                }
                Console.WriteLine("✔ Dados importados com sucesso!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ℹ Info: Alguns ficheiros ainda não existem. Serão criados ao guardar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Erro ao ler CSV: {ex.Message}");
            }
        }

        // Método Público e Estático para guardar tudo
        public static void GuardarDados(Clinica clinica)
        {
            try
            {
                // 1. Guardar Pacientes
                var linhasP = new List<string> { "numProcesso,nome,dataNascimento" };
                linhasP.AddRange(clinica.pacientes.Select(p => $"{p.NumProcesso},{p.Nome},{p.DataNascimento:yyyy-MM-dd}"));
                File.WriteAllLines(FichPacientes, linhasP);

                // 2. Guardar Médicos
                var linhasM = new List<string> { "numCedula,nome,especialidade" };
                linhasM.AddRange(clinica.medicos.Select(m => $"{m.NumCedula},{m.Nome},{m.Especialidade}"));
                File.WriteAllLines(FichMedicos, linhasM);

                // 3. Guardar Consultas e Observações
                var linhasC = new List<string> { "dataHora,idPaciente,idMedico" };
                var linhasO = new List<string> { "dataHoraConsulta,texto,prioridade" };

                foreach (var c in clinica.consultas)
                {
                    string dataFormatada = c.DataHora.ToString("yyyy-MM-dd HH:mm:ss");
                    linhasC.Add($"{dataFormatada},{c.Paciente.NumProcesso},{c.Medico.NumCedula}");

                    foreach (var obs in c.GetObservacoes())
                    {
                        linhasO.Add($"{dataFormatada},{obs.Texto},{obs.NivelPrioridade}");
                    }
                }

                File.WriteAllLines(FichConsultas, linhasC);
                File.WriteAllLines(FichObs, linhasO);

                Console.WriteLine("✔ Todos os ficheiros foram atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro crítico ao guardar dados: {ex.Message}");
            }
        }
    }
}