import array as arr

def criaTabuada(n):
    tabuada = arr.array('i', [])
    for i in range(10):
        tabuada.append((i+1)*n)
    return tabuada


def printArr(array):
    for a in array:
        print(a)



def multTabuada(array):
    array = arr.array('d', array)
    for i in range(len(array)):
        array[i] = round(array[i] * 0.15, 2)

    return array

print(multTabuada(criaTabuada))