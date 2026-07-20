package com.example.room_logs

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import androidx.room.Update
import kotlinx.coroutines.flow.Flow

@Dao
interface AlunoDao {
    @Insert
    suspend fun insert(aluno: AlunoModel): Long

    @Update
    suspend fun update(aluno: AlunoModel): Int

    @Delete
    suspend fun delete(aluno: AlunoModel): Int

    @Query("SELECT * FROM Aluno WHERE ID = :id")
    suspend fun get(id: Int): AlunoModel?

    @Query("SELECT * FROM Aluno ORDER BY ID DESC")
    fun getAll(): Flow<List<AlunoModel>>
}
