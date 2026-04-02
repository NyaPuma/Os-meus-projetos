Algoritmo "Exercicio 3 André Moreira"

Var

   cliente: caractere
   destino: caractere
   guia: caractere

   diasguia: inteiro

   a, b, c: real
   precoDestino: real
   custoguiadia: real
   subtotal: real
   taxaturismo: real
   custototal: real
   custoGuiaTotal: real

Inicio

   a <- 400
   b <- 500
   c <- 750
   taxaturismo <- 0.1
   custoguiadia <- 50

   escreval("Nome do cliente:")
   leia(cliente)

   repita
   escreval("Destino escolhido (A, B ou C):")
   leia(destino)
   se (destino = "A") ou (destino = "a") entao
      precoDestino <- a
   senao
      se (destino = "B") ou (destino = "b") entao
         precoDestino <- b
      senao
         se (destino = "C") ou (destino = "c") entao
            precoDestino <- c
         senao
            escreval("Opção de destino inválida!")
            precoDestino <- 0
         fimse
      fimse
   fimse
   ate (precoDestino > 0)

   escreval("Deseja contratar um guia? (S para Sim, N para Não)")
   leia(guia)

   se (guia = "s") ou (guia = "S") entao
      escreval("Número de dias com guia:")
      leia(diasguia)
   senao
      diasguia <- 0
      se (guia <> "n") e (guia <> "N") entao
         escreval("Opção de guia inválida, assumindo sem guia.")
      fimse
   fimse

   custoGuiaTotal <- diasguia * custoguiadia
   subtotal <- precoDestino + custoGuiaTotal
   custototal <- subtotal + (subtotal * taxaturismo)

   escreval(" ")
   escreval("=== Recibo de Viagem ===")
   escreval("Nome do Cliente:", cliente)
   escreval("Destino Escolhido:", destino)
   escreval("Número de dias com guia:", diasguia)
   escreval("Custo com guia:", custoGuiaTotal)
   escreval("Subtotal:", subtotal)
   escreval("Taxa de Turismo:", subtotal * taxaturismo)
   escreval("Custo total de viagem:", custototal)

Fimalgoritmo