import pandas as pd
import matplotlib.pyplot as plt

# 1. Load Data
try:
    df = pd.read_csv('Q09_2.csv', encoding='unicode_escape', engine='python')
except FileNotFoundError:
    print("Error: File 'Q09_2.csv' not found.")
    exit()

def get_numeric_df():
    """Returns the dataframe without the 'Zona' column for calculations."""
    return df.drop(['Zona'], axis=1)

def Percentagem():
    x = input("Seleciona o País (Coluna): ")
    if x in df.columns:
        col = df[x]
        base_val = col.iloc[0]
        for val in col:
            print(f"{round((val / base_val) * 100, 2)}%")
    else:
        print("Coluna não encontrada.")

def CalcularEstatisticas(tipo="media"):
    df_num = get_numeric_df()
    if tipo == "media":
        df['Média'] = df_num.mean(axis=1)
        return df['Média']
    else:
        df['Mediana'] = df_num.median(axis=1)
        return df['Mediana']

def MaxMin():
    x = input("Seleciona o País: ")
    if x in df.columns:
        maxi = df.loc[df[x].astype(float).idxmax()][['Zona', x]]
        mini = df.loc[df[x].astype(float).idxmin()][['Zona', x]]
        return maxi, mini
    return "Erro", "Coluna Inválida"

def GerarGrafico(titulo, labels, sizes, explode_idx=0):
    explode = [0] * len(labels)
    explode[explode_idx] = 0.1
    
    fig, ax = plt.subplots()
    ax.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%', startangle=90)
    ax.axis('equal')
    plt.title(titulo)
    plt.tight_layout()
    plt.show()

# --- Menu Logic ---
menu = """
1. Máximo e Mínimo    2. Média             3. Percentagem
4. Mediana            5. Gráfico Norte     6. Gráfico Centro
7. Gráfico Lisboa     8. Gráfico Alentejo  9. Gráfico Algarve
10. Gráfico Açores    11. Gráfico Madeira
"""

print(menu)

while True:
    opcao = input("Escolha uma opção (1-11): ")
    
    if opcao == "1":
        mx, mn = MaxMin()
        print(f"Máximo:\n{mx}\nMínimo:\n{mn}")
    elif opcao == "2":
        print(CalcularEstatisticas("media"))
    elif opcao == "3":
        Percentagem()
    elif opcao == "4":
        print(CalcularEstatisticas("mediana"))
    elif opcao in [str(i) for i in range(5, 12)]:
        # Example data mapping for charts
        charts_data = {
            "5": ("Norte", ['Brasil', 'Guiné Bissau', 'Angola', 'Cabo Verde', 'Reino Unido', 'Ucrânia', 'França', 'China'], [48479, 659, 4302, 1867, 1387, 2623, 3980, 3592]),
            "9": ("Algarve", ['Brasil', 'Reino Unido', 'Angola', 'Cabo Verde', 'Ucrânia', 'Guiné Bissau', 'França', 'China'], [14694, 12031, 767, 1376, 3914, 868, 4045, 1081])
            # Add other mappings here...
        }
        if opcao in charts_data:
            data = charts_data[opcao]
            GerarGrafico(data[0], data[1], data[2])
        else:
            print("Dados do gráfico ainda não configurados no dicionário.")
    else:
        print("Opção inválida.")
        continue
    break

# Save updates
df.to_csv('Q09_2_updated.csv', index=False)
