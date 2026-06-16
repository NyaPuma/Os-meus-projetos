<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ImobiLaravel - Gestão Imobiliária</title>

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet">

    @vite(['resources/css/app.css', 'resources/js/app.js'])

    <style>
        body { font-family: 'Inter', sans-serif; }
    </style>
</head>
<body class="bg-[#f8fafc] text-slate-800 min-h-screen flex flex-col">

    <nav class="bg-white border-b border-slate-100 sticky top-0 z-50 shadow-sm">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <div class="flex justify-between h-20">
                <div class="flex items-center space-x-8">

                    <a href="{{ url('/') }}" class="flex items-center space-x-2 hover:opacity-90 transition">
                        <span class="text-2xl font-bold tracking-tight text-slate-900">
                            Imobi<span class="text-teal-500">Laravel</span>
                        </span>
                    </a>

                    <div class="hidden md:flex space-x-1">
                        <a href="{{ url('/') }}"
                           class="px-4 py-2 rounded-lg text-sm font-medium transition {{ request()->is('/') ? 'bg-slate-50 text-teal-600 font-semibold' : 'text-slate-600 hover:text-slate-900 hover:bg-slate-50' }}">
                            Dashboard
                        </a>

                        @auth
                            <a href="{{ route('apartamentos.index') }}"
                               class="px-4 py-2 rounded-lg text-sm font-medium transition {{ request()->routeIs('apartamentos.*') ? 'bg-slate-50 text-teal-600 font-semibold' : 'text-slate-600 hover:text-slate-900 hover:bg-slate-50' }}">
                                Apartamentos
                            </a>
                            <a href="{{ route('clientes.index') }}"
                               class="px-4 py-2 rounded-lg text-sm font-medium transition {{ request()->routeIs('clientes.*') ? 'bg-slate-50 text-teal-600 font-semibold' : 'text-slate-600 hover:text-slate-900 hover:bg-slate-50' }}">
                                Clientes
                            </a>
                            <a href="{{ route('vendas.index') }}"
                               class="px-4 py-2 rounded-lg text-sm font-medium transition {{ request()->routeIs('vendas.*') ? 'bg-slate-50 text-teal-600 font-semibold' : 'text-slate-600 hover:text-slate-900 hover:bg-slate-50' }}">
                                Vendas
                            </a>
                        @endauth
                    </div>
                </div>

                <div class="flex items-center space-x-4">
                    @auth
                        <a href="{{ route('vendas.create') }}" class="bg-teal-500 hover:bg-teal-600 text-white px-5 py-2.5 rounded-xl text-sm font-medium transition duration-200 shadow-sm shadow-teal-100 flex items-center space-x-2">
                            <span>Registar Venda</span>
                        </a>

                        <form action="{{ route('logout') }}" method="POST" class="inline m-0 p-0">
                            @csrf
                            <button type="submit" class="text-xs font-semibold text-rose-600 hover:text-rose-700 px-3 py-2 rounded-lg hover:bg-rose-50 transition">
                                Terminar Sessão
                            </button>
                        </form>
                    @endauth

                    @guest
                        <a href="{{ route('login') }}" class="flex items-center space-x-1.5 bg-[#1a2432] hover:bg-[#253346] text-white px-5 py-2.5 rounded-xl text-sm font-medium transition duration-200 shadow-sm shadow-slate-900/10">
                            <svg class="w-4 h-4 text-teal-400" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M17.982 18.725A7.488 7.488 0 0012 15.75a7.488 7.488 0 00-5.982 2.975m11.963 0a9 9 0 10-11.963 0m11.963 0A8.966 8.966 0 0112 21a8.966 8.966 0 01-5.982-2.275M15 9.75a3 3 0 11-6 0 3 3 0 016 0z" />
                            </svg>
                            <span>Área Pessoal</span>
                        </a>
                    @endguest
                </div>
            </div>
        </div>
    </nav>

    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 w-full mt-6">
        @if(session('success'))
            <div class="bg-emerald-50 border border-emerald-200 text-emerald-800 rounded-2xl p-4 flex items-center space-x-3 shadow-sm transition-all">
                <div class="p-1 bg-emerald-500 rounded-full text-white">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="3" d="M5 13l4 4L19 7"></path></svg>
                </div>
                <p class="text-sm font-medium">{{ session('success') }}</p>
            </div>
        @endif

        @if($errors->any())
            <div class="bg-rose-50 border border-rose-200 text-rose-800 rounded-2xl p-4 flex items-start space-x-3 shadow-sm transition-all">
                <div class="p-1 bg-rose-500 rounded-full text-white mt-0.5">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="3" d="M6 18L18 6M6 6l12 12"></path></svg>
                </div>
                <div>
                    <p class="text-sm font-semibold">Ups! Ocorreu um problema:</p>
                    <ul class="list-disc list-inside text-xs mt-1 space-y-0.5 opacity-90">
                        @foreach ($errors->all() as $error)
                            <li>{{ $error }}</li>
                        @endforeach
                    </ul>
                </div>
            </div>
        @endif
    </div>

    <main class="flex-grow max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 w-full py-8">
        @yield('content')
    </main>

    <footer class="bg-[#182232] text-slate-400 border-t border-slate-800 mt-auto">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
            <div class="grid grid-cols-1 md:grid-cols-4 gap-8">
                <div class="space-y-4">
                    <span class="text-xl font-bold text-white tracking-tight">Imobi<span class="text-teal-400">Laravel</span></span>
                    <p class="text-xs leading-relaxed text-slate-400">
                        Soluções inovadoras para a gestão de imóveis, clientes e vendas de forma fidedigna e sem complicações.
                    </p>
                </div>
                <div>
                    <h3 class="text-sm font-semibold text-white tracking-wider uppercase mb-4">Navegação</h3>
                    <ul class="space-y-2 text-xs">
                        <li><a href="{{ url('/') }}" class="hover:text-white transition">Dashboard</a></li>
                        @auth
                            <li><a href="{{ route('apartamentos.index') }}" class="hover:text-white transition">Apartamentos</a></li>
                            <li><a href="{{ route('clientes.index') }}" class="hover:text-white transition">Clientes</a></li>
                            <li><a href="{{ route('vendas.index') }}" class="hover:text-white transition">Histórico de Vendas</a></li>
                        @endauth
                    </ul>
                </div>
                <div>
                    <h3 class="text-sm font-semibold text-white tracking-wider uppercase mb-4">Suporte</h3>
                    <ul class="space-y-2 text-xs">
                        <li><a href="{{ route('documentacao') }}" class="hover:text-white transition">Documentação</a></li>
                        <li><a href="{{ route('termos') }}" class="hover:text-white transition">Termos de Serviço</a></li>
                        <li><a href="{{ route('privacidade') }}" class="hover:text-white transition">Política de Privacidade</a></li>
                    </ul>
                </div>
                <div>
                    <h3 class="text-sm font-semibold text-white tracking-wider uppercase mb-4">Contacto</h3>
                    <p class="text-xs text-slate-400 leading-relaxed">
                        Email: suporte@imobilaravel.pt<br>
                        Tel: +351 912 345 678
                    </p>
                </div>
            </div>

            <div class="mt-12 pt-6 border-t border-slate-800 text-center text-xs text-slate-500">
                &copy; 2026 ImobiLaravel. Todos os direitos reservados.
            </div>
        </div>
    </footer>

</body>
</html>
