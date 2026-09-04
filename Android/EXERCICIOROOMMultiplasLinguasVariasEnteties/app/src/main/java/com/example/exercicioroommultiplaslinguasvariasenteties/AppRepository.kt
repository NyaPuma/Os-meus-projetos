package com.example.exercicioroommultiplaslinguasvariasenteties

import androidx.lifecycle.LiveData
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
}