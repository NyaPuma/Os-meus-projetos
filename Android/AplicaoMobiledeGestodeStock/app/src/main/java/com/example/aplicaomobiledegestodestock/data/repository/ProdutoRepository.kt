package com.example.aplicaomobiledegestodestock.data.repository

import com.example.aplicaomobiledegestodestock.data.dao.ProdutoDao
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import kotlinx.coroutines.flow.Flow

/**
 * Repositório para a entidade Produto.
 * O padrão Repository abstrai a origem dos dados (neste caso, Room) do resto da aplicação,
 * facilitando a manutenção e testes unitários.
 */
class ProdutoRepository(private val produtoDao: ProdutoDao) {

    val allProdutos: Flow<List<Produto>> = produtoDao.getAll()
    val totalStock: Flow<Int?> = produtoDao.getTotalStock()
    val totalProductsCount: Flow<Int?> = produtoDao.getTotalProducts()

    fun getProdutosByCategoria(categoria: String): Flow<List<Produto>> {
        return if (categoria == "Todas") {
            produtoDao.getAll()
        } else {
            produtoDao.getByCategoria(categoria)
        }
    }

    suspend fun getById(id: Int): Produto? {
        return produtoDao.getById(id)
    }

    suspend fun insert(produto: Produto) {
        produtoDao.insert(produto)
    }

    suspend fun update(produto: Produto) {
        produtoDao.update(produto)
    }

    suspend fun delete(produto: Produto) {
        produtoDao.delete(produto)
    }

    fun search(query: String): Flow<List<Produto>> {
        return produtoDao.search(query)
    }
}
