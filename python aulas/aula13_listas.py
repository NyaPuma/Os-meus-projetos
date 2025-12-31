"""
lista = [10,11,15,13,18,12,17]
# sort -> ordena a lista por ordem crecente
# sort(reverse=True) -> ordena a lista por ordem decrescente
lista.sort()
print(lista)
print(lista[:3])
"""


lista = []
for i in range(100, 200, 10):
    lista.append(i)
print(lista)

for i in range(len(lista)):
    lista[i] = lista[i] + 10
print(lista)

