from statistics import mean
from statistics import median
import statistics
import pandas as pd
import matplotlib.pyplot as plt


df = pd.read_csv('Q09_2.csv', encoding = 'unicode_escape', engine ='python') #Mostra os valores salvos. Mas nem sempre aparecem pelo tamanho da janela
def ImprimirBasedeDados(df): 
    return (df)
print(ImprimirBasedeDados(df))


#print(df.to_string()) #Mostra os dados todos, sem esconder algumas vozes
#print(pd.options.display.max_rows) #Mostra o numero de linhas a imprimir sem ocultar
#pd.options.display.max_rows = 9999 # Modifica o número anterior
#print(df.info()) #Mostra informação sobre o tipo de dados armazenados, incluindo valores Null


def Percentagem():
     x=input("Seleciona o País:") 
     a=df[x]
     b= a[0]
     for i in range(1,len(a)):
         print(round((a[i]/b)*100,2),"%")
 
def Media():
    df2= df.drop(['Zona'], axis=1)
    df['Média'] = df2.mean(axis=1)
    return(df["Média"])

def Mediana():
    df2= df.drop(['Zona'], axis=1)
    df['Mediana']=df2.median(axis=1)
    return(df["Mediana"])

def MaxMin():
    x=input("Seleciona o País:")
    maxi=df.loc[df[x].astype(float).idxmax()][{'Zona',x}]
    mini=df.loc[df[x].astype(float).idxmin()][{'Zona',x}]
    return(maxi,mini)



def GraficoNorte():

#pais_data = df["Zona"]
#colors = ["#1f77b4", "#ff7f0e", "#2ca02c", "#d62728", "#8c564b"]
#explode = (0.1, 0, 0, 0, 0, 0, 0, 0)  
#plt.pie(sizes, labels=pais_data, explode=explode, colors=colors, autopct='%1.1f%%', shadow=False, startangle=90)
#ax1.axis('equal')
#plt.rcParams.update({'font.size': 8})
#plt.title("População residente de nacionalidade estrangeira, total por sexo e principais nacionalidades")
#plt.show()
   
    labels = 'Brasil', 'Guiné Bissau', 'Angola', 'Cabo Verde', 'Reino Unido', 'Ucrânia', 'França', 'China',
    sizes = [48479, 659, 4302, 1867, 1387, 2623, 3980, 3592]
    explode = (0.1, 0, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
            shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()
    


def GraficoCentro():
    labels = 'Brasil', 'Guiné Bissau', 'Angola', 'Reino Unido', 'Cabo Verde', 'Ucrânia', 'China','França',
    sizes = [34120, 1214, 3890, 5262, 1296, 5467, 2281, 3440]
    explode = (0.1, 0, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
            shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()    
    
    
    
def GraficoAM_Lisboa():
    labels = 'Brasil', 'Reino Unido', 'Guiné Bissau', 'China', 'França', 'Angola', 'Cabo Verde', 'Ucrânia',
    sizes = [92321, 3906, 12296, 8014, 6695, 21571, 21887, 7138]
    explode = (0.1, 0, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
            shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()  
    
    
    
def GraficoAlentejo():
    labels = 'Brasil', 'Angola', 'Cabo Verde', 'Reino Unido', 'Ucrânia', 'França', 'China', 'Guiné Bissau'
    sizes = [8885, 910, 564, 963, 1840, 564, 1290, 228]
    explode = (0.1, 0, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
            shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()
        


def GraficoAlgarve():    
    labels = 'Brasil', 'Reino Unido', 'Angola', 'Cabo Verde', 'Ucrânia', 'Guiné Bissau', 'França', 'China',
    sizes = [14694, 12031, 767, 1376, 3914, 868, 4045, 1081]
    explode = (0.1, 0, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
            shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()
    



def GraficoRA_Acores():
    labels = 'Brasil', 'Angola', 'Cabo Verde', 'Reino Unido', 'Ucrânia', 'França', 'China', 'Guiné Bissau',
    sizes = [639, 56, 126, 157, 58, 130, 230, 10]
    explode = (0.1, 0, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
        shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()
    

def GraficoRA_Madeira():
    labels = 'Brasil', 'Reino Unido', 'Angola', 'Ucrânia', 'Guiné Bissau', 'China', 'Cabo Verde', 'França'
    sizes = [672, 903, 60, 159, 23, 143, 28, 210]
    explode = (0, 0.1, 0, 0, 0, 0, 0, 0)

    fig1, ax1 = plt.subplots()
    ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
            shadow=False, startangle=90)
    ax1.axis('equal')

    plt.rcParams.update({'font.size': 8})

    plt.show()
    

print("1. Máximo e Mínimo")
print("2. Média")
print("3. Percentagem")
print("4. Mediana")
print("5. Gráfico do Norte")
print("6. Gráfico do Centro")
print("7. Gráfico do AM Lisboa")
print("8. Gráfico do Alentejo")
print("9. Gráfico do Algarve")
print("10. Gráfico do RA Açores")
print("11. Gráfico do RA Madeira")

valido=True
while valido:
    opcao=(input("Qual é a opção que quer clicar: "))
    
    if(opcao == "1" or opcao == "2" or opcao == "3" or opcao == "4" or opcao == "5" or opcao == "6" or opcao == "7" or opcao == "8"or opcao == "9"or opcao == "10" or opcao == "11"):
        if opcao == "1":
            a=MaxMin()
            print(a[0].to_string(index=0))
            print(a[1].to_string(index=0))
        elif opcao == "2":
            print(Media())
        elif opcao == "3":
            print(Percentagem())
        elif opcao == "4":
            print(Mediana())
        elif opcao == "5":
            print(GraficoNorte())
        elif opcao == "6":
            print(GraficoCentro())
        elif opcao == "7":
            print(GraficoAM_Lisboa())
        elif opcao == "8":
            print(GraficoAlentejo())
        elif opcao == "9":
            print(GraficoAlgarve())
        elif opcao == "10":
            print(GraficoRA_Acores())
        elif opcao == "11":
            print(GraficoRA_Madeira())
        break
    else:
        print("Introduza novamente a opção que quer clicar.")

            
df.to_csv('Q09_2.csv',encoding='unicode_escape',index=False)            
df.to_excel('Q09_2.xls',encoding='unicode_escape',index=False) 
