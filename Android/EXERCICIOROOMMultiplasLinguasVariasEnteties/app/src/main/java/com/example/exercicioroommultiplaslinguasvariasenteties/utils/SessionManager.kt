package com.example.exercicioroommultiplaslinguasvariasenteties.utils

import android.content.Context
import android.content.SharedPreferences
import androidx.core.content.edit

class SessionManager(context: Context) {
    private val prefs: SharedPreferences = context.getSharedPreferences("user_session", Context.MODE_PRIVATE)

    companion object {
        const val USER_ID = "user_id"
        const val USER_NAME = "user_name"
        const val USER_EMAIL = "user_email"
    }

    fun saveSession(userId: Int, name: String, email: String) {
        prefs.edit {
            putInt(USER_ID, userId)
            putString(USER_NAME, name)
            putString(USER_EMAIL, email)
        }
    }

    fun getUserId(): Int = prefs.getInt(USER_ID, -1)
    fun getUserName(): String? = prefs.getString(USER_NAME, null)
    fun getUserEmail(): String? = prefs.getString(USER_EMAIL, null)

    fun isLoggedIn(): Boolean = getUserId() != -1

    fun logout() {
        prefs.edit { clear() }
    }
}