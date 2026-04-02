Algoritmo "ficha4_ex4.2"

Var

   i:inteiro
   numero_inicial:inteiro
   numero_final:inteiro
   contador:inteiro

Inicio

   escreval("Digite um numero inicial do intervalo:")
   leia(numero_inicial)

   escreval("Digite um numero final do intervalo:")
   leia(numero_final)

   contador <- 0
   para i de numero_inicial ate numero_final faca
      se (i % 2 <> 0) entao
         escreval("o numero",i," é impar")
         contador <- contador + 2
      fimse
   fimpara

Fimalgoritmo