Algoritmo "semnome"

Var

   VF:real
   P:real
   r:real
   n:real

Inicio

   escreval("Por favor, digite o capital inicial (100 a 1000000):")
   leia(P)
   enquanto (P < 100) ou (P > 1000000) faca
      escreval("Valor inválido, digite um número entre 100 e 1000000")
      leia(P)
   fimenquanto

   escreval("Por favor, digite a taxa de juros anual (1 a 100%):")
   leia(r)
   enquanto (r < 1) ou (r > 100) faca
      escreval("Valor inválido, digite um número entre 1 e 100")
      leia(r)
   fimenquanto

   escreval("Por favor, digite o número de anos (1 a 100):")
   leia(n)
   enquanto (n < 1) ou (n > 100) faca
      escreval("Valor inválido, digite um número entre 1 e 100")
      leia(n)
   fimenquanto

   VF <- P * (1 + r/100)^n

   escreval("O valor futuro do seu investimento será", VF)

Fimalgoritmo