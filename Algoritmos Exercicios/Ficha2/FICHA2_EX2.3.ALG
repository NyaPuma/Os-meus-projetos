Algoritmo "ficha2_ex2.3"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
   // Secção de Declarações das variáveis
   numero:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   escreval("Digite um numero inteiro:")
   leia(numero)
   numero <- numero%2

   se (numero = 0) entao
      escreval("O numero é par")
   senao
      escreval("O numero é impar")
   fimse

Fimalgoritmo