x = [5, 8, 3, 2, 4, 24]

def ordenaLista(x):
    for i in range(len(x)):
        for j in range(i+1, len(x)):
            if x[j] > x[i]:
                temp = x[j]
                x[j] = x[i]
                x[i] = temp
    return x

