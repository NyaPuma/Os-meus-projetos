package com.example.exercicioroommultiplaslinguasvariasenteties.data.local

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Cliente
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.User

@Database(entities = [Destino::class, Cliente::class, User::class], version = 3)
abstract class AppDatabase : RoomDatabase() {
    abstract fun appDao(): AppDao

    companion object {
        @Volatile
        private var INSTANCE: AppDatabase? = null

        fun getDatabase(context: Context): AppDatabase {
            return INSTANCE ?: synchronized(this) {
                val instance = Room.databaseBuilder(
                    context.applicationContext,
                    AppDatabase::class.java,
                    "app_database",
                )
                    .fallbackToDestructiveMigration(dropAllTables = true)
                    .build()
                INSTANCE = instance
                instance
            }
        }
    }
}