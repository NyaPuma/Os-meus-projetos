# Explicação da Composição em Programação Orientada a Objetos

## Objetivo

Este projeto demonstra o conceito de **composição** em Programação Orientada a Objetos (POO), utilizando a linguagem **C#**.

O objetivo é compreender como uma classe pode **controlar totalmente o ciclo de vida de outra**, sendo responsável pela sua criação e gestão.

---

## Conceito abordado: Composição

A composição é uma relação forte entre classes onde uma classe **contém e gere objetos de outra classe**, assumindo a responsabilidade pela sua criação e destruição.

### Características da composição

- Existe uma relação forte entre classes  
- Uma classe “possui” outra classe  
- O ciclo de vida dos objetos dependentes é controlado pela classe principal  
- Se o objeto principal deixar de existir, os objetos dependentes também deixam de existir  
- Representa relações do tipo “parte de” (ex: funcionário → dependentes)

---


## Estrutura do projeto

O projeto contém duas classes principais:

---

### Classe `Dependente`

Representa um dependente de um funcionário.

**Atributos:**
- `Nome`
- `Idade`

**Construtor:**
- `Dependente(string nome, int idade)`

**Responsabilidade:**
Guardar os dados de cada dependente.

---

### Classe `Funcionario`

Representa um funcionário que pode ter dependentes.

**Atributos:**
- `Nome`
- `dependentes` (Lista de Dependente)

**Métodos:**
- `AdicionarDependente(string nome, int idade)`
- `ListarDependentes()`

**Responsabilidade:**
Gerir o funcionário e todos os seus dependentes.

---

## Porque este exemplo representa composição?

A classe `Funcionario` é responsável por criar e gerir os objetos do tipo `Dependente`.

```csharp
Dependente d = new Dependente(nome, idade);
dependentes.Add(d);
```

Neste caso:

✔ Os dependentes são criados dentro da classe Funcionario
✔ A lista de dependentes é controlada internamente
✔ Não existem dependentes fora do contexto do funcionário
✔ O ciclo de vida dos dependentes depende do funcionário
✔ Representa uma relação forte (composição)

---

## Execução do programa

O programa executa os seguintes passos:

1. Criação de um funcionário
2. Criação de dependentes através do funcionário
3. Armazenamento dos dependentes na lista interna
4. Listagem dos dependentes do funcionário

---

## Exemplo de saída

```text
Dependentes de Carlos
-Ana, 10 anos
-Pedro, 8 anos
```
---
O que este exemplo demostra:

✔ A classe principal controla totalmente os objetos associados
✔ Existe dependência estrutural forte entre classes
✔ O modelo aproxima-se mais de situações reais onde existe “posse” e dependência

---

Projeto desenvolvido para fins pedagógicos na aprendizagem de Programação Orientada a Objetos em C#.