package com.example.exercicio14

import android.os.Bundle
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.exercicio14.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val names = listOf("Ana", "Bruno", "Catarina", "Daniel", "Eva", "Filipe", "Guilherme", "Helena")

        binding.recyclerViewNames.layoutManager = LinearLayoutManager(this)
        binding.recyclerViewNames.adapter = PersonAdapter(names) { name ->
            Toast.makeText(this, "Olá $name", Toast.LENGTH_SHORT).show()
        }
    }
}