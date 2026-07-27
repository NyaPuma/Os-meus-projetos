# Walkthrough - Correção do Projeto Retrofit

Todas as falhas de build e erros de lógica foram corrigidos. O projeto agora compila e está pronto para uso.

## Mudanças Realizadas

### Configuração e Build
- **[libs.versions.toml](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/gradle/libs.versions.toml)**: Adicionadas versões estáveis para Retrofit (2.9.0), OkHttp (4.12.0), Coroutines (1.8.0) e Moshi (1.15.0).
- **[build.gradle.kts (app)](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/build.gradle.kts)**: Atualizado `compileSdk` para 36 para compatibilidade com as bibliotecas AndroidX e corrigida a sintaxe de declaração.
- **[AndroidManifest.xml](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/src/main/AndroidManifest.xml)**: Permissão `INTERNET` movida para o local correto (fora da tag `<application>`).

### Refatoração de Código
- **[RetrofitClient.kt](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/src/main/java/com/example/retrofit/RetrofitClient.kt)**:
    - Corrigidos typos (`HttpLogginInterceptor` -> `HttpLoggingInterceptor`).
    - Corrigido uso de classes (`Moshi.Builder()`, `Retrofit.Builder()`).
    - Configurado `Moshi` com `KotlinJsonAdapterFactory`.
- **[MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/retrofit/app/src/main/java/com/example/retrofit/MainActivity.kt)**:
    - Implementado `ViewBinding` para acesso seguro aos componentes da UI.
    - Função `carregarPosts` movida para o escopo correto da classe.
    - Chamada da API agora utiliza `lifecycleScope.launch` por ser uma função suspensa.
    - Corrigida a lógica de exibição dos posts com `joinToString`.

## Verificação
- O build foi executado com sucesso através do comando `./gradlew assembleDebug`.
- Sincronização do Gradle finalizada sem erros.

> [!IMPORTANT]
> Certifique-se de que o dispositivo de teste tem acesso à internet para que o Retrofit consiga buscar os dados da API JSONPlaceholder.
