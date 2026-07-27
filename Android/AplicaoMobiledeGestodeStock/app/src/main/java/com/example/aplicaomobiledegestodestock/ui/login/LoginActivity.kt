package com.example.aplicaomobiledegestodestock.ui.login

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.example.aplicaomobiledegestodestock.StockApplication
import com.example.aplicaomobiledegestodestock.databinding.ActivityLoginBinding
import com.example.aplicaomobiledegestodestock.ui.home.HomeActivity
import com.example.aplicaomobiledegestodestock.viewmodel.LoginViewModel
import com.example.aplicaomobiledegestodestock.viewmodel.LoginViewModelFactory
import kotlinx.coroutines.launch

/**
 * Ecrã de Login.
 * Ponto de entrada para autenticação de utilizadores.
 */
class LoginActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginBinding
    private val viewModel: LoginViewModel by viewModels {
        val app = application as StockApplication
        LoginViewModelFactory(app.utilizadorRepository, app.sessionManager)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnLogin.setOnClickListener {
            val username = binding.etUsername.text.toString()
            val password = binding.etPassword.text.toString()
            viewModel.login(username, password)
        }

        lifecycleScope.launch {
            viewModel.loginResult.collect { user ->
                if (user != null) {
                    Toast.makeText(this@LoginActivity, "Bem-vindo, ${user.nome}", Toast.LENGTH_SHORT).show()
                    startActivity(Intent(this@LoginActivity, HomeActivity::class.java))
                    finish()
                }
            }
        }

        lifecycleScope.launch {
            viewModel.error.collect { message ->
                Toast.makeText(this@LoginActivity, message, Toast.LENGTH_SHORT).show()
            }
        }
    }
}
