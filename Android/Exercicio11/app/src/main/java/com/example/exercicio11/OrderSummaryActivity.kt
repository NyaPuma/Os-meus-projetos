package com.example.exercicio11

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio11.databinding.ActivityOrderSummaryBinding
import com.example.exercicio11.databinding.ItemSummaryBinding
import java.util.Locale

class OrderSummaryActivity : AppCompatActivity() {

    private lateinit var binding: ActivityOrderSummaryBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        binding = ActivityOrderSummaryBinding.inflate(layoutInflater)
        setContentView(binding.root)

        ViewCompat.setOnApplyWindowInsetsListener(binding.root) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        @Suppress("UNCHECKED_CAST")
        val selectedProducts = intent.getSerializableExtra("SELECTED_PRODUCTS") as? ArrayList<Product>

        displaySummary(selectedProducts)

        binding.buttonBackToMain.setOnClickListener {
            val intent = Intent(this, MainActivity::class.java)
            intent.flags = Intent.FLAG_ACTIVITY_CLEAR_TOP
            startActivity(intent)
        }
    }

    private fun displaySummary(products: ArrayList<Product>?) {
        if (products == null) return

        var total = 0.0
        val inflater = LayoutInflater.from(this)

        products.forEach { product ->
            val itemBinding = ItemSummaryBinding.inflate(inflater, binding.linearLayoutItems, true)
            itemBinding.textViewItemName.text = "${product.name} (x${product.quantity})"
            val subtotal = product.price * product.quantity
            itemBinding.textViewItemSubtotal.text = String.format(Locale.getDefault(), "%.2f €", subtotal)
            total += subtotal
        }

        binding.textViewTotalValue.text = String.format(Locale.getDefault(), "%.2f €", total)
    }
}