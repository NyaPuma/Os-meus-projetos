package com.example.exercicio13

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicio13.databinding.ActivityLoginBinding

class LoginActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val usernameSalvo = intent.getStringExtra("username")
        val passwordSalva = intent.getStringExtra("password")

        binding.btnVoltarLogin.setOnClickListener {
            finish()
        }

        binding.btnLoginSubmit.setOnClickListener {
            val usernameInput = binding.editUsernameLogin.text.toString()
            val passwordInput = binding.editPasswordLogin.text.toString()

            if (usernameInput == usernameSalvo && passwordInput == passwordSalva && !usernameSalvo.isNullOrEmpty()) {
                val intent = Intent(this, SobreActivity::class.java)
                startActivity(intent)
                finish()
            } else {
                Toast.makeText(this, "Dados incorretos!", Toast.LENGTH_SHORT).show()
                binding.editUsernameLogin.text.clear()
                binding.editPasswordLogin.text.clear()
            }
        }
    }
}
