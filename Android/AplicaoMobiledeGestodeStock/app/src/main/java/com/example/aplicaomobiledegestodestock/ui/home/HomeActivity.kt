package com.example.aplicaomobiledegestodestock.ui.home

import android.content.Intent
import android.os.Bundle
import android.view.Menu
import android.view.MenuItem
import androidx.activity.viewModels
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.app.AppCompatDelegate
import androidx.core.os.LocaleListCompat
import com.example.aplicaomobiledegestodestock.R
import com.example.aplicaomobiledegestodestock.StockApplication
import com.example.aplicaomobiledegestodestock.databinding.ActivityHomeBinding
import com.example.aplicaomobiledegestodestock.ui.addproduct.AddProductActivity
import com.example.aplicaomobiledegestodestock.ui.login.LoginActivity
import com.example.aplicaomobiledegestodestock.ui.products.ProductsActivity
import com.example.aplicaomobiledegestodestock.viewmodel.HomeViewModel
import com.example.aplicaomobiledegestodestock.viewmodel.HomeViewModelFactory

/**
 * Ecrã Principal (Dashboard) da aplicação.
 * Exibe um resumo do inventário e fornece acesso às funcionalidades principais.
 */
class HomeActivity : AppCompatActivity() {

    private lateinit var binding: ActivityHomeBinding
    private val viewModel: HomeViewModel by viewModels {
        val app = application as StockApplication
        HomeViewModelFactory(app.produtoRepository, app.sessionManager)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityHomeBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // Configurar Toolbar para suportar menu
        setSupportActionBar(binding.toolbar)

        viewModel.userName.observe(this) { name ->
            binding.tvWelcome.text = getString(R.string.welcome_message, name ?: "")
        }

        viewModel.totalProducts.observe(this) { count ->
            binding.tvTotalProducts.text = (count ?: 0).toString()
        }

        viewModel.totalStock.observe(this) { stock ->
            binding.tvTotalStock.text = (stock ?: 0).toString()
        }

        binding.btnRegisterProduct.setOnClickListener {
            startActivity(Intent(this, AddProductActivity::class.java))
        }

        binding.btnViewProducts.setOnClickListener {
            startActivity(Intent(this, ProductsActivity::class.java))
        }

        binding.btnLogout.setOnClickListener {
            viewModel.logout()
            val intent = Intent(this, LoginActivity::class.java)
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
            startActivity(intent)
            finish()
        }
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.home_menu, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        return when (item.itemId) {
            R.id.action_language -> {
                showLanguageDialog()
                true
            }
            else -> super.onOptionsItemSelected(item)
        }
    }

    private fun showLanguageDialog() {
        val languages = arrayOf("Português", "English")
        val codes = arrayOf("pt", "en")

        AlertDialog.Builder(this)
            .setTitle(R.string.action_language)
            .setItems(languages) { _, which ->
                val appLocale: LocaleListCompat = LocaleListCompat.forLanguageTags(codes[which])
                AppCompatDelegate.setApplicationLocales(appLocale)
            }
            .show()
    }
}
