# Correção Geral do Projeto Retrofit

Este plano detalha as correções necessárias para resolver os erros de build e de lógica no código fonte do projeto.

## Mudanças Propostas

### 1. Configuração de Build

#### [MODIFY] [libs.versions.toml](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/gradle/libs.versions.toml)
- Adicionar versões ausentes para `retrofit`, `okhttp`, `coroutines` e `moshi`.
- Corrigir as referências de bibliotecas que usam essas versões.

#### [MODIFY] [build.gradle.kts (app)](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/build.gradle.kts)
- Corrigir a declaração de `compileSdk` para o formato padrão.
- Garantir que `viewBinding` esteja ativado corretamente.

### 2. Manifesto

#### [MODIFY] [AndroidManifest.xml](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/src/main/AndroidManifest.xml)
- Mover a permissão de INTERNET para fora da tag `<application>`.

### 3. Código Fonte

#### [MODIFY] [RetrofitClient.kt](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/src/main/java/com/example/retrofit/RetrofitClient.kt)
- Corrigir erros de digitação (ex: `HttpLogginInterceptor` -> `HttpLoggingInterceptor`).
- Corrigir o uso de classes com letra minúscula (`moshi.builder` -> `Moshi.Builder`).
- Corrigir chamadas de métodos e fábricas (`moshiConverterFactory` -> `MoshiConverterFactory`).

#### [MODIFY] [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/src/main/java/com/example/retrofit/MainActivity.kt)
- Inicializar corretamente o `ActivityMainBinding`.
- Mover a função `caregarPosts` para fora do `onCreate`.
- Usar `lifecycleScope.launch` para chamar a API (que é `suspend`).
- Corrigir a sintaxe do `joinToString` e do bloco `try-catch`.

## Plano de Verificação

### Testes Automatizados
- Executar `./gradlew assembleDebug` para garantir que o projeto compila sem erros.

### Verificação Manual
- O usuário deve testar o aplicativo para garantir que os posts estão sendo carregados e exibidos corretamente na tela.
