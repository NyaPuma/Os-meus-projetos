def gravaNotas():
    notas = []
    for i in range(10):
        nota = float(input("Introduza a norta: "))
        notas.append(nota)
    return(notas)


def mediaMaiores(listanotas):
    media = sum(listanotas)/len(listanotas)
    notasMaior = []
    for i in listanotas:
        if i > media:
            notasMaior.append(i)
