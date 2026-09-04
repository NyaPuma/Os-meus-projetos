import Foundation

enum Curso: Int {
    case python = 50
    case web = 100
    case mobile = 75
}

func getDuracao(curso: Curso) {
    if curso == .python {
        print("50 horas")
    } else if curso == .web {
        print("100 horas")
    } else if curso == .mobile {
        print("75 horas")
    } else {
        print("não existe")
    }
}

getDuracao(curso: .python)
