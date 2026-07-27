package com.example.aplicaomobiledegestodestock.data.entity

import androidx.room.Entity
import androidx.room.PrimaryKey

/**
 * Entidade que representa um Produto na base de dados Room.
 * Cada instância desta classe corresponde a uma linha na tabela "produtos".
 */
@Entity(tableName = "produtos")
data class Produto(
    @PrimaryKey(autoGenerate = true)
    val id: Int = 0,
    val nome: String,
    val categoria: String,
    val quantidade: Int,
    val preco: Double,
    val descricao: String = "",
    val fornecedor: String = ""
)
