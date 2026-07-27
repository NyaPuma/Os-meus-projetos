package com.example.aplicaomobiledegestodestock.viewmodel

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.viewModelScope
import com.example.aplicaomobiledegestodestock.data.entity.Utilizador
import com.example.aplicaomobiledegestodestock.data.repository.UtilizadorRepository
import com.example.aplicaomobiledegestodestock.utils.SessionManager
import kotlinx.coroutines.flow.MutableSharedFlow
import kotlinx.coroutines.flow.asSharedFlow
import kotlinx.coroutines.launch

/**
 * ViewModel para o processo de autenticação.
 * Valida as credenciais e gere a sessão do utilizador utilizando o SessionManager.
 */
class LoginViewModel(
    private val repository: UtilizadorRepository,
    private val sessionManager: SessionManager,
) : ViewModel() {

    private val _loginResult = MutableSharedFlow<Utilizador?>()
    val loginResult = _loginResult.asSharedFlow()

    private val _error = MutableSharedFlow<String>()
    val error = _error.asSharedFlow()

    fun login(username: String, password: String) {
        if (username.isEmpty() || password.isEmpty()) {
            viewModelScope.launch { _error.emit("Por favor, preencha todos os campos.") }
            return
        }

        viewModelScope.launch {
            val user = repository.login(username, password)
            if (user != null) {
                sessionManager.saveSession(user.id, user.username, user.nome)
                _loginResult.emit(user)
            } else {
                _error.emit("Credenciais inválidas.")
            }
        }
    }
}

class LoginViewModelFactory(
    private val repository: UtilizadorRepository,
    private val sessionManager: SessionManager
) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(LoginViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return LoginViewModel(repository, sessionManager) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
