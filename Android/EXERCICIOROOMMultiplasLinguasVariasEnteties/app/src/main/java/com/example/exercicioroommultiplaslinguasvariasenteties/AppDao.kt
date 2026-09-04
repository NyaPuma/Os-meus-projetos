package com.example.exercicioroommultiplaslinguasvariasenteties

import androidx.room.*

@Dao
interface AppDao {
    // Destino CRUD
    @Query("SELECT * FROM destinos")
    suspend fun getAllDestinos(): List<Destino>

    @Insert
    suspend fun insertDestino(destino: Destino)

    @Update
    suspend fun updateDestino(destino: Destino)

    @Delete
    suspend fun deleteDestino(destino: Destino)

    // Cliente
    @Insert
    suspend fun insertCliente(cliente: Cliente)
}
