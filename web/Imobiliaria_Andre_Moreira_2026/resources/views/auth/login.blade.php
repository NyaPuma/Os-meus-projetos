@extends('layouts.app')

@section('content')
<div class="flex items-center justify-center py-12 px-4">
    <div class="bg-white w-full max-w-[460px] p-10 rounded-[2rem] shadow-xl shadow-slate-200/50 border border-slate-50 flex flex-col items-center">

        <div class="mb-2 text-center">
            <span class="text-2xl font-bold tracking-tight text-slate-900">
                Imobi<span class="text-teal-500">Laravel</span>
            </span>
            <p class="text-xs font-bold text-slate-800 mt-3 tracking-wide">Iniciar Sessão</p>
        </div>

        <div class="flex items-center justify-center space-x-2 mt-6 mb-8 bg-slate-50 p-1 rounded-xl w-full max-w-[240px]">
            <a href="{{ route('login') }}" class="w-1/2 py-2 text-xs font-bold text-center rounded-lg bg-[#1a2432] text-white transition shadow-sm">
                Login
            </a>
            <a href="{{ route('register') }}" class="w-1/2 py-2 text-xs font-bold text-center rounded-lg text-slate-500 hover:text-slate-800 transition">
                Registo
            </a>
        </div>

        @if ($errors->any())
            <div class="w-full mb-4 p-4 rounded-xl bg-red-50 border border-red-100 text-red-600 text-xs font-medium space-y-1">
                @foreach ($errors->all() as $error)
                    <p class="flex items-center">
                        <svg class="w-3.5 h-3.5 mr-1.5 flex-shrink-0" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"/>
                        </svg>
                        {{ $error }}
                    </p>
                @endforeach
            </div>
        @endif

        <form action="{{ route('login.post') }}" method="POST" class="w-full space-y-5">
            @csrf

            <div>
                <label for="email" class="block text-xs font-medium text-slate-600 mb-1">Email</label>
                <input type="email" id="email" name="email" required value="{{ old('email') }}"
                    class="w-full px-4 py-2.5 rounded-xl border border-slate-300 bg-white text-slate-800 placeholder-slate-400 focus:outline-none focus:border-teal-500 focus:ring-1 focus:ring-teal-500 text-sm tracking-wide transition"
                    placeholder="o-seu-email@exemplo.com">
            </div>

            <div class="relative">
                <label for="password" class="block text-xs font-medium text-slate-600 mb-1">Palavra-passe</label>
                <input type="password" id="password" name="password" required
                    class="w-full px-4 py-2.5 rounded-xl border border-slate-300 bg-white text-slate-800 placeholder-slate-400 focus:outline-none focus:border-teal-500 focus:ring-1 focus:ring-teal-500 text-sm transition"
                    placeholder="••••••••">
                <div class="text-right mt-1.5">
                    <a href="#" class="text-[11px] text-slate-500 hover:text-slate-800 transition">Esqueceu-se da palavra-passe?</a>
                </div>
            </div>

            <button type="submit" class="w-full py-3 mt-4 rounded-xl bg-[#1a2432] hover:bg-[#253346] text-white text-sm font-semibold transition shadow-sm">
                Entrar
            </button>

            <div class="text-center mt-6">
                <a href="{{ url('/') }}" class="text-xs font-medium text-teal-500 hover:text-teal-600 transition">Voltar ao Início</a>
            </div>
        </form>

    </div>
</div>
@endsection
