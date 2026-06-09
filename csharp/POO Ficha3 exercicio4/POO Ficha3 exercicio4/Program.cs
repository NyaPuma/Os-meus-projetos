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
    internal class Program
    {
        static void Main(string[] args)
        {
            // TRY: Tenta executar o código. Se algo falhar, vai para o CATCH.
            try
            {
                Console.WriteLine(">>> A INICIAR SISTEMA ESCOLAR <<<");

                // 1. Instanciar os objetos (Criação)
                Professor profMat = new("Dr. Ricardo Jorge", "REG-55");
                Disciplina d1 = new("Matemática Computacional", "MAT01");
                Aluno a1 = new("Tiago Ferreira", "2026-001");
                Aluno a2 = new("Sofia Matos", "2026-002");

                // 2. Criar as ligações (Associações)
                d1.DefinirProfessor(profMat);
                d1.AdicionarAluno(a1);
                d1.AdicionarAluno(a2);

                // 3. Mostrar os resultados
                profMat.ExibirInfo();
                d1.ExibirInfo();
            }
            catch (Exception ex)
            {
                // Mostra a mensagem de erro amigável se algo correr mal
                Console.WriteLine($"Erro no Sistema: {ex.Message}");
            }
            finally
            {
                // FINALLY: Executa sempre ao terminar, com erro ou não.
                Console.WriteLine("\nSessão encerrada. Prima qualquer tecla.");
                Console.ReadKey();
            }
        }
    }
}