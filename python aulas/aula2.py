euros = float(input('Diga a quantidade de euros que quer converter: '))
moeda = input('Qual é a moedas para a qual quer converter? ')

if moeda == 'dolar':
    taxaDolar = 0.98
    dolares = euros * taxaDolar
    print(euros, 'euros equivalem a ', dolares, ' dolares')

elif moeda == 'libra':
    taxaLibra = 1.16
    libras = euros * taxaLibra
    print(euros, 'euros equivalem a ', libras, ' libras')

else:
    print('Não é possivel fazer a converssão para essa moeda')

