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
    internal class Projeto(string nome, string descricao)
    {
        // ===========================================================================
        // CLASSE: Projeto
        // OBJETIVO: O "Todo" que agrupa várias tarefas.
        // RELAÇÃO: Agregação/Associação 1:* (Um projeto para muitas tarefas).
        // ===========================================================================

        public string Nome { get; set; } = nome;
        public string Descricao { get; set; } = descricao;

        // Atributo privado (- no UML) para armazenar a coleção de tarefas
        private readonly List<Tarefa> listaTarefas = [];

        // ===========================================================================

        // Adiciona um objeto Tarefa à lista interna
        public void AdicionarTarefa(Tarefa tarefa)
        {
            if (tarefa != null)
            {
                listaTarefas.Add(tarefa);
            }
        }

        // ===========================================================================

        // Remove uma tarefa específica da lista
        public void RemoverTarefa(Tarefa tarefa)
        {
            listaTarefas.Remove(tarefa);
        }

        // ===========================================================================

        // Percorre a lista e exibe os detalhes de cada tarefa associada
        public void ExibirTarefas()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine($"LISTAGEM DO PROJETO: {Nome.ToUpper()}");
            Console.WriteLine($"DESCRIÇÃO: {Descricao}");
            Console.WriteLine(new string('=', 50));

            if (listaTarefas.Count == 0)
            {
                Console.WriteLine("Aviso: Este projeto ainda não possui tarefas atribuídas.");
            }
            else
            {
                foreach (Tarefa t in listaTarefas)
                {
                    t.ExibirInformacoes();
                    Console.WriteLine(new string('-', 30));
                }
            }
        }

    }
}
