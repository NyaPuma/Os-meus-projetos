num = int(input("diz um numero: "))

def reverse(num):
    num_rev = " "
    while(num > 0):
        num_rev = num_rev + str(num%10)
        num = num // 10

    return(int(num_rev))    


print(reverse(num))


def reverseFunc(num: int):
    if(num <= 0):
        print("Numero nao valido. Introduza um inteiro positivo")
        return(-1)
    else:
        val = ""
        while num != 0:
            resto = int()
