# Refatoração de Utilizadores para Alunos

Este plano descreve a migração do sistema de gestão de utilizadores para um sistema de gestão de alunos, incluindo a atualização de campos (Nome, Curso, Cidade) e a renomeação de componentes para manter a consistência.

## User Review Required

> [!IMPORTANT]
> A base de dados será migrada. Como o esquema mudará significativamente (removendo `username`/`password` e adicionando `nome`/`curso`/`cidade`), utilizaremos `fallbackToDestructiveMigration()` para simplificar o processo, o que apagará os dados existentes.

## Proposed Changes

### Data Layer

#### [MODIFY] [AlunoModel.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserModel.kt) (Renomear de UserModel.kt)
- Renomear classe para `AlunoModel`.
- Alterar campos para: `id` (PK), `nome`, `curso`, `cidade`.

#### [MODIFY] [AlunoDao.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserDao.kt) (Renomear de UserDao.kt)
- Renomear interface para `AlunoDao`.
- Atualizar métodos para operar com `AlunoModel`.

#### [MODIFY] [AppDatabase.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserDatabase.kt) (Renomear de UserDatabase.kt)
- Renomear classe para `AppDatabase`.
- Atualizar entidade para `AlunoModel`.

#### [MODIFY] [AlunoRepository.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserRepository.kt) (Renomear de UserRepository.kt)
- Renomear classe para `AlunoRepository`.
- Atualizar dependência para `AlunoDao`.

---

### Logic Layer

#### [MODIFY] [AlunoViewModel.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserViewModel.kt) (Renomear de UserViewModel.kt)
- Renomear classe para `AlunoViewModel`.
- Atualizar para usar `AlunoRepository` e `AlunoModel`.

---

### UI Layer

#### [MODIFY] [activity_main.xml](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/res/layout/activity_main.xml)
- Alterar inputs:
  - `edit_username` -> `edit_nome`
  - `edit_password` -> `edit_curso`
  - Adicionar `edit_cidade`

#### [MODIFY] [item_aluno.xml](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/res/layout/item_utilizador.xml) (Renomear de item_utilizador.xml)
- Atualizar TextViews para exibir Nome, Curso e Cidade.

#### [MODIFY] [AlunoAdapter.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserAdapter.kt) (Renomear de UserAdapter.kt)
- Renomear para `AlunoAdapter`.
- Atualizar ViewHolder para refletir os novos campos do aluno.

#### [MODIFY] [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/MainActivity.kt)
- Atualizar referências para `AlunoViewModel`.
- Atualizar lógica de captura de dados (3 campos em vez de 2).
- Atualizar `prepareEdit` e `handleSave`.

## Verification Plan

### Automated Tests
- Executar build do projeto (`gradlew assembleDebug`) para garantir que todas as referências foram atualizadas corretamente.

### Manual Verification
- Inserir um aluno com Nome, Curso e Cidade.
- Verificar se o aluno aparece na lista corretamente.
- Editar um aluno existente e verificar se a cidade e o curso são atualizados.
- Eliminar um aluno.
