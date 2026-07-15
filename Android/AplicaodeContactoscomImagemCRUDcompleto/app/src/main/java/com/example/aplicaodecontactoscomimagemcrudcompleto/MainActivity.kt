package com.example.aplicaodecontactoscomimagemcrudcompleto

import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.aplicaodecontactoscomimagemcrudcompleto.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private lateinit var dbHelper: DBHelper
    private lateinit var adapter: ContactAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        dbHelper = DBHelper(this)

        binding.recyclerViewContacts.layoutManager = LinearLayoutManager(this)
        
        adapter = ContactAdapter(
            onEditClick = { contact ->
                val intent = Intent(this, AddEditContactActivity::class.java)
                intent.putExtra("CONTACT", contact)
                startActivity(intent)
            },
            onDeleteClick = { contact ->
                showDeleteDialog(contact)
            }
        )
        binding.recyclerViewContacts.adapter = adapter

        binding.fabAdd.setOnClickListener {
            val intent = Intent(this, AddEditContactActivity::class.java)
            startActivity(intent)
        }
    }

    override fun onResume() {
        super.onResume()
        loadContacts()
    }

    private fun loadContacts() {
        val contacts = dbHelper.getAllContacts()
        adapter.submitList(contacts)
        binding.txtTotalContacts.text = getString(R.string.total_contactos, contacts.size)
    }

    private fun showDeleteDialog(contact: Contact) {
        AlertDialog.Builder(this)
            .setTitle("Eliminar Contacto")
            .setMessage("Tem a certeza que deseja eliminar ${contact.name}?")
            .setPositiveButton("Sim") { _, _ ->
                dbHelper.deleteContact(contact.id)
                loadContacts()
            }
            .setNegativeButton("Não", null)
            .show()
    }
}
