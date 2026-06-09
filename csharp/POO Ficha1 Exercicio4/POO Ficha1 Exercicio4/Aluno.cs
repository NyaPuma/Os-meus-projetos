using System;

namespace POO_Ficha1_Exercicio4
{
    internal class Aluno
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

        // Atributos
        private string nome;
        private int numeroAluno;
        private double[] notas;
        private static int totalAlunos = 0;

        // Construtor
        public Aluno(string nome, int numeroAluno)
        {
            this.nome = nome;
            this.numeroAluno = numeroAluno;
            this.notas = new double[2]; // Inicializa com 2 posições
            totalAlunos++;
        }

        public void AtribuirNota(int posicao, double valor)
        {
            if (posicao >= 0 && posicao < notas.Length && valor >= 0.0 && valor <= 20.0)
            {
                notas[posicao] = valor;
            }
            else
            {
                Console.WriteLine("Posição inválida!");
            }
        }

        public double ObterMedia()
        {
            double soma = 0;
            for (int i = 0; i < notas.Length; i++)
            {
                soma += notas[i];
            }
            return soma / notas.Length;
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Nº {numeroAluno} | Nome: {nome} | Média: {ObterMedia():F2}");
        }

        public static int TotalAlunos() => totalAlunos;
    }
}