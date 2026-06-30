package com.example.exercicio11

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.exercicio11.databinding.ActivityMainBinding
import com.example.exercicio11.databinding.ItemProductBinding
import java.io.Serializable
import java.util.Locale

data class Product(
    val name: String,
    val price: Double,
    val imageRes: Int,
    var quantity: Int = 1,
    var isSelected: Boolean = false,
) : Serializable

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private lateinit var adapter: ProductAdapter

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

        setupRecyclerView()

        binding.btnPlaceOrder.setOnClickListener {
            val selectedProducts = adapter.products.filter { it.isSelected }
            if (selectedProducts.isEmpty()) {
                Toast.makeText(this, "Por favor, selecione pelo menos um produto", Toast.LENGTH_SHORT).show()
            } else {
                val intent = Intent(this, SplashActivity::class.java)
                intent.putExtra("SELECTED_PRODUCTS", ArrayList(selectedProducts))
                startActivity(intent)
            }
        }
    }

    private fun setupRecyclerView() {
        val products = listOf(
            Product("Café", 0.80, android.R.drawable.ic_menu_report_image),
            Product("Pão", 0.20, android.R.drawable.ic_menu_report_image),
            Product("Chocolate", 1.50, android.R.drawable.ic_menu_report_image),
            Product("Sumo de Laranja", 2.50, android.R.drawable.ic_menu_report_image),
            Product("Torrada", 1.20, android.R.drawable.ic_menu_report_image),
            Product("Croissant", 1.80, android.R.drawable.ic_menu_report_image)
        )

        adapter = ProductAdapter(products)
        binding.recyclerViewProducts.layoutManager = LinearLayoutManager(this)
        binding.recyclerViewProducts.adapter = adapter
    }
}

class ProductAdapter(val products: List<Product>) : RecyclerView.Adapter<ProductAdapter.ProductViewHolder>() {

    class ProductViewHolder(val binding: ItemProductBinding) : RecyclerView.ViewHolder(binding.root)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ProductViewHolder {
        val binding = ItemProductBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ProductViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ProductViewHolder, position: Int) {
        val product = products[position]
        holder.binding.textViewProductName.text = product.name
        holder.binding.textViewProductPrice.text = String.format(Locale.getDefault(), "%.2f €", product.price)
        holder.binding.imageViewProduct.setImageResource(product.imageRes)
        
        holder.binding.checkBoxSelect.isChecked = product.isSelected
        holder.binding.textViewQuantity.text = product.quantity.toString()

        // Enable/disable quantity buttons based on selection
        updateQuantityVisibility(holder, product.isSelected)

        holder.binding.checkBoxSelect.setOnCheckedChangeListener { _, isChecked ->
            product.isSelected = isChecked
            updateQuantityVisibility(holder, isChecked)
        }

        holder.binding.btnPlus.setOnClickListener {
            product.quantity++
            holder.binding.textViewQuantity.text = product.quantity.toString()
        }

        holder.binding.btnMinus.setOnClickListener {
            if (product.quantity > 1) {
                product.quantity--
                holder.binding.textViewQuantity.text = product.quantity.toString()
            }
        }
    }

    private fun updateQuantityVisibility(holder: ProductViewHolder, isSelected: Boolean) {
        holder.binding.layoutQuantity.visibility = if (isSelected) View.VISIBLE else View.INVISIBLE
    }

    override fun getItemCount() = products.size
}