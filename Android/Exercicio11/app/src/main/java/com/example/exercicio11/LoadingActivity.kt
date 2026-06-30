package com.example.exercicio11

import android.content.Intent
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.view.View
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.IntentCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class LoadingActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_loading)

        val root = findViewById<View>(R.id.loading_root)
        ViewCompat.setOnApplyWindowInsetsListener(root) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val selectedProducts = IntentCompat.getSerializableExtra(
            intent,
            "SELECTED_PRODUCTS",
            ArrayList::class.java
        )

        Handler(Looper.getMainLooper()).postDelayed({
            val intent = Intent(this, OrderSummaryActivity::class.java)
            intent.putExtra("SELECTED_PRODUCTS", selectedProducts)
            startActivity(intent)
            finish()
        }, 2000)
    }
}
