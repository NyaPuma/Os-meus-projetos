package com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities

import android.os.Build
import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.R
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ActivityAddDestinoBinding
import com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel.DestinoViewModel

class AddDestinoActivity : AppCompatActivity() {

    private lateinit var binding: ActivityAddDestinoBinding
    private val viewModel: DestinoViewModel by viewModels()
    private var destinoEdit: Destino? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityAddDestinoBinding.inflate(layoutInflater)
        setContentView(binding.root)

        destinoEdit = if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
            intent.getSerializableExtra("destino", Destino::class.java)
        } else {
            @Suppress("DEPRECATION")
            intent.getSerializableExtra("destino") as? Destino
        }

        destinoEdit?.let {
            binding.etNomeDestino.setText(it.nomeDestino)
            binding.etPais.setText(it.pais)
            binding.etPreco.setText(it.preco.toString())
        }

        binding.btnSave.setOnClickListener {
            val nome = binding.etNomeDestino.text.toString()
            val pais = binding.etPais.text.toString()
            val precoStr = binding.etPreco.text.toString()

            if (nome.isNotEmpty() && pais.isNotEmpty() && precoStr.isNotEmpty()) {
                val preco = precoStr.toDoubleOrNull() ?: 0.0
                
                if (destinoEdit == null) {
                    viewModel.insert(Destino(nomeDestino = nome, preco = preco, pais = pais))
                } else {
                    viewModel.update(destinoEdit!!.copy(nomeDestino = nome, preco = preco, pais = pais))
                }
                Toast.makeText(this@AddDestinoActivity, R.string.destination_saved, Toast.LENGTH_SHORT).show()
                finish()
            } else {
                Toast.makeText(this, R.string.invalid_data, Toast.LENGTH_SHORT).show()
            }
        }
    }
}