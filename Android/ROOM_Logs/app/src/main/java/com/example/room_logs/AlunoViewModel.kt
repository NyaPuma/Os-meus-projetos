package com.example.room_logs

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.asLiveData
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.launch

class AlunoViewModel(private val repository: AlunoRepository) : ViewModel() {

    val allAlunos = repository.allAlunos.asLiveData()

    fun insert(aluno: AlunoModel) = viewModelScope.launch {
        repository.insert(aluno)
    }

    fun update(aluno: AlunoModel) = viewModelScope.launch {
        repository.update(aluno)
    }

    fun delete(aluno: AlunoModel) = viewModelScope.launch {
        repository.delete(aluno)
    }

    class AlunoViewModelFactory(private val repository: AlunoRepository) : ViewModelProvider.Factory {
        override fun <T : ViewModel> create(modelClass: Class<T>): T {
            if (modelClass.isAssignableFrom(AlunoViewModel::class.java)) {
                @Suppress("UNCHECKED_CAST")
                return AlunoViewModel(repository) as T
            }
            throw IllegalArgumentException("Unknown ViewModel class")
        }
    }
}
