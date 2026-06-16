@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Registar Contrato de Venda</h1>
        <p class="text-sm text-neutral-500 mt-1">Associe um cliente a uma viatura em stock e defina os valores acordados para a transação.</p>
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
            <span class="text-xs text-neutral-400 font-mono font-bold">ABERTURA DE NOVO PROCESSO DE VENDA</span>
        </div>
        <span class="bg-orange-950 text-orange-400 px-2.5 py-0.5 rounded font-mono text-[10px] font-bold border border-orange-900/40 tracking-wider">
            NOVO REGISTO
        </span>
    </div>

    <form action="{{ route('vendas.store') }}" method="POST" class="p-6 space-y-6">
        @csrf

        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

            <div>
                <label for="cliente_id" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Selecionar Cliente</label>
                <select name="cliente_id" id="cliente_id" required
                        class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-sm text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                    <option value="" class="text-neutral-400">-- Escolha um cliente --</option>
                    @foreach($clientes as $cliente)
                        <option value="{{ $cliente->id }}" {{ old('cliente_id') == $cliente->id ? 'selected' : '' }}>
                            {{ $cliente->nome }} (NIF: {{ $cliente->nif }})
                        </option>
                    @endforeach
                </select>
            </div>

            <div>
                <label for="viatura_id" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Selecionar Viatura (Apenas Disponíveis)</label>
                <select name="viatura_id" id="viatura_id" required
                        class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-sm text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                    <option value="" class="text-neutral-400">-- Escolha um veículo --</option>
                    @foreach($viaturas as $viatura)
                        <option value="{{ $viatura->id }}" {{ old('viatura_id') == $viatura->id ? 'selected' : '' }}>
                            {{ $viatura->marca }} {{ $viatura->modelo }} [{{ $viatura->matricula }}] — {{ number_format($viatura->preco, 2, ',', '.') }} €
                        </option>
                    @endforeach
                </select>
            </div>

            <div>
                <label for="data_venda" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Data da Venda</label>
                <input type="date" name="data_venda" id="data_venda" max="{{ date('Y-m-d') }}" value="{{ old('data_venda', date('Y-m-d')) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="valor_venda" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Valor de Venda Acordado (€)</label>
                <input type="number" name="valor_venda" id="valor_venda" step="0.01" min="0" value="{{ old('valor_venda') }}" required placeholder="Ex: 24500.00"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div class="md:col-span-2">
                <label for="observacoes" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Observações do Contrato (Opcional)</label>
                <textarea name="observacoes" id="observacoes" rows="4" placeholder="Detalhes sobre garantias incluídas, plano ou método de pagamento, revisões ou observações de retoma..."
                          class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">{{ old('observacoes') }}</textarea>
            </div>
        </div>

        <div class="flex items-center justify-end space-x-3 pt-5 border-t border-neutral-100 bg-neutral-50/40 -mx-6 -mb-6 p-6">

            <a href="{{ route('vendas.index') }}"
               class="inline-flex items-center px-4 py-2.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-lg font-bold uppercase text-xs tracking-wider transition-colors duration-150">
                Voltar
            </a>

            <button type="submit"
                    class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
                <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-transform duration-150 group-hover:scale-110" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
                Emitir Contrato
            </button>

        </div>
    </form>
</div>
@endsection
