package com.example.exercicio9_extra

import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio9_extra.databinding.ActivityMainBinding

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

        binding.buttonEnviar.setOnClickListener {
            val intent = Intent(this, DetailsActivity::class.java)
            intent.putExtra("NOME", binding.editTextNome.text.toString())
            intent.putExtra("MORADA", binding.editTextMorada.text.toString())
            intent.putExtra("TELEFONE", binding.editTextTelefone.text.toString())
            intent.putExtra("EMAIL", binding.editTextEmail.text.toString())
            startActivity(intent)
        }
    }
}
