package com.example.exercicio6

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.widget.doOnTextChanged
import com.example.exercicio6.databinding.ActivityMainBinding
import java.util.Locale

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    companion object {
        private const val RATE_USD = 1.1343
        private const val SYMBOL_USD = "$"
        private const val RATE_BRL = 6.4019
        private const val SYMBOL_BRL = "R$"
        private const val RATE_CHF = 0.9336
        private const val SYMBOL_CHF = "CHF"
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        binding.editTextEuro.doOnTextChanged { _, _, _, _ ->
            binding.textInputLayout.error = null
        }

        binding.buttonDolares.setOnClickListener {
            convert(RATE_USD, SYMBOL_USD)
        }

        binding.buttonReais.setOnClickListener {
            convert(RATE_BRL, SYMBOL_BRL)
        }

        binding.buttonFrancos.setOnClickListener {
            convert(RATE_CHF, SYMBOL_CHF)
        }
    }

    private fun convert(rate: Double, symbol: String) {
        val valueString = binding.editTextEuro.text.toString()
        binding.textInputLayout.error = null

        if (valueString.isNotEmpty()) {
            try {
                val euroValue = valueString.toDouble()
                val convertedValue = euroValue * rate
                binding.textViewResult.text = String.format(Locale.getDefault(), "%.2f %s",
                    convertedValue, symbol)
            } catch (_: NumberFormatException) {
                binding.textInputLayout.error = "Valor inválido"
                binding.textViewResult.text = getString(R.string.resultado)
            }
        } else {
            binding.textInputLayout.error = "Insira um valor"
            binding.textViewResult.text = getString(R.string.resultado)
        }
    }
}
