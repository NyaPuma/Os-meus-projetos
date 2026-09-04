package com.example.room_logs

import kotlinx.coroutines.flow.Flow

class UserRepository(private val userDao: UserDao) {

    val allUsers: Flow<List<UserModel>> = userDao.getAll()

    suspend fun insert(user: UserModel) {
        userDao.insert(user)
    }

    suspend fun update(user: UserModel) {
        userDao.update(user)
    }

    suspend fun delete(user: UserModel) {
        userDao.delete(user)
    }
}
