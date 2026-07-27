package com.example.retrofit

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.lifecycle.lifecycleScope
import com.example.retrofit.databinding.ActivityMainBinding
import kotlinx.coroutines.launch

class MainActivity : AppCompatActivity() {

    private val binding by lazy {
        ActivityMainBinding.inflate(layoutInflater)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        carregarPosts()
    }

    private fun carregarPosts() {
        lifecycleScope.launch {
            try {
                val posts = RetrofitClient.api.getPosts()
                binding.txtPost.text = posts.joinToString("\n\n") { post ->
                    "ID: ${post.id}\nTítulo: ${post.title}\nCorpo: ${post.body}"
                }
            } catch (e: Exception) {
                binding.txtPost.text = "Erro ao carregar posts: ${e.message}"
            }
        }
    }
}
