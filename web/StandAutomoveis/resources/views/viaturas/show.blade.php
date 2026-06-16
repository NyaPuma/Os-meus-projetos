@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <span class="text-xs font-mono font-bold text-neutral-400 uppercase tracking-widest block mb-1">Ficha Detalhada da Viatura</span>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">
            {{ $viatura->marca }} <span class="font-normal text-neutral-500">{{ $viatura->modelo }}</span>
        </h1>
    </div>
    <a href="{{ route('viaturas.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Voltar ao Catálogo
    </a>
</div>

<div class="grid grid-cols-1 lg:grid-cols-3 gap-8">

    <div class="lg:col-span-1 bg-neutral-50 border border-neutral-200 rounded-xl overflow-hidden flex items-center justify-center p-3 min-h-[260px] lg:h-auto shadow-sm">
        @if ($viatura->foto)
            <img src="{{ asset('storage/' . $viatura->foto) }}" alt="{{ $viatura->marca }}" class="w-full h-full object-cover rounded-lg shadow-sm">
        @else
            <div class="text-center p-8 flex flex-col items-center justify-center">
                <div class="p-4 bg-white rounded-full border border-neutral-200 text-neutral-300 shadow-sm mb-3">
                    <svg class="w-10 h-10" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="1.5">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 002-2H4a2 2 0 00-2 2v12a2 2 0 002 2z" />
                    </svg>
                </div>
                <p class="text-[10px] font-bold uppercase tracking-wider text-neutral-400">Nenhuma imagem associada</p>
            </div>
        @endif
    </div>

    <div class="lg:col-span-2 bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden flex flex-col justify-between">

        <div class="bg-neutral-900 px-6 py-4 border-b border-neutral-800 flex items-center justify-between">
            <div class="flex items-center gap-2">
                <span class="text-xs text-neutral-400 font-mono font-bold">REGISTO #{{ sprintf('%03d', $viatura->id) }}</span>
            </div>
            <span class="bg-neutral-800 text-neutral-200 px-2.5 py-0.5 rounded font-mono text-xs font-bold border border-neutral-700 tracking-wider">
                {{ $viatura->matricula }}
            </span>
        </div>

        <div class="p-6 grid grid-cols-1 md:grid-cols-2 gap-6 flex-1">

            <div class="border-b border-neutral-100 pb-3 md:border-none md:pb-0">
                <label class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Marca e Modelo</label>
                <span class="text-lg font-black text-neutral-900 tracking-tight">
                    {{ $viatura->marca }} <span class="font-normal text-neutral-500">{{ $viatura->modelo }}</span>
                </span>
            </div>

            <div class="border-b border-neutral-100 pb-3 md:border-none md:pb-0">
                <label class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Estado Comercial</label>
                <div>
                    <span class="inline-flex items-center mt-1 text-[11px] font-black uppercase tracking-wider px-2.5 py-1 rounded-md border
                        {{ $viatura->estado === 'disponível' ? 'bg-emerald-50 text-emerald-700 border-emerald-200/60' : 'bg-rose-50 text-rose-700 border-rose-200/60' }}">
                        {{ $viatura->estado }}
                    </span>
                </div>
            </div>

            <div class="border-b border-neutral-100 pb-3 md:border-none md:pb-0">
                <label class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Ano de Registo</label>
                <div class="flex items-center gap-2 text-neutral-900 font-bold text-base mt-1">
                    <span class="text-neutral-400 text-sm">📅</span>
                    <span>{{ $viatura->ano }}</span>
                </div>
            </div>

            <div>
                <label class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-1">Quilometragem Total</label>
                <div class="flex items-center gap-2 text-neutral-900 font-bold text-base mt-1">
                    <span class="text-neutral-400 text-sm">🛣️</span>
                    <span>{{ number_format($viatura->quilometros, 0, ',', '.') }} Km</span>
                </div>
            </div>

            <div class="md:col-span-2 mt-4 pt-5 border-t border-neutral-100 flex items-center justify-between bg-neutral-50/40 -mx-6 -mb-6 p-6">
                <div>
                    <span class="block text-xs uppercase tracking-wider text-neutral-400 font-bold">Valor de Venda Avaliado</span>
                    <p class="text-[11px] text-neutral-400 mt-0.5">Preço base para preenchimento contratual de venda.</p>
                </div>
                <span class="text-3xl font-black text-orange-600 tracking-tight">
                    {{ number_format($viatura->preco, 2, ',', '.') }} €
                </span>
            </div>

        </div>

    </div>
</div>

<div class="mt-8 pt-5 border-t border-neutral-200 flex items-center justify-end gap-3">
    <a href="{{ route('viaturas.index') }}"
       class="inline-flex items-center px-4 py-2.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-lg font-bold uppercase text-xs tracking-wider transition-colors duration-150">
        Voltar ao Catálogo
    </a>
    <a href="{{ route('viaturas.edit', $viatura->id) }}"
       class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
        <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-colors duration-150" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z" />
        </svg>
        Editar Dados da Viatura
    </a>
</div>
@endsection
