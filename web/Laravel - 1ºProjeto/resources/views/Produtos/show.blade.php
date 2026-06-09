<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Detalhes do Produto</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>

    <div class="container mt-5">
        <div class="card shadow">
            <div class="card-header">
                <h3 class="mb-0">Detalhes do produto</h3>
            </div>
            <div class="card-body">

                <div class="row mb-3">
                    <div class="col-md-4">
                        <strong>ID:</strong> {{ $produto->id }}
                    </div>
                    <div class="col-md-4">
                        <strong>Referência / SKU:</strong> <span
                            class="text-secondary fw-bold">{{ $produto->referencia }}</span>
                    </div>
                    <div class="col-md-4">
                        <strong>Estado de Venda:</strong>
                        @if ($produto->estado == 'ativo')
                            <span class="badge bg-success">Disponível</span>
                        @else
                            <span class="badge bg-danger">Indisponível / Descontinuado</span>
                        @endif
                    </div>
                </div>

                <hr>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <strong>Nome do Produto:</strong> {{ $produto->nome }}
                    </div>
                    <div class="col-md-6">
                        <strong>Código de Barras (EAN):</strong> {{ $produto->codigo_barras ?? 'Não definido' }}
                    </div>
                </div>

                <hr>

                <h5 class="text-primary mb-3">Informações Comerciais</h5>
                <div class="row mb-3">
                    <div class="col-md-3">
                        <strong>Preço de Custo:</strong> {{ number_format($produto->preco_custo, 2, ',', '.') }} €
                    </div>
                    <div class="col-md-3">
                        <strong>Preço de Venda:</strong> {{ number_format($produto->preco_venda, 2, ',', '.') }} €
                    </div>
                    <div class="col-md-3">
                        <strong>Portes de Envio:</strong>
                        @if ($produto->portes_envio > 0)
                            {{ number_format($produto->portes_envio, 2, ',', '.') }} €
                        @else
                            <span
                                class="badge bg-success-subtle text-success border border-success-subtle">Grátis</span>
                        @endif
                    </div>
                    <div class="col-md-3">
                        <strong>Taxa de IVA:</strong> {{ $produto->taxa_iva }}%
                    </div>
                </div>

                @php
                    // O lucro agora abate o preço de custo e também os portes de envio
                    $lucro = $produto->preco_venda - $produto->preco_custo - $produto->portes_envio;
                @endphp
                <div class="row mb-3">
                    <div class="col-md-4">
                        <strong>Margem de Lucro Estimada:</strong>
                        <span class="{{ $lucro > 0 ? 'text-success' : 'text-danger' }} fw-bold">
                            {{ number_format($lucro, 2, ',', '.') }} €
                        </span>
                    </div>
                </div>

                <hr>

                <h5 class="text-primary mb-3">Gestão de Inventário</h5>
                <div class="row mb-3">
                    <div class="col-md-4">
                        options<strong>Stock Atual:</strong>
                        @if ($produto->stock_atual <= $produto->stock_minimo)
                            <span class="badge bg-danger fs-6">{{ $produto->stock_atual }} (Abaixo do Mínimo)</span>
                        @else
                            <span class="badge bg-secondary fs-6">{{ $produto->stock_atual }}</span>
                        @endif
                    </div>
                    <div class="col-md-4">
                        <strong>Stock Mínimo (Alerta):</strong> {{ $produto->stock_minimo }}
                    </div>
                </div>

                <hr>

                <div class="mb-4">
                    <strong>Descrição do Produto:</strong>
                    <div class="border rounded p-3 mt-2 bg-light">
                        {{ $produto->descricao ?? 'Sem descrição registada para este produto.' }}
                    </div>
                </div>

                <div class="d-flex gap-2 align-items-center">
                    <a href="{{ route('produtos.index') }}" class="btn btn-secondary">
                        Voltar
                    </a>
                    <a href="{{ route('produtos.edit', $produto->id) }}" class="btn btn-warning">
                        Editar
                    </a>
                    <form action="{{ route('produtos.destroy', $produto->id) }}" method="POST" class="m-0">
                        @csrf
                        @method('DELETE')
                        <button type="submit" class="btn btn-danger"
                            onclick="return confirm('Tem a certeza que deseja eliminar este produto definitivamente?')">
                            Eliminar
                        </button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>

</html>
