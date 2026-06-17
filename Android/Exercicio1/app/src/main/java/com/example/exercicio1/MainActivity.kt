package com.example.exercicio1

import android.os.Bundle
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio1.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding

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

        binding.btnConverter.setOnClickListener {
            val euroInput = binding.editEuros.text.toString().toDoubleOrNull()
            
            if (euroInput == null) {
                binding.textviewResultado.text = getString(R.string.result_placeholder)
                Toast.makeText(this, getString(R.string.error_invalid_input), Toast.LENGTH_SHORT).show()
            } else {
                // Conversão de Euro para Dólar (Taxa exemplo: 1.05)
                val taxaConversao = 1.05
                val dolar = euroInput * taxaConversao
                val resultadoFormatado = String.format("%.2f", dolar)

                binding.textviewResultado.text = getString(R.string.result_format, resultadoFormatado)
            }
        }
    }
}