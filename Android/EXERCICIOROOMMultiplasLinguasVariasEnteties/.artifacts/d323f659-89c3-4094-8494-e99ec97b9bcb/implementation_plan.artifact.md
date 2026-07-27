# Implementation Plan - Project Package Organization

Organize the project files into a clear package structure (Data, UI, ViewModels, Utils) to improve maintainability and follow Android best practices.

## Proposed Changes

### 1. New Package Structure

I will move the existing files into the following sub-packages under `com.example.exercicioroommultiplaslinguasvariasenteties`:

| Package | Files |
| :--- | :--- |
| **.data.model** | `User.kt`, `Cliente.kt`, `Destino.kt` |
| **.data.local** | `AppDao.kt`, `AppDatabase.kt` |
| **.data.repository** | `AppRepository.kt` |
| **.ui.activities** | `MainActivity.kt`, `LoginActivity.kt`, `RegisterActivity.kt`, `ReservaActivity.kt`, `AddDestinoActivity.kt`, `EditProfileActivity.kt`, `ChangePasswordActivity.kt` |
| **.ui.fragments** | `DestinoListFragment.kt`, `ProfileFragment.kt` |
| **.ui.adapters** | `DestinoAdapter.kt` |
| **.viewmodel** | `AuthViewModel.kt`, `DestinoViewModel.kt`, `ProfileViewModel.kt`, `ReservaViewModel.kt` |
| **.utils** | `SessionManager.kt` |

### 2. File Operations

For each file, I will:
1.  Read the content.
2.  Update the `package` declaration.
3.  Add necessary `import` statements (since classes previously in the same package will now be in different ones).
4.  Write the updated content to the new absolute path.
5.  Delete the old file using a shell command.

### 3. Configuration Updates

#### [MODIFY] [AndroidManifest.xml](file:///C:/Users/Cesae/Downloads/Github/Android/EXERCICIOROOMMultiplasLinguasVariasEnteties/app/src/main/AndroidManifest.xml)
- Update Activity declarations to reflect new package paths (e.g., `.ui.activities.MainActivity`).

## Verification Plan

### Automated Tests
- Run `gradle_build("assembleDebug")` to ensure all imports and package names are correct.

### Manual Verification
- Launch the app and verify that navigation between Activities and Fragments still works correctly.
