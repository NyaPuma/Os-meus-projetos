package com.example.exercicio12

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicio12.databinding.ActivityMainBinding
import java.util.Locale

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    private val resultLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == RESULT_OK) {
            val valorOriginal = binding.editTextValor.text.toString().toDoubleOrNull() ?: 0.0
            val desconto = result.data?.getDoubleExtra("DESCONTO", 0.0) ?: 0.0
            
            val valorFinal = valorOriginal * (1 - (desconto / 100))
            binding.textViewResultado.text = String.format(Locale.getDefault(), "Resultado: %.2f€ (Desconto de %.1f%%)", valorFinal, desconto)
        } else if (result.resultCode == RESULT_CANCELED) {
            Toast.makeText(this, "Operator cancelada", Toast.LENGTH_SHORT).show()
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.buttonAplicarDesconto.setOnClickListener {
            val valorStr = binding.editTextValor.text.toString()
            if (valorStr.isNotEmpty()) {
                val intent = Intent(this, DiscountActivity::class.java)
                resultLauncher.launch(intent)
            } else {
                binding.editTextValor.error = "Introduza o valor da compra"
            }
        }
    }
}
