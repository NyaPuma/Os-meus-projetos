Algoritmo "ficha1_ex1.4"
// Disciplina  :  [Linguagem e Lógica de Programação] 
// Professor   : Antonio Carlos Nicolodi 
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
// Secção de Declarações das variáveis
l1:real
l2:real
l3:real
T:real
area:real

Inicio
// Secção de Comandos, procedimento, funções, operadores, etc...
escreval("*****Bem-vindo(a) ao calculador de area do triangulo*****")
escreval("Para calcular terá de digitar os 3 lados do triangulo")

escreval("Digite o primeiro lado do triangulo: ")
leia(l1)
escreval("Digite agora o segundo lado do triangulo: ")
leia(l2)
escreval("Digite agora o terceiro lado do triangulo: ")
leia(l3)

T <- (l1+l2+l3)/2

area <- raizq(T*(T-l1)*(T-l2)*(T-l3))

escreval("A area total do triangulo é de: ",area)

Fimalgoritmo