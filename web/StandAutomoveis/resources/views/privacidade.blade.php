@extends('layouts.app')

@section('title', 'Política de Privacidade - STANDAUTO')

@section('content')
    <header class="bg-white border-b border-neutral-200 py-6">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <h2 class="font-black text-2xl text-neutral-900 tracking-tight leading-tight">
                Política de Privacidade
            </h2>
            <p class="text-xs text-neutral-500 mt-0.5">Última atualização: {{ date('d/m/Y') }}</p>
        </div>
    </header>

    <main class="py-12">
        <div class="max-w-3xl mx-auto px-4 sm:px-6 lg:px-8 bg-white p-8 rounded-xl border border-neutral-200 shadow-sm space-y-8">

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">1. Recolha de Dados</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    A nossa plataforma opera estritamente para a gestão interna do stand. Os únicos dados pessoais recolhidos são aqueles introduzidos manualmente na gestão de clientes, nomeadamente: **Nome**, **Contacto Telefónico**, **Email** e **NIF**, estritamente necessários para a emissão de contratos de venda.
                </p>
            </section>

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">2. Finalidade do Tratamento</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Os dados introduzidos no sistema são utilizados exclusivamente para:
                </p>
                <ul class="list-disc pl-5 text-sm text-neutral-600 space-y-1">
                    <li>Processamento e registo histórico de vendas de viaturas.</li>
                    <li>Contacto direto com o cliente para acompanhamento do processo de aquisição.</li>
                    <li>Emissão de faturas e cumprimento de obrigações legais do negócio.</li>
                </ul>
            </section>

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">3. Retenção e Segurança</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Os dados são armazenados de forma segura na nossa base de dados e são mantidos apenas durante o período legalmente exigido para efeitos fiscais e auditoria comercial. Implementamos medidas técnicas para prevenir o acesso não autorizado, alteração ou destruição dos registos.
                </p>
            </section>

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">4. Partilha de Informação</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    O <span class="font-bold text-neutral-850">STANDAUTO</span> não comercializa, aluga ou partilha qualquer dado de clientes com entidades terceiras para fins publicitários ou de marketing. A partilha de dados ocorre apenas quando estritamente exigido por autoridades judiciais ou fiscais competentes.
                </p>
            </section>

            <hr class="border-neutral-200" />

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">5. Direitos do Utilizador</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Em conformidade com a legislação de proteção de dados vigente (RGPD), o cliente ou administrador pode, a qualquer momento, solicitar a consulta, retificação ou atualização dos dados armazenados no sistema diretamente através do formulário de edição de clientes.
                </p>
            </section>

        </div>
    </main>
@endsection
