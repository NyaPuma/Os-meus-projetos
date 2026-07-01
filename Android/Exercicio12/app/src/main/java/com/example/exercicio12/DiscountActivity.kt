package com.example.exercicio12

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicio12.databinding.ActivityDiscountBinding

class DiscountActivity : AppCompatActivity() {

    private lateinit var binding: ActivityDiscountBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityDiscountBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.buttonOk.setOnClickListener {
            val descontoStr = binding.editTextDesconto.text.toString()
            if (descontoStr.isNotEmpty()) {
                val intent = Intent()
                intent.putExtra("DESCONTO", descontoStr.toDouble())
                setResult(RESULT_OK, intent)
                finish()
            } else {
                binding.editTextDesconto.error = "Introduza um valor"
            }
        }

        binding.buttonCancelar.setOnClickListener {
            setResult(RESULT_CANCELED)
            finish()
        }
    }
}
