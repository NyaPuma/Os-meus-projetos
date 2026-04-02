Algoritmo "repita_exemplo"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 26/03/2026
Var
   // Secção de Declarações das variáveis
   idade:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   escreval("Digite a sua idade")
   leia(idade)

   repita
      escreval("Escreva idade correta")
      leia(idade)
   ate(idade>=0) e (idade<=100)

   se (idade >= 18) entao
      escreval("Maior de idade")
   senao
      escreval("Menor de idade")
   fimse

Fimalgoritmo