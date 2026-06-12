<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;
use App\Models\User;

class AuthController extends Controller
{
    /**
     * Exibir o ecrã de Login (GET /login)
     */
    public function showLogin()
    {
        return view('auth.login');
    }

    /**
     * Processar a tentativa de Login (POST /login)
     */
    public function login(Request $request)
    {
        // 1. Validar os dados introduzidos pelo utilizador
        $credentials = $request->validate([
            'email' => ['required', 'email'],
            'password' => ['required'],
        ], [
            'email.required' => 'O campo email é obrigatório.',
            'email.email' => 'Introduza um endereço de email válido.',
            'password.required' => 'A palavra-passe é obrigatória.',
        ]);

        // 2. Tentar autenticar o utilizador (Lembrar se a checkbox estiver ativa)
        $remember = $request->has('remember');

        if (Auth::attempt($credentials, $remember)) {
            // Regenerar a sessão por motivos de segurança contra ataques de fixação
            $request->session()->regenerate();

            return redirect()->intended('/')
                ->with('success', 'Sessão iniciada com sucesso! Bem-vindo de volta.');
        }

        // 3. Se falhar, voltar atrás com erro
        return back()->withErrors([
            'email' => 'As credenciais introduzidas não correspondem aos nossos registos.',
        ])->onlyInput('email');
    }

    /**
     * Exibir o ecrã de Registo (GET /register)
     */
    public function showRegister()
    {
        return view('auth.register');
    }

    /**
     * Processar a criação de uma nova conta (POST /register)
     */
    public function register(Request $request)
    {
        // 1. Validar os dados do novo agente/consultor
        $request->validate([
            'name' => ['required', 'string', 'max:255'],
            'email' => ['required', 'string', 'email', 'max:255', 'unique:users'],
            'password' => ['required', 'string', 'min:8'],
        ], [
            'name.required' => 'O nome é obrigatório.',
            'email.required' => 'O email é obrigatório.',
            'email.unique' => 'Este e-mail já está registado na plataforma.',
            'password.required' => 'A palavra-passe é obrigatória.',
            'password.min' => 'A palavra-passe deve ter pelo menos 8 caracteres.',
        ]);

        // 2. Criar o utilizador na Base de Dados
        $user = User::create([
            'name' => $request->name,
            'email' => $request->email,
            'password' => Hash::make($request->password), // Encriptação da password
        ]);

        // 3. Iniciar sessão automaticamente para o utilizador acabado de criar
        Auth::login($user);

        return redirect('/')
            ->with('success', 'Conta criada com sucesso! Já tem acesso total ao sistema.');
    }

    /**
     * Terminar Sessão / Logout (POST /logout)
     */
    public function logout(Request $request)
    {
        Auth::logout();

        // Limpar os dados da sessão atual
        $request->session()->invalidate();
        // Regenerar o token CSRF de segurança
        $request->session()->regenerateToken();

        return redirect('/')
            ->with('success', 'A sua sessão foi terminada.');
    }
}
