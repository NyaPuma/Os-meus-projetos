package com.example.exercicioroommultiplaslinguasvariasenteties

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableCornerRadius
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.launch

class AuthViewModel(application: Application) : AndroidViewModel(application) {
    private val repository: AppRepository
    
    private val _loginResult = MutableLiveData<User?>()
    val loginResult: LiveData<User?> = _loginResult

    private val _registerSuccess = MutableLiveData<Boolean>()
    val registerSuccess: LiveData<Boolean> = _registerSuccess

    private val _error = MutableLiveData<String>()
    val error: LiveData<String> = _error

    init {
        val appDao = AppDatabase.getDatabase(application).appDao()
        repository = AppRepository(appDao)
    }

    fun login(email: String, pass: String) = viewModelScope.launch {
        val user = repository.getUserByEmail(email)
        if (user != null && user.password == pass) {
            _loginResult.value = user
        } else {
            _error.value = "Credenciais inválidas"
            _loginResult.value = null
        }
    }

    fun register(nome: String, email: String, pass: String) = viewModelScope.launch {
        val existing = repository.getUserByEmail(email)
        if (existing == null) {
            repository.insertUser(User(nome = nome, email = email, password = pass))
            _registerSuccess.value = true
        } else {
            _error.value = "Email já registado"
            _registerSuccess.value = false
        }
    }
}