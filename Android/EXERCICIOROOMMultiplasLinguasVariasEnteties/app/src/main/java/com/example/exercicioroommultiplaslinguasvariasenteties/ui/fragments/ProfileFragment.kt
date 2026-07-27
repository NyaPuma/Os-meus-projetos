package com.example.exercicioroommultiplaslinguasvariasenteties.ui.fragments

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import com.example.exercicioroommultiplaslinguasvariasenteties.R
import com.example.exercicioroommultiplaslinguasvariasenteties.databinding.FragmentProfileBinding
import com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities.ChangePasswordActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities.EditProfileActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.ui.activities.LoginActivity
import com.example.exercicioroommultiplaslinguasvariasenteties.utils.SessionManager
import com.example.exercicioroommultiplaslinguasvariasenteties.viewmodel.ProfileViewModel

class ProfileFragment : Fragment() {
    private var _binding: FragmentProfileBinding? = null
    private val binding get() = _binding!!
    private val viewModel: ProfileViewModel by viewModels()
    private lateinit var sessionManager: SessionManager

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View {
        _binding = FragmentProfileBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        sessionManager = SessionManager(requireContext())

        viewModel.user.observe(viewLifecycleOwner) { user ->
            user?.let {
                binding.tvProfileName.text = it.nome
                binding.tvProfileEmail.text = it.email
            }
        }

        viewModel.bookingCount.observe(viewLifecycleOwner) { count ->
            binding.tvBookingCount.text = getString(R.string.bookings_made, count)
        }

        binding.btnEditProfile.setOnClickListener {
            startActivity(Intent(requireContext(), EditProfileActivity::class.java))
        }

        binding.btnChangePassword.setOnClickListener {
            startActivity(Intent(requireContext(), ChangePasswordActivity::class.java))
        }

        binding.btnLogout.setOnClickListener {
            sessionManager.logout()
            val intent = Intent(requireContext(), LoginActivity::class.java)
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
            startActivity(intent)
        }
    }

    override fun onResume() {
        super.onResume()
        if (sessionManager.isLoggedIn()) {
            viewModel.loadUserData(sessionManager.getUserId())
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}