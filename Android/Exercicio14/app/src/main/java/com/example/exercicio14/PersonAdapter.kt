package com.example.exercicio14

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.exercicio14.databinding.ItemPersonBinding

class PersonAdapter(
    private val names: List<String>,
    private val onClick: (String) -> Unit,
) : RecyclerView.Adapter<PersonAdapter.PersonViewHolder>() {

    inner class PersonViewHolder(private val binding: ItemPersonBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun bind(name: String) {
            binding.textViewName.text = name
            binding.root.setOnClickListener {
                onClick(name)
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): PersonViewHolder {
        val binding = ItemPersonBinding.inflate(
            LayoutInflater.from(parent.context),
            parent,
            false
        )
        return PersonViewHolder(binding)
    }

    override fun onBindViewHolder(holder: PersonViewHolder, position: Int) {
        holder.bind(names[position])
    }

    override fun getItemCount(): Int = names.size
}
