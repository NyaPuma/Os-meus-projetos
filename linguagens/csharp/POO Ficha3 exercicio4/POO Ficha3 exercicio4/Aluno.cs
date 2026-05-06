namespace POO_Ficha3_exercicio4
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um programa em C# para gerir um sistema escolar de matrículas.                               ::::: //
    // ::::: O sistema deve permitir a criação de alunos, disciplinas e professores, e associar                      ::::: //
    // ::::: alunos a disciplinas e professores a disciplinas.                                                       ::::: //
    // :::::                                                                                                         ::::: //
    // ::::: O programa deve incluir as seguintes funcionalidades:                                                   ::::: //
    // ::::: Criação de Alunos, Disciplinas e Professores:                                                           ::::: //
    // :::::    1. Permitir ao utilizador criar alunos, inserindo o nome e o número de matrícula.                    ::::: //
    // :::::    2. Permitir ao utilizador criar disciplinas, inserindo o nome e o código.                            ::::: //
    // :::::    3. Permitir ao utilizador criar professores, inserindo o nome e o número de registro.                ::::: //
    // :::::                                                                                                         ::::: //
    // ::::: O sistema deve incluir as classes:                                                                      ::::: //
    // ::::: Aluno: Com atributos nome e numeroMatricula e uma lista de disciplinas em que o aluno está matriculado. ::::: //
    // ::::: Disciplina: Com atributos nome e código, lista de alunos matriculados e associação com Professor.       ::::: //
    // ::::: Professor: com atributos Nome e numeroRegisto e uma lista de disciplinas que o professor leciona.       ::::: //
    // :::::                                                                                                         ::::: //
    // ::::: Associação entre Aluno e Disciplina:                                                                    ::::: //
    // ::::: Um aluno pode estar matriculado em várias disciplinas e uma disciplina pode ter vários                  ::::: //
    // ::::: alunos matriculados. Logo a lista DisciplinasMatriculadas na classe Aluno e a lista                     ::::: //
    // ::::: AlunosMatriculados na classe Disciplina representam uma associação de muitos para muitos.               ::::: //
    // :::::                                                                                                         ::::: //
    // ::::: Associação entre Professor e Disciplina:                                                                ::::: //
    // ::::: Um professor pode lecionar várias disciplinas, e cada disciplina é lecionada por apenas                 ::::: //
    // ::::: um professor.A lista DisciplinasLecionadas na classe Professor e o atributo Professor                   ::::: //
    // ::::: na Disciplina representam essa relação                                                                  ::::: //
    // :::::                                                                                                         ::::: //
    // ::::: Listagem de Alunos Matriculados em Disciplinas:                                                         ::::: //
    // :::::    1.Exibir a lista de alunos matriculados em cada disciplina.                                          ::::: //
    // :::::                                                                                                         ::::: //
    // ::::: Listagem de Disciplinas Lecionadas por Professores:                                                     ::::: //
    // ::::: Exibir a lista de disciplinas lecionadas por cada professor.                                            ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Aluno(string nome, string matricula)
    {
        // ===========================================================================
        // CLASSE: Aluno
        // EXPLICAÇÃO: Representa o estudante. Tem uma relação Muitos-para-Muitos
        // com Disciplina, o que significa que ele possui uma lista delas.
        // ===========================================================================

        public string Nome { get; set; } = nome;
        public string NumeroMatricula {  get; set; } = matricula;

        // Lista de objetos do tipo Disciplina (Associação)
        public List<Disciplina> DisciplinasMatriculadas { get; set; } = [];

        // ===========================================================================

        // Método para matricular o aluno numa disciplina específica
        public void MatricularDisciplina(Disciplina disciplina)
        {
            // Verificar se a disciplina não é nula e se o aluno já não está nela
            if (disciplina != null && !DisciplinasMatriculadas.Contains(disciplina))
            {
                DisciplinasMatriculadas.Add(disciplina);
            }
        }

        // ===========================================================================

        public void ExibirInfo()
        {
            Console.WriteLine($"Aluno: {Nome} | Matrícula: {NumeroMatricula}");
        }
    }
}