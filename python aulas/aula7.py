num = 1
conta = 0


while True:
    num = int(input("Diga um numero: "))
    if num < 0:
        break

    if num >= 0:
        if num % 2 == 0:
            conta = conta + 1     

print("A quantidade de numeros pares é %d" %conta)



