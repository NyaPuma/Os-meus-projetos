Algoritmo "Tarefa 1: Algoritmos-Avançados"

// Desenvolva um algoritmo em pseudocodigo que solicite o nome,
// a idade, o sexo (Masculino ou Feminino)e a localidade de 5 pessoas
// e armazene esses dados em vetores.
// O programa deve oferecer um menu que permita ao utilizador
// as seguintes opções:

// introduzir os dados das 5 pessoas
// sair do programa

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

   nome:vetor [0..4] de caractere
   idade:vetor [0..4] de inteiro
   sexo:vetor [0..4] de caractere
   localidade:vetor [0..4] de caractere
   opcao_menu:inteiro
   i:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   // ::::::::::::::::::::::::::::::::::::::::::
   // :::::  Utilizador introduz os dados  :::::
   // ::::::::::::::::::::::::::::::::::::::::::

   para i de 0 ate 4 faca
      escreval("Digite o nome da pessoa:")
      leia(nome[i])
      escreval("Digite a idade da pessoa:")
      leia(idade[i])
      escreval("Digite o sexo da pessoa:")
      leia(sexo[i])
      escreval("Digite a localidade da pessoa:")
      leia(localidade[i])
   fimpara

   // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
   // :::::  O menu de escolha é apresentado ao utilizador  :::::
   // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

   escreval(" ")
   escreval(":::::  Menu  :::::")
   escreval(" ")
   escreval("1- consultar a lista de pessoas")
   escreval("2- consultar a media de idades do homens")
   escreval("3- consultar a media das idades das mulheres")
   escreval("4- consultar a lista de mulheres")
   escreval("5- consultar a lista de homens")
   escreval(" ")

   // ::::::::::::::::::::::::::::::::::::::::::::
   // :::::  O utilizador faz a sua escolha  :::::
   // ::::::::::::::::::::::::::::::::::::::::::::

   escreval("Digite a opção que pretende utilizar:")
   leia(opcao_menu)

   enquanto (opcao_menu > 5) ou (opcao_menu < 1) faca
      escreval("!!!!!  Opção Inválida  !!!!!")
      escreval("Digite um valor válido ( 1 a 5 )")
      leia(opcao_menu)
   fimenquanto

   // :::::::::::::::::::::::::::::::::::::::::::::
   // :::::  1- consultar a lista de pessoas  :::::
   // :::::::::::::::::::::::::::::::::::::::::::::
   
   para i de 0 ate 4 faca
   
   fimpara



Fimalgoritmo