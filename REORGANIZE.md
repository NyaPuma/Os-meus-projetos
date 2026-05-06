# 🔧 Instruções para Reorganizar o Repositório

**Objetivo**: Reorganizar o repositório para uma estrutura mais profissional.
**Branch**: `refactor-organization`

---

## 📌 Passos a Seguir

### 1️⃣ Clona o repositório (se ainda não o tens localmente)
```bash
git clone https://github.com/NyaPuma/Os-meus-projetos.git
cd Os-meus-projetos
```

### 2️⃣ Muda para a branch `refactor-organization`
```bash
git checkout refactor-organization
```

### 3️⃣ Executa os comandos abaixo para reorganizar as pastas
*(Copia e cola cada bloco no Git Bash ou terminal)*

#### Criar a nova estrutura de pastas
```bash
mkdir -p exercicios/algoritmos
mkdir -p exercicios/bases-de-dados
mkdir -p exercicios/analise-dados/python-pandas
mkdir -p formacao/python/aulas
mkdir -p linguagens/csharp
mkdir -p projetos/embarcados/microcontroladores
mkdir -p projetos/modelacao-3d/solidworks-secretaria
mkdir -p projetos/modelacao-3d/solidworks-pecas-mecanicas
mkdir -p projetos/modelacao-3d/autodesk-fusion
mkdir -p projetos/visao-computacional/deteccao-bordas-python
mkdir -p projetos/cnc-torno
mkdir -p projetos/web/laranja-miau
mkdir -p projetos/web/teste-animacoes
```

#### Mover os ficheiros para as novas pastas
```bash
# Algoritmos
mv "Algoritmos Exercicios"/* exercicios/algoritmos/

# Bases de Dados
mv "Base de dados Exercicios"/* exercicios/bases-de-dados/

# Análise de Dados
mv "csv python with pandas - imcomplete"/* exercicios/analise-dados/python-pandas/

# Formação Python
mv "python aulas"/* formacao/python/aulas/

# Linguagens C#
mv "C#"/* linguagens/csharp/

# Projetos Embarcados
mv "Microcontroladores - Microship Studio"/* projetos/embarcados/microcontroladores/

# Modelação 3D
mv "Projeto SolidWorks - Secretaria"/* projetos/modelacao-3d/solidworks-secretaria/
mv "Projeto SolidWorks - peças mecanicas"/* projetos/modelacao-3d/solidworks-pecas-mecanicas/
mv "Geometrias básicas - Autodesk Fusion"/* projetos/modelacao-3d/autodesk-fusion/

# Visão Computacional
mv "Visão Industrial - deteta bordas dos objetos usando cores (Python)"/* projetos/visao-computacional/deteccao-bordas-python/

# CNC
mv "CNC - Torno"/* projetos/cnc-torno/

# Web
mv "Laranja Miau - Website"/* projetos/web/laranja-miau/
mv "Teste de animações - Website"/* projetos/web/teste-animacoes/
```

#### Remover as pastas antigas (após verificar que tudo foi movido)
```bash
rmdir "Algoritmos Exercicios"
rmdir "Base de dados Exercicios"
rmdir "csv python with pandas - imcomplete"
rmdir "python aulas"
rmdir "C#"
rmdir "Microcontroladores - Microship Studio"
rmdir "Projeto SolidWorks - Secretaria"
rmdir "Projeto SolidWorks - peças mecanicas"
rmdir "Geometrias básicas - Autodesk Fusion"
rmdir "Visão Industrial - deteta bordas dos objetos usando cores (Python)"
rmdir "CNC - Torno"
rmdir "Laranja Miau - Website"
rmdir "Teste de animações - Website"
```

### 4️⃣ Faz commit e push para a branch `refactor-organization`
```bash
git add .
git commit -m "feat: reorganize repository structure"
git push origin refactor-organization
```

---

## 🎯 O que este script faz?
- **Cria a nova estrutura de pastas** (ex: `exercicios/algoritmos`, `projetos/web/laranja-miau`).
- **Move os ficheiros** das pastas antigas para as novas localizações.
- **Remove as pastas antigas** (apenas se estiverem vazias).
- **Preserva todos os ficheiros**, incluindo os links do Figma.

---

## ⚠️ Notas Importantes
1. **Faz um backup** do teu repositório local antes de executar os comandos.
2. **Verifica** que todos os ficheiros foram movidos corretamente antes de fazer `git add .`.
3. Se alguma pasta não estiver vazia (ex: ficheiros ocultos), remove manualmente.

---

## 📩 Próximos Passos
1. **Executa os comandos** acima no teu terminal (Git Bash ou Linux/macOS).
2. **Faz push** para a branch `refactor-organization`.
3. **Vou criar um Pull Request** para a branch `main`.
4. **Aprova o Pull Request** no GitHub.

---

## 🔗 Links Úteis
- [Ver a branch `refactor-organization`](https://github.com/NyaPuma/Os-meus-projetos/tree/refactor-organization)
- [Abrir um Pull Request](https://github.com/NyaPuma/Os-meus-projetos/pulls)
