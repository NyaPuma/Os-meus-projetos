package com.example.aplicaomobiledegestodestock.data.dao

import androidx.room.*
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import kotlinx.coroutines.flow.Flow

/**
 * DAO (Data Access Object) para a entidade Produto.
 * Define as operações de base de dados utilizando a biblioteca Room.
 * O uso de Flow permite uma programação reativa, onde a UI é notificada automaticamente
 * sempre que os dados na base de dados mudam.
 */
@Dao
interface ProdutoDao {
    @Query("SELECT * FROM produtos")
    fun getAll(): Flow<List<Produto>>

    @Query("SELECT * FROM produtos WHERE categoria = :categoria")
    fun getByCategoria(categoria: String): Flow<List<Produto>>

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(produto: Produto)

    @Update
    suspend fun update(produto: Produto)

    @Delete
    suspend fun delete(produto: Produto)

    @Query("SELECT * FROM produtos WHERE id = :id")
    suspend fun getById(id: Int): Produto?

    @Query("SELECT SUM(quantidade) FROM produtos")
    fun getTotalStock(): Flow<Int?>

    @Query("SELECT COUNT(*) FROM produtos")
    fun getTotalProducts(): Flow<Int?>

    @Query("SELECT * FROM produtos WHERE nome LIKE '%' || :query || '%'")
    fun search(query: String): Flow<List<Produto>>
}
