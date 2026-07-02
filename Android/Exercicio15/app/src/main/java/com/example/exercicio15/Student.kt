package com.example.exercicio15

import java.io.Serializable

data class Student(
    val nome: String,
    val morada: String,
    val email: String
) : Serializable
