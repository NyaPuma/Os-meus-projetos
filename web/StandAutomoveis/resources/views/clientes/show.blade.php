@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Ficha do Cliente</h1>
        <p class="text-sm text-neutral-500 mt-1">Visualização detalhada dos dados gerais e de faturação do cliente.</p>
    </div>
    <a href="{{ route('clientes.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Voltar à Listagem
    </a>
</div>

<div class="grid grid-cols-1 lg:grid-cols-3 gap-6">

    <div class="bg-neutral-50 rounded-xl border border-neutral-200 p-6 flex flex-col items-center text-center justify-center shadow-sm">
        <div class="w-20 h-20 bg-neutral-900 text-orange-500 rounded-full flex items-center justify-center text-2xl font-black shadow-inner border border-neutral-800 uppercase tracking-wider">
            {{ substr($cliente->nome, 0, 2) }}
        </div>
        <h2 class="text-xl font-bold text-neutral-900 mt-4 leading-tight">{{ $cliente->nome }}</h2>

        <span class="inline-block bg-neutral-200 text-neutral-700 px-3 py-1 rounded-md font-mono text-xs font-bold mt-3 border border-neutral-300/40">
            REGISTO #{{ sprintf('%03d', $cliente->id) }}
        </span>
    </div>

    <div class="lg:col-span-2 bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden flex flex-col justify-between">
        <div>
            <div class="bg-neutral-900 px-6 py-4 border-b border-neutral-800 flex items-center gap-2">
                <span class="text-sm">📋</span>
                <h3 class="text-xs font-bold uppercase tracking-wider text-neutral-300">Especificações e Parâmetros Fiscais</h3>
            </div>

            <div class="p-6 grid grid-cols-1 md:grid-cols-2 gap-6">

                <div>
                    <span class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Nome Completo</span>
                    <span class="text-base font-semibold text-neutral-900">{{ $cliente->nome }}</span>
                </div>

                <div>
                    <span class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Número de Identificação Fiscal</span>
                    <span class="inline-block bg-neutral-100 text-neutral-800 px-2.5 py-1 rounded font-mono text-sm font-bold border border-neutral-200 shadow-inner">
                        {{ $cliente->nif }}
                    </span>
                </div>

                <div>
                    <span class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Endereço Eletrónico</span>
                    <span class="text-base text-neutral-800 font-medium flex items-center gap-2">
                        <span class="text-neutral-400 text-sm">✉️</span> {{ $cliente->email }}
                    </span>
                </div>

                <div>
                    <span class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Contacto Telefónico</span>
                    <span class="text-base text-neutral-800 font-medium flex items-center gap-2">
                        <span class="text-neutral-400 text-sm">📞</span> {{ $cliente->telefone }}
                    </span>
                </div>

                <div class="md:col-span-2 border-t border-neutral-100 pt-4">
                    <span class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Morada de Faturação</span>
                    <span class="text-base text-neutral-800 font-medium flex items-center gap-2">
                        <span class="text-neutral-400 text-sm">📍</span> {{ $cliente->morada }}
                    </span>
                </div>

            </div>
        </div>
    </div>

</div>

<div class="mt-8 pt-5 border-t border-neutral-200 flex flex-wrap gap-3 justify-end">

    <a href="{{ route('clientes.edit', $cliente->id) }}"
       class="inline-flex items-center gap-2 bg-amber-600 hover:bg-amber-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-colors duration-150 uppercase text-xs tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z" />
        </svg>
        Modificar Dados
    </a>

    <form action="{{ route('clientes.destroy', $cliente->id) }}" method="POST" onsubmit="return confirm('Tem a certeza que deseja apagar definitivamente este cliente?');">
        @csrf
        @method('DELETE')
        <button type="submit"
                class="inline-flex items-center gap-2 bg-rose-50 text-rose-700 hover:bg-rose-100 border border-rose-200/60 font-bold py-2.5 px-5 rounded-lg transition-colors duration-150 uppercase text-xs tracking-wider">
            Eliminar Registo
        </button>
    </form>

</div>
@endsection
