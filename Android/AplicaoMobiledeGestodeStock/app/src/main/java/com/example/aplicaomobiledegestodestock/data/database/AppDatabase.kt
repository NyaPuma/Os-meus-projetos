package com.example.aplicaomobiledegestodestock.data.database

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import androidx.sqlite.db.SupportSQLiteDatabase
import com.example.aplicaomobiledegestodestock.data.dao.ProdutoDao
import com.example.aplicaomobiledegestodestock.data.dao.UtilizadorDao
import com.example.aplicaomobiledegestodestock.data.entity.Produto
import com.example.aplicaomobiledegestodestock.data.entity.Utilizador
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

/**
 * Base de dados principal da aplicação utilizando Room.
 * Implementa o padrão Singleton para garantir que existe apenas uma instância da base de dados,
 * evitando desperdício de recursos e potenciais conflitos.
 */
@Database(entities = [Produto::class, Utilizador::class], version = 1, exportSchema = false)
abstract class AppDatabase : RoomDatabase() {

    abstract fun produtoDao(): ProdutoDao
    abstract fun utilizadorDao(): UtilizadorDao

    companion object {
        @Volatile
        private var INSTANCE: AppDatabase? = null

        /**
         * Retorna a instância da base de dados. Se não existir, cria uma nova.
         * O parâmetro scope é utilizado para executar operações assíncronas no callback.
         */
        fun getDatabase(context: Context, scope: CoroutineScope): AppDatabase {
            return INSTANCE ?: synchronized(this) {
                val instance = Room.databaseBuilder(
                    context.applicationContext,
                    AppDatabase::class.java,
                    "stock_database",
                )
                    .addCallback(AppDatabaseCallback(scope))
                    .build()
                INSTANCE = instance
                instance
            }
        }
    }

    /**
     * Callback para popular a base de dados com dados iniciais quando é criada pela primeira vez.
     */
    private class AppDatabaseCallback(private val scope: CoroutineScope) : Callback() {
        override fun onCreate(db: SupportSQLiteDatabase) {
            super.onCreate(db)
            INSTANCE?.let { database ->
                scope.launch(Dispatchers.IO) {
                    populateDatabase(database.utilizadorDao())
                }
            }
        }

        suspend fun populateDatabase(utilizadorDao: UtilizadorDao) {
            utilizadorDao.insert(Utilizador(username = "admin", password = "password123", nome = "Administrador"))
            utilizadorDao.insert(Utilizador(username = "cesae", password = "cesae", nome = "CESAE"))
            utilizadorDao.insert(Utilizador(username = "cesae_aluno", password = "123", nome = "Aluno CESAE"))
        }
    }
}
