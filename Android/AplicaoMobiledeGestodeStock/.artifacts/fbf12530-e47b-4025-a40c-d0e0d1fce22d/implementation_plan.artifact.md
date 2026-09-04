# Implementation Plan - Aplicação de Gestão de Stock (Informática)

Desenvolvimento de uma aplicação Android completa para gestão de stock de uma loja de informática, seguindo a arquitetura MVVM e utilizando Room para persistência.

## User Review Required

> [!IMPORTANT]
> A aplicação utilizará o tema de **Loja de Informática**. As categorias sugeridas são: Hardware, Periféricos, Portáteis, Redes e Software.
> O idioma principal será o **Português**, conforme solicitado no enunciado.

## Proposed Changes

### Configuration & Dependencies

#### [MODIFY] [libs.versions.toml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/gradle/libs.versions.toml)
- Adicionar versões e bibliotecas para Room, Lifecycle (ViewModel, LiveData), DataStore e KSP.

#### [MODIFY] [build.gradle.kts (Project)](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/build.gradle.kts)
- Adicionar plugin KSP.

#### [MODIFY] [build.gradle.kts (App)](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/build.gradle.kts)
- Aplicar plugin KSP.
- Ativar ViewBinding.
- Adicionar as novas dependências.

---

### Data Layer

#### [NEW] [Produto.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/entity/Produto.kt)
- Entidade Room para o produto (id, nome, categoria, quantidade, preco, descricao, fornecedor).

#### [NEW] [Utilizador.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/entity/Utilizador.kt)
- Entidade Room para o utilizador (id, username, password, nome).

#### [NEW] [ProdutoDao.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/dao/ProdutoDao.kt)
- Operações CRUD para produtos, incluindo filtros e ordenação.

#### [NEW] [UtilizadorDao.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/dao/UtilizadorDao.kt)
- Operações de autenticação e inserção de utilizadores.

#### [NEW] [AppDatabase.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/database/AppDatabase.kt)
- Singleton da base de dados com `RoomDatabase.Callback` para inserir utilizadores padrão.

#### [NEW] [ProdutoRepository.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/repository/ProdutoRepository.kt)
- Abstração dos dados de produtos.

#### [NEW] [UtilizadorRepository.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/data/repository/UtilizadorRepository.kt)
- Abstração dos dados de utilizadores.

---

### Session Management

#### [NEW] [SessionManager.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/java/com/example/aplicaomobiledegestodestock/utils/SessionManager.kt)
- Gestão de sessão utilizando DataStore para persistir o utilizador logado.

---

### UI & ViewModels

#### [NEW] Splash Screen
- `SplashActivity.kt`: Lógica de animação e navegação.
- `activity_splash.xml`: Layout com logo e nome.

#### [NEW] Login
- `LoginActivity.kt`: Interface de autenticação.
- `LoginViewModel.kt`: Lógica de validação e login.
- `activity_login.xml`: Layout moderno MD3.

#### [NEW] Home (Dashboard)
- `HomeActivity.kt`: Menu principal com estatísticas.
- `HomeViewModel.kt`: Cálculo de totais e gestão de estado.
- `activity_home.xml`: Layout com Material Cards.

#### [NEW] Register/Edit Product
- `AddProductActivity.kt`: Formulário de inserção/edição.
- `AddProductViewModel.kt`: Validação e persistência.
- `activity_add_product.xml`: Layout com campos de texto e dropdown.

#### [NEW] Products List
- `ProductsActivity.kt`: Listagem, filtros e pesquisa.
- `ProductsViewModel.kt`: Gestão da lista de produtos.
- `ProductAdapter.kt`: RecyclerView Adapter com ViewHolder.
- `activity_products.xml`: Layout com RecyclerView e filtros.
- `item_product.xml`: Layout de cada item da lista.

---

### Resources

#### [MODIFY] [strings.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/res/values/strings.xml)
- Tradução e definição de todas as strings.

#### [MODIFY] [colors.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/res/values/colors.xml)
- Definição da paleta de cores Material 3.

#### [MODIFY] [themes.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaoMobiledeGestodeStock/app/src/main/res/values/themes.xml)
- Configuração do tema MD3.

---

## Verification Plan

### Automated Tests
- Build do projeto via Gradle para garantir que não existem erros de compilação.

### Manual Verification
- Testar fluxo completo: Splash -> Login (admin/password123) -> Home -> Add Product -> View Products -> Filter/Sort -> Logout.
- Verificar se a sessão persiste ao fechar e abrir a app.
- Verificar validações de campos vazios e números negativos.
- Verificar animações e design visual.
