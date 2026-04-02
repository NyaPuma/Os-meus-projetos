Algoritmo "ficha2_ex2.2"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
   // Secção de Declarações das variáveis
   idade:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   escreval("Por favor, Digite a idade:")
   leia(idade)

   se (idade>=0) e (idade<=11) entao
      escreval("Esta pessoa é uma criança")
   senao

      se (idade>=12) e (idade<=17) entao
         escreval("Esta pessoa é um adolescente")
      senao

         se (idade>=18) e (idade<=59) entao
            escreval("Esta pessoa é um adulto")
         senao

            se (idade>=60)entao
               escreval("Esta pessoa é idosa")
            fimse
         fimse
      fimse
   fimse

Fimalgoritmo