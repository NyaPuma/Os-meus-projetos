<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Fornecedores</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <div class="d-flex align-items-center gap-3">
                <a href="{{ url('/') }}" class="btn btn-outline-secondary btn-sm">
                    ← Início
                </a>
                <h1 class="mb-0">Listagem de fornecedores</h1>
            </div>

            <a href="{{ route('fornecedores.create') }}" class="btn btn-primary">
                Novo Fornecedor
            </a>
        </div>

        @if (session('success'))
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                {{ session('success') }}
                <button type="button" class="btn-close" data-bs-dismiss="alert">
                </button>
            </div>
        @endif

        <div class="p-3 mb-4 border rounded bg-light shadow-sm">
            <form action="{{ route('fornecedores.index') }}" method="GET">

                <div class="input-group mb-3">
                    <input type="text" name="search" id="search" class="form-control"
                        placeholder="Procurar por Nome, NIF ou Email..." value="{{ request('search') }}">

                    <button type="submit" class="btn btn-secondary">
                        Procurar
                    </button>

                    @if (request()->anyFilled(['search', 'estado', 'pais', 'order_by', 'direction']))
                        <a href="{{ route('fornecedores.index') }}" class="btn btn-outline-danger">
                            Limpar Filtros e Ordenação
                        </a>
                    @endif
                </div>

                <div class="row g-2">
                    <div class="col-sm-6 col-md-3">
                        <label for="estado" class="form-label small fw-bold text-muted mb-1">Estado</label>
                        <select name="estado" id="estado" class="form-select form-select-sm"
                            onchange="this.form.submit()">
                            <option value="">Todos os Estados</option>
                            <option value="ativo" {{ request('estado') == 'ativo' ? 'selected' : '' }}>Ativo</option>
                            <option value="inativo" {{ request('estado') == 'inativo' ? 'selected' : '' }}>Inativo
                            </option>
                        </select>
                    </div>

                    <div class="col-sm-6 col-md-3">
                        <label for="pais" class="form-label small fw-bold text-muted mb-1">País</label>
                        <select name="pais" id="pais" class="form-select form-select-sm"
                            onchange="this.form.submit()">
                            <option value="">Todos os Países</option>
                            <option value="PT" {{ request('pais') == 'PT' ? 'selected' : '' }}>Portugal</option>
                            <option value="OUT" {{ request('pais') == 'OUT' ? 'selected' : '' }}>Estrangeiro / Outro
                            </option>
                        </select>
                    </div>

                    <div class="col-sm-6 col-md-3">
                        <label for="order_by" class="form-label small fw-bold text-muted mb-1">Ordenar por</label>
                        <select name="order_by" id="order_by" class="form-select form-select-sm"
                            onchange="this.form.submit()">
                            <option value="id" {{ request('order_by') == 'id' ? 'selected' : '' }}>ID</option>
                            <option value="nome" {{ request('order_by', 'nome') == 'nome' ? 'selected' : '' }}>Nome
                            </option>
                            <option value="nif" {{ request('order_by') == 'nif' ? 'selected' : '' }}>NIF</option>
                            <option value="email" {{ request('order_by') == 'email' ? 'selected' : '' }}>Email
                            </option>
                            <option value="telefone" {{ request('order_by') == 'telefone' ? 'selected' : '' }}>Telefone
                            </option>
                            <option value="estado" {{ request('order_by') == 'estado' ? 'selected' : '' }}>Estado
                            </option>
                        </select>
                    </div>

                    <div class="col-sm-6 col-md-3">
                        <label for="direction" class="form-label small fw-bold text-muted mb-1">Direção</label>
                        <select name="direction" id="direction" class="form-select form-select-sm"
                            onchange="this.form.submit()">
                            <option value="asc" {{ request('direction', 'asc') == 'asc' ? 'selected' : '' }}>
                                Crescente (A-Z / 1-9)</option>
                            <option value="desc" {{ request('direction') == 'desc' ? 'selected' : '' }}>Decrescente
                                (Z-A / 9-1)</option>
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
                            <th>Nome</th>
                            <th>NIF</th>
                            <th>Email</th>
                            <th>Telefone</th>
                            <th>Estado</th>
                            <th width="260">Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        @forelse ($fornecedores as $fornecedor)
                            <tr>
                                <td>{{ $fornecedor->id }}</td>
                                <td>{{ $fornecedor->nome }}</td>
                                <td>{{ $fornecedor->nif }}</td>
                                <td>{{ $fornecedor->email }}</td>
                                <td>{{ $fornecedor->telefone }}</td>
                                <td>
                                    @if ($fornecedor->estado == 'ativo')
                                        <span class="badge bg-success">Ativo</span>
                                    @else
                                        <span class="badge bg-danger">Inativo</span>
                                    @endif
                                </td>
                                <td>
                                    <div class="d-flex gap-2">
                                        <a href="{{ route('fornecedores.show', $fornecedor->id) }}"
                                            class="btn btn-info btn-sm">
                                            Ver
                                        </a>
                                        <a href="{{ route('fornecedores.edit', $fornecedor->id) }}"
                                            class="btn btn-warning btn-sm">
                                            Editar
                                        </a>
                                        <form action="{{ route('fornecedores.destroy', $fornecedor->id) }}"
                                            method="POST">
                                            @csrf
                                            @method('DELETE')
                                            <button type="submit" class="btn btn-danger btn-sm"
                                                onclick="return confirm('Tem a certeza que deseja eliminar este fornecedor?')">
                                                Eliminar
                                            </button>
                                        </form>
                                    </div>
                                </td>
                            </tr>
                        @empty
                            <tr>
                                <td colspan="7" class="text-center">
                                    Nenhum fornecedor encontrado com os filtros aplicados.
                                </td>
                            </tr>
                        @endforelse
                    </tbody>
                </table>
                @if ($fornecedores->hasPages())
                    <div class="row align-items-center mt-4">
                        <div class="col-12 col-md-4 text-center text-md-start text-muted small mb-2 mb-md-0">
                            A mostrar {{ $fornecedores->firstItem() }} a {{ $fornecedores->lastItem() }} de
                            {{ $fornecedores->total() }} entradas
                        </div>

                        <div class="col-12 col-md-4 d-flex justify-content-center custom-pagination">
                            {{ $fornecedores->withQueryString()->links() }}
                        </div>

                        <div class="col-12 col-md-4"></div>
                    </div>

                    <style>
                        .custom-pagination p.text-muted {
                            display: none !important;
                            /* Esconde o texto nativo do Laravel */
                        }

                        .custom-pagination .justify-content-between {
                            justify-content: center !important;
                            /* Força os botões a ficarem no centro */
                        }
                    </style>
                @endif
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>

</html>
