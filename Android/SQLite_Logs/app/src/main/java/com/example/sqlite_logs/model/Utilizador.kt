package com.example.sqlite_logs.model

class Utilizador (
    val id: Int=0,
    val username: String="",
    val password: String=""
    )
{
    //override do método toString()
    override fun toString(): String {
        return "Utilizador(id=$id, username='$username', password='$password')"
    }
}
