import array as arr

a = arr.array('i' , [1, 2, 3])
a.insert(1,4)

for i in a:
    print(a, end = " ")