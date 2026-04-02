Algoritmo "ficha5_ex5.1.2"
//
//

Var
   // Secção de Declarações das variáveis
   nome:vetor [0..3] de caractere
   nota1:vetor [0..3] de inteiro
   nota2:vetor [0..3] de inteiro
   media:vetor [0..3] de real
   i:inteiro
   notamax:inteiro
   notamin:inteiro
   numnotas:inteiro
   minalunos:inteiro
   totalalunos:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   notamax <- 20
   notamin <- 0
   numnotas <- 2
   minalunos <- 0
   totalalunos <- 3 // número total de alunos -1

   // :::::::::::::::::::::::::::
   // ::::: nome dos alunos :::::
   // :::::::::::::::::::::::::::

   para i de minalunos ate totalalunos faca
      escreval("Digite o nome do aluno:")
      leia(nome[i])
   fimpara

   // ::::::::::::::::::
   // ::::: nota 1 :::::
   // ::::::::::::::::::

   para i de minalunos ate totalalunos faca
      escreval("Digite a primeira nota do aluno:")
      leia(nota1[i])
      enquanto (nota1[i] > notamax) ou (nota1[i] < notamin) faca
         escreval("nota inválida, digite um número de 0 a 20:")
         leia(nota1[i])
      fimenquanto
   fimpara

   // ::::::::::::::::::
   // ::::: nota 2 :::::
   // ::::::::::::::::::

   para i de minalunos ate totalalunos faca
      escreval("Digite a segunda nota do aluno do aluno:")
      leia(nota2[i])
      enquanto (nota2[i] > notamax) ou (nota2[i] < notamin) faca
         escreval("nota inválida, digite um número de 0 a 20:")
         leia(nota2[i])
      fimenquanto
   fimpara

   // :::::::::::::::::::::::::::
   // ::::: média das notas :::::
   // :::::::::::::::::::::::::::

   para i de minalunos ate totalalunos faca
      media[i] <- (nota1[i] + nota2[i]) / numnotas
      escreval("A média das notas do aluno ",nome[i]," é:",media[i])
   fimpara

Fimalgoritmo