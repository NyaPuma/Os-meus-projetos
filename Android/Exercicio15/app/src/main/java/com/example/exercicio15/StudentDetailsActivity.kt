package com.example.exercicio15

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio15.databinding.ActivityStudentDetailsBinding

class StudentDetailsActivity : AppCompatActivity() {
    private lateinit var binding: ActivityStudentDetailsBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityStudentDetailsBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(binding.detailsMain) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val student = intent.getSerializableExtra("STUDENT") as? Student

        if (student != null) {
            binding.textViewDetailNome.text = "Nome: ${student.nome}"
            binding.textViewDetailMorada.text = "Morada: ${student.morada}"
            binding.textViewDetailEmail.text = "Email: ${student.email}"
        }
    }
}
