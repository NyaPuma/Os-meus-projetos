Algoritmo "ficha2_ex2.1"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
   // Secção de Declarações das variáveis
   nota:real
   x:inteiro
   saida:inteiro
Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   x <- 1

   enquanto (x=1) faca
      escreval("Intruduza a nota:")
      leia(nota)
      se(nota>=90) e (nota<=100) entao
         escreval("Conceito A")
      senao
         se(nota>=80) e (nota<=89) entao
            Escreval("Conceito B")
         senao
            se(nota>=70) e (nota<=79) entao
               Escreval("Conceito C")
            senao
               se(nota>=60) e (nota<=69) entao
                  escreval("Conceito D")
               senao
                  se(nota>=0) e (nota<=59) entao
                     escreval("Conceito F")
                  senao
                     escreval("Nota inválida")
                  fimse
               fimse
            fimse
         fimse
      fimse

      escreval("Deseja continuar, prima [1] para continuar, [0] para sair:")
      leia(saida)
      se (saida = 1) entao
         x <- 1
      senao
         se (saida = 0) entao
            x <- 0
         senao
            escreval("numero inválido")
         fimse
      fimse
   fimenquanto


Fimalgoritmo