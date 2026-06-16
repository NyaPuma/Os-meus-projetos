@extends('layouts.app')

@section('content')
<div class="space-y-6 max-w-5xl mx-auto">

    <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-4 rounded-2xl border border-slate-100 shadow-sm">
        <div>
            <a href="{{ route('apartamentos.index') }}" class="text-sm font-medium text-slate-600 hover:text-slate-900 flex items-center space-x-1 transition">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
                <span>Voltar à listagem</span>
            </a>
        </div>

        <div class="flex items-center space-x-2">
            <a href="{{ route('apartamentos.edit', $apartamento) }}" class="px-4 py-2 bg-teal-500 hover:bg-teal-600 text-white rounded-xl text-xs font-semibold transition flex items-center space-x-1.5 shadow-sm shadow-teal-100">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>
                <span>Editar Imóvel</span>
            </a>

            <form action="{{ route('apartamentos.destroy', $apartamento) }}" method="POST" onsubmit="return confirm('Tem a certeza que pretende remover definitivamente este imóvel?')" class="inline m-0">
                @csrf
                @method('DELETE')
                <button type="submit" class="px-4 py-2 border border-rose-200 text-rose-600 hover:bg-rose-50 rounded-xl text-xs font-semibold transition flex items-center space-x-1.5">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path></svg>
                    <span>Remover</span>
                </button>
            </form>
        </div>
    </div>

    <div class="grid grid-cols-1 md:grid-cols-12 gap-6 items-start">

        <div class="md:col-span-5 bg-white rounded-2xl border border-slate-100 shadow-sm overflow-hidden p-3">
            <div class="relative aspect-square bg-slate-50 rounded-xl overflow-hidden shadow-inner">
                @if($apartamento->fotografia)
                    <img src="{{ asset('storage/' . $apartamento->fotografia) }}" alt="Fotografia do Imóvel" class="w-full h-full object-cover">
                @else
                    <div class="w-full h-full flex flex-col items-center justify-center text-slate-400">
                        <svg class="w-16 h-16 stroke-1 mb-2" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z"></path></svg>
                        <span class="text-xs font-semibold uppercase tracking-wider">Sem Imagem Disponível</span>
                    </div>
                @endif

                <div class="absolute top-4 right-4">
                    @if($apartamento->estado === 'Disponível')
                        <span class="bg-emerald-500 text-white text-xs px-3 py-1.5 rounded-full font-bold shadow-md uppercase tracking-wider">Disponível</span>
                    @else
                        <span class="bg-rose-500 text-white text-xs px-3 py-1.5 rounded-full font-bold shadow-md uppercase tracking-wider">Imóvel Vendido</span>
                    @endif
                </div>
            </div>
        </div>

        <div class="md:col-span-7 space-y-6">

            <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8 space-y-4">
                <div class="flex items-center justify-between border-b border-slate-50 pb-4">
                    <div>
                        <span class="text-xs font-bold text-teal-600 uppercase tracking-widest">{{ $apartamento->tipologia }}</span>
                        <h2 class="text-2xl font-bold text-slate-900 tracking-tight mt-0.5">{{ $apartamento->referencia }}</h2>
                    </div>
                    <div class="text-right">
                        <p class="text-xs font-semibold text-slate-400 uppercase tracking-wider">Preço Comercial</p>
                        <p class="text-2xl font-black text-slate-900">{{ number_format($apartamento->preco, 2, ',', ' ') }} €</p>
                    </div>
                </div>

                <div class="grid grid-cols-2 gap-4 text-sm pt-2">
                    <div class="bg-slate-50 p-3 rounded-xl border border-slate-100">
                        <span class="block text-xs font-semibold text-slate-400 uppercase">Área do Imóvel</span>
                        <span class="text-slate-800 font-bold text-base mt-0.5 inline-block">{{ $apartamento->area }} m² <span class="text-xs font-normal text-slate-500">úteis</span></span>
                    </div>
                    <div class="bg-slate-50 p-3 rounded-xl border border-slate-100">
                        <span class="block text-xs font-semibold text-slate-400 uppercase">Tipo de Habitação</span>
                        <span class="text-slate-800 font-bold text-base mt-0.5 inline-block">Apartamento {{ $apartamento->tipologia }}</span>
                    </div>
                </div>

                <div class="bg-slate-50 p-4 rounded-xl border border-slate-100 space-y-1">
                    <span class="text-xs font-semibold text-slate-400 uppercase tracking-wider">Localização / Morada</span>
                    <p class="text-slate-800 text-sm font-medium leading-relaxed flex items-start space-x-2">
                        <svg class="w-4 h-4 text-teal-500 mt-0.5 flex-shrink-0" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"></path><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"></path></svg>
                        <span>{{ $apartamento->morada }}</span>
                    </p>
                </div>
            </div>

            @if($apartamento->estado === 'Vendido' && $apartamento->venda)
                <div class="bg-slate-900 text-white rounded-2xl p-6 md:p-8 space-y-4 shadow-xl shadow-slate-200 border border-slate-800 animate-fade-in">

                    <div class="flex items-center space-x-3 border-b border-slate-800 pb-4">
                        <div class="p-2 bg-teal-500 rounded-xl text-slate-900">
                            <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path></svg>
                        </div>
                        <div>
                            <h3 class="font-bold text-base tracking-tight text-white">Relatório de Transação</h3>
                            <p class="text-slate-400 text-xs">Este imóvel possui um contrato de compra e venda ativo.</p>
                        </div>
                    </div>

                    <div class="grid grid-cols-1 sm:grid-cols-2 gap-4 text-sm pt-2">
                        <div>
                            <span class="block text-xs font-medium text-slate-400 uppercase tracking-wider">Cliente Proprietário</span>
                            <a href="{{ route('clientes.show', $apartamento->venda->cliente_id) }}" class="text-teal-400 font-bold text-base hover:underline mt-0.5 inline-block">
                                {{ $apartamento->venda->cliente->nome }}
                            </a>
                        </div>
                        <div>
                            <span class="block text-xs font-medium text-slate-400 uppercase tracking-wider">Data da Escritura</span>
                            <span class="text-slate-200 font-semibold text-base mt-0.5 inline-block">
                                {{ date('d/m/Y', strtotime($apartamento->venda->data_venda)) }}
                            </span>
                        </div>
                        <div class="sm:col-span-2 bg-slate-800 p-3 rounded-xl border border-slate-700/50 flex justify-between items-center">
                            <span class="text-xs font-medium text-slate-300 uppercase tracking-wider">Valor de Fecho de Negócio</span>
                            <span class="text-xl font-black text-teal-400">{{ number_format($apartamento->venda->valor_venda, 2, ',', ' ') }} €</span>
                        </div>
                    </div>

                    @if($apartamento->venda->observacoes)
                        <div class="bg-slate-800/50 p-4 rounded-xl border border-slate-800 text-xs text-slate-300 leading-relaxed space-y-1">
                            <span class="block font-bold text-slate-400 uppercase tracking-wide">Notas da Imobiliária</span>
                            <p class="italic">"{{ $apartamento->venda->observacoes }}"</p>
                        </div>
                    @endif

                    <div class="pt-2 text-right">
                        <a href="{{ route('vendas.show', $apartamento->venda->id) }}" class="text-xs text-slate-400 hover:text-white font-medium inline-flex items-center space-x-1 transition">
                            <span>Ver Ficha de Venda Completa</span>
                            <svg class="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path></svg>
                        </a>
                    </div>
                </div>
            @endif

        </div>
    </div>
</div>
@endsection
