Algoritmo "ficha2_ex2.6"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 25/03/2026
Var
   // Secção de Declarações das variáveis
   inputmenu:inteiro
   inputdoacao:real

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   escreval("Escolha por favor a opção que pretende:")
   escreval("[1] para doar 5 euros")
   escreval("[2] para doar 10 euros")
   escreval("[3] para doar outros valores, em euros")
   escreval("[4] para cancelar a operação")
   leia(inputmenu)

   escolha inputmenu
   caso 1
      escreval("Obrigado pela sua doação de 5 euros")
   caso 2
      escreval("Obrigado pela sua doação de 10 euros")
   caso 3
      escreval("Escolha por favor o valor que pretende doar em euros")
      leia(inputdoacao)
      escreval("Obrigado pela sua doação de",inputdoacao," euros")
   caso 4
      escreval("Operação cancelada com sucesso")
   outrocaso
      escreval("Numero inválido, por favor digite um numero de 1 a 4")
   fimescolha

Fimalgoritmo