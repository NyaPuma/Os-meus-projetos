# Explicação Dependência em Programação Orientada a Objetos

## Objetivo

Este projeto demonstra o conceito de **dependência** em Programação Orientada a Objetos (POO), utilizando a linguagem **C#**.

Pretende-se mostrar como uma classe pode utilizar temporariamente outra classe para executar uma tarefa, sem manter uma relação permanente entre os objetos.

---

## Conceito abordado: Dependência

A dependência é um tipo de relacionamento entre classes onde uma classe necessita temporariamente de outra para executar uma operação.

### Características da dependência

- Uso temporário de outro objeto
- Normalmente ocorre através de parâmetros de métodos
- Não existe ligação permanente entre os objetos
- Não há armazenamento de referência ao objeto utilizado

---

## Estrutura do projeto

O projeto contém duas classes principais:

### `Funcionario`

Representa um funcionário da empresa.

**Atributos:**

- `Nome`
- `Salario`

**Responsabilidade:**

Armazenar os dados do funcionário.

---

### `RelatorioService`

Responsável por gerar relatórios.

**Atributo:**

- `Conteudo`

**Método principal:**

- `GerarRelatorio(Funcionario funcionario)`

**Responsabilidade:**

Receber temporariamente um objeto `Funcionario`, processar a informação e gerar um relatório.

---

## Porque este exemplo representa dependência?

A classe `RelatorioService` depende temporariamente da classe `Funcionario`.

Exemplo:

```csharp
public void GerarRelatorio(Funcionario funcionario)
```

Neste caso:

✔ O objeto `Funcionario` é recebido como parâmetro  
✔ É utilizado apenas durante a execução do método  
✔ Não é armazenado como atributo da classe  

Isto caracteriza uma **relação de dependência**.

---

## Execução do programa

O programa:

1. Cria dois funcionários
2. Cria dois serviços de relatório
3. Gera relatórios para cada funcionário

---

## Exemplo de saída

```text
Relatorio do Funcionario
Nome: Antonio Lopes | Salario: 1345,50

Relatorio do Funcionario
Nome: Carlota Pires | Salario: 1400,00
```

---

Projeto desenvolvido para fins pedagógicos na aprendizagem de Programação Orientada a Objetos em C#.