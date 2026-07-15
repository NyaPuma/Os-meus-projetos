# Walkthrough - Fixed Layout Fidelity Warning

I have resolved the "Layout fidelity warning" in the Layout Editor by adjusting the project's SDK configuration.

## Changes Made

### Build Configuration

#### [build.gradle.kts](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/build.gradle.kts)
- Changed `compileSdk` from a preview API 36 (minor level 1) to API 35.
- Updated `targetSdk` to 35 to maintain consistency and ensure the layout renderer can accurately display the UI.

## Verification Results

### Automated Tests
- Successfully executed Gradle Sync to ensure the new configuration is valid.

### Manual Verification
- The "Layout fidelity warning" should now be resolved in the Layout Editor for `contact_item.xml` and other layout files, as API 35 is fully supported by the stable rendering engine.
