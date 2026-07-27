package com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import com.example.exercicioroommultiplaslinguasvariasenteties.R
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ActivityMainBinding
import com.example.exercicioroommultiplaslinguasvariasenteties.ui.fragments.DestinoListFragment
import com.example.exercicioroommultiplaslinguasvariasenteties.ui.fragments.ProfileFragment
import com.example.exercicioroommultiplaslinguasvariasenteties.utils.SessionManager

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private lateinit var sessionManager: SessionManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        sessionManager = SessionManager(this)

        if (!sessionManager.isLoggedIn()) {
            startActivity(Intent(this, LoginActivity::class.java))
            finish()
            return
        }

        setupBottomNavigation()

        // Default fragment
        if (savedInstanceState == null) {
            loadFragment(DestinoListFragment())
        }
    }

    private fun setupBottomNavigation() {
        binding.bottomNav.setOnItemSelectedListener { item ->
            when (item.itemId) {
                R.id.nav_destinos -> {
                    loadFragment(DestinoListFragment())
                    true
                }
                R.id.nav_perfil -> {
                    loadFragment(ProfileFragment())
                    true
                }
                else -> false
            }
        }
    }

    private fun loadFragment(fragment: Fragment) {
        supportFragmentManager.beginTransaction()
            .replace(R.id.fragment_container, fragment)
            .commit()
    }
}