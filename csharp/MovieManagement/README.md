# Movie Management

A **Movie Management** é uma aplicação desenvolvida em C# com base numa **Arquitetura em Camadas** (N-Tier Architecture), inversão de dependência com **Interfaces** e **Persistência de Dados** flexível. 

O projeto foi desenvolvido de forma incremental, utilizando o Git e o GitHub para o controlo de versões e histórico de evolução.

---

## 🏗️ Arquitetura do Sistema

A solução está dividida em 4 camadas independentes, garantindo a separação estrita de responsabilidades:

| Camada | Projeto | Responsabilidade |
| :--- | :--- | :--- |
| **UI** | `MovieManagement.UI` | Interação com o utilizador e apresentação (Consola). |
| **Business** | `MovieManagement.Business` | Implementação e validação de todas as regras de negócio. |
| **Data** | `MovieManagement.Data` | Camada de acesso aos dados e persistência. |
| **Domain** | `MovieManagement.Domain` | Definição das entidades do sistema e contratos (interfaces). |

> 💡 **Nota de Design:** Através do uso de interfaces, a arquitetura permite alternar o motor de persistência (Memória ⇄ SQLite) sem a necessidade de alterar as camadas de UI, Business ou Domain.

---

## 🛠️ Entidades e Funcionalidades

O sistema faz a gestão de três entidades principais com as respetivas operações obrigatórias:

### 1. Filmes (`Filme`)
* **Propriedades:** Id, Título, Ano, Língua, Classificação, CategoriaId, RealizadorId.
* **Operações:** Adicionar, Listar, Procurar por título e Remover.
* **Regras de Negócio:**
    * O título é obrigatório e não pode ser duplicado.
    * A classificação deve estar obrigatoriamente entre 0 e 5.
    * Antes de adicionar um filme, a Categoria e o Realizador associados têm de existir previamente (validação feita na camada *Business*).

### 2. Categorias (`Categoria`)
* **Propriedades:** Id, Nome.
* **Operações:** Adicionar, Listar, Procurar e Remover.
* **Regras de Negócio:** O nome é obrigatório e não são permitidas categorias duplicadas.

### 3. Realizadores (`Realizador`)
* **Propriedades:** Id, Nome, País.
* **Operações:** Adicionar, Listar, Procurar e Remover.
* **Regras de Negócio:** O nome e o país são de preenchimento obrigatório.

---

## 💾 Modos de Persistência

A aplicação foi desenhada para suportar dois repositórios de dados em simultâneo:
1. **Em Memória:** Armazenamento volátil baseado em coleções genéricas `List<T>`.
2. **SQLite:** Armazenamento persistente e relacional utilizando uma base de dados local SQLite.

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão compatível com C#).
* Um motor ou visualizador de SQLite (opcional, para inspecionar o ficheiro local).

### Passo a Passo
1. Clonar o repositório:
```bash
   git clone [https://github.com/teu-utilizador/MovieManagement.git](https://github.com/teu-utilizador/MovieManagement.git)
