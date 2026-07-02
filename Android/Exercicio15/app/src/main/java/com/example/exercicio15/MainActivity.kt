package com.example.exercicio15

import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.exercicio15.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        binding.recyclerViewStudents.layoutManager = LinearLayoutManager(this)

        val students = listOf(
            Student("Ana Silva",      "Rua A, 123",      "ana@example.com"),
            Student("Bruno Santos",   "Avenida B, 456",  "bruno@example.com"),
            Student("Carla Oliveira", "Travessa C, 789", "carla@example.com"),
            Student("Daniel Pereira", "Rua D, 101",      "daniel@example.com")
        )

        val adapter = StudentAdapter(students) { student ->
            val intent = Intent(this, StudentDetailsActivity::class.java)
            intent.putExtra("STUDENT", student)
            startActivity(intent)
        }

        binding.recyclerViewStudents.adapter = adapter
    }
}
