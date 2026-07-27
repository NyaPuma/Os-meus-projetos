package com.example.aplicaomobiledegestodestock.ui.products

import android.content.Intent
import android.os.Bundle
import android.view.View
import androidx.activity.viewModels
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.widget.addTextChangedListener
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.aplicaomobiledegestodestock.R
import com.example.aplicaomobiledegestodestock.StockApplication
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import com.example.aplicaomobiledegestodestock.databinding.ActivityProductsBinding
import com.example.aplicaomobiledegestodestock.ui.adapters.ProductAdapter
import com.example.aplicaomobiledegestodestock.ui.addproduct.AddProductActivity
import com.example.aplicaomobiledegestodestock.viewmodel.ProductsViewModel
import com.example.aplicaomobiledegestodestock.viewmodel.ProductsViewModelFactory
import com.google.android.material.chip.Chip
import com.google.android.material.snackbar.Snackbar

/**
 * Ecrã de Listagem de Produtos.
 * Implementa RecyclerView com suporte a cliques, filtros e ordenação dinâmica.
 */
class ProductsActivity : AppCompatActivity() {

    private lateinit var binding: ActivityProductsBinding
    private val viewModel: ProductsViewModel by viewModels {
        ProductsViewModelFactory((application as StockApplication).produtoRepository)
    }
    private val adapter = ProductAdapter(
        onItemClick = { produto ->
            val intent = Intent(this, AddProductActivity::class.java)
            intent.putExtra("PRODUCT_ID", produto.id)
            startActivity(intent)
        },
        onItemLongClick = { produto ->
            showDeleteConfirmation(produto)
        }
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityProductsBinding.inflate(layoutInflater)
        setContentView(binding.root)

        setupToolbar()
        setupRecyclerView()
        setupFilters()
        setupSearch()
        setupSort()
        setupSwipeRefresh()

        viewModel.products.observe(this) { products ->
            adapter.submitList(products)
            binding.tvEmptyState.visibility = if (products.isEmpty()) View.VISIBLE else View.GONE
            binding.swipeRefresh.isRefreshing = false
        }
    }

    private fun setupSwipeRefresh() {
        binding.swipeRefresh.setOnRefreshListener {
            // Room is reactive, so a simple "reload" isn't strictly necessary, 
            // but we can simulate it or trigger a manual refresh if needed.
            // Here we just keep the animation for a bit and then hide it.
            viewModel.setSearchQuery(binding.etSearch.text.toString())
        }
    }

    private fun showDeleteConfirmation(produto: Produto) {
        AlertDialog.Builder(this)
            .setTitle(R.string.delete_button)
            .setMessage(R.string.delete_product_confirmation)
            .setPositiveButton(R.string.delete_button) { _, _ ->
                viewModel.deleteProduct(produto)
                Snackbar.make(binding.root, R.string.product_deleted, Snackbar.LENGTH_LONG)
                    .setAction("Anular") {
                        viewModel.insertProduct(produto)
                    }.show()
            }
            .setNegativeButton(R.string.cancel_button, null)
            .show()
    }

    private fun setupToolbar() {
        binding.toolbar.setNavigationOnClickListener {
            onBackPressedDispatcher.onBackPressed()
        }
    }

    private fun setupRecyclerView() {
        binding.rvProducts.layoutManager = LinearLayoutManager(this)
        binding.rvProducts.adapter = adapter
    }

    private fun setupFilters() {
        val categories = listOf("Hardware", "Periféricos", "Portáteis", "Redes", "Software")
        categories.forEach { category ->
            val chip = Chip(this)
            chip.text = category
            chip.isCheckable = true
            chip.setOnClickListener {
                if (chip.isChecked) {
                    viewModel.setCategory(category)
                } else {
                    viewModel.setCategory("Todas")
                }
            }
            binding.chipGroupFilter.addView(chip)
        }
        
        binding.chipAll.setOnClickListener {
            viewModel.setCategory("Todas")
        }
    }

    private fun setupSearch() {
        binding.etSearch.addTextChangedListener { text ->
            viewModel.setSearchQuery(text?.toString() ?: "")
        }
    }

    private fun setupSort() {
        binding.fabSort.setOnClickListener {
            val options = arrayOf("Stock (Crescente)", "Stock (Decrescente)", "Sem Ordenação")
            AlertDialog.Builder(this)
                .setTitle("Ordenar por")
                .setItems(options) { _, which ->
                    val order = when (which) {
                        0 -> ProductsViewModel.SortOrder.STOCK_ASC
                        1 -> ProductsViewModel.SortOrder.STOCK_DESC
                        else -> ProductsViewModel.SortOrder.NONE
                    }
                    viewModel.setSortOrder(order)
                }
                .show()
        }
    }
}
