<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Produtos</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <div class="d-flex align-items-center gap-3">
                <a href="{{ url('/') }}" class="btn btn-outline-secondary btn-sm">
                    ← Início
                </a>
                <h1 class="mb-0">Listagem de produtos</h1>
            </div>

            <a href="{{ route('produtos.create') }}" class="btn btn-primary">
                Novo Produto
            </a>
        </div>

        @if (session('success'))
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                {{ session('success') }}
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
        @endif

        <div class="p-3 mb-4 border rounded bg-light shadow-sm">
            <form action="{{ route('produtos.index') }}" method="GET">

                <div class="input-group mb-3">
                    <input type="text"
                           name="search"
                           id="search"
                           class="form-control"
                           placeholder="Procurar por Nome, Referência ou Código de Barras..."
                           value="{{ request('search') }}">

                    <button type="submit" class="btn btn-secondary">
                        Procurar
                    </button>

                    @if(request()->anyFilled(['search', 'estado', 'stock_status', 'order_by', 'direction']))
                        <a href="{{ route('produtos.index') }}" class="btn btn-outline-danger">
                            Limpar Filtros e Ordenação
                        </a>
                    @endif
                </div>

                <div class="row g-2">
                    <div class="col-sm-6 col-md-3">
                        <label for="estado" class="form-label small fw-bold text-muted mb-1">Estado</label>
                        <select name="estado" id="estado" class="form-select form-select-sm" onchange="this.form.submit()">
                            <option value="">Todos os Estados</option>
                            <option value="ativo" {{ request('estado') == 'ativo' ? 'selected' : '' }}>Disponível</option>
                            <option value="inativo" {{ request('estado') == 'inativo' ? 'selected' : '' }}>Indisponível</option>
                        </select>
                    </div>

                    <div class="col-sm-6 col-md-3">
                        <label for="stock_status" class="form-label small fw-bold text-muted mb-1">Alertas de Stock</label>
                        <select name="stock_status" id="stock_status" class="form-select form-select-sm" onchange="this.form.submit()">
                            <option value="">Todos os Níveis</option>
                            <option value="com_stock" {{ request('stock_status') == 'com_stock' ? 'selected' : '' }}>Com Stock</option>
                            <option value="alerta" {{ request('stock_status') == 'alerta' ? 'selected' : '' }}>Stock Crítico / Mínimo</option>
                        </select>
                    </div>

                    <div class="col-sm-6 col-md-3">
                        <label for="order_by" class="form-label small fw-bold text-muted mb-1">Ordenar por</label>
                        <select name="order_by" id="order_by" class="form-select form-select-sm" onchange="this.form.submit()">
                            <option value="id" {{ request('order_by') == 'id' ? 'selected' : '' }}>ID</option>
                            <option value="nome" {{ request('order_by', 'nome') == 'nome' ? 'selected' : '' }}>Nome</option>
                            <option value="referencia" {{ request('order_by') == 'referencia' ? 'selected' : '' }}>Referência</option>
                            <option value="preco_venda" {{ request('order_by') == 'preco_venda' ? 'selected' : '' }}>Preço de Venda</option>
                            <option value="portes_envio" {{ request('order_by') == 'portes_envio' ? 'selected' : '' }}>Portes de Envio</option>
                            <option value="stock_atual" {{ request('order_by') == 'stock_atual' ? 'selected' : '' }}>Quantidade em Stock</option>
                            <option value="estado" {{ request('order_by') == 'estado' ? 'selected' : '' }}>Estado</option>
                        </select>
                    </div>

                    <div class="col-sm-6 col-md-3">
                        <label for="direction" class="form-label small fw-bold text-muted mb-1">Direção</label>
                        <select name="direction" id="direction" class="form-select form-select-sm" onchange="this.form.submit()">
                            <option value="asc" {{ request('direction', 'asc') == 'asc' ? 'selected' : '' }}>Crescente (A-Z / 1-9)</option>
                            <option value="desc" {{ request('direction') == 'desc' ? 'selected' : '' }}>Decrescente (Z-A / 9-1)</option>
                        </select>
                    </div>
                </div>

            </form>
        </div>

        <div class="card shadow">
            <div class="card-body">
                <table class="table table-striped table-hover table-bordered align-middle mb-0">
                    <thead class="table-dark">
                        <tr>
                            <th>ID</th>
                            <th>Referência</th>
                            <th>Nome do Produto</th>
                            <th>Preço Venda</th>
                            <th>Portes</th>
                            <th>IVA</th>
                            <th>Stock</th>
                            <th>Estado</th>
                            <th width="240">Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        @forelse ($produtos as $produto)
                            <tr>
                                <td>{{ $produto->id }}</td>
                                <td class="fw-bold text-secondary">{{ $produto->referencia }}</td>
                                <td>{{ $produto->nome }}</td>
                                <td>{{ number_format($produto->preco_venda, 2, ',', '.') }} €</td>
                                <td>
                                    @if ($produto->portes_envio > 0)
                                        {{ number_format($produto->portes_envio, 2, ',', '.') }} €
                                    @else
                                        <span class="badge bg-success-subtle text-success border border-success-subtle">Grátis</span>
                                    @endif
                                </td>
                                <td>{{ $produto->taxa_iva }}%</td>
                                <td>
                                    @if ($produto->stock_atual <= $produto->stock_minimo)
                                        <span class="badge bg-danger text-wrap" style="min-width: 50px;">
                                            {{ $produto->stock_atual }} (Crítico)
                                        </span>
                                    @else
                                        <span class="badge bg-secondary text-wrap" style="min-width: 50px;">
                                            {{ $produto->stock_atual }}
                                        </span>
                                    @endif
                                </td>
                                <td>
                                    @if ($produto->estado == 'ativo')
                                        <span class="badge bg-success">Disponível</span>
                                    @else
                                        <span class="badge bg-danger">Indisponível</span>
                                    @endif
                                </td>
                                <td>
                                    <div class="d-flex gap-2 align-items-center">
                                        <a href="{{ route('produtos.show', $produto->id) }}" class="btn btn-info btn-sm">
                                            Ver
                                        </a>
                                        <a href="{{ route('produtos.edit', $produto->id) }}" class="btn btn-warning btn-sm">
                                            Editar
                                        </a>
                                        <form action="{{ route('produtos.destroy', $produto->id) }}" method="POST" class="m-0">
                                            @csrf
                                            @method('DELETE')
                                            <button type="submit" class="btn btn-danger btn-sm"
                                                    onclick="return confirm('Tem a certeza que deseja eliminar este produto definitivamente?')">
                                                Eliminar
                                            </button>
                                        </form>
                                    </div>
                                </td>
                            </tr>
                        @empty
                            <tr>
                                <td colspan="9" class="text-center py-3 text-muted">
                                    Nenhum produto encontrado com os filtros aplicados.
                                </td>
                            </tr>
                        @endforelse
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>

</html>
