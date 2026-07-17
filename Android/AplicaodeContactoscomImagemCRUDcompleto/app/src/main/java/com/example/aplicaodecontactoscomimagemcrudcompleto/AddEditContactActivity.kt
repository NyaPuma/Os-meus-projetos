package com.example.aplicaodecontactoscomimagemcrudcompleto

import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.IntentCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.aplicaodecontactoscomimagemcrudcompleto.databinding.ActivityAddEditContactBinding

class AddEditContactActivity : AppCompatActivity() {

    private lateinit var binding: ActivityAddEditContactBinding
    private var selectedImageUri: Uri? = null
    private var contactToEdit: Contact? = null

    private val selectImageLauncher = registerForActivityResult(ActivityResultContracts.OpenDocument()) { uri: Uri? ->
        uri?.let {
            selectedImageUri = it
            val bitmap = BitmapUtils.decodeSampledBitmapFromUri(this, it, 500, 500)
            binding.imgAddContact.setImageBitmap(bitmap)
            binding.imgAddContact.imageTintList = null
            // Grant persistable permission
            try {
                contentResolver.takePersistableUriPermission(it, Intent.FLAG_GRANT_READ_URI_PERMISSION)
            } catch (e: SecurityException) {
                e.printStackTrace()
            }
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityAddEditContactBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)

        ViewCompat.setOnApplyWindowInsetsListener(binding.root) { _, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            binding.toolbar.setPadding(systemBars.left, systemBars.top, systemBars.right, 0)
            insets
        }

        setSupportActionBar(binding.toolbar)
        binding.toolbar.setNavigationOnClickListener { finish() }

        contactToEdit = IntentCompat.getSerializableExtra(intent, "CONTACT", Contact::class.java)

        if (contactToEdit != null) {
            binding.editName.setText(contactToEdit!!.name)
            binding.editPhone.setText(contactToEdit!!.phone)
            if (contactToEdit!!.imageUri != null) {
                selectedImageUri = Uri.parse(contactToEdit!!.imageUri)
                val bitmap = BitmapUtils.decodeSampledBitmapFromUri(this, selectedImageUri!!, 500, 500)
                binding.imgAddContact.setImageBitmap(bitmap)
                binding.imgAddContact.imageTintList = null
            }
            binding.btnSave.setText(R.string.atualizar_contacto)
            binding.toolbar.title = getString(R.string.editar_contacto)
        } else {
            binding.toolbar.title = getString(R.string.adicionar_contacto)
        }

        binding.btnSelectImage.setOnClickListener {
            selectImageLauncher.launch(arrayOf("image/*"))
        }

        binding.btnSave.setOnClickListener {
            saveContact()
        }
    }

    private fun saveContact() {
        val name = binding.editName.text.toString().trim()
        val phone = binding.editPhone.text.toString().trim()

        if (name.isEmpty() || phone.isEmpty()) {
            Toast.makeText(this, "Preencha todos os campos", Toast.LENGTH_SHORT).show()
            return
        }

        val dbHelper = DBHelper(this)
        if (contactToEdit == null) {
            val newContact = Contact(name = name, phone = phone, imageUri = selectedImageUri?.toString())
            dbHelper.addContact(newContact)
            Toast.makeText(this, "Contacto adicionado", Toast.LENGTH_SHORT).show()
        } else {
            val updatedContact = Contact(
                id = contactToEdit!!.id,
                name = name,
                phone = phone,
                imageUri = selectedImageUri?.toString()
            )
            dbHelper.updateContact(updatedContact)
            Toast.makeText(this, "Contacto atualizado", Toast.LENGTH_SHORT).show()
        }

        finish()
    }
}
