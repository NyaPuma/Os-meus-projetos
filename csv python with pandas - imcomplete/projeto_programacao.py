import pandas as pd

import matplotlib.pyplot as plt

df = pd.read_csv('day.csv')

escolha = int(input("Para visualizar base dados inteira escolha 1\nPara visualizar o grafico com numeric e numeric-2 escolha 2\nPara amostrar os primeiros numeros da base de dados escolha 3\nPara amostrar os ultimos numeros da base de dados escolha 4\nPara a média dos numéricos escolha 5\nPara a mediana dos numéricos escolha 6\nPara a moda dos numéricos escolha 7:"))

def basedados():
    return(df)

def grafico():
    df.plot(kind = 'scatter', x = 'Numeric', y = 'Numeric-2')
    return plt.show()
    
def primnum():
    x = int(input("Insire a quantidade dos primeiros numeros que quer:"))
    return(df.head(x))

def ultnum():
    y = int(input("Insire a quantidade dos ultimos numeros que quer:"))
    return(df.tail(y))

def media():
    a = df["Numeric"].mean()
    return a

def mediana():
    b = df["Numeric"].median()
    return b

def moda():
    c = df["Numeric"].mode()[0]
    return c

if escolha == 1:
    print(basedados())

elif escolha == 2:
    print(grafico())
    
elif escolha == 3:
    print(primnum())
    
elif escolha == 4:
    print(ultnum())
    
elif escolha == 5:
    print(media())
    
elif escolha == 6:
    print(mediana())

elif escolha == 7:
    print(moda())
       
else:
    print("Erro!, por favor insira um valor valido.")