namespace POO_Ficha1_Exercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Implementar uma classe em C# que represente um aluno de uma turma, aplicando :::::
            // ::::: conceitos de programação orientada a objetos, incluindo o uso de variável    :::::
            // ::::: estática e array de notas.                                                   :::::
            // :::::                                                                              :::::
            // ::::: Requisitos                                                                   :::::
            // :::::                                                                              :::::
            // :::::  Criar uma classe chamada Aluno.                                            :::::
            // :::::  A classe deve possuir:                                                     :::::
            // :::::      um atributo privado nome(do tipo string);                              :::::
            // :::::      um atributo privado numeroAluno(do tipo int);                          :::::
            // :::::      um atributo privado notas(do tipo double[]) com um número fixo de      :::::
            // :::::     posições(por exemplo, 2 notas);                                          :::::
            // :::::      uma variável estática privada chamada totalAlunos(do tipo int), que    :::::
            // :::::     conte quantos alunos já foram criados.                                   :::::
            // :::::  Criar um construtor que:                                                   :::::
            // :::::      permita inicializar nome e numeroAluno;                                :::::
            // :::::      inicialize o array notas com todas as posições a 0.0;                  :::::
            // :::::      incremente a variável estática totalAlunos sempre que um novo aluno    :::::
            // :::::     é criado.                                                                :::::
            // :::::  Criar:                                                                     :::::
            // :::::      um método público AtribuirNota(int posicao, double valor) que guarde   :::::
            // :::::     uma nota numa posição válida do array;                                   :::::
            // :::::      um método público ObterMedia() que calcule e devolva a média das       :::::
            // :::::     notas do aluno;                                                          :::::
            // :::::      um método público MostrarDados() que apresente o nome, número do       :::::
            // :::::     aluno e a média das notas;                                               :::::
            // :::::      um método estático TotalAlunos() que devolva o valor da                :::::
            // :::::     variável totalAlunos(sem parâmetros).                                    :::::
            // :::::  Demonstrar o funcionamento da classe num programa principal(Main):         :::::
            // :::::      criar vários objetos Aluno;                                            :::::
            // :::::      atribuir notas a cada aluno;                                           :::::
            // :::::      apresentar a média de cada um;                                         :::::
            // :::::      no final, invocar o método estático TotalAlunos() para mostrar quantos :::::
            // :::::     alunos foram criados.                                                    :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Instanciação dos objetos Aluno
            Aluno a1 = new Aluno("Ana Silva", 101);
            Aluno a2 = new Aluno("Bruno Costa", 102);

            // Atribuição de notas
            a1.AtribuirNota(0, 16);
            a1.AtribuirNota(1, 14);

            a2.AtribuirNota(0, 12);
            a2.AtribuirNota(1, 10);

            // Output dos resultados
            a1.MostrarDados();
            a2.MostrarDados();

            Console.WriteLine($"\nTotal de alunos criados: {Aluno.TotalAlunos()}");
        }
    }
}
