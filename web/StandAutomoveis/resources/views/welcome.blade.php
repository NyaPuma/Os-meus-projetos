@extends('layouts.app')

@section('title', 'Stand de Automóveis - Painel')

@section('content')
    <header class="bg-white border-b border-neutral-200 py-6">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex flex-col sm:flex-row justify-between items-start sm:items-center gap-2">
            <div>
                <h2 class="font-black text-2xl text-neutral-900 tracking-tight leading-tight">
                    {{ __('Painel de Controlo') }}
                </h2>
                <p class="text-xs text-neutral-500 mt-0.5">Visão geral do inventário, faturação e atividade do stand.</p>
            </div>
            <span class="inline-flex items-center gap-1.5 px-3 py-1 rounded-full text-xs font-medium bg-emerald-50 text-emerald-700 border border-emerald-200/60">
                <span class="w-2 h-2 rounded-full bg-emerald-500 animate-pulse"></span>
                Stand Ativo
            </span>
        </div>
    </header>

    <main class="py-12">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 space-y-8">

            <div class="bg-white p-6 rounded-xl border border-neutral-200 shadow-sm flex items-center justify-between">
                <div>
                    <p class="text-xs font-bold uppercase text-neutral-400 tracking-wider">Faturação Total</p>
                    <h3 class="text-2xl font-black text-neutral-900 mt-2 font-mono">
                        {{ number_format($faturacaoTotal ?? 0, 2, ',', '.') }} €
                    </h3>
                </div>
                <div class="p-3 bg-orange-50 text-orange-600 rounded-lg border border-orange-100">
                    <svg class="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                    </svg>
                </div>
            </div>

            <div class="grid grid-cols-1 sm:grid-cols-3 gap-6">
                <div class="bg-white p-6 rounded-xl border border-neutral-200 shadow-sm flex items-center justify-between">
                    <div>
                        <p class="text-xs font-bold uppercase text-neutral-400 tracking-wider">Stock Disponível</p>
                        <h3 class="text-2xl font-black text-neutral-900 mt-2">
                            {{ $stockDisponivel ?? 0 }} <span class="text-xs font-normal text-neutral-400">unidades</span>
                        </h3>
                    </div>
                    <div class="p-3 bg-blue-50 text-blue-600 rounded-lg border border-blue-100">
                        <svg class="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M9 17a2 2 0 11-4 0 2 2 0 014 0zM19 17a2 2 0 11-4 0 2 2 0 014 0z" />
                            <path stroke-linecap="round" stroke-linejoin="round" d="M13 16V6a1 1 0 00-1-1H4a1 1 0 00-1 1v10a1 1 0 001 1h1m8-1a1 1 0 01-1 1H9m4-1V8a1 1 0 011-1h2.586a1 1 0 01.707.293l3.414 3.414a1 1 0 01.293.707V16a1 1 0 01-1 1h-1m-6-1a1 1 0 001 1h1M5 17a2 2 0 104 0m-4 0a2 2 0 114 0m6 0a2 2 0 104 0m-4 0a2 2 0 114 0" />
                        </svg>
                    </div>
                </div>

                <div class="bg-white p-6 rounded-xl border border-neutral-200 shadow-sm flex items-center justify-between">
                    <div>
                        <p class="text-xs font-bold uppercase text-neutral-400 tracking-wider">Viaturas Vendidas</p>
                        <h3 class="text-2xl font-black text-neutral-900 mt-2">
                            {{ $totalVendidos ?? 0 }} <span class="text-xs font-normal text-neutral-400">contratos</span>
                        </h3>
                    </div>
                    <div class="p-3 bg-emerald-50 text-emerald-600 rounded-lg border border-emerald-100">
                        <svg class="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                        </svg>
                    </div>
                </div>

                <div class="bg-white p-6 rounded-xl border border-neutral-200 shadow-sm flex items-center justify-between">
                    <div>
                        <p class="text-xs font-bold uppercase text-neutral-400 tracking-wider">Clientes Registados</p>
                        <h3 class="text-2xl font-black text-neutral-900 mt-2">
                            {{ $totalClientes ?? 0 }}
                        </h3>
                    </div>
                    <div class="p-3 bg-purple-50 text-purple-600 rounded-lg border border-purple-100">
                        <svg class="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z" />
                        </svg>
                    </div>
                </div>
            </div>

            <div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
                <div class="lg:col-span-2 space-y-4">
                    <div class="flex justify-between items-center">
                        <h3 class="text-xs font-black uppercase text-neutral-400 tracking-wider">Últimas Transações Efetuadas</h3>
                        <a href="{{ route('vendas.index') }}" class="text-xs font-bold text-orange-600 hover:text-orange-700 transition-colors">Ver Histórico Completo &rarr;</a>
                    </div>

                    <div class="bg-white rounded-xl border border-neutral-200 shadow-sm overflow-hidden">
                        <div class="overflow-x-auto">
                            <table class="min-w-full divide-y divide-neutral-200 text-left">
                                <thead class="bg-neutral-900 text-neutral-300 text-xs font-bold uppercase tracking-wider">
                                    <tr>
                                        <th scope="col" class="px-6 py-4">Contrato</th>
                                        <th scope="col" class="px-6 py-4">Cliente</th>
                                        <th scope="col" class="px-6 py-4">Viatura</th>
                                        <th scope="col" class="px-6 py-4 text-right">Valor</th>
                                    </tr>
                                </thead>
                                <tbody class="bg-white divide-y divide-neutral-200 text-sm text-neutral-700">
                                    @forelse($ultimasVendas ?? [] as $venda)
                                        <tr class="hover:bg-neutral-50/50 transition-colors duration-150">
                                            <td class="px-6 py-4 whitespace-nowrap font-bold font-mono text-neutral-900">
                                                #{{ sprintf('%04d', $venda->id) }}
                                            </td>
                                            <td class="px-6 py-4 whitespace-nowrap font-medium text-neutral-900">
                                                {{ $venda->cliente->nome }}
                                            </td>
                                            <td class="px-6 py-4 whitespace-nowrap">
                                                <span class="font-bold text-neutral-800">{{ $venda->viatura->marca }}</span>
                                                <span class="text-neutral-500">{{ $venda->viatura->modelo }}</span>
                                            </td>
                                            <td class="px-6 py-4 whitespace-nowrap text-right font-black text-neutral-900 font-mono">
                                                {{ number_format($venda->valor_venda, 2, ',', '.') }} €
                                            </td>
                                        </tr>
                                    @empty
                                        <tr>
                                            <td colspan="4" class="px-6 py-10 text-center text-xs text-neutral-400 uppercase tracking-wider">
                                                Nenhuma venda registada até ao momento.
                                            </td>
                                        </tr>
                                    @endempty
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="space-y-4">
                    <h3 class="text-xs font-black uppercase text-neutral-400 tracking-wider">Operações Rápidas</h3>
                    <div class="bg-white p-6 rounded-xl border border-neutral-200 shadow-sm space-y-3">
                        <p class="text-xs text-neutral-400 pb-2 border-b border-neutral-100">Atalhos para gestão diária:</p>

                        <a href="{{ route('vendas.create') }}" class="flex items-center justify-between p-3 rounded-lg border border-neutral-200 hover:border-orange-500 hover:bg-orange-50/30 text-neutral-700 hover:text-neutral-900 transition-all duration-150 group">
                            <div class="flex items-center gap-3">
                                <span class="p-2 rounded-md bg-orange-50 text-orange-600 group-hover:bg-orange-100">
                                    <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M12 4v16m8-8H4" />
                                    </svg>
                                </span>
                                <span class="text-xs font-bold uppercase tracking-wider">Registar Venda</span>
                            </div>
                            <span class="text-neutral-400 group-hover:translate-x-1 transition-transform">&rarr;</span>
                        </a>

                        <a href="{{ route('viaturas.create') }}" class="flex items-center justify-between p-3 rounded-lg border border-neutral-200 hover:border-blue-500 hover:bg-blue-50/30 text-neutral-700 hover:text-neutral-900 transition-all duration-150 group">
                            <div class="flex items-center gap-3">
                                <span class="p-2 rounded-md bg-blue-50 text-blue-600 group-hover:bg-blue-100">
                                    <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M12 4v16m8-8H4" />
                                    </svg>
                                </span>
                                <span class="text-xs font-bold uppercase tracking-wider">Nova Viatura</span>
                            </div>
                            <span class="text-neutral-400 group-hover:translate-x-1 transition-transform">&rarr;</span>
                        </a>

                        <a href="{{ route('clientes.create') }}" class="flex items-center justify-between p-3 rounded-lg border border-neutral-200 hover:border-purple-500 hover:bg-purple-50/30 text-neutral-700 hover:text-neutral-900 transition-all duration-150 group">
                            <div class="flex items-center gap-3">
                                <span class="p-2 rounded-md bg-purple-50 text-purple-600 group-hover:bg-purple-100">
                                    <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2.5">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M18 9v3m0 0v3m0-3h3m-3 0h-3m-2-5a4 4 0 11-8 0 4 4 0 018 0zM3 20a6 6 0 0112 0v1H3v-1z" />
                                    </svg>
                                </span>
                                <span class="text-xs font-bold uppercase tracking-wider">Criar Cliente</span>
                            </div>
                            <span class="text-neutral-400 group-hover:translate-x-1 transition-transform">&rarr;</span>
                        </a>
                    </div>
                </div>
            </div>

        </div>
    </main>
@endsection
