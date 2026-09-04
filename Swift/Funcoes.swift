import Foundation

// Funções

func escreverDia(){
  print("Ola")
}
escreverDia()

func escreverDiaNome(nome:String){
  print("Ola \(nome)")
}
escreverDiaNome(nome: "Raquel")

// função com retorno
func soma(n1:Int, n2:Int)->Int{
  return n1+n2
}
var resultado = soma(n1:2,n2:5)
print(resultado)