package com.example.sqlite_logs.ui

import android.os.Bundle
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.sqlite_logs.R
import com.example.sqlite_logs.adapter.UtilizadorAdapter
import com.example.sqlite_logs.database.DBHelper
import com.example.sqlite_logs.databinding.ActivityMainBinding
import com.example.sqlite_logs.model.Utilizador

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    private lateinit var adapter: UtilizadorAdapter
    private lateinit var dbHelper: DBHelper
    private lateinit var lista: ArrayList<Utilizador>

    private var pos: Int = -1
            
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        //instanciar a classe DBHelper
        dbHelper = DBHelper(this)

        //carregar a lista de utilizadores da base de dados
        lista = dbHelper.utilizadorSelectAll()

        //configurar o RecyclerView
        binding.recyclerUtilizadores.layoutManager = LinearLayoutManager(this)

        //criar o adapter
        adapter = UtilizadorAdapter(lista) { posicao ->
            pos = posicao
            binding.textId.text = "ID: ${lista[pos].id}"
            binding.editUsername.setText(lista[pos].username)
            binding.editPassword.setText(lista[pos].password)
        }

        //associar o adapter ao RecyclerView
        binding.recyclerUtilizadores.adapter = adapter

        // Listeners dos botões
        binding.btnInserir.setOnClickListener {
            val username = binding.editUsername.text.toString()
            val password = binding.editPassword.text.toString()

            if (username.isNotEmpty() && password.isNotEmpty()) {
                val id = dbHelper.utilizadorInsert(username, password)
                if (id > 0L) {
                    val novo = Utilizador(id.toInt(), username, password)
                    adapter.insert(novo)
                    limparCampos()
                } else {
                    Toast.makeText(this, "Erro ao inserir", Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this, "Preencha todos os campos", Toast.LENGTH_SHORT).show()
            }
        }

        binding.btnEditar.setOnClickListener {
            if (pos >= 0) {
                val username = binding.editUsername.text.toString()
                val password = binding.editPassword.text.toString()

                if (username.isNotEmpty() && password.isNotEmpty()) {
                    val id = lista[pos].id
                    val result = dbHelper.utilizadorUpdate(id, username, password)
                    if (result > 0) {
                        val utilizadorAlterado = Utilizador(id, username, password)
                        adapter.update(utilizadorAlterado, pos)
                        limparCampos()
                    }
                }
            } else {
                Toast.makeText(this, "Selecione um utilizador", Toast.LENGTH_SHORT).show()
            }
        }

        binding.btnEliminar.setOnClickListener {
            if (pos >= 0) {
                val id = lista[pos].id
                val result = dbHelper.utilizadorDelete(id)
                if (result > 0) {
                    adapter.delete(pos)
                    limparCampos()
                }
            } else {
                Toast.makeText(this, "Selecione um utilizador", Toast.LENGTH_SHORT).show()
            }
        }
    }

    private fun limparCampos() {
        binding.textId.text = "ID:"
        binding.editUsername.setText("")
        binding.editPassword.setText("")
        pos = -1
    }
}
