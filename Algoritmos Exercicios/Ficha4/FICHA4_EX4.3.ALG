Algoritmo "ficha4_ex4.3"

Var

   maior:inteiro
   menor:inteiro
   aux:inteiro
   x:inteiro
   i:inteiro

Inicio

   escreval("Digite o número inicial (maior):")
   leia(maior)
   escreval("Digite o número final (menor):")
   leia(menor)
   
   se (menor>maior) entao
   aux <- menor
   menor <- maior
   maior <- aux
   fimse
   
   escreval("Introduza o valor de passo:")
   leia(x)
   se (x < 0) entao
   x <- (-(x))
   fimse

   para i de maior ate menor passo -x faca
      escreval(i)
   fimpara

Fimalgoritmo