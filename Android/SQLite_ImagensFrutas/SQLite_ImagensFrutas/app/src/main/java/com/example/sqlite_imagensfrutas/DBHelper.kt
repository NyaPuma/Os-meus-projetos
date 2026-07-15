package com.example.sqlite_imagensfrutas

import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper

class DBHelper(context: Context): SQLiteOpenHelper(context,"frutas.db",null,1) {

    private val sql = arrayOf(
        "CREATE TABLE fruta (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, imagem TEXT NOT NULL)")

        override fun onCreate(db: SQLiteDatabase) {
//criar a tabela
            for(string in sql){
                db.execSQL(string)
            }

// Inserir frutas iniciais
            db.execSQL("INSERT INTO fruta (nome, imagem) VALUES ('Maçã', 'maca')")
            db.execSQL("INSERT INTO fruta (nome, imagem) VALUES ('Banana', 'banana')")
            db.execSQL("INSERT INTO fruta (nome, imagem) VALUES ('Morango', 'morango')")
            db.execSQL("INSERT INTO fruta (nome, imagem) VALUES ('Uva', 'uva')")


    }

    override fun onUpgrade(
        db: SQLiteDatabase,
        oldVersion: Int,
        newVersion: Int
    ) {
        db.execSQL("DROP TABLE IF EXISTS fruta")
        onCreate(db)
    }

    fun frutaListSelectAll(context: Context): ArrayList<Fruta> {
        val lista = ArrayList<Fruta>()
        val db = readableDatabase
        val c = db.rawQuery("SELECT * FROM fruta", null)

        if (c.moveToFirst()) {
            do {
                val idIndex=c.getColumnIndex("id")
                val nomeIndex = c.getColumnIndex("nome")
                val imagemNomeIndex = c.getColumnIndex("imagem")
                var id = 0
                var nome = ""
                var imagemNome = ""

                if(idIndex>=0 && nomeIndex>=0 && imagemNomeIndex>=0){
                    val id = c.getInt(idIndex)
                    val nome = c.getString(nomeIndex)
                    val imagemNome = c.getString(imagemNomeIndex)

                    // Converte "maca" → R.drawable.maca
                    val imagemResId = context.resources.getIdentifier(imagemNome,"drawable",context.packageName)


                    lista.add(Fruta(id, nome, imagemResId))
                }

            } while (c.moveToNext())
        }

        c.close()
        db.close()
        return lista
    }

}