package com.example.exercicioroommultiplaslinguasvariasenteties.data.model

import java.io.Serializable
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "destinos")
data class Destino(
    @PrimaryKey(autoGenerate = true) val id: Int = 0,
    val nomeDestino: String,
    val pais: String,
    val preco: Double,
) : Serializable