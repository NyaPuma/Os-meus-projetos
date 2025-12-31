"""
num = int(input('diga um numero: '))
resto = num % 3
if resto == 0:
    num = num + 1
    print(num)
"""



salario = float(input('diga o salario: '))
min = 700
taxa = (salario - min) * 0.035
if salario > min:
    novoSalario = salario + taxa
    print(novoSalario)
