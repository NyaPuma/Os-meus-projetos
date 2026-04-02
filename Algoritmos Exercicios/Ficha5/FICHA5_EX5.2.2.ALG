Algoritmo "ficha5_ex5.2.2"
//
//

Var
   // Secção de Declarações das variáveis

   matriz:vetor [0..2,0..2] de inteiro
   c,l:inteiro
   i,j:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   para l de 0 ate 2 faca
      para c de 0 ate 2 faca
         escreval("Digite o valor para a posição:",l," ",c)
         leia(matriz[l,c])
      fimpara
   fimpara

   para i de 0 ate 2 faca
      para j de 0 ate 2 faca
         matriz[l,c] <- l * c
         escreva(matriz[l,c])
      fimpara
      escreval()
   fimpara

Fimalgoritmo