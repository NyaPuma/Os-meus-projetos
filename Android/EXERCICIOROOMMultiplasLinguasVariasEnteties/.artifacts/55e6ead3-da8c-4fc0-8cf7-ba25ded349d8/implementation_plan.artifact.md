# Implementation Plan - Migrate to View Binding

Refactor the project to use Android View Binding instead of `findViewById`. This will improve type safety and reduce boilerplate code for UI interactions.

## User Review Required

> [!NOTE]
> View Binding will be enabled in `build.gradle.kts`, which triggers the generation of binding classes for all layout files.

## Proposed Changes

### Build Configuration

#### [MODIFY] [build.gradle.kts (app)](file:///C:/Users/Cesae/Downloads/Github/Android/EXERCICIOROOMMultiplasLinguasVariasEnteties/app/build.gradle.kts)
- Enable `viewBinding` feature in the `android` block.

---

### UI Components

#### [MODIFY] [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/EXERCICIOROOMMultiplasLinguasVariasEnteties/app/src/main/java/com/example/exercicioroommultiplaslinguasvariasenteties/MainActivity.kt)
- Replace `findViewById` calls with usage of `ActivityMainBinding`.

#### [MODIFY] [AddDestinoActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/EXERCICIOROOMMultiplasLinguasVariasEnteties/app/src/main/java/com/example/exercicioroommultiplaslinguasvariasenteties/AddDestinoActivity.kt)
- Replace `findViewById` calls with usage of `ActivityAddDestinoBinding`.

#### [MODIFY] [ReservaActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/EXERCICIOROOMMultiplasLinguasVariasEnteties/app/src/main/java/com/example/exercicioroommultiplaslinguasvariasenteties/ReservaActivity.kt)
- Replace `findViewById` calls with usage of `ActivityReservaBinding`.

#### [MODIFY] [DestinoAdapter.kt](file:///C:/Users/Cesae/Downloads/Github/Android/EXERCICIOROOMMultiplasLinguasVariasEnteties/app/src/main/java/com/example/exercicioroommultiplaslinguasvariasenteties/DestinoAdapter.kt)
- Refactor `DestinoViewHolder` to use `ItemDestinoBinding`.

---

## Verification Plan

### Automated Tests
- Build project to ensure binding classes are generated and code compiles.

### Manual Verification
1.  **Launch App**: Verify `MainActivity` loads correctly.
2.  **Add/Edit Destination**: Verify `AddDestinoActivity` functions as before.
3.  **Reservar**: Verify `ReservaActivity` displays data and handles input correctly.
4.  **Language Switch**: Ensure the UI recreation after language change still works with View Binding.
