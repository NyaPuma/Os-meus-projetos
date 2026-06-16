@extends('layouts.app')

@section('content')
<div class="space-y-6 max-w-5xl mx-auto">

    <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-4 rounded-2xl border border-slate-100 shadow-sm">
        <div>
            <a href="{{ route('clientes.index') }}" class="text-sm font-medium text-slate-600 hover:text-slate-900 flex items-center space-x-1 transition">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
                <span>Voltar à listagem</span>
            </a>
        </div>

        <div class="flex items-center space-x-2">
            <a href="{{ route('clientes.edit', $cliente) }}" class="px-4 py-2 bg-teal-500 hover:bg-teal-600 text-white rounded-xl text-xs font-semibold transition flex items-center space-x-1.5 shadow-sm shadow-teal-100">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>
                <span>Editar Perfil</span>
            </a>

            <form action="{{ route('clientes.destroy', $cliente) }}" method="POST" onsubmit="return confirm('Tem a certeza que pretende remover definitivamente este cliente?')" class="inline m-0">
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

        <div class="md:col-span-4 bg-white rounded-2xl border border-slate-100 shadow-sm p-6 text-center space-y-4">
            <div class="w-20 h-20 rounded-2xl bg-teal-50 text-teal-600 font-bold flex items-center justify-center text-3xl uppercase mx-auto shadow-inner">
                {{ mb_substr($cliente->nome, 0, 1) }}
            </div>

            <div>
                <h2 class="text-xl font-bold text-slate-900 tracking-tight">{{ $cliente->nome }}</h2>
                <span class="text-xs font-semibold text-slate-400 uppercase tracking-wider">Ficha de Cliente #{{ $cliente->id }}</span>
            </div>

            <div class="pt-4 border-t border-slate-50 text-left space-y-3 text-sm">
                <div>
                    <span class="block text-[10px] font-bold text-slate-400 uppercase tracking-wider">NIF (Contribuinte)</span>
                    <span class="font-mono text-slate-800 font-semibold">{{ $cliente->nif }}</span>
                </div>
                <div>
                    <span class="block text-[10px] font-bold text-slate-400 uppercase tracking-wider">Email de Contacto</span>
                    <span class="text-slate-800 font-medium">{{ $cliente->email }}</span>
                </div>
                <div>
                    <span class="block text-[10px] font-bold text-slate-400 uppercase tracking-wider">Telefone</span>
                    <span class="text-slate-800 font-medium">{{ $cliente->telefone }}</span>
                </div>
                <div>
                    <span class="block text-[10px] font-bold text-slate-400 uppercase tracking-wider">Morada Fiscal</span>
                    <span class="text-slate-600 text-xs leading-relaxed block mt-0.5">{{ $cliente->morada }}</span>
                </div>
            </div>
        </div>

        <div class="md:col-span-8 space-y-6">
            <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8">
                <div class="border-b border-slate-50 pb-4 mb-6">
                    <h3 class="font-bold text-lg text-slate-900 tracking-tight">Histórico de Imóveis Adquiridos</h3>
                    <p class="text-slate-400 text-xs mt-0.5">Lista de escrituras e contratos celebrados com este proprietário.</p>
                </div>

                @if($cliente->vendas->isEmpty())
                    <div class="bg-slate-50 border border-dashed border-slate-200 rounded-xl py-8 text-center">
                        <svg class="w-10 h-10 text-slate-300 mx-auto mb-2" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"></path></svg>
                        <p class="text-slate-500 text-xs font-medium">Este cliente ainda não efetuou nenhuma compra.</p>
                        <a href="{{ route('vendas.create', ['cliente_id' => $cliente->id]) }}" class="text-teal-500 text-xs mt-1 inline-block font-semibold hover:underline">Registar uma venda agora</a>
                    </div>
                @else
                    <div class="space-y-3">
                        @foreach($cliente->vendas as $venda)
                            <div class="border border-slate-100 rounded-xl p-4 hover:bg-slate-50/50 transition flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4">
                                <div class="flex items-start space-x-3">
                                    <div class="p-2 bg-slate-900 text-white rounded-lg mt-0.5 flex-shrink-0">
                                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"></path></svg>
                                    </div>
                                    <div>
                                        <a href="{{ route('apartamentos.show', $venda->apartamento_id) }}" class="font-bold text-slate-900 text-sm hover:text-teal-600 transition">
                                            Apartamento {{ $venda->apartamento->referencia }}
                                        </a>
                                        <span class="block text-xs text-slate-400 mt-0.5 line-clamp-1">
                                            {{ $venda->apartamento->morada }} &middot; {{ $venda->apartamento->tipologia }}
                                        </span>
                                    </div>
                                </div>

                                <div class="flex items-center justify-between sm:justify-end sm:gap-6 border-t sm:border-t-0 border-slate-50 pt-2 sm:pt-0">
                                    <div class="text-left sm:text-right">
                                        <span class="block text-[10px] font-bold text-slate-400 uppercase">Data</span>
                                        <span class="text-xs font-semibold text-slate-600">{{ date('d/m/Y', strtotime($venda->data_venda)) }}</span>
                                    </div>
                                    <div class="text-right">
                                        <span class="block text-[10px] font-bold text-slate-400 uppercase">Valor Fechado</span>
                                        <span class="text-sm font-bold text-slate-900">{{ number_format($venda->valor_venda, 2, ',', ' ') }} €</span>
                                    </div>
                                </div>
                            </div>
                        @endforeach
                    </div>
                @endif
            </div>
        </div>

    </div>
</div>
@endsection
