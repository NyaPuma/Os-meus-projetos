# Implementation Plan - Fix Layout Fidelity Warning

The user is experiencing a "Layout fidelity warning" in the Android Studio preview, which states that the current rendering only supports APIs up to 36, and the project is likely using a version that the renderer considers "higher" (API 36 with minor API level 1). Additionally, the user mentioned "Compose Preview" despite the project using XML layouts. I will address the fidelity warning and ensure the layout renders correctly.

## User Review Required

> [!IMPORTANT]
> The project currently uses XML layouts and does not have Jetpack Compose dependencies. I will fix the fidelity warning for the XML Layout Editor. If you intended to use Jetpack Compose, please let me know, as it would require adding dependencies and converting the layouts.

## Proposed Changes

### Build Configuration

#### [MODIFY] [build.gradle.kts](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/build.gradle.kts)
- Downgrade `compileSdk` and `targetSdk` to 35 (or a stable 36 without minor API levels) to resolve the Layout Editor fidelity warning. API 35 is currently more widely supported by stable rendering engines.

## Verification Plan

### Manual Verification
- Verify that the "Layout fidelity warning" disappears in the Layout Editor for `contact_item.xml`.
- Ensure the preview renders correctly without warnings about API compatibility.
