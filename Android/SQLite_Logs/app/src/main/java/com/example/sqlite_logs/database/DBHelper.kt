package com.example.sqlite_logs.database

import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import com.example.sqlite_logs.model.Utilizador

class DBHelper(context: Context) : SQLiteOpenHelper(context, "database.db", null, 1) {
    // array com comandos SQL para criar as tabelas e inserir dados
    private val sql = arrayOf(
        "CREATE TABLE utilizador(id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, password TEXT)",
        "INSERT INTO utilizador(username, password) VALUES('admin', 'admin')",
        "INSERT INTO utilizador(username, password) VALUES('user', 'user')",
        "INSERT INTO utilizador(username, password) VALUES('guest', 'guest')"
    )

    override fun onCreate(db: SQLiteDatabase) {
        for (string in sql) {
            db.execSQL(string)
        }
    }

    override fun onUpgrade(db: SQLiteDatabase, oldVersion: Int, newVersion: Int) {
        db.execSQL("DROP TABLE IF EXISTS utilizador")
        onCreate(db)
    }

    // INSERT
    fun utilizadorInsert(username: String, password: String): Long {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put("username", username)
        values.put("password", password)
        val id = db.insert("utilizador", null, values)
        db.close()
        return id
    }

    // Selecionar todos os elementos
    fun utilizadorSelectAll(): ArrayList<Utilizador> {
        val db = this.readableDatabase
        val cursor = db.rawQuery("SELECT * FROM utilizador", null)
        val lista = ArrayList<Utilizador>()
        if (cursor.moveToFirst()) {
            do {
                val id = cursor.getInt(0)
                val username = cursor.getString(1)
                val password = cursor.getString(2)
                lista.add(Utilizador(id, username, password))
            } while (cursor.moveToNext())
        }
        cursor.close()
        return lista
    }

    // UPDATE
    fun utilizadorUpdate(id: Int, username: String, password: String): Int {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put("username", username)
        values.put("password", password)
        val count = db.update("utilizador", values, "id=?", arrayOf(id.toString()))
        db.close()
        return count
    }

    // DELETE
    fun utilizadorDelete(id: Int): Int {
        val db = this.writableDatabase
        val count = db.delete("utilizador", "id=?", arrayOf(id.toString()))
        db.close()
        return count
    }
}
