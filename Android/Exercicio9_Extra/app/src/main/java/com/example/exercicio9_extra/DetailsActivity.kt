package com.example.exercicio9_extra

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio9_extra.databinding.ActivityDetailsBinding

class DetailsActivity : AppCompatActivity() {

    private lateinit var binding: ActivityDetailsBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        
        binding = ActivityDetailsBinding.inflate(layoutInflater)
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val nome = intent.getStringExtra("NOME") ?: ""
        val morada = intent.getStringExtra("MORADA") ?: ""
        val telefone = intent.getStringExtra("TELEFONE") ?: ""
        val email = intent.getStringExtra("EMAIL") ?: ""

        binding.textValueNome.text = nome
        binding.textValueMorada.text = morada
        binding.textValueTelefone.text = telefone
        binding.textValueEmail.text = email

        // Mantendo o formato original se ainda for necessário em algum lugar
        binding.textViewMessage.text = getString(R.string.details_message, nome, morada, telefone, email)
    }
}
