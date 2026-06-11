<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Clientes</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <div class="d-flex align-items-center gap-3">
                <a href="{{ url('/') }}" class="btn btn-outline-secondary btn-sm">
                    ← Início
                </a>
                <h1 class="mb-0">Listagem de clientes</h1>
            </div>

            <a href="{{ route('clientes.create') }}" class="btn btn-primary">
                Novo Cliente
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
            <form action="{{ route('clientes.index') }}" method="GET">

                <div class="input-group mb-3">
                    <input type="text" name="search" id="search" class="form-control"
                        placeholder="Procurar por Nome, Email, NIF..." value="{{ request('search') }}">

                    <button type="submit" class="btn btn-secondary">
                        Procurar
                    </button>

                    @if (request()->anyFilled(['search', 'order_by', 'direction']))
                        <a href="{{ route('clientes.index') }}" class="btn btn-outline-danger">
                            Limpar Filtros e Ordenação
                        </a>
                    @endif
                </div>

                <div class="row g-2">
                    <div class="col-sm-6">
                        <label for="order_by" class="form-label small fw-bold text-muted mb-1">Ordenar por</label>
                        <select name="order_by" id="order_by" class="form-select form-select-sm"
                            onchange="this.form.submit()">
                            <option value="id" {{ request('order_by') == 'id' ? 'selected' : '' }}>ID</option>
                            <option value="nome" {{ request('order_by', 'nome') == 'nome' ? 'selected' : '' }}>Nome
                            </option>
                            <option value="nif" {{ request('order_by') == 'nif' ? 'selected' : '' }}>NIF</option>
                            <option value="email" {{ request('order_by') == 'email' ? 'selected' : '' }}>Email</option>
                            <option value="telefone" {{ request('order_by') == 'telefone' ? 'selected' : '' }}>Telefone
                            </option>
                            <option value="estado" {{ request('order_by') == 'estado' ? 'selected' : '' }}>Estado
                            </option>
                        </select>
                    </div>

                    <div class="col-sm-6">
                        <label for="direction" class="form-label small fw-bold text-muted mb-1">Direção</label>
                        <select name="direction" id="direction" class="form-select form-select-sm"
                            onchange="this.form.submit()">
                            <option value="asc" {{ request('direction', 'asc') == 'asc' ? 'selected' : '' }}>
                                Crescente (A-Z / Menor ID)</option>
                            <option value="desc" {{ request('direction') == 'desc' ? 'selected' : '' }}>Decrescente
                                (Z-A / Maior ID)</option>
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
                            <th>País</th>
                            <th>Estado</th>
                            <th width="240">Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        @forelse ($clientes as $cliente)
                            <tr>
                                <td>{{ $cliente->id }}</td>
                                <td>{{ $cliente->nome }}</td>
                                <td>{{ $cliente->nif ?? '---' }}</td>
                                <td>{{ $cliente->email }}</td>
                                <td>{{ $cliente->telefone }}</td>
                                <td>{{ $cliente->pais ?? 'PT' }}</td>
                                <td>
                                    @if (($cliente->estado ?? 'ativo') == 'ativo')
                                        <span class="badge bg-success">Ativo</span>
                                    @else
                                        <span class="badge bg-danger">Inativo</span>
                                    @endif
                                </td>
                                <td>
                                    <div class="d-flex gap-2">
                                        <a href="{{ route('clientes.show', $cliente->id) }}"
                                            class="btn btn-info btn-sm">Ver</a>
                                        <a href="{{ route('clientes.edit', $cliente->id) }}"
                                            class="btn btn-warning btn-sm">Editar</a>
                                        <form action="{{ route('clientes.destroy', $cliente->id) }}" method="POST">
                                            @csrf
                                            @method('DELETE')
                                            <button type="submit" class="btn btn-danger btn-sm"
                                                onclick="return confirm('Tem a certeza que deseja eliminar este cliente?')">
                                                Eliminar
                                            </button>
                                        </form>
                                    </div>
                                </td>
                            </tr>
                        @empty
                            <tr>
                                <td colspan="8" class="text-center"> Nenhum cliente encontrado com os critérios
                                    aplicados.
                                </td>
                            </tr>
                        @endforelse
                    </tbody>
                </table>
                @if ($clientes->hasPages())
                    <div class="row align-items-center mt-4">
                        <div class="col-12 col-md-4 text-center text-md-start text-muted small mb-2 mb-md-0">
                            A mostrar {{ $clientes->firstItem() }} a {{ $clientes->lastItem() }} de
                            {{ $clientes->total() }} entradas
                        </div>

                        <div class="col-12 col-md-4 d-flex justify-content-center custom-pagination">
                            {{ $clientes->withQueryString()->links() }}
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
