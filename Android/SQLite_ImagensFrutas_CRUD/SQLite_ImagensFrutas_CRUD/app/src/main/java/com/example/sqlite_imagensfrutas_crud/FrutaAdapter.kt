package com.example.sqlite_imagensfrutas_crud

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.sqlite_imagensfrutas_crud.databinding.ItemFrutaBinding

class FrutaAdapter(
    private val listaFrutas: ArrayList<Fruta>,
    private val clique:(Int)->Unit

): RecyclerView.Adapter<FrutaAdapter.FrutaViewHolder>() {
    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): FrutaViewHolder {
        val binding = ItemFrutaBinding.inflate(LayoutInflater.from(parent.context),
            parent,
            false
        )
        return FrutaViewHolder(binding)
    }

    override fun onBindViewHolder(
        holder: FrutaViewHolder,
        position: Int
    ) {
        val fruta = listaFrutas[position]

        holder.binding.imageFruta.setImageResource(fruta.imagem)
        holder.binding.textFrutaNome.text = fruta.nome
        //detetar o clique
        holder.binding.root.setOnClickListener {
            clique(position)
        }


    }

    override fun getItemCount(): Int {
        return listaFrutas.size

    }

    class FrutaViewHolder(val binding: ItemFrutaBinding): RecyclerView.ViewHolder(binding.root)
}