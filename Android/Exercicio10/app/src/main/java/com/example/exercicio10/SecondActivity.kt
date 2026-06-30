package com.example.exercicio10

import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.widget.doAfterTextChanged
import com.example.exercicio10.databinding.ActivitySecondBinding

class SecondActivity : AppCompatActivity() {

    private lateinit var binding: ActivitySecondBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        
        binding = ActivitySecondBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val num1 = intent.getDoubleExtra("NUM1", 0.0)
        setupListeners(num1)
    }

    private fun setupListeners(num1: Double) {
        binding.editTextNumber2.doAfterTextChanged { 
            binding.textInputLayout2.error = null 
        }

        binding.buttonCalculate.setOnClickListener {
            val num2Str = binding.editTextNumber2.text.toString()
            
            if (num2Str.isNotEmpty()) {
                val intent = Intent(this, ThirdActivity::class.java).apply {
                    putExtra("NUM1", num1)
                    putExtra("NUM2", num2Str.toDouble())
                }
                startActivity(intent)
            } else {
                binding.textInputLayout2.error = getString(R.string.error_empty_number)
            }
        }
    }
}
