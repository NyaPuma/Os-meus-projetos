using System;
using System.Collections.Generic;
using System.Globalization;
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
        // Definir os nomes dos ficheiros de armazenamento
        private const string FichPacientes = "pacientes.csv";
        private const string FichMedicos = "medicos.csv";
        private const string FichConsultas = "consultas.csv";
        private const string FichObs = "observacoes.csv";

        // Tratar caracteres especiais para evitar quebras na estrutura do CSV
        private static string EscaparCsv(string campo)
        {
            if (campo.Contains(',') || campo.Contains('"') || campo.Contains('\n'))
                return $"\"{campo.Replace("\"", "\"\"")}\"";
            return campo;
        }

        // Decompor uma linha CSV em campos individuais respeitando as aspas
        private static string[] SplitCsv(string linha)
        {
            var campos = new List<string>();
            bool dentroAspas = false;
            var campoAtual = new StringBuilder();

            foreach (char c in linha)
            {
                if (c == '"')
                {
                    dentroAspas = !dentroAspas;
                }
                else if (c == ',' && !dentroAspas)
                {
                    campos.Add(campoAtual.ToString());
                    campoAtual.Clear();
                }
                else
                {
                    campoAtual.Append(c);
                }
            }
            campos.Add(campoAtual.ToString());
            return [.. campos];
        }

        // Ler e processar todos os ficheiros para restaurar o estado da clínica
        public static void CarregarDados(Clinica clinica)
        {
            try
            {
                // 1. Processar ficheiro de Pacientes
                if (File.Exists(FichPacientes))
                {
                    foreach (var linha in File.ReadAllLines(FichPacientes).Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;
                        var d = SplitCsv(linha);

                        // Validar a integridade da linha antes de processar
                        if (d.Length < 3) continue;

                        string idLimpo = d[0].ToUpper().Replace("P", "").Trim();

                        if (int.TryParse(idLimpo, out int idValido))
                        {
                            // Converter a string da data usando um formato global invariante
                            if (!DateTime.TryParseExact(d[2].Trim(), "yyyy-MM-dd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                            {
                                Console.WriteLine($"⚠️ Data inválida ignorada na linha: {linha}");
                                continue;
                            }

                            // Reinstanciar e adicionar o paciente à clínica
                            clinica.AdicionarPaciente(new Paciente(d[1].Trim(), data, idValido));
                        }
                    }
                }

                // 2. Processar ficheiro de Médicos
                if (File.Exists(FichMedicos))
                {
                    foreach (var linha in File.ReadAllLines(FichMedicos).Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;

                        var d = SplitCsv(linha);

                        if (d.Length < 3) continue;

                        // Adicionar o médico com base nos campos do CSV
                        clinica.AdicionarMedico(new Medico(d[1].Trim(), d[2].Trim(), d[0].Trim()));
                    }
                }

                // 3. Reconstruir Consultas e associar Observações
                if (File.Exists(FichConsultas))
                {
                    var linhasConsultas = File.ReadAllLines(FichConsultas).Skip(1);
                    var linhasObs = File.Exists(FichObs)
                        ? [.. File.ReadAllLines(FichObs).Skip(1)]
                        : new List<string>();

                    foreach (var linha in linhasConsultas)
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;

                        var d = SplitCsv(linha);

                        if (d.Length < 3) continue;

                        // Converter data e hora da consulta
                        if (!DateTime.TryParseExact(d[0].Trim(), "yyyy-MM-dd HH:mm:ss",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataHora))
                        {
                            Console.WriteLine($"⚠️ Data/hora inválida ignorada na linha: {linha}");
                            continue;
                        }

                        // Identificar as chaves estrangeiras (ID Paciente e ID Médico)
                        string idLimpo = d[1].ToUpper().Replace("P", "").Trim();
                        if (!int.TryParse(idLimpo, out int idPacBusca)) continue;

                        string idMedBusca = d[2].Trim();

                        // Ligar a consulta aos objetos já carregados na memória
                        var p = clinica.Pacientes.FirstOrDefault(x => x.NumProcesso == idPacBusca);
                        var m = clinica.Medicos.FirstOrDefault(x => x.NumCedula == idMedBusca);

                        if (p != null && m != null)
                        {
                            Consulta novaCons = new(dataHora, p, m);

                            // Filtrar as observações pertencentes a esta consulta específica
                            string dataChave = dataHora.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                            var obsRelacionadas = linhasObs.Where(o => o.StartsWith(dataChave));

                            foreach (var o in obsRelacionadas)
                            {
                                var dObs = SplitCsv(o);

                                // Validar e converter a prioridade da observação
                                if (dObs.Length >= 3 && Enum.TryParse(dObs[2].Trim(), true, out Prioridade prio))
                                {
                                    novaCons.AdicObs(dObs[1].Trim(), prio);
                                }
                            }

                            // Registar a consulta completa no histórico da clínica
                            clinica.RegistarConsulta(novaCons);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Reportar falhas durante a leitura dos dados
                Console.WriteLine($"⚠️ Erro ao carregar: {ex.Message}");
            }
        }

        // Serializar e gravar os dados da memória para ficheiros físicos
        public static void GuardarDados(Clinica clinica)
        {
            try
            {
                // 1. Exportar Pacientes
                // Gerar lista de strings com cabeçalho e dados escapados
                var linhasP = new List<string> { "numProcesso,nome,dataNascimento" };
                linhasP.AddRange(clinica.Pacientes.Select(p =>
                    $"{p.NumProcesso},{EscaparCsv(p.Nome)},{p.DataNascimento:yyyy-MM-dd}"));
                File.WriteAllLines(FichPacientes, linhasP, Encoding.UTF8);

                // 2. Exportar Médicos
                var linhasM = new List<string> { "numCedula,nome,especialidade" };
                linhasM.AddRange(clinica.Medicos.Select(m =>
                    $"{EscaparCsv(m.NumCedula)},{EscaparCsv(m.Nome)},{EscaparCsv(m.Especialidade)}"));
                File.WriteAllLines(FichMedicos, linhasM, Encoding.UTF8);

                // 3. Exportar Consultas e as suas respetivas Observações
                var linhasC = new List<string> { "dataHora,idPaciente,idMedico" };
                var linhasO = new List<string> { "dataHoraConsulta,texto,prioridade" };

                foreach (var c in clinica.Consultas)
                {
                    // Formatar data de forma normalizada para garantir persistência correta
                    string dataFormatada = c.DataHora.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    linhasC.Add($"{dataFormatada},{c.Paciente.NumProcesso},{EscaparCsv(c.Medico.NumCedula)}");

                    foreach (var obs in c.GetObservacoes())
                    {
                        // Gravar observações num ficheiro separado para normalização
                        linhasO.Add($"{dataFormatada},{EscaparCsv(obs.Texto)},{obs.NivelPrioridade}");
                    }
                }

                // Escrever os conteúdos finais nos ficheiros de destino
                File.WriteAllLines(FichConsultas, linhasC, Encoding.UTF8);
                File.WriteAllLines(FichObs, linhasO, Encoding.UTF8);

                Console.WriteLine("✔ Todos os ficheiros foram atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                // Capturar e exibir erros críticos durante a escrita
                Console.WriteLine($"❌ Erro crítico ao guardar dados: {ex.Message}");
            }
        }
    }
}