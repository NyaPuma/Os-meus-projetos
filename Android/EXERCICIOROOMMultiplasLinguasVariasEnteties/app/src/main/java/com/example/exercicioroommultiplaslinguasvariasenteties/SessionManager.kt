package com.example.exercicioroommultiplaslinguasvariasenteties

import android.content.Context
import android.content.SharedPreferences

class SessionManager(context: Context) {
    private val prefs: SharedPreferences = context.getSharedPreferences("user_session", Context.MODE_PRIVATE)

    companion object {
        const val USER_ID = "user_id"
        const val USER_NAME = "user_name"
        const val USER_EMAIL = "user_email"
    }

    fun saveSession(userId: Int, name: String, email: String) {
        val editor = prefs.edit()
        editor.putInt(USER_ID, userId)
        editor.putString(USER_NAME, name)
        editor.putString(USER_EMAIL, email)
        editor.apply()
    }

    fun getUserId(): Int = prefs.getInt(USER_ID, -1)
    fun getUserName(): String? = prefs.getString(USER_NAME, null)
    fun getUserEmail(): String? = prefs.getString(USER_EMAIL, null)

    fun isLoggedIn(): Boolean = getUserId() != -1

    fun logout() {
        val editor = prefs.edit()
        editor.clear()
        editor.apply()
    }
}