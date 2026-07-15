# Walkthrough - Correção de Contraste e Acessibilidade

Foi resolvida a questão do rácio de contraste insuficiente nos placeholders das imagens, garantindo que a aplicação cumpre as normas de acessibilidade visual.

## Alterações Realizadas

### Estilos e Cores
- **[colors.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/values/colors.xml)**: Atualizada a cor `gray_placeholder` para um cinzento mais escuro (`#616161`), proporcionando melhor contraste contra fundos claros.

### Interface (Layouts)
- **[activity_add_edit_contact.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/activity_add_edit_contact.xml)**:
    - Aplicada a nova cor de fundo ao placeholder.
    - Adicionado `app:tint="@color/white"` ao ícone de galeria para garantir visibilidade clara (contraste superior a 3.0).
- **[contact_item.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/contact_item.xml)**:
    - Atualizada a `ShapeableImageView` para usar o mesmo padrão de contraste (fundo escuro e ícone branco).

### Lógica de UI
- **[AddEditContactActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/AddEditContactActivity.kt)** & **[ContactAdapter.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/ContactAdapter.kt)**:
    - Implementada a limpeza dinâmica do tint (`imageTintList = null`) sempre que uma imagem real do contacto é carregada. Isto evita que as fotografias fiquem com um filtro branco indesejado.
    - O tint é reaplicado apenas quando o placeholder (ícone da galeria) está visível.

## Verificação de Contraste
- **Fundo vs Placeholder**: Contraste de ~5.8:1 (Supera o requisito de 3.0).
- **Ícone vs Placeholder**: Contraste de ~5.8:1 (Supera o requisito de 3.0).

> [!TIP]
> Estas alterações não só resolvem o aviso do Android Studio, como também tornam a aplicação muito mais utilizável para pessoas com sensibilidade visual reduzida.
