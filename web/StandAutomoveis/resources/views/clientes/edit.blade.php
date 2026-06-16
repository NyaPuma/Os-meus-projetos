@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Modificar Ficha do Cliente</h1>
        <p class="text-sm text-neutral-500 mt-1">Altere as informações necessárias nos campos abaixo e grave as alterações para atualizar o registo.</p>
    </div>
    <a href="{{ route('clientes.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Cancelar e Voltar
    </a>
</div>

<div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">

    <div class="bg-neutral-900 px-6 py-4 border-b border-neutral-800 flex items-center gap-2">
        <span class="text-sm">📝</span>
        <h3 class="text-xs font-bold uppercase tracking-wider text-neutral-300">Formulário de Atualização de Dados</h3>
    </div>

    <form action="{{ route('clientes.update', $cliente->id) }}" method="POST" class="p-6 space-y-6">
        @csrf
        @method('PUT')

        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

            <div>
                <label for="nome" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Nome Completo</label>
                <div class="relative rounded-md shadow-sm">
                    <input type="text" name="nome" id="nome"
                           value="{{ old('nome', $cliente->nome) }}" required
                           class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                </div>
            </div>

            <div>
                <label for="email" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Endereço Eletrónico</label>
                <div class="relative rounded-md shadow-sm">
                    <input type="email" name="email" id="email"
                           value="{{ old('email', $cliente->email) }}" required
                           class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                </div>
            </div>

            <div>
                <label for="telefone" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Contacto Telefónico</label>
                <div class="relative rounded-md shadow-sm">
                    <input type="text" name="telefone" id="telefone"
                           value="{{ old('telefone', $cliente->telefone) }}" required
                           class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                </div>
            </div>

            <div>
                <label for="nif" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">NIF (Contribuinte)</label>
                <div class="relative rounded-md shadow-sm">
                    <input type="text" name="nif" id="nif" maxlength="9"
                           value="{{ old('nif', $cliente->nif) }}" required
                           class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm font-mono tracking-wide text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                </div>
            </div>

            <div class="md:col-span-2 border-t border-neutral-100 pt-4">
                <label for="morada" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Morada de Faturação</label>
                <div class="relative rounded-md shadow-sm">
                    <input type="text" name="morada" id="morada"
                           value="{{ old('morada', $cliente->morada) }}" required
                           class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                </div>
            </div>

        </div>

        <div class="flex items-center justify-end space-x-3 pt-5 border-t border-neutral-100 bg-neutral-50/40 -mx-6 -mb-6 p-6">

            <a href="{{ route('clientes.index') }}"
               class="inline-flex items-center px-4 py-2.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-lg font-bold uppercase text-xs tracking-wider transition-colors duration-150">
                Descartar
            </a>

            <button type="submit"
                    class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
                <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-colors duration-150" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
                </svg>
                Gravar Alterações
            </button>

        </div>
    </form>
</div>
@endsection
