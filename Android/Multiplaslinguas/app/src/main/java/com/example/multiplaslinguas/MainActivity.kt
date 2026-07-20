package com.example.multiplaslinguas

import android.os.Bundle
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.app.AppCompatDelegate
import androidx.core.os.LocaleListCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.multiplaslinguas.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        binding.buttonAction.setOnClickListener {
            val message = getString(R.string.toast_message)
            Toast.makeText(this, message, Toast.LENGTH_SHORT).show()
        }

        // Configuração dos botões de linguagem
        binding.btnEn.setOnClickListener { setLocale("en") }
        binding.btnPt.setOnClickListener { setLocale("pt") }
        binding.btnEs.setOnClickListener { setLocale("es") }
        binding.btnZh.setOnClickListener { setLocale("zh") }
        binding.btnHi.setOnClickListener { setLocale("hi") }
        binding.btnAr.setOnClickListener { setLocale("ar") }
        binding.btnFr.setOnClickListener { setLocale("fr") }
        binding.btnBn.setOnClickListener { setLocale("bn") }
        binding.btnRu.setOnClickListener { setLocale("ru") }
        binding.btnId.setOnClickListener { setLocale("id") }
        binding.btnSq.setOnClickListener { setLocale("sq") }
        binding.btnCa.setOnClickListener { setLocale("ca") }
        binding.btnHy.setOnClickListener { setLocale("hy") }
        binding.btnDe.setOnClickListener { setLocale("de") }
        binding.btnAz.setOnClickListener { setLocale("az") }
        binding.btnBe.setOnClickListener { setLocale("be") }
        binding.btnNl.setOnClickListener { setLocale("nl") }
        binding.btnBs.setOnClickListener { setLocale("bs") }
        binding.btnHr.setOnClickListener { setLocale("hr") }
        binding.btnSr.setOnClickListener { setLocale("sr") }
        binding.btnBg.setOnClickListener { setLocale("bg") }
        binding.btnEl.setOnClickListener { setLocale("el") }
        binding.btnTr.setOnClickListener { setLocale("tr") }
        binding.btnCs.setOnClickListener { setLocale("cs") }
        binding.btnDa.setOnClickListener { setLocale("da") }
        binding.btnEt.setOnClickListener { setLocale("et") }
        binding.btnFi.setOnClickListener { setLocale("fi") }
        binding.btnSv.setOnClickListener { setLocale("sv") }
        binding.btnKa.setOnClickListener { setLocale("ka") }
        binding.btnHu.setOnClickListener { setLocale("hu") }
        binding.btnIs.setOnClickListener { setLocale("is") }
        binding.btnGa.setOnClickListener { setLocale("ga") }
        binding.btnIt.setOnClickListener { setLocale("it") }
        binding.btnKk.setOnClickListener { setLocale("kk") }
        binding.btnLv.setOnClickListener { setLocale("lv") }
        binding.btnLt.setOnClickListener { setLocale("lt") }
        binding.btnLb.setOnClickListener { setLocale("lb") }
        binding.btnMt.setOnClickListener { setLocale("mt") }
        binding.btnRo.setOnClickListener { setLocale("ro") }
        binding.btnMk.setOnClickListener { setLocale("mk") }
        binding.btnNo.setOnClickListener { setLocale("no") }
        binding.btnPl.setOnClickListener { setLocale("pl") }
        binding.btnSk.setOnClickListener { setLocale("sk") }
        binding.btnSl.setOnClickListener { setLocale("sl") }
        binding.btnUk.setOnClickListener { setLocale("uk") }
    }

    private fun setLocale(languageCode: String) {
        val appLocale: LocaleListCompat = LocaleListCompat.forLanguageTags(languageCode)
        AppCompatDelegate.setApplicationLocales(appLocale)
    }
}