@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Catálogo de Viaturas</h1>
        <p class="text-sm text-neutral-500 mt-1">Gira o stock de veículos, pesquise por marcas/modelos ou ordene por parâmetros de mercado.</p>
    </div>
    <a href="{{ route('viaturas.create') }}"
       class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-200 uppercase text-xs tracking-wider group">
        <svg class="w-4 h-4 transform group-hover:rotate-90 transition-transform duration-200" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 4v16m8-8H4" />
        </svg>
        Registar Viatura
    </a>
</div>

<form action="{{ route('viaturas.index') }}" method="GET" class="bg-white p-5 rounded-xl border border-neutral-200 shadow-sm mb-8 grid grid-cols-1 md:grid-cols-4 gap-4 items-end">
    <div class="md:col-span-2">
        <label for="search" class="block text-xs font-bold uppercase text-neutral-400 tracking-wider mb-2">Pesquisa Direta</label>
        <input type="text" name="search" id="search" value="{{ request('search') }}" placeholder="Marca, modelo ou matrícula..."
               class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
    </div>

    <div>
        <label for="sort_by" class="block text-xs font-bold uppercase text-neutral-400 tracking-wider mb-2">Ordenar por</label>
        <select name="sort_by" id="sort_by" class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            <option value="id" {{ request('sort_by') == 'id' ? 'selected' : '' }}>ID Interno</option>
            <option value="marca" {{ request('sort_by') == 'marca' ? 'selected' : '' }}>Marca</option>
            <option value="modelo" {{ request('sort_by') == 'modelo' ? 'selected' : '' }}>Modelo</option>
            <option value="ano" {{ request('sort_by') == 'ano' ? 'selected' : '' }}>Ano</option>
            <option value="preco" {{ request('sort_by') == 'preco' ? 'selected' : '' }}>Preço</option>
        </select>
    </div>

    <div class="flex gap-2">
        <div class="flex-1">
            <select name="order" class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                <option value="asc" {{ request('order') == 'asc' ? 'selected' : '' }}>Crescente</option>
                <option value="desc" {{ request('order') == 'desc' ? 'selected' : '' }}>Decrescente</option>
            </select>
        </div>

        <button type="submit" class="bg-neutral-900 hover:bg-neutral-800 text-white font-bold py-2.5 px-5 rounded-lg text-xs uppercase tracking-wider transition-colors duration-150 shadow-sm">
            Filtrar
        </button>
    </div>
</form>

