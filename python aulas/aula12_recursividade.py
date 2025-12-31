"""
def fact(num):
    if num == 0:
        return 1
    else:
        return num * fact(num-1)

num = int(input("Diga um numero: "))
print(fact(num))
"""


def potencia(num, pot):
    if num == 1:
        return 1
    elif pot == 0:
        return 1
    else:
        return num * potencia(num, pot-1)


num = int(input("Diga um numero: "))
pot = int(input("Diga um numero: "))
print(potencia(num, pot))
