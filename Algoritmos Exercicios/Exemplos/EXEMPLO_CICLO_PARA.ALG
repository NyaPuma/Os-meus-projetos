Algoritmo "exemplo_ciclo_para"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 30/03/2026
Var
   // Secção de Declarações das variáveis
   i:inteiro
   contador:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   contador <- 0

   para i de 40 ate 20 passo -2 faca
      escreval(i)
      contador <- contador + 1
   fimpara

   escreval("****************************************")
   escreval("o numero total de elementos:", contador)
   escreval("Valor de i:",i)

Fimalgoritmo