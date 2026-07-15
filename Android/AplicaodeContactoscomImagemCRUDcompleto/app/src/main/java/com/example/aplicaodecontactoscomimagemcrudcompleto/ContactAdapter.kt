package com.example.aplicaodecontactoscomimagemcrudcompleto

import android.content.res.ColorStateList
import android.graphics.Color
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.core.net.toUri
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.example.aplicaodecontactoscomimagemcrudcompleto.databinding.ContactItemBinding

class ContactAdapter(
    private val onEditClick: (Contact) -> Unit,
    private val onDeleteClick: (Contact) -> Unit
) : ListAdapter<Contact, ContactAdapter.ContactViewHolder>(ContactDiffCallback()) {

    class ContactViewHolder(val binding: ContactItemBinding) : RecyclerView.ViewHolder(binding.root)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ContactViewHolder {
        val binding = ContactItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ContactViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ContactViewHolder, position: Int) {
        val contact = getItem(position)
        holder.binding.txtName.text = contact.name
        holder.binding.txtPhone.text = contact.phone

        if (contact.imageUri != null) {
            val bitmap = BitmapUtils.decodeSampledBitmapFromUri(holder.itemView.context, contact.imageUri.toUri(), 200, 200)
            holder.binding.imgContact.setImageBitmap(bitmap)
            holder.binding.imgContact.imageTintList = null
        } else {
            holder.binding.imgContact.setImageResource(android.R.drawable.ic_menu_gallery)
            holder.binding.imgContact.imageTintList = ColorStateList.valueOf(Color.WHITE)
        }

        holder.binding.btnEdit.setOnClickListener { onEditClick(contact) }
        holder.binding.btnDelete.setOnClickListener { onDeleteClick(contact) }
    }

    class ContactDiffCallback : DiffUtil.ItemCallback<Contact>() {
        override fun areItemsTheSame(oldItem: Contact, newItem: Contact): Boolean {
            return oldItem.id == newItem.id
        }

        override fun areContentsTheSame(oldItem: Contact, newItem: Contact): Boolean {
            return oldItem == newItem
        }
    }
}

