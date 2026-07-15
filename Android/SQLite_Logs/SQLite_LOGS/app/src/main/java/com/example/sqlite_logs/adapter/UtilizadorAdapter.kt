package com.example.sqlite_logs.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.sqlite_logs.databinding.ItemUtilizadorBinding
import com.example.sqlite_logs.model.Utilizador

class UtilizadorAdapter(
    private val lista: ArrayList<Utilizador>,
    private val clique:(Int)-> Unit //o adapter envia á Main apenas a posisão de volta
): RecyclerView.Adapter<UtilizadorAdapter.UtilizadorViewHolder>()
{
    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): UtilizadorViewHolder {
        val binding= ItemUtilizadorBinding.inflate(LayoutInflater.from(parent.context),
            parent,false)
        return UtilizadorViewHolder(binding)
    }

    override fun onBindViewHolder(
        holder: UtilizadorViewHolder,
        position: Int
    ) {
        val utilizadorActual =lista [position]
        //acedemos á text view
        holder.binding.textItemInfo.text=utilizadorActual.toString()
        //deteta o  clique na linha
        holder.binding.root.setOnClickListener {
            clique(position)
        }
    }

    override fun getItemCount(): Int {
        return lista.size
    }


    class UtilizadorViewHolder(val binding: ItemUtilizadorBinding):
            RecyclerView.ViewHolder(binding.root)
}