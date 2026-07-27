package com.example.aplicaomobiledegestodestock.viewmodel

import androidx.lifecycle.*
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import com.example.aplicaomobiledegestodestock.data.repository.ProdutoRepository
import kotlinx.coroutines.ExperimentalCoroutinesApi
import kotlinx.coroutines.flow.*
import kotlinx.coroutines.launch

/**
 * ViewModel para a listagem de produtos.
 * Implementa funcionalidades avançadas como filtragem por categoria, pesquisa em tempo real
 * e ordenação de stock, utilizando operadores de Flow (combine, flatMapLatest).
 */
@OptIn(ExperimentalCoroutinesApi::class)
class ProductsViewModel(private val repository: ProdutoRepository) : ViewModel() {

    private val _categoryFilter = MutableStateFlow("Todas")
    private val _searchQuery = MutableStateFlow("")
    private val _sortOrder = MutableStateFlow(SortOrder.NONE)

    val products: LiveData<List<Produto>> = combine(_categoryFilter, _searchQuery, _sortOrder) { category, query, sort ->
        Triple(category, query, sort)
    }.flatMapLatest { (category, query, sort) ->
        val flow: Flow<List<Produto>> = if (query.isNotEmpty()) {
            repository.search(query)
        } else {
            repository.getProdutosByCategoria(category)
        }
        
        flow.map { list ->
            when (sort) {
                SortOrder.STOCK_ASC -> list.sortedBy { it.quantidade }
                SortOrder.STOCK_DESC -> list.sortedByDescending { it.quantidade }
                else -> list
            }
        }
    }.asLiveData()

    fun setCategory(category: String) {
        _categoryFilter.value = category
    }

    fun setSearchQuery(query: String) {
        _searchQuery.value = query
    }

    fun setSortOrder(order: SortOrder) {
        _sortOrder.value = order
    }

    fun deleteProduct(produto: Produto) {
        viewModelScope.launch {
            repository.delete(produto)
        }
    }

    fun insertProduct(produto: Produto) {
        viewModelScope.launch {
            repository.insert(produto)
        }
    }

    enum class SortOrder { NONE, STOCK_ASC, STOCK_DESC }
}

class ProductsViewModelFactory(private val repository: ProdutoRepository) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(ProductsViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return ProductsViewModel(repository) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
