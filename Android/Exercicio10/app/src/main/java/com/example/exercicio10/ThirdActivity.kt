package com.example.exercicio10

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.exercicio10.databinding.ActivityThirdBinding
import java.text.DecimalFormat

class ThirdActivity : AppCompatActivity() {

    private lateinit var binding: ActivityThirdBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        
        binding = ActivityThirdBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)
        
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val num1 = intent.getDoubleExtra("NUM1", 0.0)
        val num2 = intent.getDoubleExtra("NUM2", 0.0)

        calculateAndDisplay(num1, num2)
    }

    private fun calculateAndDisplay(num1: Double, num2: Double) {
        val sum = num1 + num2
        val diff = num1 - num2
        val prod = num1 * num2
        
        val df = DecimalFormat("0.##")
        val n1 = df.format(num1)
        val n2 = df.format(num2)

        binding.textViewSum.text = getString(R.string.label_sum, n1, n2, df.format(sum))
        binding.textViewDiff.text = getString(R.string.label_diff, n1, n2, df.format(diff))
        binding.textViewProd.text = getString(R.string.label_prod, n1, n2, df.format(prod))
        
        if (num2 != 0.0) {
            val div = num1 / num2
            binding.textViewDiv.text = getString(R.string.label_div, n1, n2, df.format(div))
        } else {
            binding.textViewDiv.text = getString(R.string.label_div_error, n1, n2, getString(R.string.error_div_zero))
        }
    }
}
