package com.example.exercicioroommultiplaslinguasvariasenteties

import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import kotlinx.coroutines.launch

class ReservaActivity : AppCompatActivity() {

    private lateinit var destino: Destino

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_reserva)

        destino = intent.getSerializableExtra("destino") as Destino

        val tvTitulo = findViewById<TextView>(R.id.tvReservaTitulo)
        val etNome = findViewById<EditText>(R.id.etNomeCliente)
        val etEmail = findViewById<EditText>(R.id.etEmailCliente)
        val btnConfirmar = findViewById<Button>(R.id.btnConfirmarReserva)
        val tvStatus = findViewById<TextView>(R.id.tvStatusReserva)

        tvTitulo.text = getString(R.string.booking_for, destino.nome)

        btnConfirmar.setOnClickListener {
            val nomeCliente = etNome.text.toString()
            val emailCliente = etEmail.text.toString()

            if (nomeCliente.isNotEmpty() && emailCliente.isNotEmpty()) {
                val cliente = Cliente(nome = nomeCliente, email = emailCliente, viagemEscolhida = destino.nome)
                val dao = AppDatabase.getDatabase(this).appDao()

                lifecycleScope.launch {
                    dao.insertCliente(cliente)
                    tvStatus.text = getString(R.string.booking_success, nomeCliente, destino.nome)
                    tvStatus.visibility = View.VISIBLE
                    btnConfirmar.isEnabled = false
                    Toast.makeText(this@ReservaActivity, R.string.confirm, Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this, R.string.invalid_data, Toast.LENGTH_SHORT).show()
            }
        }
    }
}
