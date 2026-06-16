@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Retificar Contrato #{{ sprintf('%04d', $venda->id) }}</h1>
        <p class="text-sm text-neutral-500 mt-1">Modifique as informações do negócio. Atenção: alterar a viatura redefinirá os estados de stock associados.</p>
    </div>
    <a href="{{ route('vendas.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Voltar ao Histórico
    </a>
</div>

<div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">

    <div class="bg-neutral-900 px-6 py-4 border-b border-neutral-800 flex items-center justify-between">
        <div class="flex items-center gap-2">
            <span class="text-xs text-neutral-400 font-mono font-bold">RETIFICAÇÃO DE DADOS FINANCEIROS</span>
        </div>
        <span class="bg-neutral-800 text-neutral-400 px-2.5 py-0.5 rounded font-mono text-[10px] font-bold border border-neutral-700 tracking-wider">
            EDIÇÃO
        </span>
    </div>

    <form action="{{ route('vendas.update', $venda->id) }}" method="POST" class="p-6 space-y-6">
        @csrf
        @method('PUT')

        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

            <div>
                <label for="cliente_id" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Cliente Beneficiário</label>
                <select name="cliente_id" id="cliente_id" required
                        class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-sm text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                    @foreach($clientes as $cliente)
                        <option value="{{ $cliente->id }}" {{ old('cliente_id', $venda->cliente_id) == $cliente->id ? 'selected' : '' }}>
                            {{ $cliente->nome }} (NIF: {{ $cliente->nif }})
                        </option>
                    @endforeach
                </select>
            </div>

            <div>
                <label for="viatura_id" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Viatura Associada</label>
                <select name="viatura_id" id="viatura_id" required
                        class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-sm text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                    @foreach($viaturas as $viatura)
                        <option value="{{ $viatura->id }}" {{ old('viatura_id', $venda->viatura_id) == $viatura->id ? 'selected' : '' }}>
                            {{ $viatura->marca }} {{ $viatura->modelo }} [{{ $viatura->matricula }}]
                            {{ $viatura->id == $venda->viatura_id ? '— (Viatura Atual deste Contrato)' : '' }}
                        </option>
                    @endforeach
                </select>
            </div>

            <div>
                <label for="data_venda" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Data da Venda</label>
                <input type="date" name="data_venda" id="data_venda" max="{{ date('Y-m-d') }}" value="{{ old('data_venda', $venda->data_venda) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="valor_venda" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Valor de Venda (€)</label>
                <input type="number" name="valor_venda" id="valor_venda" step="0.01" min="0" value="{{ old('valor_venda', $venda->valor_venda) }}" required placeholder="0.00"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div class="md:col-span-2">
                <label for="observacoes" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Observações Retificadas</label>
                <textarea name="observacoes" id="observacoes" rows="4" placeholder="Cláusulas adicionais, detalhes de retoma ou condições de garantia..."
                          class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">{{ old('observacoes', $venda->observacoes) }}</textarea>
            </div>
        </div>

        <div class="flex items-center justify-end space-x-3 pt-5 border-t border-neutral-100 bg-neutral-50/40 -mx-6 -mb-6 p-6">

            <a href="{{ route('vendas.index') }}"
               class="inline-flex items-center px-4 py-2.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-lg font-bold uppercase text-xs tracking-wider transition-colors duration-150">
                Descartar
            </a>

            <button type="submit"
                    class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
                <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-colors duration-150" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
                </svg>
                Atualizar Contrato
            </button>

        </div>
    </form>
</div>
@endsection
