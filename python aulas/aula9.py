
"""
f = int(input("Numero que que usar: "))

n = 1
for i in range(1,f+1):
    n *= i
    print(n)
"""

soma = 0
impar = 0

ni = int(input("diga o primeiro numero: "))
nf = int(input("diga o segundo numero: "))

if ni > nf:
    temp = ni
    ni = nf
    nf = temp

if not(ni % 2):
    ni += 1

for i in range(ni, nf+1, 2):
        impar += 1
        soma += 1
        ni += 2

print(impar)
print(soma)