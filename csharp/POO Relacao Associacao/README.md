# Explicação da Associação em Programação Orientada a Objetos

## Objetivo

Este projeto demonstra o conceito de **associação** em Programação Orientada a Objetos (POO), utilizando a linguagem **C#**.

Pretende-se compreender como duas classes podem estar ligadas através de objetos, onde uma classe mantém uma referência permanente a outra.

---

## Conceito abordado: Associação

A associação é uma relação estrutural entre classes onde existe uma ligação **estável e permanente** entre objetos.

### Características da associação

- Existe uma ligação entre objetos de classes diferentes  
- Um objeto pode conter referência a outro objeto  
- A relação é duradoura enquanto o objeto existir  
- Permite modelar relações do mundo real (ex: cliente → conta bancária)

---

## Estrutura do projeto

O projeto contém duas classes principais:

---

### Classe `Cliente`

Representa um cliente do sistema bancário.

**Atributos:**
- `Nome`
- `NIF`
- `Telefone`

**Responsabilidade:**
Armazenar os dados pessoais do cliente.

---

### Classe `ContaCorrente`

Representa uma conta bancária associada a um cliente.

**Atributos:**
- `Titular` (Cliente)
- `Agencia`
- `Numero`
- `Saldo`

**Métodos:**
- `Depositar(double valor)`
- `Levantar(double valor)`

**Responsabilidade:**
Gerir operações bancárias associadas ao cliente.

---

## Porque este exemplo representa associação?

A classe `ContaCorrente` mantém uma referência direta a um objeto do tipo `Cliente`.

```csharp
conta1.Titular = cliente1;
```

Neste caso:

✔A conta "conhece" o cliente associado
✔O cliente existe independentemente da conta
✔A relação é permanente enquanto o objeto existir
✔Ambos partilham o mesmo objeto em memória

Isto caracteriza uma **relação de associação**.

---

## Execução do programa

O programa executa os seguintes passos:

1. Criação de uma conta bancária
2. Criação de um cliente
3. Associação do cliente à conta
4. Acesso aos dados através da conta
5. Modificação do nome do cliente através da conta
6. Verificação de que a alteração afeta o objeto original

---

## Exemplo de saída

```text
João
João
Maria
```

---

Projeto desenvolvido para fins pedagógicos na aprendizagem de Programação Orientada a Objetos em C#.