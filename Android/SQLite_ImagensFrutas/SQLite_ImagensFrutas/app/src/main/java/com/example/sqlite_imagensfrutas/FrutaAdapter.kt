package com.example.sqlite_imagensfrutas

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.sqlite_imagensfrutas.databinding.ItemFrutaBinding

class FrutaAdapter(
    private val listaFrutas: ArrayList<Fruta>
): RecyclerView.Adapter<FrutaAdapter.FrutaViewHolder>()
{
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
    }
    override fun getItemCount(): Int {
        return listaFrutas.size
    }


    class FrutaViewHolder(val binding: ItemFrutaBinding): RecyclerView.ViewHolder(binding.root)
}