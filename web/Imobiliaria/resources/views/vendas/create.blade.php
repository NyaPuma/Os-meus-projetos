@extends('layouts.app')

@section('content')
<div class="max-w-3xl mx-auto space-y-6">

    <div>
        <a href="{{ route('vendas.index') }}" class="text-sm font-medium text-slate-600 hover:text-slate-900 flex items-center space-x-1 transition">
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
            <span>Voltar ao histórico</span>
        </a>
    </div>

    <div>
        <h1 class="text-3xl font-bold tracking-tight text-slate-900">Registar Transação Imobiliária</h1>
        <p class="text-slate-500 text-sm mt-1">Formalize o contrato de compra e venda. Ao gravar, o estado do apartamento passará automaticamente para <span class="font-semibold text-rose-600 uppercase text-xs bg-rose-50 px-1.5 py-0.5 rounded">Vendido</span>.</p>
    </div>

    <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8">

        <form action="{{ route('vendas.store') }}" method="POST" class="space-y-6">
            @csrf

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                <div class="md:col-span-2 space-y-1.5">
                    <label for="cliente_id" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Cliente Comprador</label>
                    <select name="cliente_id" id="cliente_id" required
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        <option value="" disabled {{ !request('cliente_id') ? 'selected' : '' }}>Selecione o comprador...</option>
                        @foreach($clientes as $cliente)
                            <option value="{{ $cliente->id }}"
                                {{ old('cliente_id', request('cliente_id')) == $cliente->id ? 'selected' : '' }}>
                                {{ $cliente->nome }} (NIF: {{ $cliente->nif }})
                            </option>
                        @endforeach
                    </select>
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label for="apartamento_id" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Apartamento Catalagado</label>
                    <select name="apartamento_id" id="apartamento_id" required
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        <option value="" disabled {{ !request('apartamento_id') ? 'selected' : '' }}>Selecione o imóvel disponível...</option>
                        @foreach($apartamentos as $apartamento)
                            <option value="{{ $apartamento->id }}"
                                {{ old('apartamento_id', request('apartamento_id')) == $apartamento->id ? 'selected' : '' }}>
                                [{{ $apartamento->referencia }}] {{ $apartamento->tipologia }} - {{ $apartamento->morada }} (Preço Base: {{ number_format($apartamento->preco, 0, ',', ' ') }}€)
                            </option>
                        @endforeach
                    </select>
                    <p class="text-[11px] text-slate-400 italic mt-1">Nota: Imóveis que já foram vendidos não são listados nesta secção por segurança relacional.</p>
                </div>

                <div class="space-y-1.5">
                    <label for="data_venda" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Data do Contrato / Escritura</label>
                    <input type="date" name="data_venda" id="data_venda"
                           value="{{ old('data_venda', date('Y-m-d')) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="valor_venda" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Valor de Venda Acordado (€)</label>
                    <input type="number" name="valor_venda" id="valor_venda" value="{{ old('valor_venda') }}" required min="0" step="0.01"
                           placeholder="Ex: 240000"
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition font-bold text-slate-900">
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label for="observacoes" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Observações / Cláusulas Especiais</label>
                    <textarea name="observacoes" id="observacoes" rows="4"
                              placeholder="Insira detalhes adicionais sobre o negócio, como condições de pronto pagamento, dependência de crédito bancário ou notas sobre a entrega das chaves..."
                              class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition leading-relaxed">{{ old('observacoes') }}</textarea>
                </div>

            </div>

            <div class="pt-6 border-t border-slate-100 flex items-center justify-end space-x-3">
                <a href="{{ route('vendas.index') }}" class="px-5 py-3 rounded-xl text-sm font-semibold text-slate-600 hover:bg-slate-50 transition">
                    Cancelar
                </a>
                <button type="submit" class="bg-slate-900 hover:bg-slate-800 text-white px-6 py-3 rounded-xl text-sm font-semibold transition shadow-md shadow-slate-200">
                    Celebrar e Fechar Negócio
                </button>
            </div>

        </form>
    </div>
</div>
@endsection
