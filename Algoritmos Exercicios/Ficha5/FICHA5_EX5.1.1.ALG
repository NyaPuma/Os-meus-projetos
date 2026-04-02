Algoritmo "ficha5_ex5.1.1"
//
//

Var

   numeros:vetor [0..6] de inteiro
   i:inteiro

Inicio

   para i de 0 ate 6 faca
      escreval("Por favor digite 7 númeors para verificar")
      leia(numeros[i])
   fimpara

   para i de 0 ate 6 faca
      se (numeros[i]) % 2 = 0  entao
         escreval("O número na posição",i," do vetor é par")
      senao
         escreval("o número na posição",i," do vetor é impar")
      fimse
   fimpara

Fimalgoritmo