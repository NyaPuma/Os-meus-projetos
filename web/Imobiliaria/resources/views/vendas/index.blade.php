@extends('layouts.app')

@section('content')
    <div class="space-y-8">

        <div class="flex flex-col md:flex-row md:items-center md:justify-between gap-4">
            <div>
                <h1 class="text-3xl font-bold tracking-tight text-slate-900">Histórico de Vendas</h1>
                <p class="text-slate-500 text-sm mt-1">
                    Monitore o volume de negócios, contratos fechados e escrituras realizadas pela agência.
                </p>
            </div>

            <div>
                <a href="{{ route('vendas.create') }}"
                    class="bg-slate-900 hover:bg-slate-800 text-white px-5 py-3 rounded-xl text-sm font-semibold transition shadow-sm flex items-center space-x-2">
                    <svg class="w-5 h-5 text-teal-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
                    </svg>
                    <span>Registar Nova Venda</span>
                </a>
            </div>
        </div>

        <!-- SEARCH + ORDER -->
        <div class="bg-white p-5 rounded-2xl border border-slate-100 shadow-sm">

            <form action="{{ route('vendas.index') }}" method="GET"
                class="grid grid-cols-1 md:grid-cols-4 gap-4 items-end">

                <!-- SEARCH -->
                <div class="md:col-span-2 space-y-1.5">
                    <label class="text-xs font-semibold text-slate-600 uppercase tracking-wider">
                        Pesquisar Venda
                    </label>

                    <div class="relative">
                        <div class="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-400">
                            <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                            </svg>
                        </div>

                        <input type="text" name="search" value="{{ request('search') }}"
                            placeholder="Cliente, referência do imóvel ou morada..."
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl pl-10 pr-4 py-2.5 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                    </div>
                </div>

                <!-- SORT BY -->
                <div class="space-y-1.5">
                    <label class="text-xs font-semibold text-slate-600 uppercase tracking-wider">
                        Ordenar por
                    </label>

                    <select name="sort_by"
                        class="w-full bg-slate-50 border border-slate-200 rounded-xl px-3 py-2.5 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">

                        <option value="id" {{ request('sort_by') == 'id' ? 'selected' : '' }}>
                            ID da Venda
                        </option>

                        <option value="data_venda" {{ request('sort_by') == 'data_venda' ? 'selected' : '' }}>
                            Data
                        </option>

                        <option value="valor_venda" {{ request('sort_by') == 'valor_venda' ? 'selected' : '' }}>
                            Valor
                        </option>

                    </select>
                </div>

                <!-- ORDER + BUTTON -->
                <div class="flex gap-2">

                    <select name="order"
                        class="w-1/2 bg-slate-50 border border-slate-200 rounded-xl px-3 py-2.5 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">

                        <option value="asc" {{ request('order') == 'asc' ? 'selected' : '' }}>Ascendente</option>
                        <option value="desc" {{ request('order') == 'desc' ? 'selected' : '' }}>Descendente</option>

                    </select>

                    <button type="submit"
                        class="w-1/2 bg-slate-900 hover:bg-slate-800 text-white rounded-xl text-sm font-medium transition py-2.5 px-4">
                        Aplicar
                    </button>

                </div>

            </form>
        </div>

        @if ($vendas->isEmpty())
            <div class="bg-white border border-dashed border-slate-200 rounded-2xl py-12 text-center">
                <p class="text-slate-500 text-sm font-medium">
                    Nenhuma venda encontrada para os critérios inseridos.
                </p>
            </div>
        @else
            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">

                @foreach ($vendas as $venda)
                    <div
                        class="bg-white rounded-2xl border border-slate-100 shadow-sm overflow-hidden flex flex-col group hover:shadow-md transition duration-200">

                        <div class="p-6 flex-grow flex flex-col justify-between space-y-4">

                            <div class="space-y-3">

                                <div class="flex items-center justify-between">
                                    <span class="text-xs font-bold text-teal-600 uppercase tracking-wide">
                                        Venda
                                    </span>

                                    <span
                                        class="bg-slate-100 text-slate-600 px-2 py-0.5 rounded-md text-[10px] font-semibold">
                                        #VF-{{ str_pad($venda->id, 4, '0', STR_PAD_LEFT) }}
                                    </span>
                                </div>

                                <div>
                                    <p class="text-xs text-slate-500 font-semibold">Cliente</p>
                                    <a href="{{ route('clientes.show', $venda->cliente_id) }}"
                                        class="font-semibold text-slate-900 hover:text-teal-600 transition">
                                        {{ $venda->cliente->nome }}
                                    </a>
                                </div>

                                <div>
                                    <p class="text-xs text-slate-500 font-semibold">Imóvel</p>
                                    <a href="{{ route('apartamentos.show', $venda->apartamento_id) }}"
                                        class="text-xs font-bold text-slate-800 bg-slate-100 px-2 py-1 rounded-md hover:text-teal-600 transition inline-block">
                                        {{ $venda->apartamento->referencia }}
                                    </a>
                                    <p class="text-xs text-slate-400 mt-1 line-clamp-1">
                                        {{ $venda->apartamento->morada }}
                                    </p>
                                </div>

                            </div>

                            <div class="pt-4 border-t border-slate-50 flex items-center justify-between gap-2">

                                <a href="{{ route('vendas.show', $venda) }}"
                                    class="text-xs font-semibold text-slate-600 hover:text-slate-900 px-3 py-2 bg-slate-50 hover:bg-slate-100 rounded-lg transition text-center flex-1">
                                    Ver
                                </a>

                                <a href="{{ route('vendas.edit', $venda) }}"
                                    class="text-xs font-semibold text-teal-600 hover:text-white px-3 py-2 border border-teal-100 hover:bg-teal-500 hover:border-teal-500 rounded-lg transition text-center flex-1">
                                    Editar
                                </a>

                            </div>

                        </div>
                    </div>
                @endforeach

            </div>
            <div class="mt-10 flex justify-center">
                {{ $vendas->links() }}
            </div>
        @endif

    </div>
@endsection
