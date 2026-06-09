namespace POO_Ficha3_Exercicio3
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um programa em C# para gerir projetos e as respetivas tarefas.                           ::::: //
    // ::::: O sistema deverá permitir organizar tarefas, atribuindo a cada uma delas um                         ::::: //
    // ::::: responsável.                                                                                        ::::: //
    // :::::                                                                                                     ::::: //
    // ::::: Estrutura das Classes                                                                               ::::: //
    // ::::: O sistema deve ser composto pelas seguintes três classes:                                           ::::: //
    // :::::     Responsavel                                                                                    ::::: //
    // :::::         Atributos: Nome, Email.                                                                    ::::: //
    // :::::         Método: ExibirInformacoes().                                                               ::::: //
    // :::::     Tarefa                                                                                         ::::: //
    // :::::         Atributos: Titulo, Descricao, Responsavel(associação 1:1).                                 ::::: //
    // :::::         Método: ExibirInformacoes().                                                               ::::: //
    // :::::     Projeto                                                                                        ::::: //
    // :::::         Atributos: Nome, Descricao, listaTarefas(lista de objetos Tarefa).                         ::::: //
    // :::::         Métodos: AdicionarTarefa(), RemoverTarefa(), ExibirTarefas().                              ::::: //
    // :::::                                                                                                     ::::: //
    // ::::: Regras de Negócio                                                                                   ::::: //
    // :::::    1. Relação Projeto-Tarefa: Um projeto pode conter várias tarefas (associação 1:∗).               ::::: //
    // :::::    2. Relação Tarefa-Responsavel: Cada tarefa é atribuída a um único responsável (associação 1: 1). ::::: //
    // :::::    3. Gestão: O projeto deve permitir adicionar novas tarefas à sua lista, remover                  ::::: //
    // :::::       tarefas existentes e apresentar uma listagem completa das tarefas que o compõem.              ::::: //
    // :::::                                                                                                     ::::: //
    // ::::: Exemplo de funcionalidade esperada                                                                  ::::: //
    // ::::: Ao listar as tarefas de um projeto, o sistema deve apresentar o título da tarefa, a sua             ::::: //
    // ::::: descrição e o nome do responsável associado, demonstrando a navegação entre os objetos.             ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Program
    {
        // ===========================================================================
        // CLASSE: Program (Ponto de Entrada)
        // ===========================================================================
        static void Main(string[] args)
        {
            // O bloco TRY-CATCH captura erros de input ou lógica durante a execução
            try
            {
                Console.WriteLine("=== SISTEMA DE GESTÃO DE PROJETOS ===");

                // --- CRIAÇÃO DO PROJETO ---
                Console.Write("\nIntroduza o nome do Projeto: ");
                string nomeProj = Console.ReadLine() ?? ""; // ?? "" remove warning de possível nulo

                Console.Write("Introduza a descrição do Projeto: ");
                string descProj = Console.ReadLine() ?? "";

                Projeto meuProjeto = new(nomeProj, descProj);

                // --- CRIAÇÃO DO RESPONSÁVEL ---
                Console.WriteLine("\n--- Dados do Responsável ---");
                Console.Write("Nome do Responsável: ");
                string nomeResp = Console.ReadLine() ?? "";

                Console.Write("Email do Responsável: ");
                string emailResp = Console.ReadLine() ?? "";

                Responsavel resp1 = new(nomeResp, emailResp);

                // --- CRIAÇÃO DA TAREFA ---
                Console.WriteLine("\n--- Dados da Tarefa ---");
                Console.Write("Título da Tarefa: ");
                string tituloTar = Console.ReadLine() ?? "";

                Console.Write("Descrição da Tarefa: ");
                string descTar = Console.ReadLine() ?? "";

                // Associação: Passamos o objeto 'resp1' para dentro da tarefa
                Tarefa tarefa1 = new(tituloTar, descTar, resp1);

                // --- GESTÃO ---
                // Adicionamos a tarefa ao projeto (Agregação)
                meuProjeto.AdicionarTarefa(tarefa1);

                // Limpa o ecrã para mostrar o relatório final
                Console.Clear();
                meuProjeto.ExibirTarefas();
            }
            catch (Exception ex)
            {
                // Tratamento genérico de erros para evitar que a aplicação feche sem aviso
                Console.WriteLine($"\n[ERRO DE EXECUÇÃO]: {ex.Message}");
            }
            finally
            {
                // O bloco FINALLY executa sempre, garantindo que o ReadKey seja chamado
                Console.WriteLine("\nSistema finalizado. Pressione qualquer tecla para sair.");
                Console.ReadKey();
            }
        }
    }
}
