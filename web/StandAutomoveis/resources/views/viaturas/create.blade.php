@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Registar Nova Viatura</h1>
        <p class="text-sm text-neutral-500 mt-1">Introduza as especificações técnicas e administrativas da viatura para inclusão no stock ativo.</p>
    </div>
    <a href="{{ route('viaturas.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Cancelar e Voltar
    </a>
</div>

<div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">

    <div class="bg-neutral-900 px-6 py-4 border-b border-neutral-800 flex items-center justify-between">
        <div class="flex items-center gap-2">
            <span class="text-xs text-neutral-400 font-mono font-bold">FICHA DE ENTRADA EM STOCK</span>
        </div>
        <span class="bg-neutral-800 text-neutral-400 px-2.5 py-0.5 rounded font-mono text-[10px] font-bold border border-neutral-700 tracking-wider">
            NOVO REGISTO
        </span>
    </div>

    <form action="{{ route('viaturas.store') }}" method="POST" enctype="multipart/form-data" class="p-6 space-y-6">
        @csrf

        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">

            <div>
                <label for="marca" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Marca</label>
                <input type="text" name="marca" id="marca" value="{{ old('marca') }}" required placeholder="Ex: Audi"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="modelo" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Modelo</label>
                <input type="text" name="modelo" id="modelo" value="{{ old('modelo') }}" required placeholder="Ex: A4 Avant"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="matricula" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Matrícula</label>
                <input type="text" name="matricula" id="matricula" value="{{ old('matricula') }}" required placeholder="AA-00-00"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm font-mono tracking-wide text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150 uppercase">
            </div>

            <div>
                <label for="ano" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Ano de Fabrico</label>
                <input type="number" name="ano" id="ano" value="{{ old('ano') }}" required min="1900" max="{{ date('Y')+1 }}" placeholder="Ex: 2022"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="quilometros" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Quilometragem (Km)</label>
                <input type="number" name="quilometros" id="quilometros" value="{{ old('quilometros') }}" required min="0" placeholder="0"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="preco" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Preço Base de Venda (€)</label>
                <input type="number" name="preco" id="preco" step="0.01" value="{{ old('preco') }}" required min="0" placeholder="0.00"
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="estado" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Estado Inicial</label>
                <select name="estado" id="estado"
                        class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-sm text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                    <option value="disponível" {{ old('estado') == 'disponível' ? 'selected' : '' }}>Disponível para Venda</option>
                    <option value="vendido" {{ old('estado') == 'vendido' ? 'selected' : '' }}>Vendido</option>
                </select>
            </div>

            <div class="md:col-span-2">
                <label for="foto" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Fotografia da Viatura</label>
                <input type="file" name="foto" id="foto" accept="image/*"
                       class="w-full text-sm text-neutral-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border-0 file:text-xs file:font-bold file:uppercase file:tracking-wider file:bg-neutral-100 file:text-neutral-700 hover:file:bg-orange-50 hover:file:text-orange-700 file:transition-colors file:duration-150 cursor-pointer">
            </div>
        </div>

        <div class="flex items-center justify-end space-x-3 pt-5 border-t border-neutral-100 bg-neutral-50/40 -mx-6 -mb-6 p-6">

            <a href="{{ route('viaturas.index') }}"
               class="inline-flex items-center px-4 py-2.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-lg font-bold uppercase text-xs tracking-wider transition-colors duration-150">
                Cancelar
            </a>

            <button type="submit"
                    class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
                <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-colors duration-150" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7H5a2 2 0 00-2 2v9a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2h-3m-1 4l-3 3m0 0l-3-3m3 3V4" />
                </svg>
                Gravar Viatura
            </button>

        </div>
    </form>
</div>
@endsection
