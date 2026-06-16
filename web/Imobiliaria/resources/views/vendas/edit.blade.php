@extends('layouts.app')

@section('content')
<div class="max-w-3xl mx-auto space-y-6">

    <div>
        <a href="{{ route('vendas.show', $venda) }}" class="text-sm font-medium text-slate-600 hover:text-slate-900 flex items-center space-x-1 transition">
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
            <span>Voltar ao relatório da venda</span>
        </a>
    </div>

    <div>
        <h1 class="text-3xl font-bold tracking-tight text-slate-900">Modificar Registo de Venda</h1>
        <p class="text-slate-500 text-sm mt-1">Ajuste os valores, datas ou observações do contrato do documento <span class="font-mono bg-slate-100 text-slate-800 px-1.5 py-0.5 rounded text-xs">#VF-{{ str_pad($venda->id, 4, '0', STR_PAD_LEFT) }}</span>.</p>
    </div>

    <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8">

        <form action="{{ route('vendas.update', $venda) }}" method="POST" class="space-y-6">
            @csrf
            @method('PUT') <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                <div class="md:col-span-2 space-y-1.5">
                    <label class="text-xs font-semibold text-slate-400 uppercase tracking-wider">Cliente Comprador (Fixo)</label>
                    <div class="w-full bg-slate-50 border border-slate-200 text-slate-500 rounded-xl px-4 py-3 text-sm flex items-center justify-between select-none">
                        <span class="font-medium">{{ $venda->cliente->nome }}</span>
                        <span class="text-xs font-mono bg-slate-200/60 px-2 py-0.5 rounded text-slate-600">NIF {{ $venda->cliente->nif }}</span>
                    </div>
                    <input type="hidden" name="cliente_id" value="{{ $venda->cliente_id }}">
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label class="text-xs font-semibold text-slate-400 uppercase tracking-wider">Apartamento Transacionado (Fixo)</label>
                    <div class="w-full bg-slate-50 border border-slate-200 text-slate-500 rounded-xl px-4 py-3 text-sm flex items-center justify-between select-none">
                        <span class="font-medium">[{{ $venda->apartamento->referencia }}] Apartamento {{ $venda->apartamento->tipologia }}</span>
                        <span class="text-xs text-slate-400 max-w-xs truncate hidden sm:inline">{{ $venda->apartamento->morada }}</span>
                    </div>
                    <input type="hidden" name="apartamento_id" value="{{ $venda->apartamento_id }}">
                    <p class="text-[11px] text-slate-400 italic mt-1">Nota: Por motivos de auditoria e segurança fiscal, não é permitido alterar os intervenientes (Cliente/Imóvel) diretamente. Caso tenha ocorrido um erro de digitação, deverá anular esta venda e registar uma nova.</p>
                </div>

                <div class="space-y-1.5">
                    <label for="data_venda" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Data do Contrato / Escritura</label>
                    <input type="date" name="data_venda" id="data_venda"
                           value="{{ old('data_venda', date('Y-m-d', strtotime($venda->data_venda))) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="valor_venda" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Valor de Venda Acordado (€)</label>
                    <input type="number" name="valor_venda" id="valor_venda"
                           value="{{ old('valor_venda', $venda->valor_venda) }}" required min="0" step="0.01"
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition font-bold text-slate-900">
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label for="observacoes" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Observações / Cláusulas Especiais</label>
                    <textarea name="observacoes" id="observacoes" rows="4"
                              placeholder="Insira detalhes adicionais sobre o negócio..."
                              class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition leading-relaxed">{{ old('observacoes', $venda->observacoes) }}</textarea>
                </div>

            </div>

            <div class="pt-6 border-t border-slate-100 flex items-center justify-end space-x-3">
                <a href="{{ route('vendas.show', $venda) }}" class="px-5 py-3 rounded-xl text-sm font-semibold text-slate-600 hover:bg-slate-50 transition">
                    Cancelar
                </a>
                <button type="submit" class="bg-teal-500 hover:bg-teal-600 text-white px-6 py-3 rounded-xl text-sm font-semibold transition shadow-sm shadow-teal-100">
                    Atualizar Registo de Venda
                </button>
            </div>

        </form>
    </div>
</div>
@endsection
