package com.example.exercicioroommultiplaslinguasvariasenteties

import android.content.Intent
import android.content.res.Configuration
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.FragmentDestinoListBinding
import java.util.Locale

class DestinoListFragment : Fragment() {
    private var _binding: FragmentDestinoListBinding? = null
    private val binding get() = _binding!!
    private val viewModel: DestinoViewModel by viewModels()
    private lateinit var adapter: DestinoAdapter

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View {
        _binding = FragmentDestinoListBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        adapter = DestinoAdapter(emptyList(),
            onEdit = { destino ->
                val intent = Intent(requireContext(), AddDestinoActivity::class.java)
                intent.putExtra("destino", destino)
                startActivity(intent)
            },
            onDelete = { destino ->
                viewModel.delete(destino)
                Toast.makeText(requireContext(), R.string.destination_deleted, Toast.LENGTH_SHORT).show()
            },
            onReservar = { destino ->
                val intent = Intent(requireContext(), ReservaActivity::class.java)
                intent.putExtra("destino", destino)
                startActivity(intent)
            }
        )

        binding.rvDestinos.layoutManager = LinearLayoutManager(requireContext())
        binding.rvDestinos.adapter = adapter

        binding.btnAddDestino.setOnClickListener {
            startActivity(Intent(requireContext(), AddDestinoActivity::class.java))
        }

        binding.btnLang.setOnClickListener {
            toggleLanguage()
        }

        viewModel.allDestinos.observe(viewLifecycleOwner) { destinos ->
            adapter.updateList(destinos)
        }
    }

    private fun toggleLanguage() {
        val currentLocale = resources.configuration.locales[0]
        val newLang = if (currentLocale.language == "pt") "en" else "pt"
        
        val locale = Locale(newLang)
        Locale.setDefault(locale)
        val config = Configuration(resources.configuration)
        config.setLocale(locale)
        
        resources.updateConfiguration(config, resources.displayMetrics)
        activity?.recreate()
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}