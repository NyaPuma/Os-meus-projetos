Algoritmo "exercicio_ordem_decresente"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 30/03/2026
Var
   // Secção de Declarações das variáveis
   A:inteiro
   B:inteiro
   C:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   // ::::::::::::::::::::::::::::::
   // :::::  Input utilizador  :::::
   // ::::::::::::::::::::::::::::::
   escreval("Digite um número para A:")
   leia(A)
   escreval("Digite um número para B:")
   leia(B)
   escreval("Digite um número para C:")
   leia(C)
   
   // ::::::::::::::::::::::::::::::::::::::::::::
   // :::::  Verificador de números válidos  :::::
   // ::::::::::::::::::::::::::::::::::::::::::::
   enquanto (A = 0) ou (B = 0) ou (C = 0) faca
      se (A = 0) entao
         escreval("Número inválido para A!")
         escreval("Digite um número para A:")
         leia(A)
      senao
         se (B = 0) entao
            escreval("Número inválido para B!")
            escreval("Digite um número para B:")
            leia(B)
         senao
            se (C = 0) entao
               escreval("Número inválido para C!")
               escreval("Digite um número para C:")
               leia(C)
            fimse
         fimse
      fimse
   fimenquanto
   
   // :::::::::::::::::::::::::::::::::::::::::::
   // :::::  Verificador de números iguais  :::::
   // :::::::::::::::::::::::::::::::::::::::::::
   enquanto (A = B) ou (A = C) ou (B = C) faca
      se (A = B) entao
         escreval("Número inválido para A!")
         escreval("Digite um número para A:")
         leia(A)
      senao
         se (A = C) entao
            escreval("Número inválido para A!")
            escreval("Digite um número para A:")
            leia(A)
         senao
            se (B = C) entao
               escreval("Número inválido para C!")
               escreval("Digite um número para C:")
               leia(C)
            fimse
         fimse
      fimse
   fimenquanto
   
   // :::::::::::::::::::::::::::::::::::::::::::::
   // :::::  Ordenador por ordem decrescente  :::::
   // :::::::::::::::::::::::::::::::::::::::::::::
   se (a > b) e (a > c) e (b > c) entao
      escreval(a,b,c)
   senao
      se (a > b) e (a > c) e (c > b) entao
         escreval(a,c,b)
      senao
         se (a < b) e (a > c) e (c < b) entao
            escreval(b,a,c)
         senao
            se (a < b) e (a < c) e (c < b) entao
               escreval(b,c,a)
            senao
               se (a > b) e (a < c) e (c > b) entao
                  escreval(c,a,b)
               senao
                  se (a < b) e (a < c) e (c > b) entao
                     escreval(c,b,a)
                  fimse
               fimse
            fimse
         fimse
      fimse
   fimse

Fimalgoritmo