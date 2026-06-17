package com.example.firstapp

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.firstapp.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() { // declaração da classe
    private lateinit var binding: ActivityMainBinding // inicialização da classe
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root) // diz ao android qual o layout XML a utilizar neste ecrâ

//        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
//            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
//            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
//            insets
//        }
//
//        // ligação às views
//        val texto_nome = findViewById<EditText>(R.id.editText_Nome)
//        val botao = findViewById<Button>(R.id.btn_ola)
//        val res = findViewById<TextView>(R.id.textView_resultado)
//
//        // Evento do clique do botão
//        botao.setOnClickListener {
//            val nome = texto_nome.text.toString()
//            res.text = "Olá $nome"
//        }

        // com view binding
        binding.btnOla.setOnClickListener {
            val nome = binding.editTextNome.text.toString()
            if (nome.isEmpty()) {
                Toast.makeText(this, "Insira um nome", Toast.LENGTH_SHORT).show()
            }
            else {
                binding.textViewResultado.text = "Olá $nome"
            }
        }
    }
}