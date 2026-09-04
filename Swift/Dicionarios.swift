import Foundation

// Dicionarios

var pessoas:[String:Int] = [
  "Bruno":34,
  "Ana":21,
  "Joana":56
]
print(pessoas)

// aceder ao valor a partir da chave
print(pessoas["Bruno"])
print(pessoas["Bruno"] ?? "não existe par")
print(pessoas["Matilde"] ?? "não existe par")

// Adicionar ao dic um novo par
pessoas["Matilde"] = 47
print(pessoas)

// Remover um valor
pessoas.removeValue(forKey: "Bruno")
print(pessoas)