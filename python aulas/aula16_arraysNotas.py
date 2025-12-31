import array as arr

def recebeNotas():
    notas = arr.array('d', [])
    n = int(input("quantas notas? "))
    for i in range(n):
        nota = int(input(f"Introduza a nota do aluno {i+1}: "))
        notas.append(nota)
    media = sum(notas)/len(notas)
    return media, notas

# print(notas)
x = recebeNotas()
print(x)
print("a media é: ", x[0])

for i in x[1]:
    print(i, end = " ")
print()
    
        
