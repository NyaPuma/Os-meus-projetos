package com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities

import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ActivityRegisterBinding
import com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel.AuthViewModel

class RegisterActivity : AppCompatActivity() {
    private lateinit var binding: ActivityRegisterBinding
    private val viewModel: AuthViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRegisterBinding.inflate(layoutInflater)
        setContentView(binding.root)

        viewModel.registerSuccess.observe(this) { success ->
            if (success) {
                Toast.makeText(this, "Registo efetuado com sucesso", Toast.LENGTH_SHORT).show()
                finish()
            }
        }

        viewModel.error.observe(this) { error ->
            Toast.makeText(this, error, Toast.LENGTH_SHORT).show()
        }

        binding.btnRegister.setOnClickListener {
            val nome = binding.etNome.text.toString()
            val email = binding.etEmail.text.toString()
            val pass = binding.etPassword.text.toString()
            val confirm = binding.etConfirmPassword.text.toString()

            if (nome.isNotEmpty() && email.isNotEmpty() && pass.isNotEmpty()) {
                if (pass == confirm) {
                    viewModel.register(nome, email, pass)
                } else {
                    Toast.makeText(this, "Passwords não coincidem", Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this, "Preenche todos os campos", Toast.LENGTH_SHORT).show()
            }
        }

        binding.tvGoToLogin.setOnClickListener {
            finish()
        }
    }
}