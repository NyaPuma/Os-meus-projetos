Algoritmo "ficha1_ex1.5"
// Disciplina  :  [Linguagem e Lógica de Programação] 
// Professor   : Antonio Carlos Nicolodi 
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 24/03/2026
Var
// Secção de Declarações das variáveis
area:real
volume:real
raio:real

Inicio
// Secção de Comandos, procedimento, funções, operadores, etc...
escreval("Bem-vindo(a) ao calculador de area e volume de uma esfera")
escreval("Digite o raio da esfera: ")
leia(raio)

area <- 4*pi*raio^2
escreval("A area da sua esfera é:",area)

volume <- (4/3)*pi*raio^3
escreval("O volume da sua esfera é:",volume)

Fimalgoritmo