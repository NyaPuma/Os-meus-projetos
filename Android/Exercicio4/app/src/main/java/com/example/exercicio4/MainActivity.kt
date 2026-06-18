package com.example.exercicio4

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio4.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

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

        binding.btnShowName.setOnClickListener {
            val firstName = binding.editFirstName.text.toString().trim()
            val lastName = binding.editLastName.text.toString().trim()

            if (firstName.isEmpty() || lastName.isEmpty()) {
                binding.textMessage.text = getString(R.string.nome_nao_inserido)
            } else {
                binding.textMessage.text =
                    getString(R.string.saudacao, firstName, lastName)
            }
        }
    }
}