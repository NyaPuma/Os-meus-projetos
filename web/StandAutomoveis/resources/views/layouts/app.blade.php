<!DOCTYPE html>
<html lang="pt" class="h-full">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Stand Automóveis 2026</title>

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap" rel="stylesheet">

    @vite(['resources/css/app.css', 'resources/js/app.js'])

    <style>
        body {
            font-family: 'Roboto', sans-serif;
        }
    </style>
</head>
<body class="bg-neutral-100 antialiased text-neutral-900 flex flex-col min-h-screen">

    <div class="h-1 bg-orange-600 w-full"></div>

    <header class="bg-neutral-900 text-white shadow-lg sticky top-0 z-50 border-b border-neutral-800">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <div class="flex items-center justify-between h-20">

                <div class="flex items-center flex-shrink-0">
                    <a href="{{ url('/') }}" class="flex items-center gap-2.5 group">
                        <span class="text-lg font-black tracking-wider uppercase text-white">
                            Stand <span class="text-orange-500">Automóveis</span>
                        </span>
                    </a>
                </div>

                <nav class="hidden md:flex items-center space-x-1">
                    <a href="{{ route('viaturas.index') }}"
                       class="px-4 py-2.5 rounded-md text-xs font-bold uppercase tracking-wider transition-all duration-150 {{ Request::is('viaturas*') ? 'bg-orange-600 text-white shadow-sm' : 'text-neutral-300 hover:bg-neutral-800 hover:text-white' }}">
                        Viaturas
                    </a>
                    <a href="{{ route('clientes.index') }}"
                       class="px-4 py-2.5 rounded-md text-xs font-bold uppercase tracking-wider transition-all duration-150 {{ Request::is('clientes*') ? 'bg-orange-600 text-white shadow-sm' : 'text-neutral-300 hover:bg-neutral-800 hover:text-white' }}">
                        Clientes
                    </a>
                    <a href="{{ route('vendas.index') }}"
                       class="px-4 py-2.5 rounded-md text-xs font-bold uppercase tracking-wider transition-all duration-150 {{ Request::is('vendas*') ? 'bg-orange-600 text-white shadow-sm' : 'text-neutral-300 hover:bg-neutral-800 hover:text-white' }}">
                        Vendas
                    </a>
                </nav>

                <div class="flex md:hidden">
                    <button type="button" class="text-neutral-400 hover:text-white focus:outline-none p-2 rounded-md hover:bg-neutral-800">
                        <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                        </svg>
                    </button>
                </div>

            </div>
        </div>
    </header>

    <main class="flex-grow max-w-7xl w-full mx-auto sm:px-6 lg:px-8 my-10 px-4">

        @if (session('success'))
            <div class="mb-6 p-4 bg-emerald-50 border-l-4 border-emerald-500 text-emerald-800 rounded-r-lg shadow-sm flex items-center" role="alert">
                <svg class="w-5 h-5 mr-3 text-emerald-500 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd"/>
                </svg>
                <span class="font-medium text-sm">{{ session('success') }}</span>
            </div>
        @endif

        @if ($errors->any())
            <div class="mb-6 p-4 bg-rose-50 border-l-4 border-rose-500 text-rose-800 rounded-r-lg shadow-sm" role="alert">
                <div class="flex items-center mb-2">
                    <svg class="w-5 h-5 mr-3 text-rose-500 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
                        <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7 4a1 1 0 11-2 0 1 1 0 012 0zm-1-9a1 1 0 00-1 1v4a1 1 0 102 0V6a1 1 0 00-1-1z" clip-rule="evenodd"/>
                    </svg>
                    <span class="font-bold text-sm">Por favor, verifique os seguintes erros:</span>
                </div>
                <ul class="list-disc list-inside text-xs ml-8 space-y-1 text-rose-700 font-medium">
                    @foreach ($errors->all() as $error)
                        <li>{{ $error }}</li>
                    @endforeach
                </ul>
            </div>
        @endif

        <div class="bg-white rounded-xl border border-neutral-200 shadow-sm p-6 sm:p-8">
            @yield('content')
        </div>

    </main>

    <footer class="bg-neutral-900 text-neutral-400 border-t border-neutral-800 mt-auto">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
            <div class="grid grid-cols-1 md:grid-cols-3 gap-8">

                <div class="space-y-3">
                    <div class="flex items-center gap-2">

                        <span class="text-base font-bold tracking-wider uppercase text-white">
                            Stand <span class="text-orange-500">Automóveis</span>
                        </span>
                    </div>
                    <p class="text-xs text-neutral-400 leading-relaxed max-w-sm">
                        Plataforma centralizada para gestão de stock de viaturas, ficheiros de clientes e processamento seguro de contratos de venda do stand.
                    </p>
                </div>

                <div>
                    <h4 class="text-sm font-bold uppercase tracking-wider text-white mb-4">Navegação</h4>
                    <ul class="space-y-2.5 text-xs">
                        <li>
                            <a href="{{ route('viaturas.index') }}" class="hover:text-orange-500 transition-colors duration-150 flex items-center gap-1.5">
                                <span class="text-orange-500 font-bold">»</span> Catálogo de Viaturas
                            </a>
                        </li>
                        <li>
                            <a href="{{ route('clientes.index') }}" class="hover:text-orange-500 transition-colors duration-150 flex items-center gap-1.5">
                                <span class="text-orange-500 font-bold">»</span> Ficheiros de Clientes
                            </a>
                        </li>
                        <li>
                            <a href="{{ route('vendas.index') }}" class="hover:text-orange-500 transition-colors duration-150 flex items-center gap-1.5">
                                <span class="text-orange-500 font-bold">»</span> Histórico de Vendas
                            </a>
                        </li>
                    </ul>
                </div>

                <div>
                    <h4 class="text-sm font-bold uppercase tracking-wider text-white mb-4">Sistema</h4>
                    <ul class="space-y-2 text-xs text-neutral-400">
                        <li>📍 <span class="font-medium text-neutral-300">Localização:</span> Braga, Portugal</li>
                        <li>🕒 <span class="font-medium text-neutral-300">Ano Corrente:</span> 2026</li>
                        <li>💻 <span class="font-medium text-neutral-300">Core:</span> Laravel v11 & Tailwind CSS</li>
                    </ul>
                </div>

            </div>

            <div class="mt-12 pt-6 border-t border-neutral-800 flex flex-col sm:flex-row justify-between items-center text-xs gap-4">
                <p class="text-neutral-500 text-center sm:text-left">
                    &copy; 2026 Stand Automóveis. Todos os direitos reservados.
                </p>
                <div class="flex space-x-4 text-neutral-500">
                    <a href="{{ route('termos') }}" class="hover:text-neutral-600 transition-colors">Termos de Utilização</a>
                    <span>&middot;</span>
                    <a href="{{ route('privacidade') }}" class="hover:text-neutral-600 transition-colors">Política de Privacidade</a>
                </div>
            </div>
        </div>
    </footer>

</body>
</html>
