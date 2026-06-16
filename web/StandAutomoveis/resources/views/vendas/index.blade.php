@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Histórico de Vendas</h1>
        <p class="text-sm text-neutral-500 mt-1">Consulte os contratos fechados, datas de transação e a respetiva atribuição de viaturas aos clientes.</p>
    </div>
    <a href="{{ route('vendas.create') }}"
       class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-200 uppercase text-xs tracking-wider group">
        <svg class="w-4 h-4 transform group-hover:rotate-90 transition-transform duration-200" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 4v16m8-8H4" />
        </svg>
        Registar Nova Venda
    </a>
</div>

<form action="{{ route('vendas.index') }}" method="GET" class="bg-white p-5 rounded-xl border border-neutral-200 shadow-sm mb-8 grid grid-cols-1 md:grid-cols-4 gap-4 items-end">
    <div class="md:col-span-2">
        <label for="search" class="block text-xs font-bold uppercase text-neutral-400 tracking-wider mb-2">Pesquisa Direta</label>
        <input type="text" name="search" id="search" value="{{ request('search') }}" placeholder="Nome do cliente, NIF, marca, modelo ou matrícula..."
               class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
    </div>

    <div>
        <label for="sort_by" class="block text-xs font-bold uppercase text-neutral-400 tracking-wider mb-2">Ordenar por</label>
        <select name="sort_by" id="sort_by" class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            <option value="id" {{ request('sort_by') == 'id' ? 'selected' : '' }}>ID do Contrato</option>
            <option value="data_venda" {{ request('sort_by') == 'data_venda' || !request('sort_by') ? 'selected' : '' }}>Data de Venda</option>
            <option value="valor_venda" {{ request('sort_by') == 'valor_venda' ? 'selected' : '' }}>Valor Fechado</option>
        </select>
    </div>

    <div class="flex gap-2">
        <div class="flex-1">
            <select name="order" class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                <option value="desc" {{ request('order') == 'desc' || !request('order') ? 'selected' : '' }}>Decrescente</option>
                <option value="asc" {{ request('order') == 'asc' ? 'selected' : '' }}>Crescente</option>
            </select>
        </div>

        <button type="submit" class="bg-neutral-900 hover:bg-neutral-800 text-white font-bold py-2.5 px-5 rounded-lg text-xs uppercase tracking-wider transition-colors duration-150 shadow-sm">
            Filtrar
        </button>
    </div>
</form>

<div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">
    <div class="overflow-x-auto">
        <table class="min-w-full divide-y divide-neutral-200">
            <thead class="bg-neutral-900 text-neutral-300">
                <tr>
                    <th scope="col" class="px-6 py-4 text-left text-xs font-bold uppercase tracking-wider">Contrato</th>
                    <th scope="col" class="px-6 py-4 text-left text-xs font-bold uppercase tracking-wider">Cliente</th>
                    <th scope="col" class="px-6 py-4 text-left text-xs font-bold uppercase tracking-wider">Viatura Associada</th>
                    <th scope="col" class="px-6 py-4 text-left text-xs font-bold uppercase tracking-wider">Data do Contrato</th>
                    <th scope="col" class="px-6 py-4 text-right text-xs font-bold uppercase tracking-wider">Valor Fechado</th>
                    <th scope="col" class="px-6 py-4 text-center text-xs font-bold uppercase tracking-wider">Operações</th>
                </tr>
            </thead>
            <tbody class="bg-white divide-y divide-neutral-200 text-sm text-neutral-700">
                @forelse ($vendas as $venda)
                    <tr class="hover:bg-neutral-50/70 transition-colors duration-150">
                        <td class="px-6 py-4 whitespace-nowrap font-bold font-mono text-neutral-900">
                            #{{ sprintf('%04d', $venda->id) }}
                        </td>

                        <td class="px-6 py-4 whitespace-nowrap">
                            <div class="font-bold text-neutral-900 tracking-tight">{{ $venda->cliente->nome }}</div>
                            <div class="text-xs font-mono text-neutral-400 mt-0.5">NIF {{ $venda->cliente->nif }}</div>
                        </td>

                        <td class="px-6 py-4 whitespace-nowrap">
                            <div class="font-bold text-neutral-800 tracking-tight">
                                {{ $venda->viatura->marca }}
                                <span class="font-normal text-neutral-500">{{ $venda->viatura->modelo }}</span>
                            </div>
                            <div class="inline-block bg-neutral-100 text-neutral-600 px-1.5 py-0.5 rounded font-mono text-[10px] font-bold border border-neutral-200 mt-1">
                                {{ $venda->viatura->matricula }}
                            </div>
                        </td>

                        <td class="px-6 py-4 whitespace-nowrap text-neutral-600 font-medium">
                            {{ \Carbon\Carbon::parse($venda->data_venda)->format('d/m/Y') }}
                        </td>

                        <td class="px-6 py-4 whitespace-nowrap text-right font-black text-neutral-900 text-base">
                            {{ number_format($venda->valor_venda, 2, ',', '.') }} €
                        </td>

                        <td class="px-6 py-4 whitespace-nowrap text-center text-xs font-bold uppercase tracking-wider space-x-1">
                            <a href="{{ route('vendas.show', $venda->id) }}"
                               class="inline-flex items-center px-2.5 py-1.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-md transition-colors duration-150">
                                Detalhes
                            </a>
                            <a href="{{ route('vendas.edit', $venda->id) }}"
                               class="inline-flex items-center px-2.5 py-1.5 text-amber-700 bg-amber-50 hover:bg-amber-100 border border-amber-200/40 rounded-md transition-colors duration-150">
                                Editar
                            </a>

                            <form action="{{ route('vendas.destroy', $venda->id) }}" method="POST" class="inline-block" onsubmit="return confirm('Ao cancelar esta venda, a viatura voltará ao estado DISPONÍVEL. Deseja continuar?');">
                                @csrf
                                @method('DELETE')
                                <button type="submit"
                                        class="inline-flex items-center px-2.5 py-1.5 text-rose-700 bg-rose-50 hover:bg-rose-100 border border-rose-200/40 rounded-md transition-colors duration-150">
                                    Cancelar
                                </button>
                            </form>
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="6" class="px-6 py-16 text-center bg-white">
                            <div class="flex flex-col items-center justify-center max-w-sm mx-auto">
                                <div class="p-4 bg-neutral-50 rounded-full text-neutral-400 border border-neutral-200/60 mb-4">
                                    <svg class="w-8 h-8 text-neutral-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="1.5">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                                    </svg>
                                </div>
                                <h3 class="text-sm font-bold text-neutral-800 uppercase tracking-wider">Nenhum Contrato Encontrado</h3>
                                <p class="text-xs text-neutral-400 mt-1.5 text-center leading-relaxed">
                                    Não foram detetados registos de venda que coincidam com os critérios de filtragem ou termos pesquisados no histórico.
                                </p>
                            </div>
                        </td>
                    </tr>
                @endforelse
            </tbody>
        </table>
    </div>

    {{-- SECÇÃO DE PAGINAÇÃO --}}
    @if ($vendas->hasPages())
        <div class="px-6 py-4 bg-neutral-50 border-t border-neutral-200">
            {{ $vendas->links() }}
        </div>
    @endif
</div>
@endsection
