@extends('layouts.app')

@section('content')
    <div class="space-y-8">

        <div class="flex flex-col md:flex-row md:items-center md:justify-between gap-4">
            <div>
                <h1 class="text-3xl font-bold tracking-tight text-slate-900">O Seu Imóvel Perfeito</h1>
                <p class="text-slate-500 text-sm mt-1">Gerencie a listagem de apartamentos, estados de ocupação e propostas
                    de venda.</p>
            </div>
            <div>
                <a href="{{ route('apartamentos.create') }}"
                    class="bg-teal-500 hover:bg-teal-600 text-white px-5 py-3 rounded-xl text-sm font-semibold transition shadow-sm flex items-center space-x-2">
                    <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4"></path>
                    </svg>
                    <span>Adicionar Apartamento</span>
                </a>
            </div>
        </div>

        <div class="bg-white p-5 rounded-2xl border border-slate-100 shadow-sm">
            <form action="{{ route('apartamentos.index') }}" method="GET"
                class="grid grid-cols-1 md:grid-cols-5 gap-4 items-end">

                <div class="md:col-span-2 space-y-1.5">
                    <label for="search" class="text-xs font-semibold text-slate-600 uppercase tracking-wider">Pesquisar
                        Imóvel</label>
                    <div class="relative">
                        <div class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none text-slate-400">
                            <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path>
                            </svg>
                        </div>
                        <input type="text" name="search" id="search" value="{{ request('search') }}"
                            placeholder="Referência, tipologia ou morada..."
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl pl-10 pr-4 py-2.5 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                    </div>
                </div>

                <div class="space-y-1.5">
                    <label for="estado"
                        class="text-xs font-semibold text-slate-600 uppercase tracking-wider">Estado</label>
                    <select name="estado" id="estado"
                        class="w-full bg-slate-50 border border-slate-200 rounded-xl px-3 py-2.5 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        <option value="">Todos</option>
                        <option value="Disponível" {{ request('estado') == 'Disponível' ? 'selected' : '' }}>Disponíveis
                        </option>
                        <option value="Vendido" {{ request('estado') == 'Vendido' ? 'selected' : '' }}>Vendidos</option>
                    </select>
                </div>

                <div class="space-y-1.5">
                    <label for="sort_by" class="text-xs font-semibold text-slate-600 uppercase tracking-wider">Ordenar
                        por</label>
                    <select name="sort_by" id="sort_by"
                        class="w-full bg-slate-50 border border-slate-200 rounded-xl px-3 py-2.5 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        <option value="id" {{ request('sort_by') == 'id' ? 'selected' : '' }}>ID do Registo</option>
                        <option value="tipologia" {{ request('sort_by') == 'tipologia' ? 'selected' : '' }}>Tipologia (T0,
                            T1...)</option>
                        <option value="area" {{ request('sort_by') == 'area' ? 'selected' : '' }}>Área Útil</option>
                        <option value="preco" {{ request('sort_by') == 'preco' ? 'selected' : '' }}>Preço de Venda</option>
                    </select>
                </div>

                <div class="flex gap-1.5">
                    <select name="order"
                        class="flex-1 min-w-0 bg-slate-50 border border-slate-200 rounded-xl pl-2 pr-7 py-2.5 text-xs focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        <option value="asc" {{ request('order') == 'asc' ? 'selected' : '' }}>Ascendente</option>
                        <option value="desc" {{ request('order') == 'desc' ? 'selected' : '' }}>Descendente</option>
                    </select>

                    <button type="submit"
                        class="shrink-0 bg-slate-900 hover:bg-slate-800 text-white rounded-xl text-xs font-semibold transition py-2.5 px-3.5 flex items-center justify-center">
                        <span>Aplicar</span>
                    </button>
                </div>

            </form>
        </div>

        @if ($apartamentos->count() === 0)
            <div class="bg-white border border-dashed border-slate-200 rounded-2xl py-12 text-center">
                <svg class="w-12 h-12 text-slate-300 mx-auto mb-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                        d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4">
                    </path>
                </svg>
                <p class="text-slate-500 text-sm font-medium">Nenhum apartamento encontrado para os critérios inseridos.</p>
                <a href="{{ route('apartamentos.index') }}"
                    class="text-teal-500 text-xs mt-1 inline-block font-semibold hover:underline">Limpar filtros</a>
            </div>
        @else
            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                @foreach ($apartamentos as $apartamento)
                    <div
                        class="bg-white rounded-2xl border border-slate-100 shadow-sm overflow-hidden flex flex-col group hover:shadow-md transition duration-200">

                        <div class="relative aspect-[16/10] bg-slate-100 overflow-hidden">
                            @if ($apartamento->fotografia)
                                <img src="{{ asset('storage/' . $apartamento->fotografia) }}" alt="Foto do Apartamento"
                                    class="w-full h-full object-cover group-hover:scale-105 transition duration-300">
                            @else
                                <div class="w-full h-full flex flex-col items-center justify-center text-slate-400">
                                    <svg class="w-10 h-10 stroke-1" fill="none" stroke="currentColor"
                                        viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                            d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z">
                                        </path>
                                    </svg>
                                    <span class="text-xs mt-1 font-medium">Sem fotografia</span>
                                </div>
                            @endif

                            <div class="absolute top-4 right-4">
                                @if ($apartamento->estado === 'Disponível')
                                    <span
                                        class="bg-emerald-500 text-white text-xs px-3 py-1.5 rounded-full font-semibold shadow-sm tracking-wide">
                                        Disponível
                                    </span>
                                @else
                                    <span
                                        class="bg-rose-500 text-white text-xs px-3 py-1.5 rounded-full font-semibold shadow-sm tracking-wide">
                                        Vendido
                                    </span>
                                @endif
                            </div>
                        </div>

                        <div class="p-6 flex-grow flex flex-col justify-between space-y-4">
                            <div class="space-y-2">
                                <div
                                    class="flex justify-between items-center text-xs font-bold text-teal-600 uppercase tracking-wide">
                                    <span>{{ $apartamento->tipologia }}</span>
                                    <span
                                        class="bg-slate-100 text-slate-600 px-2 py-0.5 rounded-md text-[10px]">{{ $apartamento->referencia }}</span>
                                </div>

                                <h3
                                    class="font-semibold text-slate-800 text-base line-clamp-1 group-hover:text-teal-600 transition">
                                    {{ $apartamento->morada }}
                                </h3>

                                <div class="flex items-baseline justify-between pt-1">
                                    <span class="text-slate-500 text-xs font-medium">{{ $apartamento->area }} m² de área
                                        útil</span>
                                    <span
                                        class="text-xl font-bold text-slate-900">{{ number_format($apartamento->preco, 2, ',', ' ') }}
                                        €</span>
                                </div>
                            </div>

                            <div class="pt-4 border-t border-slate-50 flex items-center justify-between gap-2">
                                <a href="{{ route('apartamentos.show', $apartamento) }}"
                                    class="text-xs font-semibold text-slate-600 hover:text-slate-900 px-3 py-2 bg-slate-50 hover:bg-slate-100 rounded-lg transition text-center flex-1">
                                    Ver Detalhes
                                </a>
                                <a href="{{ route('apartamentos.edit', $apartamento) }}"
                                    class="text-xs font-semibold text-teal-600 hover:text-white px-3 py-2 border border-teal-100 hover:bg-teal-500 hover:border-teal-500 rounded-lg transition text-center flex-1">
                                    Editar
                                </a>

                                <form action="{{ route('apartamentos.destroy', $apartamento) }}" method="POST"
                                    onsubmit="return confirm('Tem a certeza que pretende remover este apartamento?')"
                                    class="inline m-0">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit"
                                        class="p-2 text-rose-500 hover:text-white hover:bg-rose-500 rounded-lg transition"
                                        title="Apagar Imóvel">
                                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                                d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16">
                                            </path>
                                        </svg>
                                    </button>
                                </form>
                            </div>

                        </div>
                    </div>
                @endforeach
            </div>
            <div class="mt-10 flex justify-center">
                {{ $apartamentos->links() }}
            </div>
        @endif
    </div>
@endsection
