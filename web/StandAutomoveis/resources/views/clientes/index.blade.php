@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Gestão de Clientes</h1>
        <p class="text-sm text-neutral-500 mt-1">Consulte, adicione ou faça a manutenção dos clientes registados no sistema.</p>
    </div>
    <a href="{{ route('clientes.create') }}"
       class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-200 uppercase text-xs tracking-wider group">
        <svg class="w-4 h-4 transform group-hover:rotate-90 transition-transform duration-200" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 4v16m8-8H4" />
        </svg>
        Adicionar Cliente
    </a>
</div>

<form action="{{ route('clientes.index') }}" method="GET" class="bg-white p-5 rounded-xl border border-neutral-200 shadow-sm mb-8 grid grid-cols-1 md:grid-cols-4 gap-4 items-end">
    <div class="md:col-span-2">
        <label for="search" class="block text-xs font-bold uppercase text-neutral-400 tracking-wider mb-2">Pesquisa Direta</label>
        <input type="text" name="search" id="search" value="{{ request('search') }}" placeholder="Pesquise por nome, e-mail, telefone ou NIF..."
               class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
    </div>

    <div>
        <label for="sort_by" class="block text-xs font-bold uppercase text-neutral-400 tracking-wider mb-2">Ordenar por</label>
        <select name="sort_by" id="sort_by" class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            <option value="id" {{ request('sort_by') == 'id' ? 'selected' : '' }}>ID do Cliente</option>
            <option value="nome" {{ request('sort_by') == 'nome' || !request('sort_by') ? 'selected' : '' }}>Nome do Cliente</option>
        </select>
    </div>

    <div class="flex gap-2">
        <div class="flex-1">
            <select name="order" class="w-full text-sm rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                <option value="asc" {{ request('order') == 'asc' || !request('order') ? 'selected' : '' }}>Crescente (A-Z)</option>
                <option value="desc" {{ request('order') == 'desc' ? 'selected' : '' }}>Decrescente (Z-A)</option>
            </select>
        </div>

        <button type="submit" class="bg-neutral-900 hover:bg-neutral-800 text-white font-bold py-2.5 px-5 rounded-lg text-xs uppercase tracking-wider transition-colors duration-150 shadow-sm">
            Filtrar
        </button>
    </div>
</form>

<div class="overflow-x-auto rounded-xl border border-neutral-200 shadow-sm bg-white">
    <table class="min-w-full divide-y divide-neutral-200">
        <thead class="bg-neutral-900">
            <tr>
                <th scope="col" class="px-6 py-4 text-left text-xs font-bold text-neutral-300 uppercase tracking-wider w-24">ID</th>
                <th scope="col" class="px-6 py-4 text-left text-xs font-bold text-neutral-300 uppercase tracking-wider">Nome do Cliente</th>
                <th scope="col" class="px-6 py-4 text-left text-xs font-bold text-neutral-300 uppercase tracking-wider">Contacto / Email</th>
                <th scope="col" class="px-6 py-4 text-left text-xs font-bold text-neutral-300 uppercase tracking-wider">NIF</th>
                <th scope="col" class="px-6 py-4 text-center text-xs font-bold text-neutral-300 uppercase tracking-wider w-52">Ações</th>
            </tr>
        </thead>
        <tbody class="divide-y divide-neutral-100 text-sm text-neutral-700 bg-white">
            @forelse ($clientes as $cliente)
                <tr class="hover:bg-neutral-50/60 transition-colors duration-150">

                    <td class="px-6 py-4 whitespace-nowrap font-mono text-xs text-neutral-400 font-bold">
                        #{{ sprintf('%03d', $cliente->id) }}
                    </td>

                    <td class="px-6 py-4 whitespace-nowrap">
                        <div class="font-bold text-neutral-900 text-base">{{ $cliente->nome }}</div>
                    </td>

                    <td class="px-6 py-4 whitespace-nowrap">
                        <div class="font-medium text-neutral-800 flex items-center gap-1.5">
                            <span class="text-neutral-400 text-xs">📞</span> {{ $cliente->telefone }}
                        </div>
                        <div class="text-xs text-neutral-400 font-normal mt-0.5">{{ $cliente->email }}</div>
                    </td>

                    <td class="px-6 py-4 whitespace-nowrap">
                        <span class="bg-neutral-100 text-neutral-700 px-2.5 py-1 rounded-md font-mono text-xs font-semibold border border-neutral-200">
                            {{ $cliente->nif }}
                        </span>
                    </td>

                    <td class="px-6 py-4 whitespace-nowrap text-center space-x-1.5 text-xs font-bold uppercase tracking-wider">

                        <a href="{{ route('clientes.show', $cliente->id) }}"
                           class="inline-flex items-center px-2.5 py-1.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-md transition-colors duration-150">
                            Ver
                        </a>

                        <a href="{{ route('clientes.edit', $cliente->id) }}"
                           class="inline-flex items-center px-2.5 py-1.5 text-amber-700 bg-amber-50 hover:bg-amber-100 border border-amber-200/40 rounded-md transition-colors duration-150">
                            Editar
                        </a>

                        <form action="{{ route('clientes.destroy', $cliente->id) }}" method="POST" class="inline-block" onsubmit="return confirm('Tem a certeza que deseja apagar este cliente?');">
                            @csrf
                            @method('DELETE')
                            <button type="submit"
                                    class="inline-flex items-center px-2.5 py-1.5 text-rose-700 bg-rose-50 hover:bg-rose-100 border border-rose-200/40 rounded-md transition-colors duration-150">
                                Apagar
                            </button>
                        </form>

                    </td>
                </tr>
            @empty
                <tr>
                    <td colspan="5" class="px-6 py-16 text-center">
                        <div class="flex flex-col items-center justify-center max-w-sm mx-auto">
                            <div class="p-4 bg-neutral-50 rounded-full text-neutral-400 border border-neutral-200/60 mb-4">
                                <svg class="w-8 h-8 text-neutral-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="1.5">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                                </svg>
                            </div>
                            <h3 class="text-sm font-bold text-neutral-800 uppercase tracking-wider">Nenhum Cliente Encontrado</h3>
                            <p class="text-xs text-neutral-400 mt-1.5 text-center leading-relaxed">
                                Não foram localizados registos que coincidam com os critérios de pesquisa ou ordenação aplicados.
                            </p>
                        </div>
                    </td>
                </tr>
            @endforelse
        </tbody>
    </table>
</div>

<div class="mt-8 shadow-sm p-4 bg-white rounded-xl border border-neutral-200">
    {{ $clientes->links() }}
</div>

@endsection
