package com.example.exercicioroommultiplaslinguasvariasenteties

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class DestinoAdapter(
    private var destinos: List<Destino>,
    private val onEdit: (Destino) -> Unit,
    private val onDelete: (Destino) -> Unit,
    private val onReservar: (Destino) -> Unit
) : RecyclerView.Adapter<DestinoAdapter.DestinoViewHolder>() {

    class DestinoViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val tvNome: TextView = view.findViewById(R.id.tvNomeDestino)
        val tvLocalizacao: TextView = view.findViewById(R.id.tvLocalizacao)
        val tvPreco: TextView = view.findViewById(R.id.tvPreco)
        val btnEdit: Button = view.findViewById(R.id.btnEdit)
        val btnDelete: Button = view.findViewById(R.id.btnDelete)
        val btnReservar: Button = view.findViewById(R.id.btnReservar)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): DestinoViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_destino, parent, false)
        return DestinoViewHolder(view)
    }

    override fun onBindViewHolder(holder: DestinoViewHolder, position: Int) {
        val destino = destinos[position]
        holder.tvNome.text = destino.nome
        holder.tvLocalizacao.text = destino.localizacao
        holder.tvPreco.text = "${destino.preco}€"

        holder.btnEdit.setOnClickListener { onEdit(destino) }
        holder.btnDelete.setOnClickListener { onDelete(destino) }
        holder.btnReservar.setOnClickListener { onReservar(destino) }
    }

    override fun getItemCount() = destinos.size

    fun updateList(newList: List<Destino>) {
        destinos = newList
        notifyDataSetChanged()
    }
}
