@extends('layouts.app')

@section('title', 'Termos de Utilização - STANDAUTO')

@section('content')
    <header class="bg-white border-b border-neutral-200 py-6">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <h2 class="font-black text-2xl text-neutral-900 tracking-tight leading-tight">
                Termos de Utilização
            </h2>
            <p class="text-xs text-neutral-500 mt-0.5">Última atualização: {{ date('d/m/Y') }}</p>
        </div>
    </header>

    <main class="py-12">
        <div class="max-w-3xl mx-auto px-4 sm:px-6 lg:px-8 bg-white p-8 rounded-xl border border-neutral-200 shadow-sm space-y-8">

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">1. Aceitação dos Termos</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Ao aceder e utilizar a plataforma <span class="font-bold text-neutral-850">STANDAUTO</span>, o utilizador concorda expressamente em cumprir e respeitar os presentes Termos de Utilização. Se não concordar com qualquer uma das condições estabelecidas, não deverá utilizar o sistema.
                </p>
            </section>

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">2. Utilização do Serviço</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Esta aplicação destina-se à gestão interna do inventário de viaturas, registo de clientes e controlo de transações comerciais. O utilizador compromete-se a:
                </p>
                <ul class="list-disc pl-5 text-sm text-neutral-600 space-y-1">
                    <li>Introduzir dados verídicos e atualizados relativos a viaturas e clientes.</li>
                    <li>Não utilizar identidades falsas ou simular transações financeiras.</li>
                    <li>Garantir a confidencialidade dos seus dados de acesso ao painel de controlo.</li>
                </ul>
            </section>

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">3. Propriedade Intelectual</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Todo o conteúdo presente nesta plataforma — incluindo design, código-fonte, logótipos, textos e organização da base de dados — é propriedade exclusiva do <span class="font-bold text-neutral-850">STANDAUTO</span> e está protegido pela legislação nacional e internacional de direitos de autor.
                </p>
            </section>

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">4. Limitação de Responsabilidade</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    A plataforma é fornecida "tal como está". O <span class="font-bold text-neutral-850">STANDAUTO</span> não garante a total isenção de erros pontuais no sistema ou falhas de conectividade temporárias, comprometendo-se, contudo, a efetuar a manutenção necessária para mitigar qualquer impacto na operação diária do negócio.
                </p>
            </section>

            <hr class="border-neutral-200" />

            <section class="space-y-2">
                <h3 class="text-sm font-black uppercase text-neutral-900 tracking-wider">5. Contactos e Suporte</h3>
                <p class="text-sm text-neutral-600 leading-relaxed">
                    Se tiver qualquer dúvida ou necessitar de esclarecimentos adicionais sobre as condições de utilização da plataforma, poderá contactar a equipa de administração técnica através do email de suporte interno do stand.
                </p>
            </section>

        </div>
    </main>
@endsection
