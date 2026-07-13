package com.example.sqlite_logs.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.sqlite_logs.databinding.ItemUtilizadorBinding
import com.example.sqlite_logs.model.Utilizador

class UtilizadorAdapter(
    private val lista: ArrayList<Utilizador>,
    private val clique: (Int) -> Unit //o adapter envia a Main apenas a posição de volta
): RecyclerView.Adapter<UtilizadorAdapter.UtilizadorViewHolder>()

{
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UtilizadorViewHolder {
        val binding = ItemUtilizadorBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return UtilizadorViewHolder(binding)
    }

    override fun onBindViewHolder(holder: UtilizadorViewHolder, position: Int) {
        val utilizador = lista[position]
        holder.binding.textItemInfo.text = "ID: ${utilizador.id} | Utilizador: ${utilizador.username}"
        holder.itemView.setOnClickListener {
            clique(position)
        }
    }

    override fun getItemCount(): Int = lista.size

    // Métodos para manipulação da lista (Insert, UPDATE, DELETE)
    fun insert(utilizador: Utilizador) {
        lista.add(utilizador)
        notifyItemInserted(lista.size - 1)
    }

    fun update(utilizador: Utilizador, position: Int) {
        lista[position] = utilizador
        notifyItemChanged(position)
    }

    fun delete(position: Int) {
        lista.removeAt(position)
        notifyItemRemoved(position)
        notifyItemRangeChanged(position, lista.size)
    }

    class UtilizadorViewHolder(val binding: ItemUtilizadorBinding):
        RecyclerView.ViewHolder(binding.root)
}
