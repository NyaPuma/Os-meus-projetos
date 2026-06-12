@extends('layouts.app')

@section('content')
    <div class="max-w-3xl mx-auto space-y-6">

        <div>
            <a href="{{ route('apartamentos.index') }}"
                class="text-sm font-medium text-teal-600 hover:text-teal-700 flex items-center space-x-1 transition">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18">
                    </path>
                </svg>
                <span>Voltar à listagem</span>
            </a>
        </div>

        <div>
            <h1 class="text-3xl font-bold tracking-tight text-slate-900">Adicionar Novo Imóvel</h1>
            <p class="text-slate-500 text-sm mt-1">Insira os dados técnicos e a fotografia do apartamento para
                disponibilizá-lo no catálogo.</p>
        </div>

        <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8">

            <form action="{{ route('apartamentos.store') }}" method="POST" enctype="multipart/form-data" class="space-y-6">
                @csrf

                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                    <div class="space-y-1.5">
                        <label class="text-xs font-semibold text-slate-700 uppercase tracking-wider">
                            Referência Interna
                        </label>

                        <div
                            class="w-full bg-slate-100 border border-slate-200 rounded-xl px-4 py-3 text-sm text-slate-600 font-semibold">
                            Será gerada automaticamente
                        </div>
                    </div>

                    <div class="space-y-1.5">
                        <label for="tipologia"
                            class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Tipologia</label>
                        <select name="tipologia" id="tipologia" required
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                            <option value="" disabled selected>Selecione uma opção...</option>
                            <option value="T0" {{ old('tipologia') == 'T0' ? 'selected' : '' }}>T0</option>
                            <option value="T1" {{ old('tipologia') == 'T1' ? 'selected' : '' }}>T1</option>
                            <option value="T2" {{ old('tipologia') == 'T2' ? 'selected' : '' }}>T2</option>
                            <option value="T3" {{ old('tipologia') == 'T3' ? 'selected' : '' }}>T3</option>
                            <option value="T4" {{ old('tipologia') == 'T4' ? 'selected' : '' }}>T4</option>
                            <option value="Outro" {{ old('tipologia') == 'Outro' ? 'selected' : '' }}>Outro</option>
                        </select>
                    </div>

                    <div class="md:col-span-2 space-y-1.5">
                        <label for="morada" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Morada
                            do Imóvel</label>
                        <input type="text" name="morada" id="morada" value="{{ old('morada') }}" required
                            placeholder="Rua, Número de Porta, Cidade"
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                    </div>

                    <div class="space-y-1.5">
                        <label for="area" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Área
                            Útil (m²)</label>
                        <input type="number" name="area" id="area" value="{{ old('area') }}" required
                            min="1" placeholder="Ex: 95"
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                    </div>

                    <div class="space-y-1.5">
                        <label for="preco" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Preço
                            Pedido (€)</label>
                        <input type="number" name="preco" id="preco" value="{{ old('preco') }}" required
                            min="0" step="0.01" placeholder="Ex: 245000"
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                    </div>

                    <div class="space-y-1.5">
                        <label for="estado" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Estado
                            do Imóvel</label>
                        <select name="estado" id="estado" required
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                            <option value="Disponível" {{ old('estado') == 'Disponível' ? 'selected' : '' }}>Disponível
                            </option>
                            <option value="Vendido" {{ old('estado') == 'Vendido' ? 'selected' : '' }}>Vendido</option>
                        </select>
                    </div>

                    <div class="space-y-1.5">
                        <label for="fotografia"
                            class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Fotografia
                            Principal</label>
                        <div
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-2.5 text-sm flex items-center justify-between">
                            <input type="file" name="fotografia" id="fotografia" accept="image/*"
                                class="block w-full text-xs text-slate-500 file:mr-4 file:py-2 file:px-4 file:rounded-xl file:border-0 file:text-xs file:font-semibold file:bg-teal-50 file:text-teal-700 hover:file:bg-teal-100 cursor-pointer">
                        </div>
                    </div>

                </div>

                <div class="pt-6 border-t border-slate-100 flex items-center justify-end space-x-3">
                    <a href="{{ route('apartamentos.index') }}"
                        class="px-5 py-3 rounded-xl text-sm font-semibold text-slate-600 hover:bg-slate-50 transition">
                        Cancelar
                    </a>
                    <button type="submit"
                        class="bg-teal-500 hover:bg-teal-600 text-white px-6 py-3 rounded-xl text-sm font-semibold transition shadow-sm shadow-teal-100">
                        Gravar Apartamento
                    </button>
                </div>

            </form>
        </div>
    </div>
@endsection
