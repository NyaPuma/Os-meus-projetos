@extends('layouts.app')

@section('content')
<div class="space-y-8 max-w-5xl mx-auto">

    <div class="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm flex flex-col md:flex-row md:items-center md:justify-between gap-4">
        <div>
            <h1 class="text-2xl font-black text-slate-900 tracking-tight">
                Política de Privacidade
            </h1>
            <p class="text-slate-500 text-sm mt-0.5">
                Como os dados são recolhidos, utilizados e protegidos na plataforma Imobi<span class="text-teal-500 font-semibold">Laravel</span>.
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
                Introdução
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                A presente Política de Privacidade descreve a forma como o ImobiLaravel recolhe, utiliza, armazena e protege os dados pessoais dos seus utilizadores.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">2</span>
                Dados Recolhidos
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Durante a utilização da plataforma poderão ser recolhidos dados necessários ao funcionamento do sistema, incluindo:
            </p>

            <div class="bg-slate-50 rounded-xl p-4 border border-slate-100">
                <ul class="text-sm text-slate-600 space-y-2 list-disc pl-5">
                    <li>Nome completo;</li>
                    <li>Endereço de correio eletrónico;</li>
                    <li>Número de telemóvel;</li>
                    <li>NIF;</li>
                    <li>Informação relacionada com imóveis e contratos de venda.</li>
                </ul>
            </div>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">3</span>
                Finalidade da Utilização dos Dados
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Os dados recolhidos são utilizados exclusivamente para garantir o correto funcionamento da plataforma, gestão de imóveis, gestão de clientes, registo de vendas e produção de relatórios operacionais.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">4</span>
                Conservação dos Dados
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Os dados são conservados apenas durante o período necessário para cumprir obrigações legais, fiscais e operacionais relacionadas com a atividade imobiliária.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">5</span>
                Segurança da Informação
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                São aplicadas medidas técnicas e organizacionais adequadas para proteger os dados contra acesso não autorizado, alteração indevida, perda ou divulgação não autorizada.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">6</span>
                Direitos dos Utilizadores
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Os utilizadores têm o direito de solicitar acesso, retificação, atualização ou eliminação dos seus dados pessoais, nos termos da legislação aplicável.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">7</span>
                Partilha de Dados
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                O ImobiLaravel não comercializa nem partilha dados pessoais com terceiros, salvo quando tal seja exigido por obrigação legal ou autoridade competente.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">8</span>
                Alterações à Política
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Esta Política de Privacidade poderá ser atualizada periodicamente para refletir alterações legais ou operacionais. Recomenda-se a consulta regular desta página.
            </p>
        </section>

        <hr class="border-slate-100">

        <section class="space-y-3">
            <h2 class="text-lg font-bold text-slate-900 flex items-center gap-2">
                <span class="flex items-center justify-center w-6 h-6 rounded-lg bg-slate-900 text-white text-xs font-mono">9</span>
                Contacto
            </h2>

            <p class="text-sm text-slate-600 leading-relaxed">
                Para qualquer questão relacionada com privacidade ou proteção de dados, contacte:
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
