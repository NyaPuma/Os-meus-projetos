package com.example.aplicaomobiledegestodestock.data.repository

import com.example.aplicaomobiledegestodestock.data.dao.UtilizadorDao
import com.example.aplicaomobiledegestodestock.data.entity.Utilizador

/**
 * Repositório para a gestão de Utilizadores.
 * Centraliza as operações de login e acesso a dados de utilizador.
 */
class UtilizadorRepository(private val utilizadorDao: UtilizadorDao) {

    suspend fun login(username: String, password: String): Utilizador? {
        return utilizadorDao.login(username, password)
    }

    suspend fun getByUsername(username: String): Utilizador? {
        return utilizadorDao.getByUsername(username)
    }

    suspend fun insert(utilizador: Utilizador) {
        utilizadorDao.insert(utilizador)
    }
}
