Algoritmo "Tabuada simples"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 30/03/2026
Var
   // Secção de Declarações das variáveis
   numero:inteiro
   i:inteiro
   resultado:inteiro
   repetir:caractere

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   repetir <- "S"

   enquanto (repetir = "S") faca
      escreval("Qual a tabuada?")
      leia(numero)

      para i de 1 ate 10 faca
         resultado <- numero * i
         escreval("Tabuada:",numero," *",i," =",resultado)
      fimpara

      escreval("Deseja continuar?:")
      leia(repetir)
   fimenquanto

Fimalgoritmo