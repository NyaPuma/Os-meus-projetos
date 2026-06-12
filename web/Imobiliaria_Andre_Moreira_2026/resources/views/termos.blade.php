@extends('layouts.app')

@section('content')
<div class="space-y-8 max-w-5xl mx-auto">

    <div class="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm flex flex-col md:flex-row md:items-center md:justify-between gap-4">
        <div>
            <h1 class="text-2xl font-black text-slate-900 tracking-tight">
                Termos de Serviço
            </h1>
            <p class="text-slate-500 text-sm mt-0.5">
                Condições de utilização da plataforma Imobi<span class="text-teal-500 font-semibold">Laravel</span>.
            </p>
        </div>

        <div class="text-xs font-semibold text-teal-600 bg-teal-50/50 px-3 py-2 rounded-xl border border-teal-100/50 self-start md:self-auto">
            Última atualização:
            <span class="font-mono font-bold">11/06/2026</span>
        </div>
    </div>

    <div class="bg-white rounded-3xl border border-slate-100 p-8 md:p-10 shadow-sm space-y-10">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">1</span>
                Aceitação dos Termos
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Ao utilizar a plataforma ImobiLaravel, o utilizador concorda integralmente com os presentes Termos de Serviço. Caso não concorde com alguma das disposições aqui descritas, deverá cessar imediatamente a utilização da aplicação.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">2</span>
                Finalidade da Plataforma
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                O ImobiLaravel destina-se à gestão de imóveis, clientes e contratos de venda, permitindo às agências imobiliárias centralizar informação operacional e acompanhar indicadores de desempenho comercial.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-4">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">3</span>
                Responsabilidades do Utilizador
            </h2>

            <div class="bg-slate-50 rounded-xl p-4 border border-slate-100">
                <ul class="text-sm text-slate-600 space-y-2 list-disc pl-5">
                    <li>Fornecer informações corretas e atualizadas.</li>
                    <li>Manter a confidencialidade das credenciais de acesso.</li>
                    <li>Utilizar a plataforma exclusivamente para fins legítimos.</li>
                    <li>Não realizar atividades que comprometam a segurança ou disponibilidade do sistema.</li>
                </ul>
            </div>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">4</span>
                Disponibilidade do Serviço
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Embora sejam aplicadas medidas para garantir a disponibilidade contínua da plataforma, poderão ocorrer interrupções temporárias devido a manutenção, atualizações técnicas ou circunstâncias imprevistas.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">5</span>
                Proteção de Dados
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Os dados introduzidos pelos utilizadores são tratados de acordo com as boas práticas de segurança e privacidade. A utilização da plataforma implica o tratamento dos dados necessários ao funcionamento normal das operações imobiliárias.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">6</span>
                Limitação de Responsabilidade
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                A equipa responsável pelo ImobiLaravel não poderá ser responsabilizada por perdas indiretas, interrupções de negócio ou danos resultantes da utilização inadequada da plataforma por parte dos utilizadores.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">7</span>
                Alterações aos Termos
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Os presentes Termos de Serviço poderão ser alterados a qualquer momento para refletir mudanças legais, técnicas ou operacionais. Recomenda-se a consulta periódica desta página.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">8</span>
                Contacto
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Para esclarecimentos relacionados com estes termos, os utilizadores poderão contactar a equipa de suporte através do endereço:
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
