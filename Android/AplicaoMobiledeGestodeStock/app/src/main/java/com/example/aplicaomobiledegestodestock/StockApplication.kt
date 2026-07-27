package com.example.aplicaomobiledegestodestock

import android.app.Application
import com.example.aplicaomobiledegestodestock.data.database.AppDatabase
import com.example.aplicaomobiledegestodestock.data.repository.ProdutoRepository
import com.example.aplicaomobiledegestodestock.data.repository.UtilizadorRepository
import com.example.aplicaomobiledegestodestock.utils.SessionManager
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.SupervisorJob

class StockApplication : Application() {

    val applicationScope = CoroutineScope(SupervisorJob())

    val database by lazy { AppDatabase.getDatabase(this, applicationScope) }
    val produtoRepository by lazy { ProdutoRepository(database.produtoDao()) }
    val utilizadorRepository by lazy { UtilizadorRepository(database.utilizadorDao()) }
    val sessionManager by lazy { SessionManager(this) }
}
