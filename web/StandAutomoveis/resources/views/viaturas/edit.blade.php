@extends('layouts.app')

@section('content')
<div class="flex flex-col sm:flex-row justify-between items-start sm:items-center pb-5 mb-6 border-b border-neutral-200 gap-4">
    <div>
        <h1 class="text-2xl font-black text-neutral-900 tracking-tight">Editar Registo de Viatura</h1>
        <p class="text-sm text-neutral-500 mt-1">Altere os dados técnicos, ajuste valores comerciais ou atualize a fotografia de cobertura do veículo.</p>
    </div>
    <a href="{{ route('viaturas.index') }}"
       class="inline-flex items-center gap-2 text-xs font-bold text-neutral-600 hover:text-orange-600 transition-colors duration-150 uppercase tracking-wider">
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Descartar e Voltar
    </a>
</div>

<div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">

    <div class="bg-neutral-900 px-6 py-4 border-b border-neutral-800 flex items-center justify-between">
        <div class="flex items-center gap-2">
            <span class="text-xs text-neutral-400 font-mono font-bold">MODIFICAÇÃO DE REGISTO</span>
        </div>
        <span class="bg-neutral-800 text-neutral-300 px-2.5 py-0.5 rounded font-mono text-xs font-bold border border-neutral-700 tracking-wider">
            ID Interno: #{{ sprintf('%03d', $viatura->id) }}
        </span>
    </div>

    <form action="{{ route('viaturas.update', $viatura->id) }}" method="POST" enctype="multipart/form-data" class="p-6 space-y-6">
        @csrf
        @method('PUT')

        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">

            <div>
                <label for="marca" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Marca</label>
                <input type="text" name="marca" id="marca" value="{{ old('marca', $viatura->marca) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="modelo" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Modelo</label>
                <input type="text" name="modelo" id="modelo" value="{{ old('modelo', $viatura->modelo) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="matricula" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Matrícula</label>
                <input type="text" name="matricula" id="matricula" value="{{ old('matricula', $viatura->matricula) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm font-mono tracking-wide text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150 uppercase">
            </div>

            <div>
                <label for="ano" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Ano de Registo</label>
                <input type="number" name="ano" id="ano" value="{{ old('ano', $viatura->ano) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="quilometros" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Quilometragem (Km)</label>
                <input type="number" name="quilometros" id="quilometros" value="{{ old('quilometros', $viatura->quilometros) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="preco" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Preço de Venda (€)</label>
                <input type="number" name="preco" id="preco" step="0.01" value="{{ old('preco', $viatura->preco) }}" required
                       class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-4 py-2.5 text-sm text-neutral-900 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
            </div>

            <div>
                <label for="estado" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Estado Comercial</label>
                <select name="estado" id="estado"
                        class="w-full rounded-lg border-neutral-300 bg-neutral-50/50 px-3 py-2.5 text-sm text-neutral-800 shadow-sm focus:border-orange-500 focus:ring-orange-500 focus:bg-white transition-all duration-150">
                    <option value="disponível" {{ old('estado', $viatura->estado) == 'disponível' ? 'selected' : '' }}>Disponível para Venda</option>
                    <option value="vendido" {{ old('estado', $viatura->estado) == 'vendido' ? 'selected' : '' }}>Vendido / Faturado</option>
                </select>
            </div>

            <div class="md:col-span-2">
                <label for="foto" class="block text-xs uppercase tracking-wider text-neutral-400 font-bold mb-2">Substituir Fotografia (Opcional)</label>
                <input type="file" name="foto" id="foto" accept="image/*"
                       class="w-full text-sm text-neutral-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border-0 file:text-xs file:font-bold file:uppercase file:tracking-wider file:bg-neutral-100 file:text-neutral-700 hover:file:bg-orange-50 hover:file:text-orange-700 file:transition-colors file:duration-150 cursor-pointer">
            </div>
        </div>

        @if($viatura->foto)
            <div class="mt-2 p-4 bg-neutral-50 rounded-xl border border-neutral-200 inline-flex flex-col gap-2 shadow-sm">
                <span class="block text-[10px] text-neutral-400 font-bold uppercase tracking-wider">Imagem Atualmente em Stock</span>
                <div class="relative w-40 h-24 rounded-lg overflow-hidden border border-neutral-200 bg-white">
                    <img src="{{ asset('storage/' . $viatura->foto) }}" alt="Preview" class="w-full h-full object-cover">
                </div>
            </div>
        @endif

        <div class="flex items-center justify-end space-x-3 pt-5 border-t border-neutral-100 bg-neutral-50/40 -mx-6 -mb-6 p-6">

            <a href="{{ route('viaturas.index') }}"
               class="inline-flex items-center px-4 py-2.5 text-neutral-700 bg-neutral-100 hover:bg-neutral-200 rounded-lg font-bold uppercase text-xs tracking-wider transition-colors duration-150">
                Descartar
            </a>

            <button type="submit"
                    class="inline-flex items-center gap-2 bg-orange-600 hover:bg-orange-700 text-white font-bold py-2.5 px-5 rounded-lg shadow-sm transition-all duration-150 uppercase text-xs tracking-wider group">
                <svg class="w-4 h-4 text-orange-200 group-hover:text-white transition-colors duration-150" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
                </svg>
                Guardar Alterações
            </button>

        </div>
    </form>
</div>
@endsection
