# Implementation Plan - Fix Layout Editor Render, Accessibility, and Edge-to-Edge Issues

The goal is to resolve multiple issues in the Android Studio Layout Editor:
1.  **Layout fidelity warning**: API version mismatch and non-ASCII characters.
2.  **Accessibility**: Insufficient contrast ratio for `imgContact`.
3.  **Edge-to-Edge**: `txtTotalContacts` covered by System UI in previews.

## User Review Required

> [!IMPORTANT]
> The project uses non-ASCII characters in theme names (e.g., `Theme.AplicaçãoDeContactosComImagemCRUDCompleto`). I will rename these to `Theme.ContactApp` to ensure stable rendering across all IDE versions.

## Proposed Changes

### Configuration

#### [MODIFY] [app/build.gradle.kts](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/build.gradle.kts)
- Ensure `compileSdk` and `targetSdk` are set to 35.

### Resources

#### [MODIFY] [activity_main.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/activity_main.xml)
- Add `android:fitsSystemWindows="true"` to the root layout or adjust padding to ensure the preview correctly accounts for system bars.
- Alternatively, use `tools:paddingTop` to simulate the inset in the preview.

#### [MODIFY] [contact_item.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/contact_item.xml)
- Replace legacy `androidx.cardview.widget.CardView` with `com.google.android.material.card.MaterialCardView`.
- Update `imgContact` background color to `@color/gray_placeholder_accessible` (a lighter gray) to fix the contrast issue.

#### [MODIFY] [colors.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/values/colors.xml)
- Update `gray_placeholder` to `#FFE0E0E0` (Light Gray) to improve contrast against dark icons.

#### [MODIFY] [themes.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/values/themes.xml) and [themes.xml (night)](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/values-night/themes.xml)
- Rename theme `Theme.AplicaçãoDeContactosComImagemCRUDCompleto` to `Theme.ContactApp`.

#### [MODIFY] [AndroidManifest.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/AndroidManifest.xml)
- Update the `android:theme` reference.

### Code

#### [MODIFY] [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/MainActivity.kt)
- If theme names are changed, ensure any programmatic references (if any) are updated.

## Verification Plan

### Automated Tests
- Run `./gradlew assembleDebug`.

### Manual Verification
- Check `activity_main.xml` preview: `txtTotalContacts` should not be covered by the status bar.
- Check `contact_item.xml` preview: No fidelity warnings and no contrast errors.
