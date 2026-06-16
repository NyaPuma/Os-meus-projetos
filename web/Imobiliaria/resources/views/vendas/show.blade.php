@extends('layouts.app')

@section('content')
<div class="space-y-6 max-w-5xl mx-auto">

    <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-4 rounded-2xl border border-slate-100 shadow-sm">
        <div>
            <a href="{{ route('vendas.index') }}" class="text-sm font-medium text-slate-600 hover:text-slate-900 flex items-center space-x-1 transition">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18"></path></svg>
                <span>Voltar ao histórico global</span>
            </a>
        </div>

        <div class="flex items-center space-x-2">
            <a href="{{ route('vendas.edit', $venda) }}" class="px-4 py-2 bg-teal-500 hover:bg-teal-600 text-white rounded-xl text-xs font-semibold transition flex items-center space-x-1.5 shadow-sm shadow-teal-100">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>
                <span>Modificar Valores / Notas</span>
            </a>

            <form action="{{ route('vendas.destroy', $venda) }}" method="POST" onsubmit="return confirm('ATENÇÃO: Ao anular esta venda, o apartamento associado voltará imediatamente ao estado de «Disponível». Deseja confirmar o estorno?')" class="inline m-0">
                @csrf
                @method('DELETE')
                <button type="submit" class="px-4 py-2 border border-rose-200 text-rose-600 hover:bg-rose-50 rounded-xl text-xs font-semibold transition flex items-center space-x-1.5">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path></svg>
                    <span>Anular Negócio</span>
                </button>
            </form>
        </div>
    </div>

    <div class="bg-slate-900 text-white rounded-3xl border border-slate-800 shadow-xl overflow-hidden relative">
        <div class="absolute -right-10 -bottom-10 text-slate-800 pointer-events-none opacity-20">
            <svg class="w-64 h-64" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="1" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path></svg>
        </div>

        <div class="p-6 md:p-8 space-y-6 relative">
            <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between border-b border-slate-800 pb-6 gap-4">
                <div>
                    <span class="bg-teal-500/10 text-teal-400 text-[10px] font-bold px-2.5 py-1 rounded-md uppercase tracking-wider border border-teal-500/20 inline-block mb-2">Contrato Imobiliário Fechado</span>
                    <h2 class="text-2xl font-black tracking-tight text-white">Relatório de Transação #VF-{{ str_pad($venda->id, 4, '0', STR_PAD_LEFT) }}</h2>
                </div>
                <div class="sm:text-right">
                    <p class="text-slate-400 text-xs uppercase tracking-wider font-semibold">Valor Registado em Escritura</p>
                    <p class="text-3xl font-black text-teal-400 mt-0.5">{{ number_format($venda->valor_venda, 2, ',', ' ') }} €</p>
                </div>
            </div>

            <div class="grid grid-cols-2 md:grid-cols-3 gap-6 text-sm">
                <div>
                    <span class="text-slate-400 block text-xs font-medium uppercase tracking-wider">Data da Assinatura</span>
                    <span class="text-slate-100 font-bold text-base mt-0.5 inline-block">{{ date('d \d\e F \d\e Y', strtotime($venda->data_venda)) }}</span>
                </div>
                <div>
                    <span class="text-slate-400 block text-xs font-medium uppercase tracking-wider">Diferença de Preço Comercial</span>
                    @php
                        $diferenca = $venda->valor_venda - $venda->apartamento->preco;
                    @endphp
                    @if($diferenca > 0)
                        <span class="text-emerald-400 font-bold text-base mt-0.5 inline-block">+{{ number_format($diferenca, 2, ',', ' ') }} € <span class="text-[10px] text-slate-400 font-normal">(Acima do Pedido)</span></span>
                    @elseif($diferenca < 0)
                        <span class="text-rose-400 font-bold text-base mt-0.5 inline-block">{{ number_format($diferenca, 2, ',', ' ') }} € <span class="text-[10px] text-slate-400 font-normal">(Desconto Concedido)</span></span>
                    @else
                        <span class="text-slate-300 font-bold text-base mt-0.5 inline-block">Preço Base Exato</span>
                    @endif
                </div>
            </div>

            @if($venda->observacoes)
                <div class="bg-slate-800/40 border border-slate-800 p-4 rounded-xl text-slate-300 text-sm leading-relaxed">
                    <span class="block font-bold text-xs text-slate-400 uppercase tracking-wider mb-1">Cláusulas e Observações da Agência:</span>
                    <p class="italic">"{{ $venda->observacoes }}"</p>
                </div>
            @endif
        </div>
    </div>

    <div class="grid grid-cols-1 md:grid-cols-2 gap-6 items-start">

        <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 space-y-4">
            <div class="flex items-center space-x-3 border-b border-slate-50 pb-4">
                <div class="w-10 h-10 bg-teal-50 text-teal-600 rounded-xl flex items-center justify-center font-bold text-sm uppercase shadow-inner">
                    {{ mb_substr($venda->cliente->nome, 0, 1) }}
                </div>
                <div>
                    <h3 class="font-bold text-slate-900 text-base leading-tight">Ficha do Comprador</h3>
                    <p class="text-slate-400 text-xs">Proprietário legal do imóvel.</p>
                </div>
            </div>

            <div class="space-y-2.5 text-sm">
                <div class="flex justify-between py-1 border-b border-slate-50/50">
                    <span class="text-slate-400 font-medium">Nome Completo:</span>
                    <span class="font-semibold text-slate-800">{{ $venda->cliente->nome }}</span>
                </div>
                <div class="flex justify-between py-1 border-b border-slate-50/50">
                    <span class="text-slate-400 font-medium">NIF Fiscal:</span>
                    <span class="font-mono font-semibold text-slate-700">{{ $venda->cliente->nif }}</span>
                </div>
                <div class="flex justify-between py-1 border-b border-slate-50/50">
                    <span class="text-slate-400 font-medium">Email:</span>
                    <span class="text-slate-600 font-medium">{{ $venda->cliente->email }}</span>
                </div>
                <div class="flex justify-between py-1">
                    <span class="text-slate-400 font-medium">Contacto Telefónico:</span>
                    <span class="text-slate-600 font-medium">{{ $venda->cliente->telefone }}</span>
                </div>
            </div>

            <div class="pt-2 text-right">
                <a href="{{ route('clientes.show', $venda->cliente_id) }}" class="text-xs font-bold text-teal-600 hover:text-teal-700 hover:underline inline-flex items-center space-x-1 transition">
                    <span>Ver Perfil Completo do Cliente</span>
                    <svg class="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path></svg>
                </a>
            </div>
        </div>

        <div class="bg-white rounded-2xl border border-slate-100 shadow-sm p-6 space-y-4">
            <div class="flex items-center space-x-3 border-b border-slate-50 pb-4">
                <div class="w-10 h-10 bg-slate-100 text-slate-700 rounded-xl flex items-center justify-center font-bold text-xs uppercase shadow-inner">
                    {{ $venda->apartamento->tipologia }}
                </div>
                <div>
                    <h3 class="font-bold text-slate-900 text-base leading-tight">Especificações do Imóvel</h3>
                    <p class="text-slate-400 text-xs">Ficha técnica e registo comercial.</p>
                </div>
            </div>

            <div class="flex gap-4 items-center bg-slate-50/75 border border-slate-100 p-3 rounded-xl">
                <div class="w-16 h-12 rounded-lg bg-slate-200 overflow-hidden flex-shrink-0 shadow-inner">
                    @if($venda->apartamento->fotografia)
                        <img src="{{ asset('storage/' . $venda->apartamento->fotografia) }}" alt="Foto" class="w-full h-full object-cover">
                    @else
                        <div class="w-full h-full flex items-center justify-center text-[9px] font-bold text-slate-400 uppercase tracking-tight">Sem Foto</div>
                    @endif
                </div>
                <div>
                    <span class="font-bold text-slate-900 text-sm block">Referência: {{ $venda->apartamento->referencia }}</span>
                    <span class="text-slate-400 text-xs font-medium block mt-0.5">Área Útil: {{ $venda->apartamento->area }} m²</span>
                </div>
            </div>

            <div class="space-y-2 text-sm pt-1">
                <div>
                    <span class="text-slate-400 font-medium block text-xs uppercase tracking-wider">Morada de Registo:</span>
                    <span class="text-slate-700 font-medium text-xs block leading-relaxed mt-0.5">{{ $venda->apartamento->morada }}</span>
                </div>
                <div class="flex justify-between items-center pt-2 border-t border-slate-50 mt-2">
                    <span class="text-slate-400 font-medium text-xs uppercase">Preço Inicial de Catálogo:</span>
                    <span class="font-bold text-slate-600 text-sm">{{ number_format($venda->apartamento->preco, 2, ',', ' ') }} €</span>
                </div>
            </div>

            <div class="pt-2 text-right">
                <a href="{{ route('apartamentos.show', $venda->apartamento_id) }}" class="text-xs font-bold text-teal-600 hover:text-teal-700 hover:underline inline-flex items-center space-x-1 transition">
                    <span>Ver Catálogo do Apartamento</span>
                    <svg class="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path></svg>
                </a>
            </div>
        </div>

    </div>
</div>
@endsection
