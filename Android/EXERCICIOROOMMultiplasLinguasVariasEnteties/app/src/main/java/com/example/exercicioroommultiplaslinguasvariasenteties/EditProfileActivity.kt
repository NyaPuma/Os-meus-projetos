package com.example.exercicioroommultiplaslinguasvariasenteties

import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ActivityEditProfileBinding

class EditProfileActivity : AppCompatActivity() {
    private lateinit var binding: ActivityEditProfileBinding
    private val viewModel: ProfileViewModel by viewModels()
    private lateinit var sessionManager: SessionManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityEditProfileBinding.inflate(layoutInflater)
        setContentView(binding.root)

        sessionManager = SessionManager(this)
        val userId = sessionManager.getUserId()

        viewModel.loadUserData(userId)

        viewModel.user.observe(this) { user ->
            user?.let {
                binding.etEditNome.setText(it.nome)
                binding.etEditEmail.setText(it.email)
            }
        }

        viewModel.updateStatus.observe(this) { success ->
            if (success) {
                sessionManager.saveSession(userId, binding.etEditNome.text.toString(), binding.etEditEmail.text.toString())
                Toast.makeText(this, R.string.profile_updated, Toast.LENGTH_SHORT).show()
                finish()
            }
        }

        binding.btnUpdateProfile.setOnClickListener {
            val nome = binding.etEditNome.text.toString()
            val email = binding.etEditEmail.text.toString()

            if (nome.isNotEmpty() && email.isNotEmpty()) {
                viewModel.updateProfile(userId, nome, email)
            } else {
                Toast.makeText(this, R.string.fill_all_fields, Toast.LENGTH_SHORT).show()
            }
        }
    }
}