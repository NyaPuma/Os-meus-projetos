import Foundation

class Pessoa {
    var nome: String
    var email: String
    var idade: Int

    // Construtor
    init(nome: String, email: String, idade: Int) {
        self.nome = nome
        self.email = email
        self.idade = idade
    }
}

let p1 = Pessoa(
    nome: "Maria",
    email: "maria@exemplo.com",
    idade: 34
)

print(p1.nome)
print(p1.email)
print(p1.idade)