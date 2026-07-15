package com.example.aplicaodecontactoscomimagemcrudcompleto

import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper

class DBHelper(context: Context) : SQLiteOpenHelper(context, DATABASE_NAME, null, DATABASE_VERSION) {

    companion object {
        private const val DATABASE_NAME = "contacts_db"
        private const val DATABASE_VERSION = 1
        private const val TABLE_CONTACTS = "contacts"

        private const val KEY_ID = "id"
        private const val KEY_NAME = "name"
        private const val KEY_PHONE = "phone"
        private const val KEY_IMAGE_URI = "image_uri"
    }

    override fun onCreate(db: SQLiteDatabase?) {
        val createTable = ("CREATE TABLE $TABLE_CONTACTS ("
                + "$KEY_ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "$KEY_NAME TEXT,"
                + "$KEY_PHONE TEXT,"
                + "$KEY_IMAGE_URI TEXT" + ")")
        db?.execSQL(createTable)
    }

    override fun onUpgrade(db: SQLiteDatabase?, oldVersion: Int, newVersion: Int) {
        db?.execSQL("DROP TABLE IF EXISTS $TABLE_CONTACTS")
        onCreate(db)
    }

    fun addContact(contact: Contact): Long {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put(KEY_NAME, contact.name)
        values.put(KEY_PHONE, contact.phone)
        values.put(KEY_IMAGE_URI, contact.imageUri)
        val id = db.insert(TABLE_CONTACTS, null, values)
        db.close()
        return id
    }

    fun getAllContacts(): List<Contact> {
        val contactList = mutableListOf<Contact>()
        val selectQuery = "SELECT * FROM $TABLE_CONTACTS"
        val db = this.readableDatabase
        val cursor = db.rawQuery(selectQuery, null)

        if (cursor.moveToFirst()) {
            do {
                val contact = Contact(
                    cursor.getInt(cursor.getColumnIndexOrThrow(KEY_ID)),
                    cursor.getString(cursor.getColumnIndexOrThrow(KEY_NAME)),
                    cursor.getString(cursor.getColumnIndexOrThrow(KEY_PHONE)),
                    cursor.getString(cursor.getColumnIndexOrThrow(KEY_IMAGE_URI))
                )
                contactList.add(contact)
            } while (cursor.moveToNext())
        }
        cursor.close()
        db.close()
        return contactList
    }

    fun updateContact(contact: Contact): Int {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put(KEY_NAME, contact.name)
        values.put(KEY_PHONE, contact.phone)
        values.put(KEY_IMAGE_URI, contact.imageUri)

        val success = db.update(TABLE_CONTACTS, values, "$KEY_ID = ?", arrayOf(contact.id.toString()))
        db.close()
        return success
    }

    fun deleteContact(id: Int) {
        val db = this.writableDatabase
        db.delete(TABLE_CONTACTS, "$KEY_ID = ?", arrayOf(id.toString()))
        db.close()
    }
}
