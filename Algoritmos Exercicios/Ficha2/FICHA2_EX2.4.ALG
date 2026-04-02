Algoritmo "ficha2_ex2.4"
// Disciplina  :  [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
   // Secção de Declarações das variáveis
   l1:real
   l2:real
   lmax:real

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...
   escreval("Digite o valor do lado maior do triangulo:")
   leia(lmax)
   escreval("Digite o valor de outro lado do triangulo:")
   leia(l1)
   escreval("Digite o valor do lado em falta do triangulo:")
   leia(l2)

   se (lmax >= l1 + l2) entao
      escreval("não existe triangulo")
   senao
      se (lmax^2 = l1^2 + l2^2) entao
         escreval("triangulo rectangulo")
      senao
         se (lmax^2 > l1^2 + l2^2) entao
            escreval("triangulo obtuso")
         senao
            se (lmax^2 < l1^2 + l2^2) entao
               escreval("triangulo agudo")
            fimse
         fimse
      fimse
   fimse

Fimalgoritmo