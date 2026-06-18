package com.example.exercicio2

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import java.util.Locale

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val editCelsius = findViewById<EditText>(R.id.editCelsius)
        val btnConvert = findViewById<Button>(R.id.btnConvert)
        val txtResult = findViewById<TextView>(R.id.txtResult)

        btnConvert.setOnClickListener {
            val celsiusStr = editCelsius.text.toString()
            if (celsiusStr.isNotEmpty()) {
                try {
                    val celsius = celsiusStr.toDouble()
                    val fahrenheit = (celsius * 1.8) + 32
                    txtResult.text = String.format(Locale.getDefault(), "%.2f °F", fahrenheit)
                } catch (_: NumberFormatException) {
                    Toast.makeText(this, "Valor inválido", Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this, "Por favor insira um valor", Toast.LENGTH_SHORT).show()
            }
        }
    }
}
