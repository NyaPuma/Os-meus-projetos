package com.example.aplicaomobiledegestodestock.viewmodel

import androidx.lifecycle.*
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import com.example.aplicaomobiledegestodestock.data.repository.ProdutoRepository
import kotlinx.coroutines.flow.MutableSharedFlow
import kotlinx.coroutines.flow.asSharedFlow
import kotlinx.coroutines.launch

/**
 * ViewModel responsável pela lógica de negócio da adição e edição de produtos.
 * Segue o padrão MVVM, mantendo o estado da UI e isolando a lógica da Activity.
 * Utiliza Coroutines para operações assíncronas na base de dados.
 */
class AddProductViewModel(private val repository: ProdutoRepository) : ViewModel() {

    private val _saveResult = MutableSharedFlow<Boolean>()
    val saveResult = _saveResult.asSharedFlow()

    private val _error = MutableSharedFlow<String>()
    val error = _error.asSharedFlow()

    private val _product = MutableLiveData<Produto?>()
    val product: LiveData<Produto?> = _product

    private var currentProductId: Int = 0

    fun loadProduct(id: Int) {
        currentProductId = id
        viewModelScope.launch {
            _product.value = repository.getById(id)
        }
    }

    fun saveProduct(
        nome: String,
        categoria: String,
        quantidadeStr: String,
        precoStr: String,
        descricao: String,
        fornecedor: String,
    ) {
        if (nome.isEmpty() || categoria.isEmpty() || quantidadeStr.isEmpty() || precoStr.isEmpty()) {
            viewModelScope.launch { _error.emit("Preencha todos os campos obrigatórios.") }
            return
        }

        val quantidade = quantidadeStr.toIntOrNull() ?: -1
        val preco = precoStr.toDoubleOrNull() ?: 0.0

        if (quantidade < 0) {
            viewModelScope.launch { _error.emit("Quantidade inválida.") }
            return
        }
        if (preco <= 0) {
            viewModelScope.launch { _error.emit("Preço inválido.") }
            return
        }

        val produto = Produto(
            id = currentProductId,
            nome = nome,
            categoria = categoria,
            quantidade = quantidade,
            preco = preco,
            descricao = descricao,
            fornecedor = fornecedor
        )

        viewModelScope.launch {
            if (currentProductId == 0) {
                repository.insert(produto)
            } else {
                repository.update(produto)
            }
            _saveResult.emit(value = true)
        }
    }
}

class AddProductViewModelFactory(private val repository: ProdutoRepository) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(AddProductViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return AddProductViewModel(repository) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
