Algoritmo "exemplo_vectores"
//programa que pede valores para serem armazenados
//dentro de um vetor
Var
   // Secção de Declarações das variáveis
   numeros:vetor [0..3] de inteiro
   i:inteiro

Inicio
   // Secção de Comandos, procedimento, funções, operadores, etc...

   //ciclo de preenchimento de um vetor
   para i de 0 ate 3 faca
      escreval("Digite um valor para a posição:",i)
      leia(numeros[i])
   fimpara

   //Ciclo que percorre o vetor para exibir o conteudo em posição
   para i de 0 ate 3 faca
      escreva(numeros[i])
   fimpara

   //Ciclo para alterar os valores do vetor
   Para i de 0 ate 3 faca
      numeros[i] <- numeros[i] * 100
      escreva(numeros[i])
   fimpara
Fimalgoritmo