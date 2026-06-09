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
    internal class Tarefa(string titulo, string descricao, Responsavel responsavel)
    {
        // ===========================================================================
        // CLASSE: Tarefa
        // OBJETIVO: Contém os dados de uma tarefa e a associação com um Responsavel.
        // RELAÇÃO: Associação 1:1 com a classe Responsavel.
        // ===========================================================================

        public string Titulo { get; set; } = titulo;
        public string Descricao { get; set; } = descricao;

        // Referência ao objeto Responsavel (Associação 1:1)
        // O "!" indica ao compilador que temos a certeza que este valor não será nulo após o construtor
        public Responsavel Responsavel { get; set; } = responsavel;

        // ===========================================================================

        // Exibe os dados da tarefa e aciona o método do objeto associado (Responsavel)
        public void ExibirInformacoes()
        {
            Console.WriteLine($"* Título: {Titulo}");
            Console.WriteLine($"  Descrição: {Descricao}");
            // Navegação de objetos: A tarefa sabe quem é o seu responsável
            Responsavel.ExibirInformacoes();
        }

    }
}
