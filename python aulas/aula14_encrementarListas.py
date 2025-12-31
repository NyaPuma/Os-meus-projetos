

def criaLista(prim_num, ult_num, intervalo):
    lista = []
    for i in range(prim_num, ult_num, intervalo):
        lista.append(i)
    return lista


def encrementaLista(lista):
    for i in range(len(lista)):
        lista[i] = lista[i] + 10
    return lista

prim_num = int(input("Diga o primeiro numero da lista: "))
ult_num = int(input("Diga o ultimo numero da lista: "))
intervalo = int(input("Diga o intervalo entre numero da lista: "))
print(criaLista(prim_num, ult_num, intervalo))
print(encrementaLista(criaLista(prim_num, ult_num, intervalo)))


