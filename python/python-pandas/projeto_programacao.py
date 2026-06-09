import pandas as pd
import matplotlib.pyplot as plt

# Load the data
try:
    df = pd.read_csv('day.csv')
except FileNotFoundError:
    print("Erro: O ficheiro 'day.csv' não foi encontrado.")
    exit()

def base_dados():
    return df

def mostrar_grafico():
    # Improved with a title and labels
    df.plot(kind='scatter', x='Numeric', y='Numeric-2', color='blue')
    plt.title('Relação entre Numeric e Numeric-2')
    plt.xlabel('Eixo X (Numeric)')
    plt.ylabel('Eixo Y (Numeric-2)')
    plt.grid(True)
    plt.show() 

def amostra(tipo='head'):
    qtd = int(input(f"Insira a quantidade de linhas ({tipo}): "))
    return df.head(qtd) if tipo == 'head' else df.tail(qtd)

# Statistics functions
def calc_stats(operacao):
    if operacao == 'media':
        return df["Numeric"].mean()
    elif operacao == 'mediana':
        return df["Numeric"].median()
    elif operacao == 'moda':
        return df["Numeric"].mode()[0]

menu = """
--- MENU DE DADOS ---
1. Visualizar base de dados inteira
2. Gráfico de Dispersão (Scatter)
3. Primeiras N linhas
4. Últimas N linhas
5. Média de 'Numeric'
6. Mediana de 'Numeric'
7. Moda de 'Numeric'
Escolha: """

try:
    escolha = int(input(menu))

    if escolha == 1:
        print(base_dados())
    elif escolha == 2:
        mostrar_grafico() # Não precisa de print
    elif escolha == 3:
        print(amostra('head'))
    elif escolha == 4:
        print(amostra('tail'))
    elif escolha == 5:
        print(f"Média: {calc_stats('media')}")
    elif escolha == 6:
        print(f"Mediana: {calc_stats('mediana')}")
    elif escolha == 7:
        print(f"Moda: {calc_stats('moda')}")
    else:
        print("Opção inválida!")

except ValueError:
    print("Erro: Por favor, insira apenas números.")
