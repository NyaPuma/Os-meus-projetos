package com.example.exercicio13

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicio13.databinding.ActivitySobreBinding

class SobreActivity : AppCompatActivity() {

    private lateinit var binding: ActivitySobreBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySobreBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnVoltarSobre.setOnClickListener {
            finish()
        }
    }
}
