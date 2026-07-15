# Fix "Canvas: trying to draw too large bitmap" crash

The application is now crashing because it tries to display high-resolution images directly in an `ImageView`. Android has a limit on the size of bitmaps that can be drawn on a `Canvas`. When the user selects a large image (e.g., from the camera), it exceeds this limit.

To fix this, we will implement a helper function to decode images efficiently by downsampling them to a reasonable size (e.g., 512x512 pixels) before displaying them.

## User Review Required

> [!IMPORTANT]
> This change introduces a `BitmapUtils` class to handle image loading. The images will be scaled down for display in the app. This is a standard practice in Android to avoid `OutOfMemoryError` and Canvas drawing limits.

## Proposed Changes

### [app]

#### [NEW] [BitmapUtils.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/BitmapUtils.kt)
- Create a utility class with a function to decode and scale `Uri` images.

#### [MODIFY] [AddEditContactActivity.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/AddEditContactActivity.kt)
- Use `BitmapUtils` to load and display the selected image.

#### [MODIFY] [ContactAdapter.kt](file:///C:/Users/Cesae/Downloads/Github/Android/AplicaodeContactoscomImagemCRUDcompleto/app/src/main/java/com/example/aplicaodecontactoscomimagemcrudcompleto/ContactAdapter.kt)
- Use `BitmapUtils` to load images in the RecyclerView items.

## Verification Plan

### Manual Verification
1. Pick a large image from the gallery.
2. Verify that the image is displayed without crashing.
3. Save the contact and verify the image appears in the list.
4. Verify that editing the contact also displays the image correctly.
