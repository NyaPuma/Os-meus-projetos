package com.example.aplicaomobiledegestodestock.ui.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.content.ContextCompat
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.example.aplicaomobiledegestodestock.R
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import com.example.aplicaomobiledegestodestock.databinding.ItemProductBinding

class ProductAdapter(
    private val onItemClick: (Produto) -> Unit,
    private val onItemLongClick: (Produto) -> Unit
) : ListAdapter<Produto, ProductAdapter.ProductViewHolder>(ProductDiffCallback()) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ProductViewHolder {
        val binding = ItemProductBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ProductViewHolder(binding, onItemClick, onItemLongClick)
    }

    override fun onBindViewHolder(holder: ProductViewHolder, position: Int) {
        holder.bind(getItem(position))
    }

    class ProductViewHolder(
        private val binding: ItemProductBinding,
        private val onItemClick: (Produto) -> Unit,
        private val onItemLongClick: (Produto) -> Unit
    ) : RecyclerView.ViewHolder(binding.root) {
        fun bind(produto: Produto) {
            val context = binding.root.context
            binding.tvProductName.text = produto.nome
            binding.tvProductCategory.text = produto.categoria
            binding.tvProductPrice.text = context.getString(R.string.price_format, produto.preco)
            binding.tvProductQuantity.text = context.getString(R.string.quantity_label, produto.quantidade)

            val colorRes = when (produto.categoria) {
                "Hardware" -> R.color.cat_hardware
                "Periféricos" -> R.color.cat_peripherals
                "Portáteis" -> R.color.cat_laptops
                "Redes" -> R.color.cat_networking
                "Software" -> R.color.cat_software
                else -> R.color.primary
            }
            binding.viewCategoryColor.setBackgroundColor(ContextCompat.getColor(binding.root.context, colorRes))

            if (produto.quantidade < 5) {
                binding.tvLowStock.visibility = View.VISIBLE
                binding.tvProductQuantity.setTextColor(ContextCompat.getColor(binding.root.context, R.color.low_stock))
            } else {
                binding.tvLowStock.visibility = View.GONE
                binding.tvProductQuantity.setTextColor(ContextCompat.getColor(binding.root.context, R.color.black))
            }

            binding.root.setOnClickListener { onItemClick(produto) }
            binding.root.setOnLongClickListener {
                onItemLongClick(produto)
                true
            }
        }
    }

    class ProductDiffCallback : DiffUtil.ItemCallback<Produto>() {
        override fun areItemsTheSame(oldItem: Produto, newItem: Produto): Boolean = oldItem.id == newItem.id
        override fun areContentsTheSame(oldItem: Produto, newItem: Produto): Boolean = oldItem == newItem
    }
}
