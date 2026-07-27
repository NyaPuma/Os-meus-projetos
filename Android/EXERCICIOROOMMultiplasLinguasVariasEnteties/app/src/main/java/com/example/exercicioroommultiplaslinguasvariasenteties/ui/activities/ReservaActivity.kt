package com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities

import android.os.Build
import android.os.Bundle
import android.view.View
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.R
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Cliente
import com.example.exercicioroommultiplaslinguasvariasenteties.data.model.Destino
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.ActivityReservaBinding
import com.example.exercicioroommultiplaslinguasvariasenteties.utils.SessionManager
import com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel.ReservaViewModel

class ReservaActivity : AppCompatActivity() {

    private lateinit var binding: ActivityReservaBinding
    private val viewModel: ReservaViewModel by viewModels()
    private lateinit var destino: Destino
    private lateinit var sessionManager: SessionManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityReservaBinding.inflate(layoutInflater)
        setContentView(binding.root)

        sessionManager = SessionManager(this)

        val destinoExtra = if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
            intent.getSerializableExtra("destino", Destino::class.java)
        } else {
            @Suppress("DEPRECATION")
            intent.getSerializableExtra("destino") as? Destino
        }
        if (destinoExtra == null) {
            Toast.makeText(this, "Erro: Destino não encontrado", Toast.LENGTH_SHORT).show()
            finish()
            return
        }
        destino = destinoExtra

        binding.tvReservaTitulo.text = getString(R.string.trip_selected, destino.nomeDestino)

        // Pre-fill user data
        if (sessionManager.isLoggedIn()) {
            binding.etNomeCliente.setText(sessionManager.getUserName())
            binding.etEmailCliente.setText(sessionManager.getUserEmail())
        }

        binding.btnConfirmarReserva.setOnClickListener {
            val nomeCliente = binding.etNomeCliente.text.toString()
            val emailCliente = binding.etEmailCliente.text.toString()
            val telefoneCliente = binding.etTelefoneCliente.text.toString()

            if (nomeCliente.isNotEmpty() && emailCliente.isNotEmpty() && telefoneCliente.isNotEmpty()) {
                val cliente = Cliente(
                    userId = sessionManager.getUserId(),
                    nomeCliente = nomeCliente,
                    email = emailCliente,
                    telefone = telefoneCliente,
                    viagemEscolhida = destino.nomeDestino,
                )

                viewModel.insertCliente(cliente)
                
                binding.tvStatusReserva.text = getString(R.string.booking_success, nomeCliente, destino.nomeDestino)
                binding.cardStatusReserva.visibility = View.VISIBLE
                binding.btnConfirmarReserva.isEnabled = false
                
                // Return to MainActivity after 2 seconds
                binding.root.postDelayed({
                    finish()
                }, 2000)
                
                Toast.makeText(this@ReservaActivity, R.string.confirm_reservation, Toast.LENGTH_SHORT).show()
            } else {
                Toast.makeText(this, R.string.invalid_data, Toast.LENGTH_SHORT).show()
            }
        }
    }
}