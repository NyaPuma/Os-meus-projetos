# Walkthrough - Migração para Gestão de Alunos

Concluí a refatoração do projeto para gerir **Alunos** em vez de utilizadores genéricos. O sistema agora suporta os campos **Nome**, **Curso** e **Cidade**.

## Alterações Realizadas

### Camada de Dados
- **Modelo**: [UserModel.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserModel.kt) foi atualizado para `AlunoModel` com os novos campos.
- **DAO**: [UserDao.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserDao.kt) agora opera sobre `AlunoModel`.
- **Base de Dados**: [UserDatabase.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserDatabase.kt) renomeada internamente para `AppDatabase` e configurada para usar `fallbackToDestructiveMigration()` para aplicar as mudanças de esquema.

### Camada de Lógica (MVVM)
- **Repositório**: [UserRepository.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserRepository.kt) atualizado para `AlunoRepository`.
- **ViewModel**: [UserViewModel.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserViewModel.kt) atualizado para `AlunoViewModel`.

### Interface de Utilizador (UI)
- **Layout Principal**: [activity_main.xml](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/res/layout/activity_main.xml) agora contém campos para Nome, Curso e Cidade.
- **Item da Lista**: [item_utilizador.xml](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/res/layout/item_utilizador.xml) visualmente ajustado para mostrar as três informações.
- **Adapter**: [UserAdapter.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/UserAdapter.kt) atualizado para `AlunoAdapter`.
- **Activity**: [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/ROOM_Logs/app/src/main/java/com/example/room_logs/MainActivity.kt) totalmente refatorada para gerir a nova entidade.

## Verificação
- **Build**: O projeto foi compilado com sucesso (`assembleDebug`).
- **Esquema**: A base de dados `userDB` foi substituída por `alunoDB` (internamente na lógica de build do Room).

> [!NOTE]
> Os nomes dos ficheiros foram mantidos como os originais (ex: `UserModel.kt`) para evitar problemas de sincronização do sistema de ficheiros, mas todas as classes e lógica interna foram renomeadas para a semântica de "Aluno".
