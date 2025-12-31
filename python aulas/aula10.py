from math import sqrt
"""
num = int(input("Diga o numero a verificar: "))
limite = int(sqrt(num))+1
if num == 2:
    print(True)

elif(num % 2 == 0):
    print(False)    

else:
    for i in range(3, limite, 2):
        if(num % i == 0):
            print(False)
            break
        else:
            print(True)
"""

num = int(input("Verifica primo até: "))
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


