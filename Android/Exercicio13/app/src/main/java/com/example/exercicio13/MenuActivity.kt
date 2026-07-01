package com.example.exercicio13

import android.content.Intent
import android.os.Bundle
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import androidx.core.splashscreen.SplashScreen.Companion.installSplashScreen
import com.example.exercicio13.databinding.ActivityMenuBinding

class MenuActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMenuBinding
    private var usernameSalvo: String? = null
    private var passwordSalva: String? = null

    private val registoLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == RESULT_OK) {
            val data = result.data
            usernameSalvo = data?.getStringExtra("username")
            passwordSalva = data?.getStringExtra("password")
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        installSplashScreen()
        super.onCreate(savedInstanceState)
        binding = ActivityMenuBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnRegisto.setOnClickListener {
            val intent = Intent(this, RegistoActivity::class.java)
            registoLauncher.launch(intent)
        }

        binding.btnLogin.setOnClickListener {
            val intent = Intent(this, LoginActivity::class.java)
            intent.putExtra("username", usernameSalvo)
            intent.putExtra("password", passwordSalva)
            startActivity(intent)
        }

        binding.btnSobre.setOnClickListener {
            val intent = Intent(this, SobreActivity::class.java)
            startActivity(intent)
        }
    }
}
