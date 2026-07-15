package com.example.aplicaodecontactoscomimagemcrudcompleto

import java.io.Serializable

data class Contact(
    val id: Int = 0,
    val name: String,
    val phone: String,
    val imageUri: String? = null
) : Serializable
