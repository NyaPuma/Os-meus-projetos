import csv
import random

# Dicionário de organização de dias por mês
diasMes = {
    31 : [1,3,5,6,8,10,12],
    30 : [4,7,9,11]
}

# [dia, mes, ano]
data = [0,0,0]

selecoes = []
numJogo = [0]

continentes = {
    "America" : 0,
    "Europa" : 0,
    "Oceania" : 0,
    "Asia": 0,
    "Africa" : 0,
    "Antártida" : 0
}

golosMarcados = {}
golosSofridos = {}

equipasFase = {
    "oitavos" : [], 
    "quartos" : [], 
    "meias" : [], 
    "final" : []
}

jogosFase = {
    0 : [], 
    1 : [], 
    2 : [], 
    3 : []
}

def main():
    count = False
    try:
        with open("equipas.csv", 'r', encoding='utf-8') as equipas:
            reader = csv.reader(equipas)
            for row in reader:   
                if (count == True):
                    selecoes.append(row)
                count = True
    except FileNotFoundError:
        print("Aviso: Arquivo 'equipas.csv' não encontrado. Adicione seleções manualmente.")
    
    mainMenu()

def addSelecao():
    nome = input("Introduza o nome da seleção: ") 
    pais = input("Introduza o país da sua seleção: ")
    continente = input("Introduza o continente da seleção: ") 
    ranking = int(input("Introduza o ranking da seleção: "))
    selecoes.append([nome, pais, continente, ranking])

def remSelecao():
    selecaoRemovida = input("Qual equipa vai ser removida: ")
    for x in selecoes:
        if selecaoRemovida == x[0]:
            selecoes.remove(x)
            print(f"{selecaoRemovida} removida com sucesso.")
            break

def anoBissexto(ano):
    if((ano % 400 == 0) or (ano % 100 != 0) and (ano % 4 == 0)):  
        return True
    else:
        return False

def incrementarData(incremento):
    global data
    data[0] += incremento
    if((data[1] in diasMes.get(31, []) and data[0] > 31) or (data[1] in diasMes.get(30, []) and data[0] > 30)):
        data[0] = incremento
        data[1] += 1
    elif(data[1] == 2):
        limite = 29 if anoBissexto(data[2]) else 28
        if data[0] > limite:
            data[0] = incremento
            data[1] += 1
            
    if(data[1] > 12):
        data[1] = 1
        data[2] += 1
    return data

def randJogo(listaEquipa, fase):
    ret = []
    flipflop = False
    # Criar uma cópia para não destruir a lista original durante o sorteio
    equipas_disponiveis = listaEquipa.copy()
    
    while(len(equipas_disponiveis) >= 2):
        random.shuffle(equipas_disponiveis)
        
        hora = "16:00" if flipflop else "14:00"
        flipflop = not flipflop
        
        tempoUtil = int(90 * ((random.randrange(60, 70)/100)))
        
        casa = equipas_disponiveis.pop(0)
        fora = equipas_disponiveis.pop(0)
        
        resCasa = random.randint(0, 6)
        resFora = random.randint(0, 6)
        
        if(resCasa == resFora): # Empate não permitido em eliminatórias
            resFora += 1
            
        equipaApurada = casa if resCasa > resFora else fora
        ret.append(equipaApurada)
        
        adicionarGolosMarcados(casa[0], resCasa)
        adicionarGolosMarcados(fora[0], resFora)
        adicionarGolosSofridos(casa[0], resFora)
        adicionarGolosSofridos(fora[0], resCasa)
        
        numJogo[0] += 1
        jogosFase[fase].append([numJogo[0], casa[0], fora[0], data.copy(), hora, resCasa, resFora, tempoUtil, equipaApurada[0]])
        
        if(flipflop == False):
            incrementarData(1)
    return ret

def distContinente():
    for continente, contagem in continentes.items():
        print(f"{continente}: {contagem}") 

