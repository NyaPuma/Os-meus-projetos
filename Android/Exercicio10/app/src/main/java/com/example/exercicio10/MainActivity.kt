package com.example.exercicio10

import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.widget.doAfterTextChanged
import com.example.exercicio10.databinding.ActivityMainBinding

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

        setupListeners()
    }

    private fun setupListeners() {
        binding.editTextNumber1.doAfterTextChanged { 
            binding.textInputLayout1.error = null 
        }

        binding.buttonNext.setOnClickListener {
            val num1Str = binding.editTextNumber1.text.toString()
            
            if (num1Str.isNotEmpty()) {
                val intent = Intent(this, SecondActivity::class.java).apply {
                    putExtra("NUM1", num1Str.toDouble())
                }
                startActivity(intent)
            } else {
                binding.textInputLayout1.error = getString(R.string.error_empty_number)
            }
        }
    }
}
