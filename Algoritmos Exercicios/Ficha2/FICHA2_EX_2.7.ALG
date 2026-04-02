Algoritmo "ficha2_ex_2.7"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 25/03/2026
Var
   // Secção de Declarações das variáveis
   input:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   escreval("Escolha uma opção do menu")
   escreval("[1] para segunda-feira")
   escreval("[2] para terça-feira")
   escreval("[3] para quarta-feira")
   escreval("[4] para quinta-feira")
   escreval("[5] para sexta-feira")
   escreval("[6] para sábado")
   escreval("[7] para domingo")
   leia(input)

   //para cada numero de 1 a 7 será apresentado
   //o dia da semana correspondente

   escolha input
   caso 1
      escreval("Hoje é Segunda-feira")
   caso 2
      escreval("Hoje é Terça-feira")
   caso 3
      escreval("Hoje é Quarta-feira")
   caso 4
      escreval("Hoje é Quinta-feira")
   caso 5
      escreval("Hoje é Sexta-feira")
   caso 6
      escreval("Hoje é Sábado")
   caso 7
      escreval("Hoje é Domingo")
   outrocaso
      escreval("Erro, numero inválido")
   fimescolha

Fimalgoritmo