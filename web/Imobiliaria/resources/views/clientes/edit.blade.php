@extends('layouts.app')

@section('content')
<div class="max-w-3xl mx-auto space-y-6">

    <div>
        <a href="{{ route('clientes.index') }}" class="text-sm font-medium text-teal-600 hover:text-teal-700 flex items-center space-x-1 transition">
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
            <span>Voltar à listagem</span>
        </a>
    </div>

    <div>
        <h1 class="text-3xl font-bold tracking-tight text-slate-900">Modificar Ficha de Cliente</h1>
        <p class="text-slate-500 text-sm mt-1">Atualize as informações de contacto ou dados fiscais do cliente: <span class="font-semibold text-slate-800">{{ $cliente->nome }}</span>.</p>
    </div>

    <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8">

        <form action="{{ route('clientes.update', $cliente) }}" method="POST" class="space-y-6">
            @csrf
            @method('PUT') <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                <div class="md:col-span-2 space-y-1.5">
                    <label for="nome" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Nome Completo</label>
                    <input type="text" name="nome" id="nome" value="{{ old('nome', $cliente->nome) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="nif" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">NIF (Contribuinte)</label>
                    <input type="text" name="nif" id="nif" value="{{ old('nif', $cliente->nif) }}" required maxlength="9" pattern="[0-9]{9}"
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition font-mono">
                </div>

                <div class="space-y-1.5">
                    <label for="telefone" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Contacto Telefónico</label>
                    <input type="tel" name="telefone" id="telefone" value="{{ old('telefone', $cliente->telefone) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label for="email" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Endereço de Email</label>
                    <input type="email" name="email" id="email" value="{{ old('email', $cliente->email) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label for="morada" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Morada Fiscal</label>
                    <input type="text" name="morada" id="morada" value="{{ old('morada', $cliente->morada) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

            </div>

            <div class="pt-6 border-t border-slate-100 flex items-center justify-end space-x-3">
                <a href="{{ route('clientes.index') }}" class="px-5 py-3 rounded-xl text-sm font-semibold text-slate-600 hover:bg-slate-50 transition">
                    Cancelar
                </a>
                <button type="submit" class="bg-teal-500 hover:bg-teal-600 text-white px-6 py-3 rounded-xl text-sm font-semibold transition shadow-sm shadow-teal-100">
                    Atualizar Dados
                </button>
            </div>

        </form>
    </div>
</div>
@endsection