def updateContinente(selecoes_fase):
    for continente in continentes.keys():
        continentes[continente] = 0
    for selecao in selecoes_fase:
        for continente in continentes.keys():
            if (continente.lower() == selecao[2].lower()):
                continentes[continente] += 1

def checkMenuOption(toCheck, max_val):
    if(toCheck.isdigit()):
        ret = int(toCheck)
        if(ret >= 0 and ret < max_val):
            return ret
    print("\n!! Opção inválida !!\n")
    return -1

def apuramento():
    organiza = selecoes.copy()
    random.shuffle(organiza)
    ret = []
    
    # Prioridade para ranking <= 30
    for i in range(len(organiza) - 1, -1, -1):
        if len(ret) < 13 and int(organiza[i][3]) <= 30:
            ret.append(organiza.pop(i))
            
    # Preencher restante com sorteio aleatório
    while len(ret) < 16 and organiza:
        ret.append(organiza.pop(0))
    return ret

def printCalendario(fase, filtro):
    fases_nomes = ["Oitavos de Final", "Quartos de Final", "Meias de Final", "Final"]
    print(f"\n< {fases_nomes[fase]} >")
    
    encontrou = False
    for jogo in jogosFase[fase]:
        if(filtro == 0 or filtro == jogo[1] or filtro == jogo[2]):
            encontrou = True
            print(f"[{jogo[3][0]}/{jogo[3][1]}/{jogo[3][2]}] {jogo[4]} | {jogo[1]} {jogo[5]} - {jogo[6]} {jogo[2]} (Tempo Útil: {jogo[7]}min)")
    
    if not encontrou:
        print("!! Sem jogos registados para este filtro !!")

def validaData(aValidar):
    try:
        dia, mes, ano = int(aValidar[0]), int(aValidar[1]), int(aValidar[2])
    except:
        return False
        
    if(mes <= 12 and dia > 0 and mes > 0 and ano >= 0):
        if((mes in diasMes[31] and dia <= 31) or (mes in diasMes[30] and dia <= 30)):
            return True
        elif(mes == 2):
            limite = 29 if anoBissexto(ano) else 28
            return dia <= limite
    return False

def obterData():
    while True:
        dia = input("Introduza um dia: ")
        mes = input("Introduza um mês: ")
        ano = input("Introduza um ano: ")
        if(validaData([dia, mes, ano])):
            return [int(dia), int(mes), int(ano)]
        print("\n!! Data inválida !!")
        if input("(0 para cancelar, Enter para tentar de novo): ") == "0":
            return -1

def resDia(dia_alvo):       
    ret = []
    if(dia_alvo == -1): return ret
    for fase in jogosFase:
        for jogo in jogosFase[fase]:
            if(jogo[3] == dia_alvo):
                ret.append(jogo)
    return ret

def validaSelecao(selecao):
    for fase in jogosFase:
        for jogo in jogosFase[fase]:
            if(jogo[1] == selecao or jogo[2] == selecao):
                return True
    return False

def obterSeleção():
    while True:
        selecao = input("Introduza o nome de uma seleção: ")
        if(validaSelecao(selecao)):
            return selecao
        print("\n!! Seleção não encontrada no campeonato !!")
        if input("(0 para cancelar, Enter para tentar de novo): ") == "0":
            return -1

def limparCampeonato():
    numJogo[0] = 0
    for fase in jogosFase:
        jogosFase[fase] = []
    for c in continentes:
        continentes[c] = 0
    golosMarcados.clear()
    golosSofridos.clear()

def maisUtil(fase):
    if not jogosFase[fase]: return None
    return max(jogosFase[fase], key=lambda x: x[7])

def adicionarGolosSofridos(nome, golos):
    golosSofridos[nome] = golosSofridos.get(nome, 0) + golos

def adicionarGolosMarcados(nome, golos):
    golosMarcados[nome] = golosMarcados.get(nome, 0) + golos

def printDef():
    if not golosSofridos: return "Nenhum dado"
    min_golos = min(golosSofridos.values())
    melhores = [k for k, v in golosSofridos.items() if v == min_golos]
    return melhores

