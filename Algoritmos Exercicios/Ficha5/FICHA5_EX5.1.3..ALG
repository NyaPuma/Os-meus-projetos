Algoritmo "ficha5_ex5.1.3."
//
//

Var
   // Secção de Declarações das variáveis

   produtos:vetor [0..2] de caractere
   preco_unitario:vetor [0..2] de real
   stock:vetor [0..2] de inteiro
   i:inteiro
   compra_produto:inteiro
   quantidade_produto:inteiro
   preco_final:real

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   // :::::::::::::::::::::::::::::::::::::::
   // :::::  Base de dados de produtos  :::::
   // :::::::::::::::::::::::::::::::::::::::

   produtos[0] <- "computador"
   produtos[1] <- "teclado"
   produtos[2] <- "rato"

   // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
   // :::::  Base de dados de preços unitários de produtos  :::::
   // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

   preco_unitario[0] <- 100
   preco_unitario[1] <- 20
   preco_unitario[2] <- 10

   // ::::::::::::::::::::::::::::::::::::::::::::::::
   // :::::  Base de dados de stock de produtos  :::::
   // ::::::::::::::::::::::::::::::::::::::::::::::::

   stock[0] <- 1
   stock[1] <- 5
   stock[2] <- 10

   // :::::::::::::::::::::::::::::::::::::::
   // :::::  Lista de índice + produto  :::::
   // :::::::::::::::::::::::::::::::::::::::

   escreval("Lista de índice e produtos disponiveis:")

   para i de 0 ate 2 faca
      escreval (i," ", produtos[i])
   fimpara

   // ::::::::::::::::::::::::::::::::::::::::
   // :::::  Utilizador escolhe produto  :::::
   // ::::::::::::::::::::::::::::::::::::::::

   escreval("Digite o índice do produto que pretende adiquirir")
   leia(compra_produto)

   enquanto (compra_produto > 2) ou (compra_produto < 0) faca
      escreval("Número de produto inválido, por favor digite um número válido:")
      leia(compra_produto)
   fimenquanto

   i <- compra_produto

   // :::::::::::::::::::::::::::::::::::::::::::
   // :::::  Utilizador escolhe quantidade  :::::
   // :::::::::::::::::::::::::::::::::::::::::::

   escreval("Digite a quantidade desse produto que pretende adquirir")
   leia(quantidade_produto)

   enquanto (quantidade_produto > stock[i]) ou (quantidade_produto < 0) faca
      se (quantidade_produto > stock[i]) entao
         escreval("!!!!! O valor digitado ultrapassa o stock !!!!!")
         escreval("Stock disponível:", stock[i])
         escreval("Digite um valor que não ultrapasse o stock:")
         leia(quantidade_produto)
      fimse

      se (quantidade_produto < 0) entao
         escreval("!!!!! O valor digitado não pode ser negativo !!!!!")
         escreval("Digite um valor que não seja negativo:")
         leia(quantidade_produto)
      fimse
   fimenquanto

   // ::::::::::::::::::::::::::::::::::::::::
   // :::::  Calculos para o preço final :::::
   // ::::::::::::::::::::::::::::::::::::::::

   preco_final <- preco_unitario[i] * quantidade_produto

   // ::::::::::::::::::::::::::::::::::::::::::::::::::::::
   // :::::  Mensagem final apresentada ao utilizador  :::::
   // ::::::::::::::::::::::::::::::::::::::::::::::::::::::

   escreval("Produto:",produtos[i])
   escreval("Quantidade:",quantidade_produto)
   escreval("Preço unitário:",preco_unitario[i])
   escreval("Preço final:",preco_final)

Fimalgoritmo