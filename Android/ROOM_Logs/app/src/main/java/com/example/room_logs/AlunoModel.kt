package com.example.room_logs

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity("Aluno")
data class AlunoModel(
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo("ID")
    val id: Int? = null,

    @ColumnInfo("nome")
    val nome: String,
    @ColumnInfo("curso")
    val curso: String,
    @ColumnInfo("cidade")
    val cidade: String
) {
    override fun toString(): String {
        return "nome=$nome | curso=$curso | cidade=$cidade"
    }
}
