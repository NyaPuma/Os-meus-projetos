package com.example.exercicioroommultiplaslinguasvariasenteties

import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ActivityChangePasswordBinding

class ChangePasswordActivity : AppCompatActivity() {
    private lateinit var binding: ActivityChangePasswordBinding
    private val viewModel: ProfileViewModel by viewModels()
    private lateinit var sessionManager: SessionManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityChangePasswordBinding.inflate(layoutInflater)
        setContentView(binding.root)

        sessionManager = SessionManager(this)
        val userId = sessionManager.getUserId()

        viewModel.updateStatus.observe(this) { success ->
            if (success) {
                Toast.makeText(this, R.string.password_changed, Toast.LENGTH_SHORT).show()
                finish()
            }
        }

        viewModel.error.observe(this) { error ->
            Toast.makeText(this, error, Toast.LENGTH_SHORT).show()
        }

        binding.btnSubmitChangePassword.setOnClickListener {
            val current = binding.etCurrentPassword.text.toString()
            val new = binding.etNewPassword.text.toString()
            val confirm = binding.etConfirmNewPassword.text.toString()

            if (current.isNotEmpty() && new.isNotEmpty() && confirm.isNotEmpty()) {
                if (new == confirm) {
                    viewModel.changePassword(userId, current, new)
                } else {
                    Toast.makeText(this, R.string.passwords_dont_match, Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this, R.string.fill_all_fields, Toast.LENGTH_SHORT).show()
            }
        }
    }
}