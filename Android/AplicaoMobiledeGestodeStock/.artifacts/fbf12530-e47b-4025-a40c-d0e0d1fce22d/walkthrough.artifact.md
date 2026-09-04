# Walkthrough - Stock Informática

Aplicação completa de gestão de stock para uma loja de informática, desenvolvida com Kotlin, Room, MVVM e Material Design 3.

## Funcionalidades Implementadas

### 1. Sistema de Dados (Room)
- **Entidades**: `Utilizador` (para login) e `Produto` (para o inventário).
- **DAOs**: Operações CRUD completas, incluindo filtros por categoria e pesquisa por nome.
- **Base de Dados**: Singleton `AppDatabase` com pre-população automática de utilizadores (`admin`, `cesae`, `cesae_aluno`).

### 2. Gestão de Sessão
- Implementada com **Jetpack DataStore** para persistir o login do utilizador de forma segura e eficiente.

### 3. Interface (Material Design 3)
- **Splash Screen**: Com animação de fade-in e lógica de encaminhamento (Login ou Home).
- **Login**: Ecrã moderno com validação de campos e autenticação na base de dados local.
- **Dashboard**: Cartões informativos com o total de produtos e stock global, além de boas-vindas personalizadas.
- **Registo de Produto**: Formulário completo com validações (preço > 0, quantidade >= 0) e dropdown de categorias.
- **Consulta de Stock**:
    - `RecyclerView` com `ListAdapter` para atualizações de lista eficientes.
    - Filtros por categoria através de Chips.
    - Pesquisa em tempo real.
    - Ordenação por stock (Crescente/Decrescente).
    - Indicador visual de **Stock Baixo** (menos de 5 unidades).

## Arquitetura
- **MVVM**: Separação total da lógica de negócio da UI.
- **Repository Pattern**: Centralização do acesso aos dados.
- **View Binding & Data Binding**: Código de UI limpo e tipado.

## Verificação Técnica
- [x] Compilação sem erros (`./gradlew app:assembleDebug`).
- [x] AndroidX e Jetifier configurados.
- [x] KSP utilizado para o processamento do Room.

> [!TIP]
> **Credenciais de Teste:**
> - Username: `admin` | Password: `password123`
> - Username: `cesae` | Password: `cesae`
