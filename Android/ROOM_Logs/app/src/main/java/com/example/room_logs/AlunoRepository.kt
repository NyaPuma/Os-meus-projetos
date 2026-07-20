package com.example.room_logs

import kotlinx.coroutines.flow.Flow

class AlunoRepository(private val alunoDao: AlunoDao) {

    val allAlunos: Flow<List<AlunoModel>> = alunoDao.getAll()

    suspend fun insert(aluno: AlunoModel) {
        alunoDao.insert(aluno)
    }

    suspend fun update(aluno: AlunoModel) {
        alunoDao.update(aluno)
    }

    suspend fun delete(aluno: AlunoModel) {
        alunoDao.delete(aluno)
    }
}
