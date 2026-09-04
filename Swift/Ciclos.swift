import Foundation

// Ciclos

for i in 0..<10{
  print(i)
}

var nomes = ["Ana","João","Maria"]
for nome in nomes{
  print(nome)
}

for nome in nomes where nome == "Ana"{
  print(nome)
}

var numerosAleatorios:[Int]=[]
for i in 0...5{
  let numero = Int.random(in:0...100)
  numerosAleatorios.append(numero)
}
print(numerosAleatorios)