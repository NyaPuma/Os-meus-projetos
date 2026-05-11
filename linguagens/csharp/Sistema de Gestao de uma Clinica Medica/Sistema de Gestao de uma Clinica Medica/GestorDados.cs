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
    internal class GestorDados : IDadosRepository
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
        public void Carregar(Clinica clinica)
        {
            try
            {
                // 1. Processar Pacientes
                if (File.Exists(FichPacientes))
                {
                    using var reader = new StreamReader(FichPacientes);
                    reader.ReadLine(); // Saltar cabeçalho

                    while (!reader.EndOfStream)
                    {
                        var linhaCifrada = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(linhaCifrada)) continue;

                        // --- DECIFRAR AQUI ---
                        string linhaDecifrada = CriptoHelper.Decifrar(linhaCifrada);
                        var d = SplitCsv(linhaDecifrada);

                        if (d.Length < 3) continue;

                        if (int.TryParse(d[0], out int idValido))
                        {
                            if (DateTime.TryParseExact(d[2].Trim(), "yyyy-MM-dd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                            {
                                clinica.AdicionarPacienteAuto(d[1].Trim(), data);
                            }
                        }
                    }
                }

                // 2. Processar Médicos
                if (File.Exists(FichMedicos))
                {
                    foreach (var linhaCifrada in File.ReadAllLines(FichMedicos).Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(linhaCifrada)) continue;

                        string linhaDecifrada = CriptoHelper.Decifrar(linhaCifrada);
                        var d = SplitCsv(linhaDecifrada);

                        if (d.Length < 3) continue;
                        clinica.AdicionarMedico(new Medico(d[1].Trim(), d[2].Trim(), d[0].Trim()));
                    }
                }

                // 3. Reconstruir Consultas e Observações
                if (File.Exists(FichConsultas))
                {
                    var linhasConsultasCifradas = File.ReadAllLines(FichConsultas).Skip(1);

                    // Deciframos todas as observações primeiro para podermos filtrar por data
                    var listaObsDecifradas = new List<string[]>();
                    if (File.Exists(FichObs))
                    {
                        foreach (var linhaO in File.ReadAllLines(FichObs).Skip(1))
                        {
                            if (!string.IsNullOrWhiteSpace(linhaO))
                                listaObsDecifradas.Add(SplitCsv(CriptoHelper.Decifrar(linhaO)));
                        }
                    }

                    foreach (var linhaC in linhasConsultasCifradas)
                    {
                        if (string.IsNullOrWhiteSpace(linhaC)) continue;

                        string linhaDecifrada = CriptoHelper.Decifrar(linhaC);
                        var d = SplitCsv(linhaDecifrada);

                        if (d.Length < 3) continue;

                        if (DateTime.TryParseExact(d[0].Trim(), "yyyy-MM-dd HH:mm:ss",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataHora))
                        {
                            if (!int.TryParse(d[1], out int idPacBusca)) continue;
                            string idMedBusca = d[2].Trim();

                            var p = clinica.Pacientes.FirstOrDefault(x => x.NumProcesso == idPacBusca);
                            var m = clinica.Medicos.FirstOrDefault(x => x.NumCedula == idMedBusca);

                            if (p != null && m != null)
                            {
                                Consulta novaCons = new(dataHora, p, m);

                                // Filtrar as observações decifradas que pertencem a esta consulta
                                string dataChave = dataHora.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                                var obsRelacionadas = listaObsDecifradas.Where(o => o[0] == dataChave);

                                foreach (var dObs in obsRelacionadas)
                                {
                                    if (dObs.Length >= 3 && Enum.TryParse(dObs[2].Trim(), true, out Prioridade prio))
                                    {
                                        novaCons.AdicObs(dObs[1].Trim(), prio);
                                    }
                                }
                                clinica.RegistarConsulta(novaCons);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Erro ao decifrar ou carregar os dados: {ex.Message}");
                Console.WriteLine("Certifique-se de que a chave de cifragem está correta e os ficheiros não estão corrompidos.");
            }
        }

        // Serializar e gravar os dados da memória para ficheiros físicos
        public void Guardar(Clinica clinica)
        {
            try
            {
                // 1. Exportar Pacientes
                var linhasP = new List<string> { "DADOS_CIFRADOS_PACIENTES" };
                foreach (var p in clinica.Pacientes)
                {
                    // Primeiro montamos a linha normal
                    string linhaLimpa = $"{p.NumProcesso},{EscaparCsv(p.Nome)},{p.DataNascimento:yyyy-MM-dd}";
                    // Ciframos e adicionamos à lista
                    linhasP.Add(CriptoHelper.Cifrar(linhaLimpa));
                }
                File.WriteAllLines(FichPacientes, linhasP, Encoding.UTF8);

                // 2. Exportar Médicos
                var linhasM = new List<string> { "DADOS_CIFRADOS_MEDICOS" };
                foreach (var m in clinica.Medicos)
                {
                    string linhaLimpa = $"{EscaparCsv(m.NumCedula)},{EscaparCsv(m.Nome)},{EscaparCsv(m.Especialidade)}";
                    linhasM.Add(CriptoHelper.Cifrar(linhaLimpa));
                }
                File.WriteAllLines(FichMedicos, linhasM, Encoding.UTF8);

                // 3. Exportar Consultas e Observações
                var linhasC = new List<string> { "DADOS_CIFRADOS_CONSULTAS" };
                var linhasO = new List<string> { "DADOS_CIFRADOS_OBSERVACOES" };

                foreach (var c in clinica.Consultas)
                {
                    string dataFormatada = c.DataHora.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    // Linha da Consulta
                    string linhaConsLimpa = $"{dataFormatada},{c.Paciente.NumProcesso},{EscaparCsv(c.Medico.NumCedula)}";
                    linhasC.Add(CriptoHelper.Cifrar(linhaConsLimpa));

                    foreach (var obs in c.GetObservacoes())
                    {
                        // Linha da Observação
                        string linhaObsLimpa = $"{dataFormatada},{EscaparCsv(obs.Texto)},{obs.NivelPrioridade}";
                        linhasO.Add(CriptoHelper.Cifrar(linhaObsLimpa));
                    }
                }

                File.WriteAllLines(FichConsultas, linhasC, Encoding.UTF8);
                File.WriteAllLines(FichObs, linhasO, Encoding.UTF8);

                Console.WriteLine("✔ Todos os ficheiros foram cifrados e atualizados!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro crítico ao guardar dados: {ex.Message}");
            }
        }
    }
}