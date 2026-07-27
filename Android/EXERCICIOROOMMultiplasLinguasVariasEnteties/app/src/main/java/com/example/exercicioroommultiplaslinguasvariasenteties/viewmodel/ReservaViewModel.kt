package com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.viewModelScope
import com.example.exercicioroommultiplaslinguasvariasenteties.data.local.AppDatabase
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Cliente
import com.example.exercicioroommultiplaslinguasvariasenteties.data.repository.AppRepository
import kotlinx.coroutines.launch

class ReservaViewModel(application: Application) : AndroidViewModel(application) {

    private val repository: AppRepository

    init {
        val appDao = AppDatabase.getDatabase(application).appDao()
        repository = AppRepository(appDao)
    }

    fun insertCliente(cliente: Cliente) = viewModelScope.launch {
        repository.insertCliente(cliente)
    }
}