"""
lado1=float(input("introduza a medida do primeiro lado do triangulo: "))
lado2=float(input("introduza a medida do segundo lado do triangulo: "))
lado3=float(input("introduza a medida do terceiro lado do triangulo: "))

if ((lado1+lado2)>lado3 and (lado1+lado3)>lado2 and (lado2+lado3)>lado1):

    print ("o triangulo é valido")

    if(lado1==lado2==lado3):
    
       print("o triangulo é equilatero" )
    
    elif (lado1==lado2 and lado1==lado3 and lado2==lado3):
        print ("o triangulo é isosceles")
        
    else:
        print ("o triangulo e escaleno")
    
"""
valido = True
while valido:
    dia = int(input("Diga o dia da semana: "))

    if (0<dia<8):
        if(dia == 1):
            print("domingo")
        elif(dia == 2):
            print("Segunda-feira")
        elif(dia == 3):
            print()
        elif(dia == 3):
            print()
        elif(dia == 4):
            print("Quarta")
        elif(dia == 5):
            print("Quinta")
        elif(dia == 6):
            print("Sexta")
        else:
            print("Sabado")
 


