using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                // 1. GESTÃO DA CLÍNICA: Configuração inicial obrigatória (Regra 1)
                Console.WriteLine("=== INICIALIZAÇÃO DO SISTEMA CLÍNICO ===");

                // Validação de entrada para o nome e morada da clínica com limites de caracteres
                string nomeC = LerTexto("Nome da Clínica", 3, true);
                string moradaC = LerTexto("Morada da Clínica", 5, false);

                // Instanciação do objeto Clínica (Raiz do sistema)
                Clinica clinica = new(nomeC, moradaC);
                bool sair = false;

                // Ciclo principal de interação com o utilizador
                while (!sair)
                {
                    try
                    {
                        // Interface do Menu Principal (Regra 6 - Listagens e Operações)
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
                                // 2. REGISTO DE PACIENTES: Captura de dados validados (Nome, Data Nasc, Num Processo)
                                string np = LerTexto("Nome do Paciente", 3, true);
                                DateTime dn = LerData("Data de Nascimento (dd/mm/aaaa)"); // Máscara automática e validação real
                                int proc = LerInteiro("Número de Processo"); // Garante número positivo

                                // Agregação: Adiciona um novo Paciente à lista da Clínica
                                clinica.pacientes.Add(new Paciente(np, dn, proc));
                                Console.WriteLine("✔ Paciente adicionado!");
                                break;

                            case "2":
                                // 3. REGISTO DE MÉDICOS: Captura de dados (Nome, Especialidade, Cédula)
                                string nm = LerTexto("Nome do Médico", 3, true);
                                string esp = LerTexto("Especialidade", 4, true);
                                string ced = LerTexto("Nº Cédula", 2, false, true); // Valida apenas números

                                // Associação: Adiciona um novo Médico ao corpo clínico
                                clinica.medicos.Add(new Medico(nm, esp, ced));
                                Console.WriteLine("✔ Médico adicionado!");
                                break;

                            case "3":
                                // 4. GESTÃO DE CONSULTAS: Requer existência prévia de dados para as associações
                                if (clinica.pacientes.Count == 0 || clinica.medicos.Count == 0)
                                {
                                    Console.WriteLine("⚠ Erro: Precisa de ter médicos e pacientes registados.");
                                    break;
                                }

                                // Listagem e Seleção do Paciente para a Consulta (Associação 1..*)
                                Console.WriteLine("\n--- Selecione o Paciente ---");
                                for (int i = 0; i < clinica.pacientes.Count; i++)
                                    Console.WriteLine($"{i}. {clinica.pacientes[i].Nome}");
                                int idxP = LerInteiroRange("Índice do Paciente", 0, clinica.pacientes.Count - 1);

                                // Listagem e Seleção do Médico para a Consulta (Associação 1..*)
                                Console.WriteLine("\n--- Selecione o Médico ---");
                                for (int i = 0; i < clinica.medicos.Count; i++)
                                    Console.WriteLine($"{i}. {clinica.medicos[i].Nome}");
                                int idxM = LerInteiroRange("Índice do Médico", 0, clinica.medicos.Count - 1);

                                // Criação da Consulta associando os objetos Paciente e Médico escolhidos
                                Consulta novaCons = new(DateTime.Now, clinica.pacientes[idxP], clinica.medicos[idxM]);

                                // 5. GESTÃO DE OBSERVAÇÕES: Composição (as observações pertencem a esta consulta)
                                Console.Write("Adicionar observação? (s/n): ");
                                while ((Console.ReadLine() ?? "").ToLower() == "s")
                                {
                                    string txt = LerTexto("Observação", 5, false);
                                    int pInt = LerInteiroRange("Prioridade (0-Baixa, 1-Media, 2-Alta)", 0, 2);

                                    // Adiciona a observação diretamente no objeto Consulta (Composição)
                                    novaCons.AdicObs(txt, (Prioridade)pInt);
                                    Console.Write("Adicionar outra? (s/n): ");
                                }

                                // Registo final da consulta realizada na Clínica
                                clinica.consultas.Add(novaCons);
                                Console.WriteLine("✔ Consulta registada!");
                                break;

                            case "4":
                                // 6. LISTAGENS: Exibe todos os pacientes (Agregação)
                                clinica.ListarTodosPacientes();
                                break;
                            case "5":
                                // 6. LISTAGENS: Exibe todos os médicos (Associação)
                                clinica.ListarTodosMedicos();
                                break;
                            case "6":
                                // 6. LISTAGENS: Exibe consultas com detalhes completos, médicos, pacientes e obs
                                clinica.ListarTodasConsultas();
                                break;
                            case "0":
                                sair = true;
                                break;
                            default:
                                Console.WriteLine("⚠ Opção inválida!");
                                break;
                        }
                    }
                    // Tratamento de erros para capturar falhas de conversão de dados no ciclo
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"\n[ERRO DE FORMATO]: {ex.Message} - Tente novamente.");
                    }
                    // Tratamento de erros genérico para evitar o encerramento abrupto do programa
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n[ERRO INESPERADO NO CICLO]: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Este catch apanha erros fatais fora do ciclo while (ex: falha na criação da clínica)
                Console.WriteLine($"\n[ERRO FATAL]: O sistema encontrou um problema crítico: {ex.Message}");
            }
            finally
            {
                // O finally executa SEMPRE, quer haja erro ou não.
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("Sistema finalizado. Obrigado por utilizar!");
                Console.WriteLine("Prima qualquer tecla para fechar a consola.");
                Console.ReadKey();
            }

            // ========================================================================================================================= //
            // ========================================================================================================================= //
            // ========================================================================================================================= //

            static string LerTexto(string campo, int minLetras, bool apenasLetras, bool apenasNumeros = false)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"{campo}: ");
                        string entrada = Console.ReadLine()?.Trim() ?? "";

                        // Validação de preenchimento e tamanho
                        if (string.IsNullOrEmpty(entrada) || entrada.Length < minLetras)
                        {
                            throw new ArgumentException($"O campo '{campo}' é obrigatório e deve ter pelo menos {minLetras} caracteres.");
                        }

                        // Validação de apenas letras
                        if (apenasLetras && entrada.Any(char.IsDigit))
                        {
                            throw new FormatException($"O campo '{campo}' não pode conter números.");
                        }

                        // Validação de apenas números
                        if (apenasNumeros && !entrada.All(char.IsDigit))
                        {
                            throw new FormatException($"O campo '{campo}' deve conter apenas algarismos numéricos.");
                        }

                        // Regra: Formatação de nomes (Primeiras letras em Maiúsculas)
                        // Ex: "ana maria" -> "Ana Maria"
                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entrada.ToLower());
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"[ERRO DE ARGUMENTO]: {ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"[ERRO DE FORMATO]: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ERRO INESPERADO]: {ex.Message}");
                    }

                    // Se chegar aqui, o try falhou e o ciclo while repete a pergunta
                }
            }

            // ========================================================================================================================= //
            // ========================================================================================================================= //
            // ========================================================================================================================= //

            // Valida Datas reais (respeitando meses de 30/31 dias e bissextos) com máscara automática
            static DateTime LerData(string prompt)
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

                            // Se premir Enter, sai do ciclo de teclas
                            if (tecla.Key == ConsoleKey.Enter)
                            {
                                Console.WriteLine();
                                break;
                            }

                            // Lógica do Backspace (Apagar)
                            if (tecla.Key == ConsoleKey.Backspace && entrada.Length > 0)
                            {
                                // Se o que vamos apagar for uma barra, apaga a barra e o número anterior
                                if (entrada.EndsWith("/"))
                                {
                                    entrada = entrada.Substring(0, entrada.Length - 1);
                                    Console.Write("\b \b");
                                }

                                entrada = entrada.Substring(0, entrada.Length - 1);
                                Console.Write("\b \b");
                                continue;
                            }

                            // Aceita apenas números e limita a 10 caracteres (dd/mm/aaaa)
                            if (char.IsDigit(tecla.KeyChar) && entrada.Length < 10)
                            {
                                entrada += tecla.KeyChar;
                                Console.Write(tecla.KeyChar);

                                // Inserção automática da barra no 2º e 5º dígito
                                if (entrada.Length == 2 || entrada.Length == 5)
                                {
                                    entrada += "/";
                                    Console.Write("/");
                                }
                            }
                        }

                        // Validação técnica da data (Cultura Invariante para evitar erros de sistema)
                        if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                        {
                            if (data > DateTime.Now)
                            {
                                throw new Exception("A data não pode ser no futuro.");
                            }
                            return data; // Sucesso
                        }
                        else
                        {
                            throw new FormatException("Data inválida ou formato incompleto.");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"\n[ERRO]: {ex.Message} Use o formato Dia/Mês/Ano.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n[ERRO]: {ex.Message}");
                    }
                    // O loop continua até o return data ser atingido
                }
            }

            // ========================================================================================================================= //
            // ========================================================================================================================= //
            // ========================================================================================================================= //

            static int LerInteiro(string campo)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"{campo}: ");
                        string entrada = Console.ReadLine() ?? "";

                        // 1. Tenta converter para inteiro
                        if (!int.TryParse(entrada, out int valor))
                        {
                            throw new FormatException("A entrada deve ser um número inteiro válido.");
                        }

                        // 2. Verifica se é positivo (regra do negócio para IDs e Processos)
                        if (valor <= 0)
                        {
                            throw new ArgumentOutOfRangeException(nameof(valor), "O valor deve ser um número positivo (maior que zero).");
                        }

                        return valor; // Se chegou aqui, os dados estão corretos
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"[ERRO DE FORMATO]: {ex.Message}");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        // O ParamName do exception às vezes suja a mensagem, por isso usei o Split
                        Console.WriteLine($"[ERRO DE VALOR]: {ex.Message.Split('\r')[0]}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ERRO INESPERADO]: {ex.Message}");
                    }
                }
            }

            // ========================================================================================================================= //
            // ========================================================================================================================= //
            // ========================================================================================================================= //

            static int LerInteiroRange(string campo, int min, int max)
            {
                while (true)
                {
                    try
                    {
                        // Chama o método que já valida se é um número inteiro e positivo
                        int valor = LerInteiro(campo);

                        // Validação do intervalo específico
                        if (valor < min || valor > max)
                        {
                            throw new ArgumentOutOfRangeException(nameof(valor), $"O valor inserido está fora dos limites permitidos ({min} a {max}).");
                        }

                        return valor; // Sucesso
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        // Limpa a mensagem para mostrar apenas o texto relevante ao utilizador
                        Console.WriteLine($"[ERRO DE INTERVALO]: {ex.Message.Split('\r')[0]}");
                    }
                    catch (Exception ex)
                    {
                        // Captura qualquer outro erro que possa subir na pilha de chamadas
                        Console.WriteLine($"[ERRO NO RANGE]: {ex.Message}");
                    }
                }
            }
        }
    }
}
