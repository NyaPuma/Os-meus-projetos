import Foundation

//let nome:String = "Sara"
let nome = "Sara"
print(type(of:nome))
print("Olá\(nome)")

/*nome = Cesae
print(nome)*/

// Tipos de dados
let idade: Int = 25
let preco: Double = 19.00
let temperatura: Float = 36.5
let aprovado: Bool = true
let inicial: Character = "S"
let nome1: String = "Sara"

print(type(of: temperatura))

// Operadores
let a = 10
let b = 5

var resultado = a + b
print(a+b)
print(resultado)

print(a > b)
print(a == b)

// Condicionais
let temBilhete = true

if idade >= 18 && temBilhete{
  print("Pode entrar")
}else{
  print("Não pode entrar")
}

let nota = 15
if nota >= 19{
  print("Excelente")
}else if nota >= 10{
  print("Aprovado")
}else{
  print("Reprovado")
}

let codigo = 4
switch codigo{
  case 1: print("Um")
  case 2: print("Dois")
  case 3: print("Tres")
  case 4: print("Quatro")
  default: print("Outro valor")
}

switch nota{
  case 0..<10: print("reprovado")
  case 10...14: print("suficiente")
  case 15..<20: print("muito bom")
  default: print("Nota invalida")
}