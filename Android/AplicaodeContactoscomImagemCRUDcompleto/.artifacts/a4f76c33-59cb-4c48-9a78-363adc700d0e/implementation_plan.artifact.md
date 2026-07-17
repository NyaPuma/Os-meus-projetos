# Professional UX/UI Redesign - Material 3

This plan details the transformation of the contact management app into a professional-grade product using **Material 3 (M3)** principles. The focus is on clarity, modern aesthetics, and improved user experience.

## User Review Required

> [!IMPORTANT]
> The redesign involves a full overhaul of the visual identity, including colors, typography, and component structure. The UI will become cleaner and more functional.

## Proposed Changes

### [res/values]

#### [MODIFY] [colors.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/values/colors.xml)
- Define a modern Material 3 palette:
    - `md_theme_primary`: Deep Indigo (#3F51B5)
    - `md_theme_secondary`: Light Blue (#03A9F4)
    - `md_theme_surface`: Off-white/Gray (#F5F5F5)
    - `md_theme_error`: Soft Red (#B00020)

#### [MODIFY] [themes.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/values/themes.xml)
- Apply Material 3 theme attributes.
- Customize `ShapeAppearance` for cards and buttons.

### [res/drawable] (New Icons)
- Create clean, vector-based icons for:
    - **Add** (FAB)
    - **Edit** (Action)
    - **Delete** (Action)
    - **Person** (Placeholder)
    - **Phone** (Input Icon)

### [res/layout]

#### [MODIFY] [activity_main.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/activity_main.xml)
- Add `MaterialToolbar` within an `AppBarLayout`.
- Use `RecyclerView` with vertical padding and clip-to-padding disabled.
- Add an **Empty State** view with an illustration/icon and helpful text.

#### [MODIFY] [contact_item.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/contact_item.xml)
- Enclose item in a `MaterialCardView` with subtle elevation.
- Use a circular `ShapeableImageView` for the contact photo.
- Improved spacing and typography.

#### [MODIFY] [activity_add_edit_contact.xml](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/res/layout/activity_add_edit_contact.xml)
- Add a `TopAppBar` with a back button.
- Center a large circular image preview with a "Change Photo" button.
- Use `TextInputLayout` (OutlinedBox) for all inputs with icons.

### [Source Code]

#### [MODIFY] [MainActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/MainActivity.kt)
- Update to handle toolbar setup.
- Add logic to show/hide the Empty State view based on the contact list size.

## Verification Plan

### Manual Verification
- **Visual Audit**: Compare the new UI against Material 3 guidelines.
- **Interactions**: Check button ripple effects and card clicks.
- **Responsiveness**: Verify the layout looks good on different screen sizes.
- **Theming**: Test Light and Dark modes.
