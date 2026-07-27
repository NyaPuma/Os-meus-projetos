package com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.viewModelScope
import com.example.exercicioroommultiplaslinguasvariasenteties.data.local.AppDatabase
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.User
import com.example.exercicioroommultiplaslinguasvariasenteties.data.repository.AppRepository
import kotlinx.coroutines.launch

class ProfileViewModel(application: Application) : AndroidViewModel(application) {
    private val repository: AppRepository

    private val _user = MutableLiveData<User?>()
    val user: LiveData<User?> = _user

    private val _bookingCount = MutableLiveData<Int>()
    val bookingCount: LiveData<Int> = _bookingCount

    private val _updateStatus = MutableLiveData<Boolean>()
    val updateStatus: LiveData<Boolean> = _updateStatus

    private val _error = MutableLiveData<String>()
    val error: LiveData<String> = _error

    init {
        val appDao = AppDatabase.getDatabase(application).appDao()
        repository = AppRepository(appDao)
    }

    fun loadUserData(userId: Int) = viewModelScope.launch {
        _user.value = repository.getUserById(userId)
        _bookingCount.value = repository.getBookingCountByUserId(userId)
    }

    fun updateProfile(userId: Int, nome: String, email: String) = viewModelScope.launch {
        val currentUser = repository.getUserById(userId)
        if (currentUser != null) {
            val updatedUser = currentUser.copy(nome = nome, email = email)
            repository.updateUser(updatedUser)
            _user.value = updatedUser
            _updateStatus.value = true
        }
    }

    fun changePassword(userId: Int, currentPass: String, newPass: String) = viewModelScope.launch {
        val currentUser = repository.getUserById(userId)
        if ((currentUser != null) && (currentUser.password == currentPass)) {
            val updatedUser = currentUser.copy(password = newPass)
            repository.updateUser(updatedUser)
            _updateStatus.value = true
        } else {
            _error.value = "Password atual incorreta"
            _updateStatus.value = false
        }
    }
}