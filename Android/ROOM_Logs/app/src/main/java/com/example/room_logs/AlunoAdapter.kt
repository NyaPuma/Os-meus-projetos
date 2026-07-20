package com.example.room_logs

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.example.room_logs.databinding.ItemAlunoBinding

class AlunoAdapter(
    private val onEdit: (AlunoModel) -> Unit,
    private val onDelete: (AlunoModel) -> Unit
) : ListAdapter<AlunoModel, AlunoAdapter.AlunoViewHolder>(AlunoDiffCallback()) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AlunoViewHolder {
        val binding = ItemAlunoBinding.inflate(
            LayoutInflater.from(parent.context),
            parent,
            false
        )
        return AlunoViewHolder(binding)
    }

    override fun onBindViewHolder(holder: AlunoViewHolder, position: Int) {
        holder.bind(getItem(position), onEdit, onDelete)
    }

    class AlunoViewHolder(private val binding: ItemAlunoBinding) :
        RecyclerView.ViewHolder(binding.root) {

        fun bind(aluno: AlunoModel, onEdit: (AlunoModel) -> Unit, onDelete: (AlunoModel) -> Unit) {
            binding.textNome.text = aluno.nome
            binding.textCurso.text = aluno.curso
            binding.textCidade.text = aluno.cidade
            binding.textIdLabel.text = binding.root.context.getString(R.string.id_label, aluno.id)
            
            binding.imgAlunoIcon.text = aluno.nome.take(1).uppercase()

            binding.buttonMore.setOnClickListener {
                showMenu(it, aluno, onEdit, onDelete)
            }

            binding.root.setOnClickListener { onEdit(aluno) }
        }

        private fun showMenu(view: android.view.View, aluno: AlunoModel, onEdit: (AlunoModel) -> Unit, onDelete: (AlunoModel) -> Unit) {
            val popup = androidx.appcompat.widget.PopupMenu(view.context, view)
            popup.menu.add(view.context.getString(R.string.editar)).setOnMenuItemClickListener {
                onEdit(aluno)
                true
            }
            popup.menu.add(view.context.getString(R.string.eliminar)).setOnMenuItemClickListener {
                onDelete(aluno)
                true
            }
            popup.show()
        }
    }

    class AlunoDiffCallback : DiffUtil.ItemCallback<AlunoModel>() {
        override fun areItemsTheSame(oldItem: AlunoModel, newItem: AlunoModel): Boolean {
            return oldItem.id == newItem.id
        }

        override fun areContentsTheSame(oldItem: AlunoModel, newItem: AlunoModel): Boolean {
            return oldItem == newItem
        }
    }
}
