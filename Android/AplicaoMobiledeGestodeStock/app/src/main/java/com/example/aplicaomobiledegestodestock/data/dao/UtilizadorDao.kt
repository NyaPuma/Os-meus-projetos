package com.example.aplicaomobiledegestodestock.data.dao

import androidx.room.*
import com.example.aplicaomobiledegestodestock.data.entity.Utilizador

/**
 * DAO para a entidade Utilizador.
 * Gere as operações de autenticação e registo de utilizadores.
 */
@Dao
interface UtilizadorDao {
    @Query("SELECT * FROM utilizadores WHERE username = :username AND password = :password LIMIT 1")
    suspend fun login(username: String, password: String): Utilizador?

    @Query("SELECT * FROM utilizadores WHERE username = :username LIMIT 1")
    suspend fun getByUsername(username: String): Utilizador?

    @Insert(onConflict = OnConflictStrategy.IGNORE)
    suspend fun insert(utilizador: Utilizador)

    @Query("SELECT COUNT(*) FROM utilizadores")
    suspend fun count(): Int
}
