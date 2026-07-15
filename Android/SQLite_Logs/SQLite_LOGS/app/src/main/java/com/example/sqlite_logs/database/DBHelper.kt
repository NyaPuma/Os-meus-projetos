package com.example.sqlite_logs.database

import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import com.example.sqlite_logs.model.Utilizador

class DBHelper(context: Context): SQLiteOpenHelper
    (context,"database.db",null,1) {
    //array com comandos SQL para criar a tabela e inserir dados iniciais

    val sql = arrayOf(
        "CREATE TABLE utilizador(id INTEGER PRIMARY KEY AUTOINCREMENT,username TEXT,password TEXT)",
        "INSERT INTO utilizador (username,password) VALUES ('user','pass')",
        "INSERT INTO utilizador (username,password) VALUES ('admin','123')",
    )


    override fun onCreate(db: SQLiteDatabase) {
        for (string in sql) {
            db.execSQL(string)
        }
    }

    override fun onUpgrade(
        db: SQLiteDatabase,
        oldVersion: Int,
        newVersion: Int
    ) {
        db.execSQL("DROP TABLE IF EXISTS utilizador")
        onCreate(db)
    }

    //SELECIONAR TODOS OS ELEMENTOS DA BD E DEVOVER UM ARRAY

    fun utilizdorListSelectALL(): ArrayList<Utilizador> {

        val db = this.readableDatabase //abrir a base de dados em modo de leitura
        val listaUtilizadores = ArrayList<Utilizador>()

        val c = db.rawQuery("SELECT * FROM utilizador", null)
        //o cursor tem que apontar para a 1ª linha
        if (c.moveToFirst()) {
            do {
                val idIndex = c.getColumnIndex("id")
                val usernameIndex = c.getColumnIndex("username")
                val passwordIndex = c.getColumnIndex("password")

                if (idIndex >= 0 && usernameIndex >= 0 && passwordIndex >= 0) {
                    val id = c.getInt(idIndex)
                    val username = c.getString(usernameIndex)
                    val password = c.getString(passwordIndex)

                    listaUtilizadores.add(Utilizador(id, username, password))
                }
            } while (c.moveToNext())
        }

        c.close() //fechar o cursor
        db.close() //fechar a base de dados
        return listaUtilizadores

    }

    //selecionar apenas 1 utilizador

    fun utilizadorSelectById(id: Int): Utilizador {

        val db = this.readableDatabase
        val c = db.rawQuery("SELECT*FROM utilizador WHERE id=?", arrayOf(id.toString()))
        var utilizador = Utilizador()
        if (c.moveToFirst()) {
            do {
                val idIndex = c.getColumnIndex("id")
                val usernameIndex = c.getColumnIndex("username")
                val passwordIndex = c.getColumnIndex("password")

                if (idIndex >= 0 && usernameIndex >= 0 && passwordIndex >= 0) {
                    val id = c.getInt(idIndex)
                    val username = c.getString(usernameIndex)
                    val password = c.getString(passwordIndex)

                    utilizador = Utilizador(id, username, password)

                }
            } while (c.moveToNext())
        }
            c.close()
            db.close()
            return utilizador
        }



        //----------------------------CRUD--------------------------------------------
        //-------------------------INSERT----------------------------------------

        fun utilizadorInsert(
            username: String,
            password: String
        ): Long { //Long é numero de ID da linha

            //abrir a base de dados em modo de escrita
            val db = this.writableDatabase
            val contentValue = ContentValues()
            contentValue.put("username", username)
            contentValue.put("password", password)

            val res = db.insert("utilizador", null, contentValue)
            //fechar a ligação
            db.close()
            return res //res=numero (linha em que foi inserido), res=-1 (falha na inserçao)
        }

        //Selecionar todos os elementos

    //-------------------------REMOVE----------------------------------------
    

    }
