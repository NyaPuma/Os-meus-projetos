"""
consumo = float(input("Qual é o seu consumo: "))

taxa_iva = 1.23
valido = True
while valido:
    tipo_cliente = (input("Que tipo de cliente é: "))
    if tipo_cliente == "PC" or tipo_cliente == "PI" or tipo_cliente == "PE" or tipo_cliente == "MG" or tipo_cliente == "EOP":
        if tipo_cliente == "PC":
            fatura_mensal = consumo * 0.1865 * taxa_iva
            print(fatura_mensal)
        elif tipo_cliente == "PI":
            fatura_mensal = consumo * 0.1875 * taxa_iva
            print(fatura_mensal)
        elif tipo_cliente == "PE":
            fatura_mensal = consumo * 0.1754 * taxa_iva
            print(fatura_mensal)
        elif tipo_cliente == "MG":
            fatura_mensal = consumo * 0.1592 * taxa_iva
            print(fatura_mensal)
        elif tipo_cliente == "EOP":
            fatura_mensal = consumo * 0.1311 * taxa_iva
            print(fatura_mensal)
        break
    else:
        print("Valor nao existe")
"""


nome = ""
idade = 0
continuar = ""

while continuar != "STOP":
    nome_novo = input("Diz um novo nome: ")
    idade_nova = int(input("diz a idade nova: "))
    continuar = nome_novo.upper()
    if idade_nova >= idade and continuar != "STOP":
        idade = idade_nova
        nome = nome_novo 
print("o %s é o aluno mais velho com %d anos" %(nome, idade))