<div class="flex flex-col gap-6">
    @forelse ($viaturas as $viatura)
        <div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden flex flex-col hover:shadow-md transition-all duration-200 group">

            <div class="p-4 flex flex-col md:flex-row gap-5">

                <div class="w-full md:w-72 h-44 bg-neutral-100 rounded-lg overflow-hidden relative flex-shrink-0 border border-neutral-100">
                    @if ($viatura->foto)
                        <img src="{{ asset('storage/' . $viatura->foto) }}" alt="{{ $viatura->marca }}" class="w-full h-full object-cover group-hover:scale-102 transition-transform duration-300">
                    @else
                        <div class="text-center h-full flex flex-col items-center justify-center p-4 bg-neutral-50">
                            <svg class="w-8 h-8 text-neutral-300" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="1.5">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            <p class="text-[9px] font-bold uppercase tracking-wider text-neutral-400 mt-1">Sem foto</p>
                        </div>
                    @endif

                    <span class="absolute top-2 left-2 bg-white text-neutral-800 text-[10px] font-bold px-2 py-0.5 rounded shadow-sm border border-neutral-200">
                        {{ $viatura->ano >= date('Y') - 1 ? 'Novo' : 'Usado' }}
                    </span>

                    <div class="absolute bottom-2 right-2 bg-neutral-900/70 text-white text-[9px] font-mono font-bold px-1.5 py-0.5 rounded tracking-wider">
                        1 / 4
                    </div>
                </div>

                <div class="flex-1 flex flex-col justify-between">
                    <div>
                        <div class="flex flex-col lg:flex-row justify-between items-start gap-2">
                            <div>
                                <h3 class="text-base font-bold text-neutral-900 tracking-tight">
                                    {{ $viatura->ano >= date('Y') - 1 ? 'Novo' : 'Usado' }} ({{ $viatura->ano }}) {{ $viatura->marca }} {{ $viatura->modelo }}
                                </h3>

                                <div class="flex flex-wrap items-center gap-x-2 gap-y-1 mt-2 text-xs text-neutral-500">
                                    <span class="bg-blue-50 text-neutral-800 px-1.5 py-0.5 rounded text-[11px] font-medium border border-blue-100/60">{{ $viatura->ano }}</span>
                                    <span class="bg-blue-50 text-blue-700 px-2 py-0.5 rounded text-[11px] font-bold border border-blue-100">{{ number_format($viatura->quilometros, 0, ',', '.') }} km</span>
                                    <span class="text-neutral-300">&bull;</span>
                                    <span class="text-neutral-600 font-medium">Matrícula: <strong class="font-mono text-neutral-900 text-[11px]">{{ $viatura->matricula }}</strong></span>
                                    <span class="text-neutral-300">&bull;</span>
                                    <span class="text-neutral-400 font-mono">Ref: #{{ sprintf('%03d', $viatura->id) }}</span>
                                </div>
                            </div>

                            <div class="flex items-center lg:items-end gap-3 lg:flex-col lg:text-right self-stretch lg:self-start justify-between border-t lg:border-t-0 pt-2 lg:pt-0 border-neutral-100 mt-1 lg:mt-0">
                                <p class="text-xl font-black text-neutral-900 tracking-tight">&euro; {{ number_format($viatura->preco, 0, ',', '.') }}</p>
                            </div>
                        </div>

                        <div class="mt-2.5">
                            <a href="{{ route('viaturas.show', $viatura->id) }}" class="text-xs font-bold text-sky-600 hover:text-sky-700 inline-flex items-center gap-0.5">
                                Detalhes
                                <svg class="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M9 5l7 7-7 7" />
                                </svg>
                            </a>
                        </div>
                    </div>

                    <div class="grid grid-cols-3 gap-3 mt-4">
                        <div class="border border-neutral-200/80 rounded-lg p-1.5 text-center bg-white shadow-sm flex flex-col justify-center min-h-[48px]">
                            <span class="block text-[9px] font-bold text-neutral-400 uppercase tracking-tight">Avaliação</span>
                            <span class="text-[11px] font-black text-emerald-600 inline-flex items-center justify-center gap-0.5">
                                <svg class="w-2.5 h-2.5" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="3"><path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" /></svg>
                                Adequado
                            </span>
                        </div>
                        <div class="border border-neutral-200/80 rounded-lg p-1.5 text-center bg-white shadow-sm flex flex-col justify-center min-h-[48px]">
                            <span class="block text-[9px] font-bold text-neutral-400 uppercase tracking-tight">Alteração Preço</span>
                            <span class="text-[11px] font-bold text-neutral-700">0%</span>
                        </div>
                        <div class="border border-neutral-200/80 rounded-lg p-1.5 text-center bg-white shadow-sm flex flex-col justify-center min-h-[48px]">
                            <span class="block text-[9px] font-bold text-neutral-400 uppercase tracking-tight">Estado Geral</span>
                            <span class="text-[10px] font-bold uppercase tracking-wider {{ $viatura->estado === 'disponível' ? 'text-emerald-600' : 'text-rose-600' }}">
                                {{ $viatura->estado }}
                            </span>
                        </div>
                    </div>

                </div>
            </div>

            <div class="bg-neutral-50 px-4 py-3 border-t border-neutral-200 flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4 text-xs">

                <div class="flex items-center gap-2">
                    <svg class="w-4 h-4 text-sky-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z" />
                    </svg>
                    <div>
                        <a href="{{ route('viaturas.show', $viatura->id) }}" class="font-bold text-sky-600 hover:underline inline-flex items-center gap-0.5">
                            AutoGest Direct
                            <svg class="w-2.5 h-2.5" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5"><path stroke-linecap="round" stroke-linejoin="round" d="M9 5l7 7-7 7" /></svg>
                        </a>
                        <span class="block text-[10px] text-neutral-400 font-medium">Pronto para entrega</span>
                    </div>
                </div>

                <div class="flex flex-wrap items-center justify-between sm:justify-end gap-x-4 gap-y-2 w-full sm:w-auto border-t sm:border-t-0 pt-2 sm:pt-0 border-neutral-200/60">
                    <div class="flex items-center gap-1.5">
                        <span class="w-2 h-2 rounded-full {{ $viatura->estado === 'disponível' ? 'bg-emerald-500' : 'bg-rose-400' }}"></span>
                        <span class="text-[11px] text-neutral-500 font-medium">Disponibilidade verificada</span>
                    </div>

                    <div class="flex items-center gap-1.5">
                        <a href="{{ route('viaturas.edit', $viatura->id) }}" class="text-neutral-500 hover:text-neutral-800 font-bold uppercase text-[10px] tracking-wider px-2 py-1.5 transition-colors">
                            Editar
                        </a>
                        <form action="{{ route('viaturas.destroy', $viatura->id) }}" method="POST" onsubmit="return confirm('Eliminar do sistema?');" class="inline">
                            @csrf
                            @method('DELETE')
                            <button type="submit" class="text-rose-600 hover:text-rose-800 font-bold uppercase text-[10px] tracking-wider px-2 py-1.5 transition-colors">
                                Apagar
                            </button>
                        </form>

                        <a href="{{ route('viaturas.show', $viatura->id) }}"
                           class="inline-flex items-center gap-1.5 bg-sky-500 hover:bg-sky-600 text-white font-bold py-2 px-3.5 rounded-lg shadow-sm text-[11px] uppercase tracking-wider transition-colors duration-150">
                            Ver o carro
                            <svg class="w-3.5 h-3.5" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M10 6H6a2 2 0 00-2 2v10a2 2 0 002 2h10a2 2 0 002-2v-4M14 4h6m0 0v6m0-6L10 14" />
                            </svg>
                        </a>
                    </div>
                </div>

            </div>
        </div>
    @empty
        <div class="bg-white border border-neutral-200 rounded-xl p-16 text-center shadow-sm">
            <div class="flex flex-col items-center justify-center max-w-sm mx-auto">
                <div class="p-4 bg-neutral-50 rounded-full text-neutral-400 border border-neutral-200/60 mb-4">
                    <svg class="w-8 h-8 text-neutral-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="1.5">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                    </svg>
                </div>
                <h3 class="text-sm font-bold text-neutral-800 uppercase tracking-wider">Nenhum Veículo Encontrado</h3>
                <p class="text-xs text-neutral-400 mt-1.5 text-center leading-relaxed">
                    Não existem viaturas em stock que coincidam com os critérios de filtragem ou termos pesquisados até ao momento.
                </p>
            </div>
        </div>
    @endforelse
</div>

<div class="mt-8 shadow-sm p-4 bg-white rounded-xl border border-neutral-200">
    {{ $viaturas->links() }}
</div>

@endsection
