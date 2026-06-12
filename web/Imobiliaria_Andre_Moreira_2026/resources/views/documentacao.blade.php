@extends('layouts.app')

@section('content')
<div class="space-y-8 max-w-5xl mx-auto">

    <div class="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm flex flex-col md:flex-row md:items-center md:justify-between gap-4">
        <div>
            <h1 class="text-2xl font-black text-slate-900 tracking-tight">
                Documentação do Sistema
            </h1>
            <p class="text-slate-500 text-sm mt-0.5">
                Guia de utilização, regras de negócio e funcionalidades do Imobi<span class="text-teal-500 font-semibold">Laravel</span>.
            </p>
        </div>

        <div class="text-xs font-semibold text-teal-600 bg-teal-50/50 px-3 py-2 rounded-xl border border-teal-100/50 self-start md:self-auto">
            Versão da Plataforma:
            <span class="font-mono font-bold">v1.0.0</span>
        </div>
    </div>

    <div class="bg-white rounded-3xl border border-slate-100 p-8 md:p-10 shadow-sm space-y-10">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">1</span>
                Introdução à Plataforma
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                O ImobiLaravel foi desenvolvido para centralizar e simplificar a operação diária de agências imobiliárias. O sistema permite gerir apartamentos, clientes e contratos de venda de forma organizada e segura.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-4">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">2</span>
                Módulo de Apartamentos
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Cada apartamento registado possui uma referência única, tipologia, preço de venda e estado atual.
            </p>

            <div class="bg-slate-50 rounded-xl p-4 border border-slate-100">
                <span class="block text-xs font-bold text-slate-700 uppercase tracking-wide mb-3">
                    Estados Disponíveis
                </span>

                <ul class="text-sm text-slate-600 space-y-2 list-disc pl-5">
                    <li>
                        <strong class="text-emerald-600">Disponível:</strong>
                        imóvel disponível para venda.
                    </li>
                    <li>
                        <strong class="text-slate-600">Vendido:</strong>
                        imóvel associado a uma venda concluída.
                    </li>
                </ul>
            </div>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">3</span>
                Gestão de Clientes
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                A plataforma permite armazenar informações essenciais dos clientes, incluindo nome, email, telefone e NIF.
            </p>

            <p class="text-sm text-slate-600 leading-relaxed">
                Clientes associados a vendas registadas não podem ser eliminados, garantindo a integridade histórica da informação.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-4">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">4</span>
                Contratos de Venda
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Para registar uma venda é necessário selecionar um apartamento disponível e um cliente válido.
            </p>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">

                <div class="bg-slate-50 rounded-xl border border-slate-100 p-4">
                    <h3 class="font-semibold text-slate-800 mb-2">
                        Atualização Automática
                    </h3>

                    <p class="text-sm text-slate-600">
                        O apartamento passa automaticamente para o estado "Vendido" após a conclusão da venda.
                    </p>
                </div>

                <div class="bg-slate-50 rounded-xl border border-slate-100 p-4">
                    <h3 class="font-semibold text-slate-800 mb-2">
                        Volume de Negócios
                    </h3>

                    <p class="text-sm text-slate-600">
                        O valor da venda é automaticamente contabilizado nas métricas da Dashboard.
                    </p>
                </div>

            </div>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">5</span>
                Níveis de Acesso
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                O sistema disponibiliza diferentes permissões de acordo com o perfil do utilizador.
            </p>

            <div class="bg-teal-50 border border-teal-100 rounded-xl p-4">
                <ul class="space-y-3 text-sm text-slate-700">

                    <li class="flex items-start gap-2">
                        <span class="text-teal-600 font-bold">✓</span>
                        <span>
                            <strong>Visitantes:</strong>
                            podem consultar a página principal e visualizar imóveis disponíveis.
                        </span>
                    </li>

                    <li class="flex items-start gap-2">
                        <span class="text-teal-600 font-bold">✓</span>
                        <span>
                            <strong>Utilizadores Autenticados:</strong>
                            têm acesso à gestão de apartamentos, clientes e vendas.
                        </span>
                    </li>

                </ul>
            </div>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">6</span>
                Suporte Técnico
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Para esclarecimento de dúvidas ou reporte de problemas técnicos, contacte a equipa de suporte.
            </p>

            <div class="bg-teal-50 border border-teal-100 rounded-xl p-4">
                <p class="text-sm font-semibold text-teal-700">
                    suporte@imobilaravel.pt
                </p>
            </div>
        </section>

    </div>

</div>
@endsection
