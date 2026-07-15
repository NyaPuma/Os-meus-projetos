package com.example.sqlite_logs.ui

import android.os.Binder
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
    private lateinit var listautilizadores: ArrayList<Utilizador>

    private var pos:Int =-1




    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding= ActivityMainBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        //instaciar a classe base de dados

        val db= DBHelper(this)
        //carregar a lista vinda da base de dados

        listautilizadores=db.utilizdorListSelectALL()

        //configurar a RecyclerView
        binding.recyclerView.layoutManager= LinearLayoutManager(this)

        //inicio o adapter passando a lista que veio da base de dados
        adapter= UtilizadorAdapter(listautilizadores){
            posicao->
            pos=posicao
            binding.textId.text="ID: ${listautilizadores[pos].id}"
            binding.editUsername.setText(listautilizadores[pos].username)
            binding.editPassword.setText(listautilizadores[pos].password)
        }

       //associar o adapter á receyclerView

        binding.recyclerView.adapter=adapter

        //BOTAO INSERIR

        binding.btnInserir.setOnClickListener {

            val username =binding.editUsername.text.toString()
            val password = binding.editUsername.text.toString()

            //validação
            if(username.isNotEmpty() && password.isNotEmpty()){
                val res =db.utilizadorInsert(username,password)
                if(res >0){
                    Toast.makeText(this,"Dados inseridos com sucesso", Toast.LENGTH_LONG).show()

                    //adição do novovo objeto á lista
                    listautilizadores.add(Utilizador(res.toInt(),username,password))
                    //notificar o adpeter de que hove uma alteração

                    adapter.notifyItemInserted(listautilizadores.size-1)

                }else{
                    Toast.makeText(this,"Erro ao inserir", Toast.LENGTH_LONG).show()
                }

            }else{
                Toast.makeText(this,"Preencha os campos", Toast.LENGTH_LONG).show()
            }
        }

    }
}