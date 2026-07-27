package com.example.aplicaomobiledegestodestock.ui.addproduct

import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.example.aplicaomobiledegestodestock.R
import com.example.aplicaomobiledegestodestock.StockApplication
import com.example.aplicaomobiledegestodestock.databinding.ActivityAddProductBinding
import com.example.aplicaomobiledegestodestock.viewmodel.AddProductViewModel
import com.example.aplicaomobiledegestodestock.viewmodel.AddProductViewModelFactory
import kotlinx.coroutines.launch

/**
 * Activity para Adicionar ou Editar um Produto.
 * Demonstra a integração entre ViewBinding, ViewModel e LiveData.
 */
class AddProductActivity : AppCompatActivity() {

    private lateinit var binding: ActivityAddProductBinding
    private val viewModel: AddProductViewModel by viewModels {
        AddProductViewModelFactory((application as StockApplication).produtoRepository)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityAddProductBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val productId = intent.getIntExtra("PRODUCT_ID", 0)
        if (productId != 0) {
            binding.toolbar.title = getString(R.string.edit_product_title)
            viewModel.loadProduct(productId)
        }

        setupToolbar()
        setupCategorySpinner()

        viewModel.product.observe(this) { produto ->
            produto?.let {
                binding.etProductName.setText(it.nome)
                binding.spinnerCategory.setText(it.categoria, false)
                binding.etQuantity.setText(it.quantidade.toString())
                binding.etPrice.setText(it.preco.toString())
                binding.etDescription.setText(it.descricao)
                binding.etSupplier.setText(it.fornecedor)
            }
        }

        binding.btnSave.setOnClickListener {
            viewModel.saveProduct(
                binding.etProductName.text.toString(),
                binding.spinnerCategory.text.toString(),
                binding.etQuantity.text.toString(),
                binding.etPrice.text.toString(),
                binding.etDescription.text.toString(),
                binding.etSupplier.text.toString()
            )
        }

        lifecycleScope.launch {
            viewModel.saveResult.collect { success ->
                if (success) {
                    Toast.makeText(this@AddProductActivity, "Produto guardado!", Toast.LENGTH_SHORT).show()
                    finish()
                }
            }
        }

        lifecycleScope.launch {
            viewModel.error.collect { message ->
                Toast.makeText(this@AddProductActivity, message, Toast.LENGTH_SHORT).show()
            }
        }
    }

    /**
     * Configura a Toolbar e a lógica de "Retroceder".
     * Ao clicar no ícone de navegação, a atividade é encerrada, voltando ao ecrã anterior.
     */
    private fun setupToolbar() {
        binding.toolbar.setNavigationOnClickListener {
            onBackPressedDispatcher.onBackPressed()
        }
    }

    private fun setupCategorySpinner() {
        val categories = arrayOf("Hardware", "Periféricos", "Portáteis", "Redes", "Software")
        val adapter = ArrayAdapter(this, android.R.layout.simple_dropdown_item_1line, categories)
        binding.spinnerCategory.setAdapter(adapter)
    }
}
