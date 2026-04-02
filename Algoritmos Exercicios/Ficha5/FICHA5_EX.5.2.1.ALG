Algoritmo "ficha5_ex.5.2.1"
//
//

Var
   // Secção de Declarações das variáveis

   matriz:vetor [0..2,0..2] de inteiro
   l,c:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   para l de 0 ate 2 faca
      para c de 0 ate 2 faca
         escreval("Digite um valor para a posição:",l,",",c," !")
         leia(matriz[l,c])
      fimpara
   fimpara

   // para impressão da matriz
   escreval(":::::  MATRIZ  :::::")

   para l de 0 ate 2 faca
      para c de 0 ate 2 faca
         escreva(matriz[l,c]," ")
      fimpara
      escreval()
   fimpara

Fimalgoritmo