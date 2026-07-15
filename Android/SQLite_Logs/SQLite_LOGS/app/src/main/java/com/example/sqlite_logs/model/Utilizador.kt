package com.example.sqlite_logs.model

class Utilizador(
    val id:Int=0,
    var username: String="",
    var password: String=""
)
{
    //override do metodo toString
    override fun toString(): String {
        return "ID: $id | Username:$username"
    }
}