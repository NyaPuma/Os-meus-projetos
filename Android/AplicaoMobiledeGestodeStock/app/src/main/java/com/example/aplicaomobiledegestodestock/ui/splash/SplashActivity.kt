package com.example.aplicaomobiledegestodestock.ui.splash

import android.annotation.SuppressLint
import android.content.Intent
import android.os.Bundle
import android.view.animation.AlphaAnimation
import android.view.animation.AnimationSet
import android.view.animation.ScaleAnimation
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.example.aplicaomobiledegestodestock.StockApplication
import com.example.aplicaomobiledegestodestock.databinding.ActivitySplashBinding
import com.example.aplicaomobiledegestodestock.ui.home.HomeActivity
import com.example.aplicaomobiledegestodestock.ui.login.LoginActivity
import kotlinx.coroutines.delay
import kotlinx.coroutines.flow.first
import kotlinx.coroutines.launch

/**
 * Ecrã de Splash.
 * Responsável pela animação inicial e verificação automática de sessão.
 */
@SuppressLint("CustomSplashScreen")
class SplashActivity : AppCompatActivity() {

    private lateinit var binding: ActivitySplashBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySplashBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // Animação de Fade-In e Escala (Zoom) combinadas
        val animationSet = AnimationSet(true)
        
        val fadeIn = AlphaAnimation(0.0f, 1.0f)
        fadeIn.duration = 1500

        val scale = ScaleAnimation(
            0.8f, 1.0f, 0.8f, 1.0f,
            ScaleAnimation.RELATIVE_TO_SELF, 0.5f,
            ScaleAnimation.RELATIVE_TO_SELF, 0.5f
        )
        scale.duration = 1500

        animationSet.addAnimation(fadeIn)
        animationSet.addAnimation(scale)

        binding.logo.startAnimation(animationSet)
        binding.appName.startAnimation(fadeIn)

        lifecycleScope.launch {
            delay(2500L)
            checkSession()
        }
    }

    private suspend fun checkSession() {
        val sessionManager = (application as StockApplication).sessionManager
        val isLoggedIn = sessionManager.isLoggedIn.first()

        val intent = if (isLoggedIn) {
            Intent(this, HomeActivity::class.java)
        } else {
            Intent(this, LoginActivity::class.java)
        }
        startActivity(intent)
        finish()
    }
}
