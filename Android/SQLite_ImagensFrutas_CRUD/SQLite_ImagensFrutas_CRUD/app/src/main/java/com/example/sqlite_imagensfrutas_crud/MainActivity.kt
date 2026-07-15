package com.example.sqlite_imagensfrutas_crud

import android.os.Bundle
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.sqlite_imagensfrutas_crud.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    private lateinit var db: DBHelper
    private lateinit var listaFrutas: ArrayList<Fruta>
    private lateinit var adapter: FrutaAdapter

    private var pos:Int=-1

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
        // 1. Criar DBHelper
        db = DBHelper(this)

        // 2. Ler frutas da base de dados
        listaFrutas = db.frutaListSelectAll(this)



        // 4. Configurar RecyclerView
        binding.recyclerView.layoutManager = LinearLayoutManager(this)


        //inicialização do adapter passando a lista e a função que trata do clique
        adapter= FrutaAdapter(listaFrutas){
            posicaoclicada->
            pos=posicaoclicada

            //passar os dados da fruta selecionada para os campos do ecra

            binding.editNome.setText(listaFrutas[pos].nome)
            binding.editImagemNome.setText(
                db.frutaSelectImagemNomeById(listaFrutas[pos].id)
            )

            //mostrar a imagem
            binding.imagePreview.setImageResource(listaFrutas[pos].imagem)

        }
        binding.recyclerView.adapter=adapter

        //BUTOES

        binding.btnInserir.setOnClickListener {

            val nome = binding.editNome.text.toString().trim()
            var imagemNome = binding.editImagemNome.text.toString().trim()

            // se o utilizador não escrever nome da imagem → usar default
            if (imagemNome.isEmpty()) {
                imagemNome = "default_image"
            }

            // inserir na BD
            val res =db.frutaInsert(nome, imagemNome)

            if(res>0){
                Toast.makeText(this, "Fruta inserida", Toast.LENGTH_LONG).show()

// converter nome do ficheiro → resource ID
                val imagemResId = resources.getIdentifier(
                    imagemNome,
                    "drawable",
                    packageName
                )
                // adicionar à lista atual sem recriar adapter
                listaFrutas.add(
                    Fruta(res.toInt(), nome, imagemResId))
                // atualizar RecyclerView
                adapter.notifyDataSetChanged()

                // limpar campos
                binding.editNome.text.clear()
                binding.editImagemNome.text.clear()
            }else{
                Toast.makeText(this, "ERRO ao inserir", Toast.LENGTH_LONG).show()

            }



        }

        binding.btnUpdate.setOnClickListener {

            val novoNome = binding.editNome.text.toString().trim()
            var novaImagemNome = binding.editImagemNome.text.toString().trim()

            if (novaImagemNome.isEmpty()) {
                novaImagemNome = "default_image"
            }

            //se clicar no botão UPDATE sem ter selecionado nenhum item, pos continua a ser -1 (o valor inicial) a app cracha
            if (pos >= 0) {

                val idFruta = listaFrutas[pos].id

                // atualizar na BD
                val res = db.frutaUpdate(idFruta, novoNome, novaImagemNome)

                if (res > 0) {

                    // converter nome do ficheiro → resource ID
                    val imagemResId = resources.getIdentifier(
                        novaImagemNome,
                        "drawable",
                        packageName
                    )

                    // atualizar o objeto na lista (mesma lógica do inserir)
                    listaFrutas[pos] = Fruta(idFruta, novoNome, imagemResId)

                    // atualizar RecyclerView
                    adapter.notifyDataSetChanged()

                    // limpar campos
                    binding.editNome.text.clear()
                    binding.editImagemNome.text.clear()
                    binding.imagePreview.setImageResource(0)

                    pos = -1

                    Toast.makeText(this, "Fruta atualizada", Toast.LENGTH_LONG).show()

                } else {
                    Toast.makeText(this, "ERRO ao atualizar", Toast.LENGTH_LONG).show()
                }
            }
        }

        binding.btnDelete.setOnClickListener {

            if (pos >= 0) {

                val idFruta = listaFrutas[pos].id

                // apagar da BD
                val res = db.frutaDelete(idFruta)

                if (res > 0) {

                    // remover da lista (mesma lógica do inserir, mas ao contrário)
                    listaFrutas.removeAt(pos)

                    // atualizar RecyclerView
                    adapter.notifyDataSetChanged()

                    // limpar campos
                    binding.editNome.text.clear()
                    binding.editImagemNome.text.clear()
                    binding.imagePreview.setImageResource(0)

                    pos = -1

                    Toast.makeText(this, "Fruta eliminada", Toast.LENGTH_LONG).show()

                } else {
                    Toast.makeText(this, "ERRO ao eliminar", Toast.LENGTH_LONG).show()
                }
            }
        }




    }


}