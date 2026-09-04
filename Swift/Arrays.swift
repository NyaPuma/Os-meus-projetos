import Foundation

// Arrays

// declarar um array vazio
var vazio: [Int]=[]
print(vazio)

var nomes = ["Ana","João","Maria"]
print(type(of:nomes))

print(vazio.count)
print(vazio.first)

print(nomes.first)
print(nomes.first!)
print(nomes.last!)

print(nomes.first ?? "Não existem elementos")
// ?? operador de coalescencia dupla.
// utiliza-se quando temos um Optional e queremos dizer: 
// utiliza este valor se for nil utiliza outro
print(vazio.first ?? "Não existe")

var idades = [4,12,53,34,22,5,13,20]

// adicionar um elemento ao vetor
idades.append(10)
print(idades)
// ver qual elementos esta na posição
print(idades[4])
// ordenar
idades.sort()
print(idades)
// ordem decrescente
idades.reverse()
print(idades)
// baralhar
idades.shuffle()
print(idades)

// converter o array idades num set
var idadesSet = Set(idades)
print(idadesSet)

// novo set
var numeros:Set = [4,13,22,22,22,56]
print(numeros)