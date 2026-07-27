package com.example.exercicioroommultiplaslinguasvariasenteties.data.repository

import com.example.exercicioroommultiplaslinguasvariasenteties.data.local.AppDao
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Cliente
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.User
import kotlinx.coroutines.flow.Flow

class AppRepository(private val appDao: AppDao) {

    val allDestinos: Flow<List<Destino>> = appDao.getAllDestinos()

    suspend fun insertDestino(destino: Destino) {
        appDao.insertDestino(destino)
    }

    suspend fun updateDestino(destino: Destino) {
        appDao.updateDestino(destino)
    }

    suspend fun deleteDestino(destino: Destino) {
        appDao.deleteDestino(destino)
    }

    suspend fun insertCliente(cliente: Cliente) {
        appDao.insertCliente(cliente)
    }

    suspend fun getBookingCountByUserId(userId: Int): Int {
        return appDao.getBookingCountByUserId(userId)
    }

    suspend fun insertUser(user: User) {
        appDao.insertUser(user)
    }

    suspend fun updateUser(user: User) {
        appDao.updateUser(user)
    }

    suspend fun getUserByEmail(email: String): User? {
        return appDao.getUserByEmail(email)
    }

    suspend fun getUserById(userId: Int): User? {
        return appDao.getUserById(userId)
    }
}