def printAtk():
    if not golosMarcados: return "Nenhum dado"
    max_golos = max(golosMarcados.values())
    melhores = [k for k, v in golosMarcados.items() if v == max_golos]
    return melhores

def menuGerirEquipa():
    while True:
        print("\n< Gerir Equipas >")
        print("0) Sair\n1) Adicionar Equipa\n2) Remover Equipa")
        opt = checkMenuOption(input(">? "), 3)
        if opt == 0: break
        elif opt == 1: addSelecao()
        elif opt == 2: remSelecao()

def menuSimulacoes(equipas, fase):
    if not equipas:
        limparCampeonato()
        return []
    
    if fase == 0:
        updateContinente(equipas)
        for x in equipas:
            golosMarcados[x[0]] = 0
            golosSofridos[x[0]] = 0
            
    fases_titulos = ["Oitavos de Final", "Quartos de Final", "Meias de Final", "Final"]
    vencedores = randJogo(equipas, fase)
    
    while True:
        print(f"\n< {fases_titulos[fase]} Simulação >")
        print("0) Sair\n1) Calendário/Resultados da Fase\n2) Equipas Apuradas\n3) Jogo com Mais Tempo Útil")
        if fase < 3: print("4) Seguir para a próxima Fase")
        
        opt = checkMenuOption(input(">? "), 5)
        if opt == 0: return []
        elif opt == 1: printCalendario(fase, 0)
        elif opt == 2: print(*[v[0] for v in vencedores], sep=", ")
        elif opt == 3: print(maisUtil(fase))
        elif opt == 4 and fase < 3:
            incrementarData(2)
            return vencedores
        elif fase == 3: # Se for a final, sai após mostrar resultados
            print("\nCampeonato Terminado!")
            input("Prima Enter para voltar ao menu principal...")
            return []

def menuEstatisticasCampeonato():
    if not jogosFase[0]:
        print("\n!! Simule um campeonato primeiro !!")
        return
        
    while True:
        print("\n< Estatísticas Campeonato >")
        print("0) Sair\n1) Calendário Completo\n2) Calendário da Seleção\n3) Resultados do Dia")
        print("4) Seleções por Continente\n5) Equipas Participantes\n6) Jogo > Tempo Útil Total")
        print("7) Melhor Defesa\n8) Melhor Ataque")
        
        opt = checkMenuOption(input(">? "), 9)
        if opt == 0: break
        elif opt == 1: 
            for i in range(4): printCalendario(i, 0)
        elif opt == 2:
            sel = obterSeleção()
            if sel != -1:
                for i in range(4): printCalendario(i, sel)
        elif opt == 3:
            print(resDia(obterData()))
        elif opt == 4: distContinente()
        elif opt == 5: print(*golosMarcados.keys(), sep=", ")
        elif opt == 6:
            todos_mais_uteis = [maisUtil(i) for i in range(4) if maisUtil(i)]
            if todos_mais_uteis:
                print(max(todos_mais_uteis, key=lambda x: x[7]))
        elif opt == 7: print(f"Equipa(s) com menos golos sofridos: {printDef()}")
        elif opt == 8: print(f"Equipa(s) com mais golos marcados: {printAtk()}")
        input("\n(Enter para continuar)")

def mainMenu():
    while True:
        print("\n< MENU PRINCIPAL >")
        print("0) Sair\n1) Gerir Seleções\n2) Simular Campeonato\n3) Estatísticas")
        opt = checkMenuOption(input(">? "), 4)
        if opt == 0: break
        elif opt == 1: menuGerirEquipa()
        elif opt == 2:
            limparCampeonato()
            dt = obterData()
            if dt != -1:
                data[0], data[1], data[2] = dt
                # Pipeline de fases
                res = apuramento()
                res = menuSimulacoes(res, 0)
                if res: res = menuSimulacoes(res, 1)
                if res: res = menuSimulacoes(res, 2)
                if res: menuSimulacoes(res, 3)
        elif opt == 3: menuEstatisticasCampeonato()

if __name__ == "__main__":
    main()
