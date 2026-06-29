package com.example.exercicio9

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class ControlPanelActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_control_panel)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.control_panel)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val buttonMetrics = findViewById<Button>(R.id.buttonMetrics)
        buttonMetrics.setOnClickListener {
            val intent = Intent(this, MetricsActivity::class.java)
            startActivity(intent)
        }
    }
}
