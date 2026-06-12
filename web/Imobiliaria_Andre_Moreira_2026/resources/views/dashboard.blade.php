@extends('layouts.app')

@section('content')
    <div class="space-y-8">

        <div
            class="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm flex flex-col md:flex-row md:items-center md:justify-between gap-4">
            <div>
                <h1 class="text-2xl font-black text-slate-900 tracking-tight">Bem-vindo ao Imobi<span
                        class="text-teal-500">Laravel</span></h1>
                <p class="text-slate-500 text-sm mt-0.5">Aqui está o ponto de situação atualizado do portefólio imobiliário e
                    performance de vendas.</p>
            </div>
            <div
                class="text-xs font-semibold text-slate-400 bg-slate-50 px-3 py-2 rounded-xl border border-slate-100 self-start md:self-auto">
                Última sincronização: <span class="text-slate-700 font-mono">{{ date('d/m/Y H:i') }}</span>
            </div>
        </div>

        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-5">

            <div class="bg-white p-5 rounded-2xl border border-slate-100 shadow-sm flex items-center space-x-4">
                <div class="w-12 h-12 rounded-xl bg-slate-100 text-slate-700 flex items-center justify-center flex-shrink-0">
                    <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4">
                        </path>
                    </svg>
                </div>
                <div>
                    <span class="block text-xs font-bold text-slate-400 uppercase tracking-wider">Imóveis Catalogados</span>
                    <span class="text-2xl font-black text-slate-900 leading-tight">{{ $totalApartamentos ?? 0 }}</span>
                </div>
            </div>

            <div class="bg-white p-5 rounded-2xl border border-slate-100 shadow-sm flex items-center space-x-4">
                <div
                    class="w-12 h-12 rounded-xl bg-emerald-50 text-emerald-600 flex items-center justify-center flex-shrink-0">
                    <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                    </svg>
                </div>
                <div>
                    <span class="block text-xs font-bold text-slate-400 uppercase tracking-wider">Disponíveis para
                        Venda</span>
                    <span
                        class="text-2xl font-black text-emerald-600 leading-tight">{{ $apartamentosDisponiveis ?? 0 }}</span>
                </div>
            </div>

            <div class="bg-white p-5 rounded-2xl border border-slate-100 shadow-sm flex items-center space-x-4">
                <div class="w-12 h-12 rounded-xl bg-teal-50 text-teal-600 flex items-center justify-center flex-shrink-0">
                    <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z">
                        </path>
                    </svg>
                </div>
                <div>
                    <span class="block text-xs font-bold text-slate-400 uppercase tracking-wider">Clientes Registados</span>
                    <span class="text-2xl font-black text-teal-600 leading-tight">{{ $totalClientes ?? 0 }}</span>
                </div>
            </div>

            <div class="bg-white p-5 rounded-2xl border border-slate-100 shadow-sm flex items-center space-x-4">
                <div class="w-12 h-12 rounded-xl bg-slate-900 text-teal-400 flex items-center justify-center flex-shrink-0">
                    <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z">
                        </path>
                    </svg>
                </div>
                <div>
                    <span class="block text-xs font-bold text-slate-400 uppercase tracking-wider">Volume de Negócios</span>
                    <span
                        class="text-xl font-black text-slate-900 leading-tight">{{ number_format($faturacaoTotal ?? 0, 2, ',', ' ') }}
                        €</span>
                </div>
            </div>

        </div>

        <div class="grid grid-cols-1 lg:grid-cols-12 gap-6 items-start">

            <div class="lg:col-span-4 space-y-4">
                <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6">
                    <h3 class="font-bold text-base text-slate-900 tracking-tight mb-4">Ações Operacionais</h3>

                    <div class="space-y-2">
                        @auth
                            <a href="{{ route('apartamentos.create') }}"
                                class="w-full text-left px-4 py-3 bg-slate-50 border border-slate-100 rounded-xl text-xs font-semibold text-slate-700 hover:bg-slate-900 hover:text-white transition flex items-center justify-between group">
                                <span>+ Catalogar Novo Apartamento</span>
                                <svg class="w-4 h-4 text-slate-400 group-hover:text-teal-400 transition" fill="none"
                                    stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7">
                                    </path>
                                </svg>
                            </a>

                            <a href="{{ route('clientes.create') }}"
                                class="w-full text-left px-4 py-3 bg-slate-50 border border-slate-100 rounded-xl text-xs font-semibold text-slate-700 hover:bg-slate-900 hover:text-white transition flex items-center justify-between group">
                                <span>+ Registar Novo Cliente</span>
                                <svg class="w-4 h-4 text-slate-400 group-hover:text-teal-400 transition" fill="none"
                                    stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7">
                                    </path>
                                </svg>
                            </a>

                            <a href="{{ route('vendas.create') }}"
                                class="w-full text-left px-4 py-3 bg-teal-500 rounded-xl text-xs font-semibold text-white hover:bg-teal-600 transition flex items-center justify-between shadow-sm shadow-teal-100">
                                <span>$ Celebrar Contrato de Venda</span>
                                <svg class="w-4 h-4 text-teal-200" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M14 5l7 7-7 7">
                                    </path>
                                </svg>
                            </a>
                        @endauth

                        @guest
                            <div class="text-center py-4 bg-slate-50/50 rounded-xl border border-dashed border-slate-200 p-4">
                                <p class="text-xs text-slate-500 mb-3 leading-relaxed">Autentique-se na plataforma comercial
                                    para realizar novas operações no sistema.</p>
                                <a href="{{ route('login') }}"
                                    class="inline-flex w-full justify-center items-center bg-[#1a2432] text-white px-4 py-2.5 rounded-xl text-xs font-bold hover:bg-[#253346] transition shadow-sm">
                                    Entrar na Área Pessoal
                                </a>
                            </div>
                        @endguest
                    </div>
                </div>
            </div>

            @auth
                <div class="lg:col-span-8 bg-white rounded-2xl border border-slate-100 shadow-sm p-6">
                    <div class="flex items-center justify-between border-b border-slate-50 pb-4 mb-4">
                        <div>
                            <h3 class="font-bold text-base text-slate-900 tracking-tight">
                                Últimas Vendas Celebradas
                            </h3>
                            <p class="text-slate-400 text-xs">
                                Histórico recente de escrituras na agência.
                            </p>
                        </div>

                        <a href="{{ route('vendas.index') }}"
                            class="text-xs font-bold text-teal-600 hover:text-teal-700 hover:underline transition">
                            Ver todas &rarr;
                        </a>
                    </div>

                    @if (empty($ultimasVendas) || $ultimasVendas->isEmpty())
                        <div
                            class="text-center py-8 text-slate-400 text-xs font-medium border border-dashed border-slate-100 rounded-xl">
                            Nenhuma transação financeira foi efetuada recentemente.
                        </div>
                    @else
                        <div class="space-y-3">
                            @foreach ($ultimasVendas as $venda)
                                <div
                                    class="flex flex-col sm:flex-row sm:items-center justify-between p-3 border border-slate-50 rounded-xl hover:bg-slate-50/50 transition gap-2">
                                    <div class="flex items-center space-x-3">
                                        <div class="p-2 bg-slate-900 text-white rounded-lg flex-shrink-0 text-xs font-bold">
                                            {{ $venda->apartamento->tipologia ?? 'N/A' }}
                                        </div>

                                        <div>
                                            <span class="font-bold text-slate-900 text-sm block">
                                                Apartamento {{ $venda->apartamento->referencia ?? '#' }}
                                            </span>

                                            <span class="text-slate-400 text-xs block">
                                                Comprador: {{ $venda->cliente->nome ?? 'Desconhecido' }}
                                            </span>
                                        </div>
                                    </div>

                                    <div
                                        class="text-left sm:text-right flex sm:flex-col justify-between sm:justify-center items-center sm:items-end border-t sm:border-t-0 border-slate-50 pt-2 sm:pt-0">
                                        <span class="text-sm font-black text-slate-900">
                                            {{ number_format($venda->valor_venda, 2, ',', ' ') }} €
                                        </span>

                                        <span class="text-[10px] text-slate-400 font-mono sm:mt-0.5">
                                            {{ date('d/m/Y', strtotime($venda->data_venda)) }}
                                        </span>
                                    </div>
                                </div>
                            @endforeach
                        </div>
                    @endif
                </div>
            @endauth

        </div>
    </div>
@endsection
