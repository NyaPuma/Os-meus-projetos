package com.example.exercicio8

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicio8.databinding.ActivityLoginErradoBinding

class LoginErradoActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginErradoBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginErradoBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.buttonVoltar.setOnClickListener {
            finish()
        }
    }
}
