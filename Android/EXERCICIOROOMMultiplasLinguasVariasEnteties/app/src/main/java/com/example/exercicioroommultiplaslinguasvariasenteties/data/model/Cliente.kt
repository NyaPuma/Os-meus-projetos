package com.example.exercicioroommultiplaslinguasvariasenteties.data.model

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "clientes")
data class Cliente(
    @PrimaryKey(autoGenerate = true) val id: Int = 0,
    val userId: Int,
    val nomeCliente: String,
    val email: String,
    val telefone: String,
    val viagemEscolhida: String,
)