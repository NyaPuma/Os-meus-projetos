Algoritmo "ficha2_ex2.5"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
   // Secção de Declarações das variáveis
   massa:real
   altura:real
   imc:real
   min:real
   max:real

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   max <- 24.9
   min <- 18.5

   escreval(min)

   escreval("Digite a sua massa em kilos:")
   leia(massa)
   escreval("Digite a sua altura em metros:")
   leia(altura)

   imc <- massa/altura^2

   se (imc >= max) entao
      escreval("Obeso")
   senao
      se (imc >= min) e (imc < max) entao
         escreval("Peso normal")
      senao
         se (imc < min) entao
            escreval("Magra")
         fimse
      fimse
   fimse

Fimalgoritmo