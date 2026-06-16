@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Detalhes do Contrato #{{ sprintf('%04d', $venda->id) }}</h1>
        <p class="text-sm text-neutral-500 mt-1">Registo formalizado no sistema em: {{ \Carbon\Carbon::parse($venda->data_venda)->format('d/m/Y') }}</p>
    </div>
    <a href="{{ route('vendas.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Voltar ao Histórico
    </a>
</div>

<div class="grid grid-cols-1 md:grid-cols-2 gap-6 mb-6">

    <div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">
        <div class="bg-neutral-900 px-5 py-3 border-b border-neutral-800">
            <span class="text-[10px] text-neutral-400 font-mono font-bold uppercase tracking-wider">👤 Informação do Comprador</span>
        </div>
        <div class="p-5 space-y-4">
            <div>
                <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Nome do Cliente</span>
                <p class="text-base font-bold text-neutral-900 tracking-tight mt-0.5">{{ $venda->cliente->nome }}</p>
            </div>
            <div class="grid grid-cols-2 gap-4 pt-3 border-t border-neutral-100">
                <div>
                    <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">NIF</span>
                    <p class="text-xs font-mono font-bold text-neutral-800 mt-0.5">{{ $venda->cliente->nif }}</p>
                </div>
                <div>
                    <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Contacto Telefónico</span>
                    <p class="text-xs font-medium text-neutral-800 mt-0.5">{{ $venda->cliente->telefone }}</p>
                </div>
            </div>
            <div class="pt-3 border-t border-neutral-100">
                <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Endereço Eletrónico</span>
                <p class="text-xs font-medium text-neutral-800 mt-0.5">{{ $venda->cliente->email }}</p>
            </div>
        </div>
    </div>

    <div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">
        <div class="bg-neutral-900 px-5 py-3 border-b border-neutral-800">
            <span class="text-[10px] text-neutral-400 font-mono font-bold uppercase tracking-wider">🚗 Veículo Transacionado</span>
        </div>
        <div class="p-5 space-y-4">
            <div>
                <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Marca e Modelo</span>
                <p class="text-base font-bold text-neutral-900 tracking-tight mt-0.5">
                    {{ $venda->viatura->marca }} <span class="font-normal text-neutral-500">{{ $venda->viatura->modelo }}</span>
                </p>
            </div>
            <div class="grid grid-cols-2 gap-4 pt-3 border-t border-neutral-100">
                <div>
                    <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Matrícula</span>
                    <div class="mt-1">
                        <span class="inline-block bg-neutral-100 text-neutral-700 px-2 py-0.5 rounded font-mono text-[10px] font-bold border border-neutral-200 uppercase tracking-wider">
                            {{ $venda->viatura->matricula }}
                        </span>
                    </div>
                </div>
                <div>
                    <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Ano / Quilometragem</span>
                    <p class="text-xs font-medium text-neutral-800 mt-1">
                        {{ $venda->viatura->ano }} &middot; {{ number_format($venda->viatura->quilometros, 0, ',', '.') }} Km
                    </p>
                </div>
            </div>
            <div class="pt-3 border-t border-neutral-100">
                <span class="block text-[10px] uppercase tracking-wider text-neutral-400 font-bold">Preço de Tabela (Stock)</span>
                <p class="text-xs font-bold text-neutral-500 mt-0.5">{{ number_format($venda->viatura->preco, 2, ',', '.') }} €</p>
            </div>
        </div>
    </div>
</div>

<div class="bg-neutral-900 text-white rounded-xl border border-neutral-800 shadow-md overflow-hidden mb-6">
    <div class="p-6 flex flex-col sm:flex-row justify-between items-start sm:items-center gap-6">
        <div>
            <span class="text-[10px] uppercase tracking-widest text-neutral-400 font-bold">Preço Final de Fecho de Negócio</span>
            <p class="text-3xl font-black text-white tracking-tight mt-1">{{ number_format($venda->valor_venda, 2, ',', '.') }} €</p>
        </div>
        <div class="text-xs font-mono text-neutral-400 sm:text-right space-y-1">
            <p><span class="text-neutral-500 uppercase tracking-wider text-[9px] font-bold block sm:inline">Natureza da Operação:</span> Contrato Definitivo</p>
            <p><span class="text-neutral-500 uppercase tracking-wider text-[9px] font-bold block sm:inline">Data de Liquidação:</span> {{ \Carbon\Carbon::parse($venda->data_venda)->format('d-m-Y') }}</p>
        </div>
    </div>

    @if($venda->observacoes)
        <div class="bg-neutral-950 px-6 py-4 border-t border-neutral-800/60">
            <span class="text-[10px] uppercase tracking-widest text-neutral-500 font-bold block mb-1">Cláusulas e Observações Adicionais</span>
            <p class="text-sm text-neutral-300 italic font-medium leading-relaxed">
                &ldquo;{{ $venda->observacoes }}&rdquo;
            </p>
        </div>
    @endif
</div>

<div class="flex items-center justify-start space-x-3">
    <a href="{{ route('vendas.edit', $venda->id) }}"
       class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
        <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-colors duration-150" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z" />
        </svg>
        Alterar Contrato
    </a>
</div>
@endsection
