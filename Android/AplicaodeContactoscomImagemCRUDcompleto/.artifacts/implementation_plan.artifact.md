# Refatoração para ListAdapter e DiffUtil

Este plano descreve a substituição do `RecyclerView.Adapter` genérico por `ListAdapter` com `DiffUtil`. Esta mudança otimiza a atualização da lista, processando apenas as alterações reais (inserções, remoções ou edições) em vez de recarregar toda a lista com `notifyDataSetChanged`.

## Mudanças Propostas

### 1. Adaptador de Contactos
- **[MODIFY] [ContactAdapter.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/ContactAdapter.kt)**:
    - Alterar a classe base para `ListAdapter<Contact, ContactAdapter.ContactViewHolder>(ContactDiffCallback())`.
    - Remover a gestão manual da lista (`private var contacts`).
    - Implementar a classe `ContactDiffCallback` para comparar itens.

### 2. Activity Principal
- **[MODIFY] [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/MainActivity.kt)**:
    - Atualizar a chamada de atualização para `adapter.submitList(contacts)`.

## Plano de Verificação

### Testes Manuais
1. **Adição/Edição/Remoção**: Confirmar que as animações da lista são fluidas (efeito lateral do DiffUtil).
2. **Estabilidade**: Garantir que a lista reflete exatamente o estado da base de dados após cada operação.

> [!TIP]
> O `ListAdapter` corre o cálculo de diferenças numa thread de background, evitando bloqueios na UI (jank) quando a lista de contactos cresce significativamente.
