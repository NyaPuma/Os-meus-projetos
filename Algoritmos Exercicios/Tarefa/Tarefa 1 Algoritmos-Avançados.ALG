Algoritmo "Tarefa 1: Algoritmos-Avançados"

// Desenvolva um algoritmo em pseudocodigo que solicite o nome,
// a idade, o sexo (Masculino ou Feminino)e a localidade de 5
// pessoas e armazene esses dados em vetores.
// O programa deve oferecer um menu que permita ao utilizador
// as seguintes opções:

// 1- introduzir os dados das 5 pessoas
// 2- sair do programa

// Apos o utilizador ter informado os dados das 5 pessoas,
// caso opção 1 seja selecionada, o programa deve oferecer as
// seguintes opções num segundo menu:

// 1- consultar a lista de pessoas
// 2- consultar a media de idades do homens
// 3- consultar a media das idades das mulheres
// 4- consultar a lista de mulheres
// 5- consultar a lista de homens

Var
   // Secção de Declarações das variáveis

   nome: vetor [0..4] de caractere
   sexo: vetor [0..4] de caractere
   localidade: vetor [0..4] de caractere

   idade: vetor [0..4] de inteiro

   menu: inteiro
   opcao_menu: inteiro
   i: inteiro
   aux1: inteiro
   aux2: inteiro

   media: real

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   // :::::::::::::::::::::::::::::::::::
   // :::::  Menu de inicialização  :::::
   // :::::::::::::::::::::::::::::::::::

   escreval(":::::  Menu  :::::")
   escreval("1 - introduzir os dados das 5 pessoas")
   escreval("2 - sair do programa")
   leia(menu)

   enquanto (menu > 2) ou (menu < 1) faca
      escreval("Número inválido, digite um número disponivel no menu:")
      leia(menu)
   fimenquanto

   // ::::::::::::::::::::::::::::::::::::::
   // :::::  Inicialização do programa :::::
   // ::::::::::::::::::::::::::::::::::::::

   se (menu = 1) entao

      // ::::::::::::::::::::::::::::::::::::::::::
      // :::::  Utilizador introduz os dados  :::::
      // ::::::::::::::::::::::::::::::::::::::::::

      para i de 0 ate 4 faca
         escreval("---------------------------------------------------------")
         escreval("Pessoa ", i + 1)
         escreval("Digite o nome da pessoa:")
         leia(nome[i])

         escreval("Digite a idade da pessoa:")
         leia(idade[i])

         enquanto (idade[i] < 0) ou (idade[i] > 150) faca
            escreval("Digite a idade da pessoa (tem de ser entre 0 e 150):")
            leia(idade[i])
         fimenquanto

         escreval("Digite o sexo da pessoa (f/m):")
         leia(sexo[i])
         enquanto (sexo[i] <> "f") e (sexo[i] <> "m") faca
            escreval("Digite o sexo da pessoa (tem de ser f ou m):")
            leia(sexo[i])
         fimenquanto

         escreval("Digite a localidade da pessoa:")
         leia(localidade[i])
         escreval("---------------------------------------------------------")
      fimpara

      // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
      // :::::  O menu de escolha é apresentado ao utilizador  :::::
      // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

      escreval(" ")
      escreval(":::::  Opções de menu  :::::")
      escreval(" ")
      escreval("1- consultar a lista de pessoas")
      escreval("2- consultar a media de idades do homens")
      escreval("3- consultar a media das idades das mulheres")
      escreval("4- consultar a lista de mulheres")
      escreval("5- consultar a lista de homens")
      escreval("6- Sair")
      escreval(" ")

      // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::
      // :::::  Repetição para permitir múltiplas consultas  :::::
      // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::

      enquanto (opcao_menu <> 6) faca

         // ::::::::::::::::::::::::::::::::::::::::::::
         // :::::  O utilizador faz a sua escolha  :::::
         // ::::::::::::::::::::::::::::::::::::::::::::

         escreval("---------------------------------------------------------")
         escreval("Digite a opção que pretende utilizar:")
         leia(opcao_menu)
         escreval("---------------------------------------------------------")

         enquanto (opcao_menu > 6) ou (opcao_menu < 1) faca
            escreval("!!!!!  Opção Inválida  !!!!!")
            escreval("Digite um valor válido ( 1 a 6 )")
            leia(opcao_menu)
         fimenquanto

         // :::::::::::::::::::::::::::::::::::::::::::::
         // :::::  1- consultar a lista de pessoas  :::::
         // :::::::::::::::::::::::::::::::::::::::::::::

         se opcao_menu = 1 entao
            escreval("Lista de pessoas:")
            para i de 0 ate 4 faca
               escreval("Nome: ",nome[i]," | Idade: ",idade[i]," | Sexo: ",sexo[i]," | Localidade: ",localidade[i])
            fimpara
         fimse

         // :::::::::::::::::::::::::::::::::::::::::::::::::::::::
         // :::::  2- consultar a media de idades dos homens  :::::
         // :::::::::::::::::::::::::::::::::::::::::::::::::::::::

         se opcao_menu = 2 entao
            aux1 <- 0 // Contador de homens
            aux2 <- 0 // Acumulador de idades

            para i de 0 ate 4 faca
               se sexo[i] = "m" entao
                  aux1 <- aux1 + 1
                  aux2 <- aux2 + idade[i]
               fimse
            fimpara

            se aux1 > 0 entao
               media <- aux2 / aux1
               escreval("Média de idade dos homens: ", media)
            senao
               escreval("Nenhum homem registado.")
            fimse
         fimse

         // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::
         // :::::  3- consultar a media de idades das mulheres  :::::
         // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::

         se opcao_menu = 3 entao
            aux1 <- 0 // Contador de mulheres
            aux2 <- 0 // Acumulador de idades

            para i de 0 ate 4 faca
               se sexo[i] = "f" entao
                  aux1 <- aux1 + 1
                  aux2 <- aux2 + idade[i]
               fimse
            fimpara

            se aux1 > 0 entao
               media <- aux2 / aux1
               escreval("Média de idade das mulheres: ", media)
            senao
               escreval("Nenhuma mulher registada.")
            fimse
         fimse

         // ::::::::::::::::::::::::::::::::::::::::::::::
         // :::::  4- consultar a lista de mulheres  :::::
         // ::::::::::::::::::::::::::::::::::::::::::::::

         se opcao_menu = 4 entao
            escreval("Lista de mulheres:")
            para i de 0 ate 4 faca
               se sexo[i] = "f" entao
                  escreval("Nome: ",nome[i]," | Idade: ",idade[i]," | Localidade: ",localidade[i])
               fimse
            fimpara
         fimse

         // ::::::::::::::::::::::::::::::::::::::::::::::
         // :::::  5- consultar a lista de homens  :::::::
         // ::::::::::::::::::::::::::::::::::::::::::::::

         se opcao_menu = 5 entao
            escreval("Lista de homens:")
            para i de 0 ate 4 faca
               se sexo[i] = "m" entao
                  escreval("Nome: ",nome[i]," | Idade: ",idade[i]," | Localidade: ",localidade[i])
               fimse
            fimpara
         fimse

         // :::::::::::::::::::::::::::::::::::::::
         // :::::  Volta às opções de menu  :::::::
         // :::::::::::::::::::::::::::::::::::::::

      fimenquanto

      // ::::::::::::::::::::::::::::::::::::::::
      // :::::  Encerramento do programa  :::::::
      // ::::::::::::::::::::::::::::::::::::::::

   fimse

Fimalgoritmo