package com.example.aplicaomobiledegestodestock.viewmodel

import androidx.lifecycle.*
import com.example.aplicaomobiledegestodestock.data.repository.ProdutoRepository
import com.example.aplicaomobiledegestodestock.utils.SessionManager
import kotlinx.coroutines.launch

/**
 * ViewModel para o ecrã principal (Dashboard).
 * Expõe dados estatísticos agregados (total de produtos e stock) através de LiveData.
 */
class HomeViewModel(
    produtoRepository: ProdutoRepository,
    private val sessionManager: SessionManager,
) : ViewModel() {

    val totalProducts = produtoRepository.totalProductsCount.asLiveData()
    val totalStock = produtoRepository.totalStock.asLiveData()
    val userName = sessionManager.userName.asLiveData()

    fun logout() {
        viewModelScope.launch {
            sessionManager.clearSession()
        }
    }
}

class HomeViewModelFactory(
    private val produtoRepository: ProdutoRepository,
    private val sessionManager: SessionManager
) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(HomeViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return HomeViewModel(produtoRepository, sessionManager) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
