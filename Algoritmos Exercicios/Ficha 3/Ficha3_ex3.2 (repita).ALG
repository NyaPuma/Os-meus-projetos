Algoritmo "semnome"

Var

   VF:real
   P:real
   r:real
   n:real

Inicio

   repita
      escreval("Por favor, digite o capital inicial (100 a 1000000):")
      leia(P)
   ate (P > 100) e (P < 1000000)

   repita
      escreval("Por favor, digite a taxa de juros anual (1 a 100%):")
      leia(r)
   ate (r > 1) e (r < 100)

   repita
      escreval("Por favor, digite o número de anos (1 a 100):")
      leia(n)
   ate (n > 1) e (n < 100)

   VF <- P * (1 + r/100)^n

   escreval("O valor futuro do seu investimento será", VF)

Fimalgoritmo