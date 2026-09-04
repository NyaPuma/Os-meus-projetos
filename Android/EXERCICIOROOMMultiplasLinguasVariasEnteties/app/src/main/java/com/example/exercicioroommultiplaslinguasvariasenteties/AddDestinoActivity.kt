package com.example.exercicioroommultiplaslinguasvariasenteties

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import kotlinx.coroutines.launch

class AddDestinoActivity : AppCompatActivity() {

    private var destinoEdit: Destino? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add_destino)

        val etNome = findViewById<EditText>(R.id.etNome)
        val etLocalizacao = findViewById<EditText>(R.id.etLocalizacao)
        val etPreco = findViewById<EditText>(R.id.etPreco)
        val btnSave = findViewById<Button>(R.id.btnSave)

        destinoEdit = intent.getSerializableExtra("destino") as? Destino

        destinoEdit?.let {
            etNome.setText(it.nome)
            etLocalizacao.setText(it.localizacao)
            etPreco.setText(it.preco.toString())
        }

        btnSave.setOnClickListener {
            val nome = etNome.text.toString()
            val localizacao = etLocalizacao.text.toString()
            val precoStr = etPreco.text.toString()

            if (nome.isNotEmpty() && localizacao.isNotEmpty() && precoStr.isNotEmpty()) {
                val preco = precoStr.toDoubleOrNull() ?: 0.0
                val dao = AppDatabase.getDatabase(this).appDao()
                
                lifecycleScope.launch {
                    if (destinoEdit == null) {
                        dao.insertDestino(Destino(nome = nome, preco = preco, localizacao = localizacao))
                    } else {
                        dao.updateDestino(destinoEdit!!.copy(nome = nome, preco = preco, localizacao = localizacao))
                    }
                    Toast.makeText(this@AddDestinoActivity, R.string.destination_saved, Toast.LENGTH_SHORT).show()
                    finish()
                }
            } else {
                Toast.makeText(this, R.string.invalid_data, Toast.LENGTH_SHORT).show()
            }
        }
    }
}
