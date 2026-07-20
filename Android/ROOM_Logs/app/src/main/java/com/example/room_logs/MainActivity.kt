package com.example.room_logs

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.room_logs.databinding.ActivityMainBinding
import com.example.room_logs.databinding.BottomSheetAlunoBinding
import com.google.android.material.bottomsheet.BottomSheetDialog
import com.google.android.material.dialog.MaterialAlertDialogBuilder
import com.google.android.material.snackbar.Snackbar

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private val viewModel: AlunoViewModel by viewModels {
        AlunoViewModel.AlunoViewModelFactory(AlunoRepository(AlunoDatabase.getDatabase(this).alunoDao()))
    }
    
    private lateinit var alunoAdapter: AlunoAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        enableEdgeToEdge()
        setContentView(binding.root)

        setupWindowInsets()
        setupRecyclerView()
        setupClickListeners()
        observeViewModel()
    }

    private fun setupWindowInsets() {
        ViewCompat.setOnApplyWindowInsetsListener(binding.main) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
    }

    private fun setupRecyclerView() {
        alunoAdapter = AlunoAdapter(
            onEdit = { aluno -> showAlunoBottomSheet(aluno) }
        ) { aluno ->
            showDeleteConfirmation(aluno)
        }
        binding.recyclerView.apply {
            layoutManager = LinearLayoutManager(this@MainActivity)
            adapter = alunoAdapter
        }
    }

    private fun setupClickListeners() {
        binding.fabAdd.setOnClickListener {
            showAlunoBottomSheet()
        }
    }

    private fun observeViewModel() {
        viewModel.allAlunos.observe(this) { alunos ->
            alunoAdapter.submitList(alunos)
            updateDashboard(alunos.size)
        }
    }

    private fun updateDashboard(count: Int) {
        binding.textTotal.text = count.toString()
        binding.textQuantidade.text = count.toString()
    }

    private fun showAlunoBottomSheet(aluno: AlunoModel? = null) {
        val bottomSheetBinding = BottomSheetAlunoBinding.inflate(layoutInflater)
        val dialog = BottomSheetDialog(this)
        dialog.setContentView(bottomSheetBinding.root)

        if (aluno != null) {
            bottomSheetBinding.textTitulo.text = getString(R.string.editar_aluno)
            bottomSheetBinding.editNome.setText(aluno.nome)
            bottomSheetBinding.editCurso.setText(aluno.curso)
            bottomSheetBinding.editCidade.setText(aluno.cidade)
        }

        bottomSheetBinding.btnCancelar.setOnClickListener { dialog.dismiss() }
        
        bottomSheetBinding.btnGuardar.setOnClickListener {
            val nome = bottomSheetBinding.editNome.text.toString().trim()
            val curso = bottomSheetBinding.editCurso.text.toString().trim()
            val cidade = bottomSheetBinding.editCidade.text.toString().trim()

            if (nome.isEmpty() || curso.isEmpty() || cidade.isEmpty()) {
                showSnackbar(getString(R.string.preencha_campos))
                return@setOnClickListener
            }

            if (aluno == null) {
                viewModel.insert(AlunoModel(nome = nome, curso = curso, cidade = cidade))
                showSnackbar(getString(R.string.aluno_inserido))
            } else {
                viewModel.update(aluno.copy(nome = nome, curso = curso, cidade = cidade))
                showSnackbar(getString(R.string.aluno_atualizado))
            }
            dialog.dismiss()
        }

        dialog.show()
    }

    private fun showDeleteConfirmation(aluno: AlunoModel) {
        MaterialAlertDialogBuilder(this)
            .setTitle(getString(R.string.eliminar_aluno))
            .setMessage(getString(R.string.confirmar_eliminar, aluno.nome))
            .setNegativeButton(getString(R.string.cancelar), null)
            .setPositiveButton(getString(R.string.eliminar)) { _, _ ->
                viewModel.delete(aluno)
                showSnackbar(getString(R.string.aluno_eliminado))
            }
            .show()
    }

    private fun showSnackbar(message: String) {
        Snackbar.make(binding.root, message, Snackbar.LENGTH_SHORT).show()
    }
}
