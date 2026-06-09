# Explicação da Agregação em Programação Orientada a Objetos

## Objetivo

Este projeto demonstra o conceito de **agregação** em Programação Orientada a Objetos (POO), utilizando a linguagem **C#**.

Pretende-se compreender como uma classe pode **agregar (conter) múltiplos objetos de outra classe**, mantendo-os como entidades independentes.

---

## Conceito abordado: Agregação

A agregação é uma relação entre classes onde uma classe contém uma coleção de objetos de outra classe, mas esses objetos **existem de forma independente**.

---

### Características da agregação

- Relação do tipo “tem muitos” (has-a)
- Os objetos agregados existem independentemente
- A classe principal apenas referencia os objetos
- Pode haver partilha de objetos entre diferentes classes
- Representa relações flexíveis no sistema

---


## Estrutura do projeto

O projeto contém duas classes principais:

---

### Classe `Estudante`

Representa um estudante no sistema.

**Atributos:**
- `Nome`
- `Numero`

**Responsabilidade:**
Armazenar os dados do estudante.

Importante:  
O estudante existe independentemente da disciplina.

---

### Classe `Disciplina`

Representa uma disciplina que pode conter vários estudantes.

**Atributos:**
- `Nome`
- `List<Estudante> Estudantes`

**Métodos:**
- `AdicionarEstudante(Estudante e)`

**Responsabilidade:**
Gerir a lista de estudantes inscritos na disciplina.

## Como funciona a agregação neste exemplo?

A classe `Disciplina` contém uma lista de objetos do tipo `Estudante`.

```csharp
public List<Estudante> Estudantes { get; set; }
```

Neste caso:

✔ A disciplina agrega vários estudantes
✔ Os estudantes existem fora da disciplina
✔ Um estudante pode existir sem estar inscrito em nenhuma disciplina
✔ Os objetos são criados independentemente e depois associados

Isto caracteriza uma **relação de agregação**.

---

## Execução do programa

O programa executa os seguintes passos:

1. Criação de estudantes (independentes)
2. Criação de uma disciplina
3. Adição dos estudantes à disciplina
4. Listagem dos estudantes inscritos
5. Apresentação dos dados no ecrã

---

## Exemplo de saída

```text
Disciplina: Programação tem 2 alunos inscritos:
Ana, nº 1
Bruno, nº 2
```
---
O que este exemplo demostra:

✔ Os estudantes existem antes da disciplina
✔ A disciplina apenas referencia os estudantes
✔ Os objetos não dependem da existência da disciplina
✔ É possível reutilizar estudantes noutras disciplinas
---

Projeto desenvolvido para fins pedagógicos na aprendizagem de Programação Orientada a Objetos em C#.