Algoritmo "ficha1_ex1.8"

Var
// Secção de Declarações das variáveis
eleitores:inteiro
votosbrancos:inteiro
votosnulos:inteiro
votosvalidos:inteiro

abstencao:real
percnulos:real
percbrancos:real
percvalidos:real
taxavota:real

Inicio
// Secção de Comandos, procedimento, funções, operadores, etc...
escreval("Bem-vindo ao programa de contagem de votos")

escreval("Intruduza o valor total de eleitores:")
leia(eleitores)
escreval("Intruduza o valor total de votos em branco:")
leia(votosbrancos)
escreval("Intruduza o valor total de votos nulos:")
leia(votosnulos)
escreval("Intruduza o valor total de votos válidos:")
leia(votosvalidos)

percbrancos <- (votosbrancos/eleitores)*100
escreval("A percentagem de votos brancos é",percbrancos,"%")

percnulos <- (votosnulos/eleitores)*100
escreval("A percentagem de votos nulos é",percnulos,"%")

percvalidos <- (votosvalidos/eleitores)*100
escreval("A percentagem de votos válidos é",percvalidos,"%")

taxavota <- (votosbrancos + votosnulos + votosvalidos)/eleitores
abstencao <- (1-taxavota)*100
escreval("A abstencao foi de",abstencao,"%")

Fimalgoritmo