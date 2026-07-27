package com.example.exercicioroommultiplaslinguasvariasenteties.data.local

import androidx.room.*
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Cliente
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.User
import kotlinx.coroutines.flow.Flow

@Dao
interface AppDao {
    // Destino CRUD
    @Query("SELECT * FROM destinos")
    fun getAllDestinos(): Flow<List<Destino>>

    @Insert
    suspend fun insertDestino(destino: Destino)

    @Update
    suspend fun updateDestino(destino: Destino)

    @Delete
    suspend fun deleteDestino(destino: Destino)

    // Cliente
    @Insert
    suspend fun insertCliente(cliente: Cliente)

    @Query("SELECT COUNT(*) FROM clientes WHERE userId = :userId")
    suspend fun getBookingCountByUserId(userId: Int): Int

    // Utilizador
    @Insert
    suspend fun insertUser(user: User)

    @Update
    suspend fun updateUser(user: User)

    @Query("SELECT * FROM utilizadores WHERE email = :email LIMIT 1")
    suspend fun getUserByEmail(email: String): User?

    @Query("SELECT * FROM utilizadores WHERE id = :userId LIMIT 1")
    suspend fun getUserById(userId: Int): User?
}