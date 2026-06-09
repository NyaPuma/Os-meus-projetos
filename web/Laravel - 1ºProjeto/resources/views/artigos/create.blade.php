<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Novo Artigo</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>

<div class="container mt-5">

    {{-- HEADER --}}
    <div class="d-flex justify-content-between align-items-center mb-4">
        <div class="d-flex align-items-center gap-3">
            <a href="{{ route('artigos.index') }}" class="btn btn-outline-secondary btn-sm">
                ← Voltar
            </a>
            <h1 class="mb-0">Novo artigo</h1>
        </div>
    </div>

    {{-- CARD --}}
    <div class="card shadow">
        <div class="card-body">

            <form action="{{ route('artigos.store') }}" method="POST" enctype="multipart/form-data">

                @csrf

                {{-- DESCRIÇÃO + PREÇO --}}
                <div class="row">

                    <div class="col-md-8 mb-3">
                        <label class="form-label">Descrição</label>
                        <input type="text" name="descricao" class="form-control" required>
                    </div>

                    <div class="col-md-4 mb-3">
                        <label class="form-label">Preço</label>
                        <input type="number" min="0" step="0.01" name="preco" class="form-control">
                    </div>

                </div>

                {{-- CARACTERÍSTICAS --}}
                <div class="mb-3">
                    <label class="form-label">Características</label>
                    <textarea class="form-control" name="caracteristicas" rows="3"></textarea>
                </div>

                {{-- CATEGORIA --}}
                <div class="mb-3">
                    <label class="form-label">Categoria</label>

                    <select name="categoria_id" class="form-select" required>

                        <option value="">Selecione uma categoria</option>

                        @forelse($categorias as $categoria)
                            <option value="{{ $categoria->id }}">
                                {{ $categoria->categoria }}
                            </option>
                        @empty
                            <option disabled>
                                Nenhuma categoria encontrada
                            </option>
                        @endforelse

                    </select>
                </div>

                {{-- FOTO --}}
                <div class="mb-3">
                    <label class="form-label">Foto</label>
                    <input type="file" class="form-control" name="foto" accept=".jpg,.jpeg,.png">
                </div>

                <hr>

                {{-- BOTÕES --}}
                <div class="d-flex gap-2">
                    <button type="submit" class="btn btn-success">
                        Guardar artigo
                    </button>

                    <a href="{{ route('artigos.index') }}" class="btn btn-secondary">
                        Cancelar
                    </a>
                </div>

            </form>

        </div>
    </div>

</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>

</html>
