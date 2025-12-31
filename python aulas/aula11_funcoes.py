"""
def imprimeNumero(numero):
    for i in range(1, numero+1):
        print(i)


numero = int(input("Nº"))
imprimeNumero(numero)
"""
from math import sqrt

num_max = int(input("Diga o numero maximo quer verificar: "))
num_min = int(input("Diga o numero minimo quer verificar: "))

def numeroPrimo(num):
    
    for j in range(2, num+1):
        limite = round(sqrt(j))+1
        if j == 2:
            print(2)

        elif(j % 2 == 0):
            continue

        else:
            for i in range(3, limite, 2):
                if(j % i == 0):
                    break
        
            else:
                print(j)    




def verPrimo(num):
    limite = int(sqrt(num))+1
    if num == 2:
        return(True)

    elif(num % 2 == 0):
        return(False)    

    else:
        for i in range(3, limite, 2):
            if(num % i == 0):
                return(False)
                break
        else:
            return(True)



for i in range(num_min, num_max+1):
    if(verPrimo(i)):
        print(i)