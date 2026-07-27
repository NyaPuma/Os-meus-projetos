package com.example.exercicioroommultiplaslinguasvariasenteties.ui.adapters

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.RecyclerView
import com.example.exercicioroommultiplaslinguasvariasenteties.R
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ItemDestinoBinding

class DestinoAdapter(
    private var destinos: List<Destino>,
    private val onEdit: (Destino) -> Unit,
    private val onDelete: (Destino) -> Unit,
    private val onReservar: (Destino) -> Unit,
) : RecyclerView.Adapter<DestinoAdapter.DestinoViewHolder>() {

    class DestinoViewHolder(val binding: ItemDestinoBinding) : RecyclerView.ViewHolder(binding.root)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): DestinoViewHolder {
        val binding = ItemDestinoBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return DestinoViewHolder(binding)
    }

    override fun onBindViewHolder(holder: DestinoViewHolder, position: Int) {
        val destino = destinos[position]
        with(holder.binding) {
            tvNomeDestino.text = destino.nomeDestino
            tvPais.text = destino.pais
            tvPreco.text = root.context.getString(R.string.price_format, destino.preco)

            btnEdit.setOnClickListener { onEdit(destino) }
            btnDelete.setOnClickListener { onDelete(destino) }
            btnReservar.setOnClickListener { onReservar(destino) }
        }
    }

    override fun getItemCount() = destinos.size

    fun updateList(newList: List<Destino>) {
        val diffResult = DiffUtil.calculateDiff(DestinoDiffCallback(destinos, newList))
        destinos = newList
        diffResult.dispatchUpdatesTo(this)
    }

    class DestinoDiffCallback(
        private val oldList: List<Destino>,
        private val newList: List<Destino>,
    ) : DiffUtil.Callback() {
        override fun getOldListSize() = oldList.size
        override fun getNewListSize() = newList.size
        override fun areItemsTheSame(oldItemPosition: Int, newItemPosition: Int): Boolean {
            return oldList[oldItemPosition].id == newList[newItemPosition].id
        }
        override fun areContentsTheSame(oldItemPosition: Int, newItemPosition: Int): Boolean {
            return oldList[oldItemPosition] == newList[newItemPosition]
        }
    }
}