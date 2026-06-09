<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Artigos</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>

<div class="container mt-5">

    {{-- HEADER --}}
    <div class="d-flex justify-content-between align-items-center mb-4">
        <div class="d-flex align-items-center gap-3">
            <a href="{{ url('/') }}" class="btn btn-outline-secondary btn-sm">
                ← Início
            </a>
            <h1 class="mb-0">Listagem de artigos</h1>
        </div>

        <a href="{{ route('artigos.create') }}" class="btn btn-primary">
            Novo Artigo
        </a>
    </div>

    {{-- SUCCESS MESSAGE --}}
    @if (session('success'))
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            {{ session('success') }}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    @endif

    {{-- FILTERS --}}
    <div class="p-3 mb-4 border rounded bg-light shadow-sm">
        <form action="{{ route('artigos.index') }}" method="GET">

            <div class="input-group mb-3">
                <input type="text"
                       name="search"
                       class="form-control"
                       placeholder="Pesquisar descrição ou características..."
                       value="{{ request('search') }}">

                <button type="submit" class="btn btn-secondary">
                    Procurar
                </button>

                @if(request()->anyFilled(['search', 'order_by', 'direction']))
                    <a href="{{ route('artigos.index') }}" class="btn btn-outline-danger">
                        Limpar Filtros
                    </a>
                @endif
            </div>

            <div class="row g-2">

                {{-- ORDER BY --}}
                <div class="col-sm-6">
                    <label class="form-label small fw-bold text-muted mb-1">Ordenar por</label>

                    <select name="order_by" class="form-select form-select-sm" onchange="this.form.submit()">

                        <option value="id" {{ request('order_by') == 'id' ? 'selected' : '' }}>
                            ID
                        </option>

                        <option value="descricao" {{ request('order_by', 'descricao') == 'descricao' ? 'selected' : '' }}>
                            Descrição
                        </option>

                        <option value="preco" {{ request('order_by') == 'preco' ? 'selected' : '' }}>
                            Preço
                        </option>

                        {{-- CATEGORIA (SUBSTITUI DATA) --}}
                        <option value="categoria" {{ request('order_by') == 'categoria' ? 'selected' : '' }}>
                            Categoria
                        </option>

                    </select>
                </div>

                {{-- DIREÇÃO --}}
                <div class="col-sm-6">
                    <label class="form-label small fw-bold text-muted mb-1">Direção</label>

                    <select name="direction" class="form-select form-select-sm" onchange="this.form.submit()">
                        <option value="asc" {{ request('direction', 'asc') == 'asc' ? 'selected' : '' }}>
                            Crescente
                        </option>

                        <option value="desc" {{ request('direction') == 'desc' ? 'selected' : '' }}>
                            Decrescente
                        </option>
                    </select>
                </div>

            </div>
        </form>
    </div>

    {{-- TABLE --}}
    <div class="card shadow">
        <div class="card-body">

            <table class="table table-striped table-hover table-bordered align-middle mb-0">

                <thead class="table-dark">
                    <tr>
                        <th>ID</th>
                        <th>Descrição</th>
                        <th>Características</th>
                        <th>Preço</th>
                        <th>Categoria</th>
                        <th>Foto</th>
                        <th width="200">Ações</th>
                    </tr>
                </thead>

                <tbody>
                    @forelse ($artigos as $artigo)
                        <tr>
                            <td>{{ $artigo->id }}</td>
                            <td>{{ $artigo->descricao }}</td>
                            <td>{{ $artigo->caracteristicas ?? '---' }}</td>
                            <td>{{ number_format($artigo->preco, 2, ',', '.') }} €</td>

                            {{-- CATEGORIA --}}
                            <td>
                                {{ $artigo->categoria->categoria ?? '---' }}
                            </td>

                            {{-- FOTO --}}
                            <td>
                                @if($artigo->foto)
                                    <img src="{{ asset('storage/' . $artigo->foto) }}"
                                         width="60"
                                         height="60"
                                         style="object-fit: cover;"
                                         class="rounded">
                                @else
                                    ---
                                @endif
                            </td>

                            <td>
                                <div class="d-flex gap-2">
                                    <a href="{{ route('artigos.show', $artigo->id) }}"
                                       class="btn btn-info btn-sm">
                                        Ver
                                    </a>

                                    <a href="{{ route('artigos.edit', $artigo->id) }}"
                                       class="btn btn-warning btn-sm">
                                        Editar
                                    </a>

                                    <form action="{{ route('artigos.destroy', $artigo->id) }}"
                                          method="POST">
                                        @csrf
                                        @method('DELETE')

                                        <button type="submit"
                                                class="btn btn-danger btn-sm"
                                                onclick="return confirm('Tem a certeza que deseja eliminar este artigo?')">
                                            Eliminar
                                        </button>
                                    </form>
                                </div>
                            </td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="7" class="text-center">
                                Nenhum artigo encontrado com os critérios aplicados.
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
