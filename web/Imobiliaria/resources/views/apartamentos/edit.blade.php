@extends('layouts.app')

@section('content')
<div class="max-w-3xl mx-auto space-y-6">

    <div>
        <a href="{{ route('apartamentos.index') }}" class="text-sm font-medium text-teal-600 hover:text-teal-700 flex items-center space-x-1 transition">
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
            <span>Voltar à listagem</span>
        </a>
    </div>

    <div>
        <h1 class="text-3xl font-bold tracking-tight text-slate-900">Editar Apartamento</h1>
        <p class="text-slate-500 text-sm mt-1">Atualize as especificações, preço ou fotografia da referência <span class="font-semibold text-slate-800">{{ $apartamento->referencia }}</span>.</p>
    </div>

    <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 md:p-8">

        <form action="{{ route('apartamentos.update', $apartamento) }}" method="POST" enctype="multipart/form-data" class="space-y-6">
            @csrf
            @method('PUT') <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                <div class="space-y-1.5">
                    <label for="referencia" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Referência Interna</label>
                    <input type="text" name="referencia" id="referencia" value="{{ old('referencia', $apartamento->referencia) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="tipologia" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Tipologia</label>
                    <select name="tipologia" id="tipologia" required
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        @foreach(['T0', 'T1', 'T2', 'T3', 'T4', 'Outro'] as $tipo)
                            <option value="{{ $tipo }}" {{ old('tipologia', $apartamento->tipologia) == $tipo ? 'selected' : '' }}>{{ $tipo }}</option>
                        @endforeach
                    </select>
                </div>

                <div class="md:col-span-2 space-y-1.5">
                    <label for="morada" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Morada do Imóvel</label>
                    <input type="text" name="morada" id="morada" value="{{ old('morada', $apartamento->morada) }}" required
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="area" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Área Útil (m²)</label>
                    <input type="number" name="area" id="area" value="{{ old('area', $apartamento->area) }}" required min="1"
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="preco" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Preço Pedido (€)</label>
                    <input type="number" name="preco" id="preco" value="{{ old('preco', $apartamento->preco) }}" required min="0" step="0.01"
                           class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                </div>

                <div class="space-y-1.5">
                    <label for="estado" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Estado do Imóvel</label>
                    <select name="estado" id="estado" required
                            class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-3 text-sm focus:outline-none focus:border-teal-500 focus:bg-white transition">
                        <option value="Disponível" {{ old('estado', $apartamento->estado) == 'Disponível' ? 'selected' : '' }}>Disponível</option>
                        <option value="Vendido" {{ old('estado', $apartamento->estado) == 'Vendido' ? 'selected' : '' }}>Vendido</option>
                    </select>
                </div>

                <div class="space-y-1.5">
                    <label for="fotografia" class="text-xs font-semibold text-slate-700 uppercase tracking-wider">Substituir Fotografia</label>
                    <div class="w-full bg-slate-50 border border-slate-200 rounded-xl px-4 py-2.5 text-sm flex items-center justify-between">
                        <input type="file" name="fotografia" id="fotografia" accept="image/*"
                               class="block w-full text-xs text-slate-500 file:mr-4 file:py-2 file:px-4 file:rounded-xl file:border-0 file:text-xs file:font-semibold file:bg-teal-50 file:text-teal-700 hover:file:bg-teal-100 cursor-pointer">
                    </div>
                </div>

                <div class="md:col-span-2 bg-slate-50 p-4 rounded-xl border border-slate-200 flex items-center space-x-4">
                    <div class="w-24 h-16 rounded-lg bg-slate-200 overflow-hidden flex-shrink-0 shadow-inner">
                        @if($apartamento->fotografia)
                            <img src="{{ asset('storage/' . $apartamento->fotografia) }}" alt="Foto Atual" class="w-full h-full object-cover">
                        @else
                            <div class="w-full h-full flex items-center justify-center text-slate-400 text-[10px] font-medium uppercase">Sem Foto</div>
                        @endif
                    </div>
                    <div>
                        <h4 class="text-xs font-bold text-slate-700 uppercase tracking-wide">Fotografia Atual em Servidor</h4>
                        <p class="text-xs text-slate-500 mt-0.5">Se não escolher nenhum ficheiro acima, a imagem atual será mantida intacta.</p>
                    </div>
                </div>

            </div>

            <div class="pt-6 border-t border-slate-100 flex items-center justify-end space-x-3">
                <a href="{{ route('apartamentos.index') }}" class="px-5 py-3 rounded-xl text-sm font-semibold text-slate-600 hover:bg-slate-50 transition">
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
