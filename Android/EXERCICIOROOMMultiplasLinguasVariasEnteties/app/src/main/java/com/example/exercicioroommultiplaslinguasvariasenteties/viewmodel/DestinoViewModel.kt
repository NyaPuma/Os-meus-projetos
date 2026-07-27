package com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.asLiveData
import androidx.lifecycle.viewModelScope
import com.example.exercicioroommultiplaslinguasvariasenteties.data.local.AppDatabase
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.data.repository.AppRepository
import kotlinx.coroutines.launch

class DestinoViewModel(application: Application) : AndroidViewModel(application) {

    private val repository: AppRepository
    val allDestinos: LiveData<List<Destino>>

    init {
        val appDao = AppDatabase.getDatabase(application).appDao()
        repository = AppRepository(appDao)
        allDestinos = repository.allDestinos.asLiveData()
    }

    fun insert(destino: Destino) = viewModelScope.launch {
        repository.insertDestino(destino)
    }

    fun update(destino: Destino) = viewModelScope.launch {
        repository.updateDestino(destino)
    }

    fun delete(destino: Destino) = viewModelScope.launch {
        repository.deleteDestino(destino)
    }
}