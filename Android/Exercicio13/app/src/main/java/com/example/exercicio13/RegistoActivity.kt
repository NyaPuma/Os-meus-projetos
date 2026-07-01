package com.example.exercicio13

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicio13.databinding.ActivityRegistoBinding

class RegistoActivity : AppCompatActivity() {

    private lateinit var binding: ActivityRegistoBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRegistoBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnVoltarRegisto.setOnClickListener {
            finish()
        }

        binding.btnGuardar.setOnClickListener {
            val username = binding.editUsername.text.toString()
            val password = binding.editPassword.text.toString()

            if (username.isNotEmpty() && password.isNotEmpty()) {
                val intent = Intent()
                intent.putExtra("username", username)
                intent.putExtra("password", password)
                setResult(RESULT_OK, intent)
                finish()
            }
        }
    }
}
